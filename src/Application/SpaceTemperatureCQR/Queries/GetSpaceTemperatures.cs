using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.SpaceTemperatureCQR.Queries
{
    public class GetSpaceTemperatures
    {
        IApplicationDbContext _context;
        IMapper _mapper;
        public GetSpaceTemperatures(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IList<SpaceTemperatureDto> GetSpaceTemperaturesDtoList()
        {
            var spaceTemperatures = _context.SpaceTemperatures;
            var spaceTemperaturesDto = _mapper.Map<IList<SpaceTemperatureDto>>(spaceTemperatures);
            return spaceTemperaturesDto;
        }
    }
}
