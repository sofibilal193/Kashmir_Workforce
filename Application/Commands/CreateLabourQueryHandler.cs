using AutoMapper;
using KC.API.Data;
using KC.API.DTO;
using KC.API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KC.API.Application.Commands
{
    public class CreateLabourQueryHandler : IRequestHandler<CreateLabourCommand, int>
    {
        private readonly KcDbContext _context;

        private readonly IMapper _mapper;

        public CreateLabourQueryHandler(KcDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLabourCommand request, CancellationToken cancellationToken)
        {

            var labour = new Labour(request.FullName, request.Age, request.MobileNumber, request.Email, request.Skills);

           await _context.Labours.AddAsync(labour, cancellationToken);

            await _context.SaveChangesAsync();


            return labour.Id;



        }
    }
}