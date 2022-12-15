using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceTemperaturesCQR.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpaceTemperaturesPages
{
	public class CreateModel : PageModel
	{
		[BindProperty]
		public SpaceTemperaturesDto SpaceTemperatureDto { get; set; }

		IApplicationDbContext _context;
		IMapper _mapper;


		public CreateModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IActionResult> OnPost(SpaceTemperaturesDto SpaceTemperatureDto)
		{
			var createSpaceTemperature = new CreateSpaceTemperature(_context, _mapper);
			await createSpaceTemperature.AddSpaceTemperature(SpaceTemperatureDto);

			return RedirectToPage("Index");
		}
	}
}
