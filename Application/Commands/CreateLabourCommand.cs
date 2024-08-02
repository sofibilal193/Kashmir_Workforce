using KC.API.DTO;
using KC.API.Model;
using MediatR;

namespace KC.API.Application.Commands
{
    public class CreateLabourCommand : IRequest<int>
    {
        public string FullName { get; init; } = string.Empty;
        public int Age { get; init; }
        public string? MobileNumber { get; init; }
        public string? Email { get; init; }
        public List<Skill> Skills { get; init; } = [];
    }
}
