using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System.Diagnostics;

namespace Application.SpacesCQR.Commands
{
    public class CreateSpace
    {
        SpacesDto _spaceDto;
        IMapper _mapper;
        IApplicationDbContext _context;

        public CreateSpace(SpacesDto spaceDto, IMapper mapper, IApplicationDbContext context)
        {
            _spaceDto = spaceDto;
            _mapper = mapper;
            _context = context;
        }

        public async Task AddSpace()
        {
            Spaces space = _mapper.Map<Spaces>(_spaceDto);
            await _context.Spaces.AddAsync(space);
            await _context.SaveChangesAsync();
        }
    }
}
