using AutoMapper;
using KC.API.Data;
using KC.API.Data.Extensions;
using KC.API.Model;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KC.API.Application.Commands
{
    public class DeleteLabourCommandHandler : IRequestHandler<DeleteLabourCommand>
    {
        private readonly KcDbContext _context;

        public DeleteLabourCommandHandler(KcDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteLabourCommand request, CancellationToken cancellationToken)
        {

          var labour = await _context.Labours.FirstOrDefaultAsync(x=>x.Id == request.Id, cancellationToken) 
           ?? throw new NotFoundException(nameof(Labour), request.Id);

            _context.Labours.Remove(labour);

            await _context.SaveChangesAsync();

        }
    }
}