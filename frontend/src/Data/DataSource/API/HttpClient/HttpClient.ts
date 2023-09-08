import {
  BaseRequestParam,
  Header,
  RequestInterceptor,
  RequestWithBody,
  RequestWithBodyAndParam,
  RequestWithParam,
  TypedResponse,
} from "./types";

export interface IHttpClient {
  baseUrl?: string;
  globalHeaders?: Header;
  requestInterceptor?: (request: RequestInterceptor) => RequestInterceptor;
  responseInterceptor?: <T>(
    response: Promise<TypedResponse<T>>
  ) => Promise<TypedResponse<T>>;

  baseRequest<TBody extends BodyInit, TResponse>(
    params: BaseRequestParam<TBody>
  ): Promise<TypedResponse<TResponse>>;
  get<TQuery extends object, TResponse>(
    params: RequestWithParam<TQuery>
  ): Promise<TypedResponse<TResponse>>;
  post<TBody extends BodyInit, TResponse>(
    params: RequestWithBody<TBody>
  ): Promise<TypedResponse<TResponse>>;
  path<TBody extends BodyInit, TResponse>(
    params: RequestWithBody<TBody>
  ): Promise<TypedResponse<TResponse>>;
  put<TBody extends BodyInit, TQuery extends object, TResponse>(
    params: RequestWithBodyAndParam<TBody, TQuery>
  ): Promise<TypedResponse<TResponse>>;
  delete<TQuery extends object, TResponse>(
    params: RequestWithParam<TQuery>
  ): Promise<TypedResponse<TResponse>>;

  objectToQueryParams<TQuery extends object>(query: TQuery): string;
}

export class HttpClient implements IHttpClient {
  baseUrl?: string | undefined;
  globalHeaders?: Header | undefined;
  requestInterceptor?: (request: RequestInterceptor) => RequestInterceptor;
  responseInterceptor?: <T>(
    response: Promise<TypedResponse<T>>
  ) => Promise<TypedResponse<T>>;

  get gHeaders(): Header {
    return this.globalHeaders ?? {};
  }

  constructor(
    baseUrl?: string | undefined,
    globalHeaders?: Header | undefined
  ) {
    this.baseUrl = baseUrl;
    this.globalHeaders = { ...globalHeaders };
  }
  objectToQueryParams<TQuery extends object>(query: TQuery): string {
    return Object.entries(query)
      .reduce(
        (acc: string[], [key, value]) => [
          `${key}=${typeof value === "string" ? value : JSON.stringify(value)}`,
          ...acc,
        ],
        []
      )
      .join("&");
  }

  baseRequest<TBody extends BodyInit, TResponse>(
    params: BaseRequestParam<TBody>
  ): Promise<TypedResponse<TResponse>> {
    const { method, url, body, headers: localHead } = params;
    if (!this.baseUrl && !url)
      throw new Error("Unable to perform a query on an undefined url");
    let route = url ?? this.baseUrl ?? "";
    const httpRegex = /^https?:\/\/.*/i;
    if (url && !httpRegex.test(url)) route = this.baseUrl + url;
    const head = localHead ?? {};
    const headers = { ...this.gHeaders, ...head };
    let request: RequestInterceptor = {
      url: route,
      options: {
        method,
        headers,
        body,
      },
    };
    if (this.requestInterceptor) request = this.requestInterceptor(request);
    let response = fetch(request.url ?? "", {
      method: request.options?.method ?? "GET",
      headers: request.options ? { ...request.options.headers } : {},
      body: request.options?.body,
    });
    if (this.responseInterceptor) response = this.responseInterceptor(response);
    return response;
  }

  get<TQuery extends object, TResponse>(
    params: RequestWithParam<TQuery>
  ): Promise<TypedResponse<TResponse>> {
    const { headers, query } = params;
    let url = params.url;
    if (query) url += `?${this.objectToQueryParams(query)}`;

    return this.baseRequest({
      url,
      method: "GET",
      headers,
    });
  }
  post<TBody extends BodyInit, TResponse>(
    params: RequestWithBody<TBody>
  ): Promise<TypedResponse<TResponse>> {
    const { url, body, headers } = params;
    return this.baseRequest({
      url,
      method: "POST",
      headers,
      body,
    });
  }
  path<TBody extends BodyInit, TResponse>(
    params: RequestWithBody<TBody>
  ): Promise<TypedResponse<TResponse>> {
    const { url, body, headers } = params;
    return this.baseRequest({
      url,
      method: "PATH",
      headers,
      body,
    });
  }
  put<TBody extends BodyInit, TQuery extends object, TResponse>(
    params: RequestWithBodyAndParam<TBody, TQuery>
  ): Promise<TypedResponse<TResponse>> {
    const { url, body, headers } = params;
    return this.baseRequest({
      url,
      method: "PUT",
      headers,
      body,
    });
  }
  delete<TQuery extends object, TResponse>(
    params: RequestWithParam<TQuery>
  ): Promise<TypedResponse<TResponse>> {
    const { headers, query } = params;
    let url = params.url;
    if (query) url += `?${this.objectToQueryParams(query)}`;

    return this.baseRequest({
      url,
      method: "DELETE",
      headers,
    });
  }
}
