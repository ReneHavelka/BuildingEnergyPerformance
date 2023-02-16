using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ThermalConductivityCQR.Commands;
using Application.ThermalConductivityCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalConductivityPages
{
	public class DeleteModel : PageModel
	{
		[BindProperty]
		public ThermalConductivitieDto ThermalConductivityDto { get; set; }

		IApplicationDbContext _context;
		IMapper _mapper;

		public DeleteModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public IActionResult OnGet(int id)
		{
			var getThermalConductivity = new GetThermalConductivity(_context, _mapper);
			ThermalConductivityDto = getThermalConductivity.GetThermalConductivityDto(id);

			if (ThermalConductivityDto == null)
			{
				return RedirectToPage("Index");
			}

			return Page();
		}

		public async Task<IActionResult> OnPost()
		{
			var deleteThermalConductivity = new DeleteThermalConductivity(_context);
			var test = ThermalConductivityDto.Id;

			await deleteThermalConductivity.RemoveThermalConductivity(ThermalConductivityDto);

			return RedirectToPage("Index");
		}

	}
}
