using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.ThermalResistanceCQR.Queries
{
    public class GetThermalResistances
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public GetThermalResistances(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<ThermalResistanceDto> GetThermalResistanceDtoList()
        {
            var thermalResistances = _context.ThermalResistances;
            var thermalResistanceDtoList = _mapper.Map<IList<ThermalResistanceDto>>(thermalResistances);
            return thermalResistanceDtoList;
        }
    }
}
