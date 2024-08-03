using AutoMapper;
using KC.API.Data;
using KC.API.DTO;
using KC.API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KC.API.Application.Commands
{
    public class GetLabourQueryHandler : IRequestHandler<GetLabourQuery, LabourDto>
    {
        private readonly KcDbContext _context;
        private readonly IMapper _mapper;


        public GetLabourQueryHandler(KcDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LabourDto> Handle(GetLabourQuery request, CancellationToken cancellationToken)
        {


            var labour = await _context.Labours.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return _mapper.Map<LabourDto>(labour);

        }


    }
}