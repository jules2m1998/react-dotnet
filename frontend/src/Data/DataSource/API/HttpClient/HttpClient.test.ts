import { HttpClient } from "./HttpClient";
import { BaseRequestParam, RequestInterceptor } from "./types";

const FAKE_URL = "https://jsonplaceholder.typicode.com/todos/1";

describe("HttpClient", () => {
  let httpclient: HttpClient;
  let headers: any;
  beforeEach(() => {
    headers = { "Content-Type": "application/json" };
    httpclient = new HttpClient(FAKE_URL, headers);
    global.fetch = jest.fn();
  });
  describe("baseRequest", () => {
    test("It's call with params fetch is call with these params", async () => {
      // Arrange
      const body = JSON.stringify({
        test: "test",
      });

      // Act
      await httpclient.baseRequest({
        method: "GET",
        body,
      });

      // Assert
      expect(fetch).toHaveBeenCalledWith(FAKE_URL, {
        method: "GET",
        headers: { ...headers },
        body,
      });
    });
    test("It's call with relative url and concat with base url", async () => {
      // Arrange
      const path = "/test";

      // Act
      await httpclient.baseRequest({
        method: "GET",
        url: "/test",
      });

      // Assert
      expect(fetch).toHaveBeenCalledWith(FAKE_URL + path, {
        method: "GET",
        headers: { ...headers },
        body: undefined,
      });
    });
    test("It's call with absolute url and ignore with base url", async () => {
      // Arrange
      const path =
        "https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch";

      // Act
      await httpclient.baseRequest({
        method: "GET",
        url: path,
      });

      // Assert
      expect(fetch).toHaveBeenCalledWith(path, {
        method: "GET",
        headers: { ...headers },
        body: undefined,
      });
    });
    test("should throw an exception if baseUrl is null and url parameter is undefined", async () => {
      // Arrange
      httpclient.baseUrl = undefined;

      // Assert
      expect(
        httpclient.baseRequest.bind(httpclient, {
          method: "GET",
        })
      ).toThrow(/unable to perform a query on an undefined url/i);
    });
    test("Request interceptor change request params", async () => {
      // Arrange
      const path =
        "https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch";
      const body = JSON.stringify({
        test: "DATA_TEST",
      });
      const head = {
        test: "TEST_HEAD",
      };
      const req = {
        url: "/URL_TEST",
        options: {
          method: "POST",
          body,
          headers: head,
        },
      };
      httpclient.requestInterceptor = jest.fn().mockReturnValue(req);

      // Act
      await httpclient.baseRequest({
        method: "GET",
        url: path,
      });

      // Assert
      expect(httpclient.requestInterceptor).toHaveBeenCalledWith({
        url: path,
        options: {
          method: "GET",
          headers,
          body: undefined,
        },
      } as RequestInterceptor);
      expect(fetch).toHaveBeenCalledWith("/URL_TEST", {
        method: "POST",
        body,
        headers: head,
      });
    });
    test("Response interceptor change response", async () => {
      // Arrange
      const path =
        "https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch";
      const resIntercepted = {
        test: "resIntercepted",
      };
      const res = {
        test: "res",
      };
      httpclient.responseInterceptor = jest
        .fn()
        .mockReturnValue(resIntercepted);
      global.fetch = jest.fn().mockReturnValue(res);

      // Act
      const result = await httpclient.baseRequest({
        method: "GET",
        url: path,
        body: undefined,
      });

      // Assert
      expect(httpclient.responseInterceptor).toHaveBeenCalledWith(res);
      expect(fetch).toBeCalledTimes(1);
      expect(result).toEqual(resIntercepted);
    });
  });
  describe("objectToQueryParams", () => {
    test("should return flatten query paramaters as get data pattern", () => {
      // Arrange
      const query = {
        name: "testname",
        age: 18,
        isOk: true,
        json: {
          line: "test",
        },
        array: [1, 2, 4],
      };
      const expected = `name=${query.name}&age=${query.age}&isOk=${
        query.isOk
      }&json=${JSON.stringify(query.json)}&array=${JSON.stringify(
        query.array
      )}`;
      const splitted = expected.split("&");

      // Act
      const result = httpclient.objectToQueryParams(query);
      const splittedResult = result.split("&");
      const difference = splitted.filter((x) => !splittedResult.includes(x));

      // Assert
      expect(splittedResult.length).toBe(splitted.length);
      expect(difference.length).toBe(0);
    });
  });
  describe("get method", () => {
    beforeEach(() => {
      httpclient.baseRequest = jest.fn();
    });
    test("Should call baseRequest with correct params", () => {
      // Arrange
      const expected = {
        method: "GET",
        url: "/test",
        headers,
      };

      // Act
      httpclient.get({
        url: expected.url,
        headers: expected.headers,
      });

      // Assert
      expect(httpclient.baseRequest).toBeCalledWith(expected);
    });
    test("Should call baseRequest with returned url from objectToQueryParams", () => {
      // Arrange
      const data = {
        url: "/test",
        query: {
          name: "testname",
          age: 18,
          isOk: true,
          json: {
            line: "test",
          },
          array: [1, 2, 4],
        },
      };
      const expectedUrlParams = `name=${data.query.name}&age=${data.query.age}&isOk=${data.query.isOk}&json={"line":"test"}&array=[1, 2, 4]`;
      httpclient.objectToQueryParams = jest
        .fn()
        .mockReturnValue(expectedUrlParams);

      // Act
      httpclient.get(data);

      // Assert
      expect(httpclient.objectToQueryParams).toBeCalledWith(data.query);
      expect(httpclient.baseRequest).toBeCalledWith({
        url: `${data.url}?${expectedUrlParams}`,
        headers: undefined,
        method: "GET",
      });
    });
  });
  describe("post method", () => {
    beforeEach(() => {
      httpclient.baseRequest = jest.fn();
    });
    test("Should call baseRequest with correct params", () => {
      // Arrange
      const expected = {
        method: "POST",
        url: "/test",
        headers,
        body: JSON.stringify({
          test: "TEST",
        }),
      };
      httpclient.baseRequest = jest.fn().mockReturnValue({ data: "TEST" });

      // Act
      const result = httpclient.post({
        url: expected.url,
        headers: expected.headers,
        body: expected.body,
      });

      // Assert
      expect(httpclient.baseRequest).toBeCalledWith(expected);
      expect(result).toEqual({ data: "TEST" });
    });
  });
  describe("put method", () => {
    beforeEach(() => {
      httpclient.baseRequest = jest.fn();
    });
    test("Should call baseRequest with correct params", () => {
      // Arrange
      httpclient.baseRequest = jest.fn().mockReturnValue({ data: "TEST" });
      const body = JSON.stringify({ test: "PUT" });
      const headers = {
        test: "test",
      };

      // Act
      const result = httpclient.put({
        url: "/put",
        body,
        headers,
      });

      // Assert
      expect(httpclient.baseRequest).toBeCalledWith({
        method: "PUT",
        body,
        headers,
        url: "/put",
      } as BaseRequestParam<string>);

      expect(result).toEqual({ data: "TEST" });
    });
  });

  describe("delete method", () => {
    beforeEach(() => {
      httpclient.baseRequest = jest.fn();
    });
    test("Should call baseRequest with correct params", () => {
      // Arrange
      const expected = {
        method: "DELETE",
        url: "/test",
        headers,
      };

      // Act
      httpclient.delete({
        url: expected.url,
        headers: expected.headers,
      });

      // Assert
      expect(httpclient.baseRequest).toBeCalledWith(expected);
    });
    test("Should call baseRequest with returned url from objectToQueryParams", () => {
      // Arrange
      const data = {
        url: "/test",
        query: {
          name: "testname",
          age: 18,
          isOk: true,
          json: {
            line: "test",
          },
          array: [1, 2, 4],
        },
      };
      const expectedUrlParams = `name=${data.query.name}&age=${data.query.age}&isOk=${data.query.isOk}&json={"line":"test"}&array=[1, 2, 4]`;
      httpclient.objectToQueryParams = jest
        .fn()
        .mockReturnValue(expectedUrlParams);

      // Act
      httpclient.delete(data);

      // Assert
      expect(httpclient.objectToQueryParams).toBeCalledWith(data.query);
      expect(httpclient.baseRequest).toBeCalledWith({
        url: `${data.url}?${expectedUrlParams}`,
        headers: undefined,
        method: "DELETE",
      });
    });
  });

  describe("path method", () => {
    beforeEach(() => {
      httpclient.baseRequest = jest.fn();
    });
    test("Should call baseRequest with correct params", () => {
      // Arrange
      const expected = {
        method: "PATH",
        url: "/test",
        headers,
        body: JSON.stringify({
          test: "TEST",
        }),
      };
      httpclient.baseRequest = jest.fn().mockReturnValue({ data: "TEST" });

      // Act
      const result = httpclient.path({
        url: expected.url,
        headers: expected.headers,
        body: expected.body,
      });

      // Assert
      expect(httpclient.baseRequest).toBeCalledWith(expected);
      expect(result).toEqual({ data: "TEST" });
    });
  });
});
