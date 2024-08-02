using Microsoft.AspNetCore.Mvc;
using KC.API.Application.Commands;
using MediatR;

namespace KC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboursController : ControllerBase
    {

        private readonly IMediator _mediator;


        public LaboursController(IMediator mediator)
        {

            _mediator = mediator;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> PostLabour(CreateLabourCommand command)
        {
            var response = await _mediator.Send(command);

            return Created("",response); 
        }

    }
}

