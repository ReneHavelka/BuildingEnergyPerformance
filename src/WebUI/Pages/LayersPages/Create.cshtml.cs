using Application.Common.HandlerServices;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.LayersCQR.Commands;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Pages.LayersPages
{
	public class CreateModel : PageModel
	{
		[BindProperty]
		public LayersDto LayerDto { get; set; }
		public SelectList StoreySelectList { get; set; }

		IApplicationDbContext _context;
		IMapper _mapper;

		public CreateModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public void OnGet()
		{
			var storeysDtoList = new GetStoreys(_context, _mapper).GetStoreyDtoListAsync();
			StoreySelectList = new SelectList((System.Collections.IEnumerable)storeysDtoList, "Id", "Name");
		}

		public JsonResult OnGetCollection(string nextCategory, int selectedValue)
		{
			var selectCollection = new SelectCollection(_context, _mapper);
			var selectedCollection = selectCollection.GetCollection(nextCategory, selectedValue);

			return new JsonResult(selectedCollection);
		}
		public JsonResult OnGetTemperature(int spaceValue)
		{
			var selectSpaceTemperature = new SelectSpaceTemperature(_context, _mapper);
			var temperature = selectSpaceTemperature.GetSpaceTemperature(spaceValue);

			return new JsonResult(temperature);
		}

		public JsonResult OnGetBuildingElementArea(int buildingElementValue)
		{
			var selectBuildingElementArea = new SelectBuildingElementArea(_context, _mapper);
			var buildingElementArea = selectBuildingElementArea.GetBuildingElementArea(buildingElementValue);

			return new JsonResult(buildingElementArea);
		}

		public async Task<IActionResult> OnPost(LayersDto LayerDto)
		{
			var createLayer = new CreateLayers(_context, _mapper);
			await createLayer.AddLayer(LayerDto);

			return RedirectToPage("Index");
		}
	}
}
