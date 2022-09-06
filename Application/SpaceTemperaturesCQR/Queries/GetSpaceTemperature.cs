using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.SpaceTemperaturesCQR.Queries
{
    public class GetSpaceTemperature
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public GetSpaceTemperature(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SpaceTemperaturesDto GetSpaceTemperatureDto(int id)
        {
            var spaceTemperature = _context.SpaceTemperatures.Find(id);
            var spaceTemperatureDto = _mapper.Map<SpaceTemperaturesDto>(spaceTemperature);
            return spaceTemperatureDto;
        }
    }
}
