﻿using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.SpacesCQR.Queries
{
	public class GetSpace
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetSpace(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public SpacesDto GetSpaceDto(int id)
		{
			var space = _context.Spaces.Find(id);
			var spaceDto = _mapper.Map<SpacesDto>(space);
			return spaceDto;
		}
	}
}
