using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceCQR.Commands;
using Application.SpaceCQR.Queries;
using Application.SpaceTemperatureCQR.Queries;
using Application.StoreyCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Pages.SpacesPages
{
	public class EditModel : PageModel
	{
		[BindProperty]
		public SpaceDto SpaceDto { get; set; }
		public SelectList SpaceTemperaturesSelectList { get; set; }
		public SelectList StoreysSelectList { get; set; }

		IApplicationDbContext _context;
		IMapper _mapper;


		public EditModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task OnGet(int id)
		{
			var spaceTemperaturesDtoList = new GetSpaceTemperatures(_context, _mapper).GetSpaceTemperaturesDtoList();
			for (int i = 0; i < spaceTemperaturesDtoList.Count; i++) { spaceTemperaturesDtoList[i].Name += ": " + spaceTemperaturesDtoList[i].Temperature + "°C"; }
			SpaceTemperaturesSelectList = new SelectList(spaceTemperaturesDtoList, "Temperature", "Name");

			var getSpace = new GetSpace(_context, _mapper);
			SpaceDto = getSpace.GetSpaceDto(id);

			var getStoreys = new GetStoreys(_context, _mapper);
			var storeysDtoList = await getStoreys.GetStoreyDtoListAsync();
			StoreysSelectList = new SelectList(storeysDtoList, "Id", "Name");
		}

		public async Task<IActionResult> OnPost()
		{
			var editSpace = new EditSpace(_context, _mapper);
			await editSpace.ModifySpaceAsync(SpaceDto);

			return RedirectToPage("Index");
		}
	}
}
