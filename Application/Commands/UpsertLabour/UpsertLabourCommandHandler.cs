using AutoMapper;
using KC.API.Data;
using KC.API.Data.Extensions;
using KC.API.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KC.API.Application.Commands
{
    public class CreateLabourCommandHandler : IRequestHandler<UpsertLabourCommand, int>
    {
        private readonly KcDbContext _context;

        public CreateLabourCommandHandler(KcDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpsertLabourCommand request, CancellationToken cancellationToken)
        {
            Labour labour;
            if (request.Id.HasValue)
            {
                labour = await _context.Labours.FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken)
                  ??  throw new NotFoundException(nameof(Labour), request.Id);
                
                labour.Update(request.FullName, request.Age, request.MobileNumber, request.Email, request.Skills);
                _context.Labours.Update(labour);
            }
            else
            {
                labour = new Labour(request.FullName, request.Age, request.MobileNumber, request.Email, request.Skills);

                await _context.Labours.AddAsync(labour, cancellationToken);
            }

            await _context.SaveChangesAsync();


            return labour.Id;



        }
    }
}