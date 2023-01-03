using Application.BuildingElementsCQR.Commands;
using Application.Common.HandlerServices;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Pages.BuildingElementsPages
{
	public class CreateModel : PageModel
	{
		[BindProperty]
		public BuildingElementsDto BuildingElementDto { get; set; }
		public SelectList StoreySelectList { get; set; }

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
			StoreySelectList = new SelectList(storeysDtoList, "Id", "Name");
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

		public async Task<IActionResult> OnPost(BuildingElementsDto BuildingElementDto)
		{
			var createBuildingElement = new CreateBuildingElement(_context, _mapper);
			await createBuildingElement.AddBuildingElement(BuildingElementDto);

			return RedirectToPage("Index");
		}
	}
}
