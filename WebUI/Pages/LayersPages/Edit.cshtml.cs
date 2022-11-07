using Application.BuildingElementsCQR.Queries;
using Application.Common.HandlerServices;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.LayersCQR.Commands;
using Application.LayersCQR.Queries;
using Application.SpacesCQR.Queries;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Pages.LayersPages
{
	public class EditModel : PageModel
	{
		[BindProperty]
		public LayersDto LayerDto { get; set; }
		public SelectList StoreySelectList { get; set; }
		public SelectList SpaceSelectList { get; set; }
		public SelectList BuildingElementList { get; set; }

		public float temperature;
		public float area;

		IApplicationDbContext _context;
		IMapper _mapper;


		public EditModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public void OnGet(int id)
		{
			var layer = new GetLayer(_context, _mapper);
			LayerDto = layer.GetLayerDto(id);
			var storeysDtoList = new GetStoreys(_context, _mapper).GetStoreyDtoList();
			StoreySelectList = new SelectList(storeysDtoList, "Id", "Name", layer.StoreyId);
			var spacesDtoList = new GetSpaces(_context, _mapper).GetSpaceDtoList();
			SpaceSelectList = new SelectList(spacesDtoList, "Id", "Name", layer.SpaceId);
			var buildingElementsDtoList = new GetBuildingElements(_context, _mapper).GetBuildingElementDtoList();
			BuildingElementList = new SelectList(buildingElementsDtoList, "Id", "Name", LayerDto.BuildingElementsId);

			temperature = spacesDtoList.FirstOrDefault(x => x.Id == layer.SpaceId).Temperature;
			area = buildingElementsDtoList.FirstOrDefault(x => x.Id == LayerDto.BuildingElementsId).EffectiveArea;
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

		public async Task<IActionResult> OnPost()
		{
			var editLayer = new EditLayers(_context, _mapper);
			await editLayer.ModifyLayer(LayerDto);

			return RedirectToPage("Index");
		}

	}
}
