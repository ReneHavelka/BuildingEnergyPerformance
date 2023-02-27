using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.ThermalConductivityCQR.Commands
{
    public class DeleteThermalConductivity
    {
        IApplicationDbContext _context;

        public DeleteThermalConductivity(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RemoveThermalConductivity(ThermalConductivitieDto thermalConductivityDto)
        {
            int id = thermalConductivityDto.Id;
            var thermalConductivity = _context.ThermalConductivities.Find(id);
            _context.ThermalConductivities.Remove(thermalConductivity);
            await _context.SaveChangesAsync();
        }
    }
}
