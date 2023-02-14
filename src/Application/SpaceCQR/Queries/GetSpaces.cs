using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.SpaceCQR.Queries
{
	public class GetSpaces
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetSpaces(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public IList<SpaceDto> GetSpaceDtoList()
		{
			var spaces = _context.Spaces;
			var spacesDto = _mapper.Map<IList<SpaceDto>>(spaces);
			return spacesDto;
		}
	}
}
