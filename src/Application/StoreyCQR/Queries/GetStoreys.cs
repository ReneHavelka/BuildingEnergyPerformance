using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.StoreyCQR.Queries
{
	public class GetStoreys
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetStoreys(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IList<StoreyDto>> GetStoreyDtoListAsync()
		{
			var storeys = _context.Storeys;
			var storeysDto = _mapper.Map<IList<StoreyDto>>(storeys);
			return storeysDto;
		}
	}
}
