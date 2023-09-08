export interface TypedResponse<T = any> extends Response {
  json<P = T>(): Promise<P>;
}

export type Header = { [prop: string]: any };

export interface BaseRequestProps {
  url?: string;
  headers?: Header;
}

export interface RequestBodyProps<T extends BodyInit> {
  body: T;
}

export interface RequestNullableBodyProps<T extends BodyInit> {
  body?: T;
}
export interface RequestQueryProps<T extends object> {
  query?: T;
}
export type RequestMethods = "GET" | "POST" | "PUT" | "DELETE" | "PATH";

export type RequestInterceptorOptions = {
  method?: RequestMethods;
  headers?: Header;
  body?: BodyInit;
};

export type RequestInterceptor = {
  url?: string;
  options?: RequestInterceptorOptions;
};

type BaseRequestParamType = BaseRequestProps & { method: RequestMethods };
export interface BaseRequestParam<TBody extends BodyInit>
  extends BaseRequestParamType,
    RequestNullableBodyProps<TBody> {}

export interface RequestWithParam<TQuery extends object>
  extends RequestQueryProps<TQuery>,
    BaseRequestProps {}

export interface RequestWithBody<TBody extends BodyInit>
  extends RequestBodyProps<TBody>,
    BaseRequestProps {}

export interface RequestWithBodyAndParam<
  TBody extends BodyInit,
  TQuery extends object
> extends RequestWithBody<TBody>,
    RequestWithParam<TQuery> {}
