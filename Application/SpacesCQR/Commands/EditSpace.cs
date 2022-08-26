using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.SpacesCQR.Commands
{
    public class EditSpace
    {
        SpacesDto spaceDto;
        IMapper _mapper;
        IApplicationDbContext _context;

        public EditSpace(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public SpacesDto GetSpace(int id)
        {
            var space = _context.Spaces.Find(id);
            spaceDto = _mapper.Map<SpacesDto>(space);
            return spaceDto;
        }
        public async Task ModifySpace(SpacesDto spaceDto)
        {
            Spaces space = _mapper.Map<Spaces>(spaceDto);
            _context.Spaces.Update(space);
            await _context.SaveChangesAsync();
        }
    }
}
