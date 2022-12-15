using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceTemperaturesCQR.Commands;
using Application.SpaceTemperaturesCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpaceTemperaturesPages
{
	public class DeleteModel : PageModel
	{
		[BindProperty]
		public SpaceTemperaturesDto SpaceTemperatureDto { get; set; }

		IApplicationDbContext _context;
		IMapper _mapper;

		public DeleteModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public IActionResult OnGet(int id)
		{
			var getSpaceTemperature = new GetSpaceTemperature(_context, _mapper);
			SpaceTemperatureDto = getSpaceTemperature.GetSpaceTemperatureDto(id);

			if (SpaceTemperatureDto == null)
			{
				return RedirectToPage("Index");
			}

			return Page();
		}

		public async Task<IActionResult> OnPost()
		{
			var deleteSpaceTemperature = new DeleteSpaceTemperature(_context);
			await deleteSpaceTemperature.RemoveSpaceTemperature(SpaceTemperatureDto);

			return RedirectToPage("Index");
		}
	}
}
