using Application.BuildingElementsCQR.Commands;
using Application.BuildingElementsCQR.Queries;
using Application.Common.HandlerServices;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Queries;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Pages.BuildingElementsPages
{
	public class EditModel : PageModel
	{
		[BindProperty]
		public BuildingElementsDto BuildingElementDto { get; set; }
		public SelectList StoreySelectList { get; set; }
		public SelectList SpaceSelectList { get; set; }

		public float temperature;

		IApplicationDbContext _context;
		IMapper _mapper;


		public EditModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public void OnGet(int id)
		{
			var buildingElement = new GetBuildingElement(_context, _mapper);
			BuildingElementDto = buildingElement.GetBuildingElementDto(id);
			var storeysDtoList = new GetStoreys(_context, _mapper).GetStoreyDtoListAsync();
			StoreySelectList = new SelectList((System.Collections.IEnumerable)storeysDtoList, "Id", "Name", buildingElement.StoreyId);
			var spacesDtoList = new GetSpaces(_context, _mapper).GetSpaceDtoList();
			SpaceSelectList = new SelectList(spacesDtoList, "Id", "Name", BuildingElementDto.SpacesId);
			temperature = spacesDtoList.FirstOrDefault(x => x.Id == BuildingElementDto.SpacesId).Temperature;
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

		public async Task<IActionResult> OnPost()
		{


			var editBuildingElement = new EditBuildingElement(_context, _mapper);
			await editBuildingElement.ModifyBuildingElement(BuildingElementDto);

			return RedirectToPage("Index");
		}
	}
}
