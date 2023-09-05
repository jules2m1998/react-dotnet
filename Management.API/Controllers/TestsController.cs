using Management.Core.Business.UseCases.TestUCs;
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
    public async Task<IActionResult> Addition(int a, int b)
    {
        var query = new MakeTest.Query(a, b);
        var result = await sender.Send(query);

        return Ok(result);
    }
}
