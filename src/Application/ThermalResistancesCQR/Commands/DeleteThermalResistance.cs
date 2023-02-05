using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.ThermalResistancesCQR.Commands
{
	public class DeleteThermalResistance
	{
		IApplicationDbContext _context;

		public DeleteThermalResistance(IApplicationDbContext context) => _context = context;

		public async Task RemoveThermalResistanceAsync(ThermalResistancesDto thermalResistanceDto)
		{
			int id = thermalResistanceDto.Id;
			var thermalResistance = _context.ThermalResistances.Find(id);
			_context.ThermalResistances.Remove(thermalResistance);
			Task saveChanges = _context.SaveChangesAsync();
			await saveChanges;
		}
	}
}
