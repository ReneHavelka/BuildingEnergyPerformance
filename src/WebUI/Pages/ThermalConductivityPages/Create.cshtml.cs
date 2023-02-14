using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ThermalConductivityCQR.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalConductivitiesPages
{
	public class CreateModel : PageModel
	{
		[BindProperty]
		public ThermalConductivitieDto ThermalConductivityDto { get; set; }

		IApplicationDbContext _context;
		IMapper _mapper;


		public CreateModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IActionResult> OnPost(ThermalConductivitieDto ThermalConductivityDto)
		{
			var createThermalConductivity = new CreateThermalConductivity(_context, _mapper);
			await createThermalConductivity.AddThermalConductivity(ThermalConductivityDto);

			return RedirectToPage("Index");
		}
	}
}
