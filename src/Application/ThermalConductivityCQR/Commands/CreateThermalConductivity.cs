using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.ThermalConductivityCQR.Commands
{
    public class CreateThermalConductivity
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public CreateThermalConductivity(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddThermalConductivity(ThermalConductivitieDto thermalConductivityDto)
        {
            ThermalConductivity thermalConductivity = _mapper.Map<ThermalConductivity>(thermalConductivityDto);
            await _context.ThermalConductivities.AddAsync(thermalConductivity);
            await _context.SaveChangesAsync();
        }
    }
}
