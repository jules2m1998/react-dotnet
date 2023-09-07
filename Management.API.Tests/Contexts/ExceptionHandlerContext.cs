using FluentValidation.Results;
using Management.Api.Middlewares;
using Management.Api.Responses;
using Management.Core.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Api.Tests.Contexts;

public class ExceptionHandlerContext
{
    public HttpExceptionMapper Mapper = new();
    public BaseException? Exception {  get; set; } = null;
    public HandleExceptionMiddleware Handler { get; set; } = null!;
    public Mock<HttpContext> ctx = new();
    public Mock<RequestDelegate> next = new();
    public int StatusCode { get; set; }
    public ErrorResponses ErrorResponse { get; set; } = null!;

}

public class TestNotFoundException : BaseException
{
    public TestNotFoundException()
    {
    }

    public TestNotFoundException(ICollection<ValidationFailure> failures, string? message = null) : base(failures, message)
    {
    }
}

public class CustomInvalidDataException: BaseException
{
    public CustomInvalidDataException()
    {
    }

    public CustomInvalidDataException(ICollection<ValidationFailure> failures, string? message = null) : base(failures, message)
    {
    }
}
