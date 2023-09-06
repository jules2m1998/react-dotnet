using FluentValidation.Results;
using Management.Api.Helpers;
using Management.Api.Responses;
using Management.Api.Tests.Contexts;
using Management.Core.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Api.Tests.Implementations;

[Binding]
public class Step_When
{
    private readonly ExceptionHandlerContext context;

    public Step_When(ExceptionHandlerContext context)
    {
        this.context = context;
    }

    private void Initialisation<TException>(TException exception) where TException : BaseException
    {
        var response = new Mock<Microsoft.AspNetCore.Http.HttpResponse>();
        response
            .SetupSet(x => x.StatusCode = It.IsAny<int>())
            .Callback<int>(value => context.StatusCode = value);

        var helper = new Mock<IResponseWritterHelper>();
        helper
            .Setup(x => x.WriteAsync(It.IsAny<Microsoft.AspNetCore.Http.HttpResponse>(), It.IsAny<ErrorResponses>()))
            .Callback<Microsoft.AspNetCore.Http.HttpResponse, ErrorResponses>((re, err) =>
            {
                context.ErrorResponse = err;
            })
            .Returns(Task.CompletedTask);

        context.Handler = new Middlewares.HandleExceptionMiddleware(context.next.Object, context.Mapper, helper.Object);
        context.next.Setup(x => x(It.IsAny<HttpContext>())).ThrowsAsync(exception);
        context.ctx.SetupGet(x => x.Response).Returns(response.Object);
    }

    [When(@"NotFound Exception is throw with message ""([^""]*)"" in the ExceptionHandlerMiddleware")]
    public async void WhenNotFoundExceptionIsThrowWithMessageInTheExceptionHandlerMiddleware(string message)
    {
        var fail = context.Exception!.Errors!.Select(x => new ValidationFailure
        {
            PropertyName = x.Key,
            ErrorMessage = x.Value.First().ToString()
        });

        var exception = new TestNotFoundException(fail.ToList(), message)
        {
            Title = context.Exception!.Title,
        };
        Initialisation(exception);
        await context.Handler!.InvokeAsync(context.ctx.Object);
    }

    [When(@"Invalid data exception is throw with message ""([^""]*)"" in the ExceptionHandlerMiddleware")]
    public async void WhenInvalidDataExceptionIsThrowWithMessageInTheExceptionHandlerMiddleware(string message)
    {
        var fail = context.Exception!.Errors!.Select(x => new ValidationFailure
        {
            PropertyName = x.Key,
            ErrorMessage = x.Value.First().ToString()
        });
        var exception = new CustomInvalidDataException(fail.ToList(), message)
        {
            Title = context.Exception!.Title,
        };
        Initialisation(exception);
        await context.Handler!.InvokeAsync(context.ctx.Object);
    }

}
