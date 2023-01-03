using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Commands;
using Application.SpaceTemperaturesCQR.Queries;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Pages.SpacesPages
{
	public class CreateModel : PageModel
	{
		public SpacesDto SpaceDto { get; set; }
		public SelectList SpaceTemperaturesSelectList { get; set; }
		public SelectList StoreysSelectList { get; set; }

		IApplicationDbContext _context;
		IMapper _mapper;


		public CreateModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task OnGet()
		{
			var getStoreys = new GetStoreys(_context, _mapper);
			var storeysDtoList = await getStoreys.GetStoreyDtoListAsync();
			StoreysSelectList = new SelectList(storeysDtoList, "Id", "Name");
			var spaceTemperaturesDtoList = new GetSpaceTemperatures(_context, _mapper).GetSpaceTemperaturesDtoList();
			for (int i = 0; i < spaceTemperaturesDtoList.Count; i++) { spaceTemperaturesDtoList[i].Name += ": " + spaceTemperaturesDtoList[i].Temperature + "°C"; }
			SpaceTemperaturesSelectList = new SelectList(spaceTemperaturesDtoList, "Temperature", "Name");
		}

		public async Task<IActionResult> OnPost(SpacesDto SpaceDto)
		{
			var createSpace = new CreateSpace(_context, _mapper);
			await createSpace.AddSpaceAsync(SpaceDto);

			return RedirectToPage("Index");
		}
	}
}
