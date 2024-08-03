using KC.API.DTO;
using KC.API.Model;
using MediatR;

namespace KC.API.Application.Commands
{
    public class DeleteLabourCommand(int Id) : IRequest
    {
        public int Id { get; } = Id;    
    }
}
