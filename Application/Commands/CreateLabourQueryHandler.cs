using AutoMapper;
using KC.API.Data;
using KC.API.Model;
using MediatR;

namespace KC.API.Application.Commands
{
    public class CreateLabourCommandHandler : IRequestHandler<CreateLabourCommand, int>
    {
        private readonly KcDbContext _context;

        public CreateLabourCommandHandler(KcDbContext context)
        {
            _context = context;
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