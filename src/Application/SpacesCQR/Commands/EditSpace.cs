using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.SpacesCQR.Commands
{
	public class EditSpace
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public EditSpace(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task ModifySpaceAsync(SpacesDto spaceDto)
		{
			var space = _mapper.Map<Spaces>(spaceDto);
			_context.Spaces.Update(space);
			await _context.SaveChangesAsync();
		}
	}
}
