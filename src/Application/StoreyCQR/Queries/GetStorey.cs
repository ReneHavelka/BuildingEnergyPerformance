using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.StoreyCQR.Queries
{
	public class GetStorey
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetStorey(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<StoreyDto> GetStoreyDtoAsync(int id)
		{
			var storey = await _context.Storeys.FindAsync(id);
			var storeyDto = _mapper.Map<StoreyDto>(storey);
			return storeyDto;
		}
	}
}
