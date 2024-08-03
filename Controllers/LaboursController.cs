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
        public async Task<ActionResult<int>> CreateLabourAsync(UpsertLabourCommand command)
        {
            var response = await _mediator.Send(command);
            return Created("",response); 
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<int>> UpdateLabourAsync(int Id, UpsertLabourCommand command)
        {
            command.SetIds(Id);
            await _mediator.Send(command);
            return NoContent(); 
        }
        
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetLaboursAsync()
        {
            var response = await _mediator.Send(new GetLaboursQuery());

            return Ok(response); 
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetLabourAsync(int Id)
        {
            var response = await _mediator.Send(new GetLabourQuery(Id));

            return Ok(response); 
        }


        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<int>> DeleteLabourAsync(int Id)
        {
             await _mediator.Send(new DeleteLabourCommand(Id));
            return NoContent(); 
        }


    }
}

