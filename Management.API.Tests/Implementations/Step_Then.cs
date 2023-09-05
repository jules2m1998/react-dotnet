using Management.Api.Responses;
using Management.Api.Tests.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Management.Api.Tests.Implementations;

[Binding]
public class Step_Then
{
    private readonly ExceptionHandlerContext context;

    private ErrorResponses Error => context.ErrorResponse;

    public Step_Then(ExceptionHandlerContext context)
    {
        this.context = context;
    }

    [Then(@"Response title is ""([^""]*)"", Detail is ""([^""]*)"" Status code is (.*)")]
    public void ThenResponseTitleIsDetailIsStatusCodeIs(string title, string detail, int status)
    {
        Assert.Equal(status, context.StatusCode);
        Assert.Equal(status, Error.Status);
        Assert.Equal(title, Error.Title);
        Assert.Equal(detail, Error.Detail);
    }

    [Then(@"Response detail length is (.*)")]
    public void ThenResponseDetailLengftIs(int length)
    {
        Assert.Equal(length, Error.Details?.Count);
    }

    [Then(@"First Detail is ""([^""]*)"" and ""([^""]*)""")]
    public void ThenFirstDetailIsAnd(string property, string value)
    {
        var first = Error.Details?.FirstOrDefault();
        Assert.NotNull(first);
        Assert.Equal(property, first?.Key);
        Assert.Equal(value, first?.Value?.FirstOrDefault());
    }
}
