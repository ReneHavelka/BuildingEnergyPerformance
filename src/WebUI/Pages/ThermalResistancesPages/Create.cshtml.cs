using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceTemperaturesCQR.Commands;
using Application.ThermalConductivitiesCQR.Commands;
using Application.ThermalResistancesCQR.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalResistancesPages
{
    public class CreateModel : PageModel
    {
		[BindProperty]
		public ThermalResistancesDto ThermalResistanceDto { get; set; }

		IApplicationDbContext _context;
		IMapper _mapper;


		public CreateModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IActionResult> OnPostAsync(ThermalResistancesDto ThermalResistanceDto)
		{
			var createThermalResistance = new CreateThermalResistance(_context, _mapper);
			await createThermalResistance.AddThermalResistanceAsync(ThermalResistanceDto);

			return RedirectToPage("Index");
		}
	}
}
