using Application.Common.Interfaces;
using Application.SpacesCQR.Commands;
using Application.SpacesCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpacesPages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public GetSpacesWithStoreys SpaceWithStorey { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;

        public DeleteModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void OnGet(int id)
        {
            var getSpaces = new GetSpaceWithStorey(_context, id);
            SpaceWithStorey = getSpaces.GetSpaceWithStoreyDto();
        }

        public async Task<IActionResult> OnPost()
        {
            var deleteSpace = new DeleteSpace(_context);
            await deleteSpace.RemoveSpace(SpaceWithStorey);

            return RedirectToPage("Index");
        }
    }
}
