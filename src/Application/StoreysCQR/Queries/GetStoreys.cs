using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.StoreysCQR.Queries
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

		public async Task<IList<StoreysDto>> GetStoreyDtoList()
		{
			var storeys = _context.Storeys;
			var storeysDto = _mapper.Map<IList<StoreysDto>>(storeys);
			return storeysDto;
		}
	}
}
