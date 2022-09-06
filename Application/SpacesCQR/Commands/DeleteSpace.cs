using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.SpacesCQR.Commands
{
    public class DeleteSpace
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public DeleteSpace(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task RemoveSpace(int id)
        {
            var space = _context.Spaces.Find(id);
            _context.Spaces.Remove(space);
            await _context.SaveChangesAsync();
        }
    }
}
