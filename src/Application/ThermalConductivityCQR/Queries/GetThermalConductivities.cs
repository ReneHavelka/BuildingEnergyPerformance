using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.ThermalConductivityCQR.Queries
{
    public class GetThermalConductivities
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public GetThermalConductivities(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<ThermalConductivitieDto> GetThermalConductivitiesDtoList()
        {
            var thermalConductivities = _context.ThermalConductivities;
            var thermalConductivitiesDtoList = _mapper.Map<IList<ThermalConductivitieDto>>(thermalConductivities);
            return thermalConductivitiesDtoList;
        }
    }
}
