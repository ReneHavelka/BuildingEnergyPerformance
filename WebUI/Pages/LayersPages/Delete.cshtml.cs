using Application.Common.Interfaces;
using Application.LayersCQR.Commands;
using Application.LayersCQR.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebUI.Pages.LayersPages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public GetLayersWithBuildingElements LayerWithBuildingElement { get; set; }

        IApplicationDbContext _context;

        public DeleteModel(IApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            var getLayer = new GetLayerWithBuildingElement(_context, id);
            LayerWithBuildingElement = getLayer.GetLayerWithBuildingElementDto();

            if (LayerWithBuildingElement == null)
            {
				return RedirectToPage("Index");
			}

            //?
            LayerWithBuildingElement.ContiguousSpaceName = "--Vonkajší priestor--";
            //?
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var deleteLayer = new DeleteLayer(_context);
            await deleteLayer.RemoveLayer(LayerWithBuildingElement);

            return RedirectToPage("Index");
        }
    }
}
