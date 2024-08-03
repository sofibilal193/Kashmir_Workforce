using KC.API.DTO;
using KC.API.Model;
using MediatR;

namespace KC.API.Application.Commands
{
    public class GetLabourQuery(int Id) : IRequest<LabourDto>
    {
        public int Id { get; } = Id;
    }
}
