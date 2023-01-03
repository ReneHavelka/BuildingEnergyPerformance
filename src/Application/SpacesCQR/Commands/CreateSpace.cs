using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.SpacesCQR.Commands
{
	public class CreateSpace
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public CreateSpace(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task AddSpaceAsync(SpacesDto spaceDto)
		{
			var space = _mapper.Map<Spaces>(spaceDto);
			await _context.Spaces.AddAsync(space);
			await _context.SaveChangesAsync();
		}
	}
}
