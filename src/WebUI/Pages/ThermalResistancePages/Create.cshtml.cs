using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ThermalResistanceCQR.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalResistancePages
{
	public class CreateModel : PageModel
	{
		[BindProperty]
		public ThermalResistanceDto ThermalResistanceDto { get; set; }

		IApplicationDbContext _context;
		IMapper _mapper;


		public CreateModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IActionResult> OnPostAsync(ThermalResistanceDto ThermalResistanceDto)
		{
			var createThermalResistance = new CreateThermalResistance(_context, _mapper);
			await createThermalResistance.AddThermalResistanceAsync(ThermalResistanceDto);

			return RedirectToPage("Index");
		}
	}
}
