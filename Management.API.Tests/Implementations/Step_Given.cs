using AutoMapper.Internal.Mappers;
using Management.Api.Middlewares;
using Management.Api.Tests.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Api.Tests.Implementations;

[Binding]
public class Step_Given
{
    private readonly ExceptionHandlerContext context;

    public Step_Given(ExceptionHandlerContext context)
    {
        this.context = context;
    }
    [Given(@"NotFound Exception is register in builder exception mapper with status code (.*)")]
    public void GivenNotFoundExceptionIsRegisterInBuilderExceptionMapperWithStatusCode(int status)
    {
        context.Mapper.Map<TestNotFoundException>(status);
    }

    [Given(@"NotFound Exception title is ""([^""]*)""")]
    public void GivenNotFoundExceptionTitleIs(string title)
    {
        var ex = new TestNotFoundException
        {
            Title = title
        };
        context.Exception = ex;
    }

    [Given(@"Invalid data exception in builder exception mapper with status code (.*)")]
    public void GivenInvalidDataExceptionInBuilderExceptionMapperWithStatusCode(int status)
    {
        context.Mapper.Map<CustomInvalidDataException>(status);
    }

    [Given(@"Invalid data exception title is ""([^""]*)""")]
    public void GivenInvalidDataExceptionTitleIs(string title)
    {
        var ex = new CustomInvalidDataException
        {
            Title = title
        };
        context.Exception = ex;
    }

    [Given(@"Field ""([^""]*)"" has error ""([^""]*)""")]
    public void GivenFieldHasError(string property, string error)
    {
        context.Exception?.Errors?.Add(property, new[] { error });
    }

}
