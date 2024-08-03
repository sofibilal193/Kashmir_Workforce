using AutoMapper;
using KC.API.Data;
using KC.API.DTO;
using KC.API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KC.API.Application.Commands
{
    public class GetLaboursQueryHandler : IRequestHandler<GetLaboursQuery, List<LabourDto>>
    {
        private readonly KcDbContext _context;
        private readonly IMapper _mapper;


        public GetLaboursQueryHandler(KcDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LabourDto>> Handle(GetLaboursQuery request, CancellationToken cancellationToken)
        {


           var labours = await _context.Labours.ToListAsync(cancellationToken);

            return _mapper.Map<List<LabourDto>>(labours);



        }

       
    }
}