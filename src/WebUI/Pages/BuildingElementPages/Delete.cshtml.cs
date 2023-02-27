using Application.BuildingElementCQR.Commands;
using Application.BuildingElementCQR.Queries;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.BuildingElementPages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public GetBuildingElementsWithSpaces BuildingElementWithSpace { get; set; }

        IApplicationDbContext _context;

        public DeleteModel(IApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            var getBuildingElement = new GetBuildingElementWithSpace(_context, id);
            BuildingElementWithSpace = getBuildingElement.GetBuildingElementWithSpaceDto();

            if (BuildingElementWithSpace == null)
            {
                return RedirectToPage("Index");
            }
            //?
            BuildingElementWithSpace.ContiguousSpaceName = "--Vonkajší priestor--";
            //?

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var deleteBuildingElement = new DeleteBuildingElement(_context);
            await deleteBuildingElement.RemoveBuildingElement(BuildingElementWithSpace);

            return RedirectToPage("Index");
        }
    }
}
