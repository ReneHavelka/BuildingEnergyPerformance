using Application.BuildingElementCQR.Queries;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.BuildingElementPages
{
	public class IndexModel : PageModel
	{
		private readonly IApplicationDbContext _context;

		public IList<GetBuildingElementsWithSpaces> BuildingElementsList { get; set; }

		public IndexModel(IApplicationDbContext context)
		{
			_context = context;
		}

		public void OnGet()
		{
			var getBuildingElements = new GetBuildingElementsWithSpaces();
			BuildingElementsList = getBuildingElements.GetBuildingElementsWithSpacesList(_context);
		}
	}
}
