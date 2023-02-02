using MediatR;
using Microsoft.AspNetCore.Mvc;
using OncuService.Common.Models.RequestModels;

namespace OncuService.Api.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SmsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SmsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Send([FromBody] SendSmsCommand command)
    {
        var res = await _mediator.Send(command);

        return Ok(res);
    }
}
