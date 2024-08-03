using KC.API.DTO;
using KC.API.Model;
using MediatR;

namespace KC.API.Application.Commands
{
    public class GetLaboursQuery() : IRequest<List<LabourDto>>{}
}
