using Microsoft.AspNetCore.Mvc;
using KC.API.Application.Commands;
using MediatR;

namespace KC.API.Controllers
{
    [Route("api/Labours")]
    [ApiController]
    public class LaboursController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LaboursController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> CreateLabourAsync(CreateLabourCommand command)
        {
            var response = await _mediator.Send(command);

            return Created("",response); 
        }
        
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetLaboursAsync()
        {
            var response = await _mediator.Send(new GetLaboursQuery());

            return Ok(response); 
        }

    }
}

