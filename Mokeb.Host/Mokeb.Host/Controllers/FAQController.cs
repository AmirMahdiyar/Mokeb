using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mokeb.Application.CommandHandler.AdminCommands.AddFAQ;

namespace Mokeb.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FAQController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FAQController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddFAQ([FromBody] AddFAQCommand command, CancellationToken ct)
        {
            command.Validate();
            var result = await _mediator.Send(command, ct);
            if (result.Result)
                return Ok("سوال اضافه شد");
            return BadRequest("سوال اضافه نشد");
        }
    }
}
