using Application.Common.Interfaces;
using Application.LayersCQR.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.LayersPages
{
    public class IndexModel : PageModel
    {
        IApplicationDbContext _context;
        public IList<GetLayersWithBuildingElements>  LayersList { get; set; }

        public IndexModel(IApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var getLayers = new GetLayersWithBuildingElements();
            LayersList = getLayers.GetLayersWithBuildingElementsList(_context);
        }


    }
}
