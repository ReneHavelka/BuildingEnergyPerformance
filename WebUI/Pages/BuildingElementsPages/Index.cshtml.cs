using Application.BuildingElementsCQR.Queries;
using Application.Common.Interfaces;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.BuildingElementsPages
{
    public class IndexModel : PageModel
    {
        private readonly IApplicationDbContext _context;

        public IList<GetBuildingElementsWithSpaces> BuildingElementsList { get; set; }

        public IndexModel(ApplicationDbContext context)
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
