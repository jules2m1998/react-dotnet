using Management.Api.Responses;
using Management.Core.Business.DTOs.Test;
using Management.Core.Business.UseCases.TestUCs;
using Management.Core.Business.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    private readonly ISender sender;

    public TestsController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    [Route("Single")]
    [ProducesResponseType(typeof(Response<TestDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponses), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Single(int a, int b)
    {
        var query = new MakeTest.Query(a, b);
        var result = await sender.Send(query);
        var response = new Response<TestDto>(true, "Ok", result);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<PagedList<TestDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Multiple([FromQuery] TestParametersDto dto)
    {
        var query = new MakeTestWithArray.Query(dto);
        var result = await sender.Send(query);
        var response = new Response<PagedList<TestDto>>(true, "Ok", result);
        Response.Headers.Add("X-Pagination", result.ToPaginationMetada());
        return Ok(response);
    }

}
