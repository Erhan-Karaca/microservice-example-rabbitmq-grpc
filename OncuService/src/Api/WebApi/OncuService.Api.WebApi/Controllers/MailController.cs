using MediatR;
using Microsoft.AspNetCore.Mvc;
using OncuService.Common.Models.RequestModels;

namespace OncuService.Api.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MailController : ControllerBase
{
    private readonly IMediator _mediator;

    public MailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Send([FromBody] SendMailCommand command)
    {
        var res = await _mediator.Send(command);

        return Ok(res);
    }
}
