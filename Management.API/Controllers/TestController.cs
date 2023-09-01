using Managerment.Core.Business.DTOs;
using Managerment.Core.Business.UseCases.TestUcs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISender sender;

        public TestController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(TestDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Test(string data)
        {
            var query = new MakeTest.Query(data);
            var result = await sender.Send(query);

            return Ok(result);
        }
    }
}
