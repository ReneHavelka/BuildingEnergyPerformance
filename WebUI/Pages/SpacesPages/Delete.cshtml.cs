using Application.Common.Interfaces;
using Application.SpacesCQR.Commands;
using Application.SpacesCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebUI.Pages.SpacesPages
{
    public class DeleteModel : PageModel
    {
        public GetSpacesWithStoreys SpaceWithStorey { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;

        [BindProperty]
        public int Id { get; set; }

        public DeleteModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void OnGet(int id)
        {
            var getSpaces = new GetSpaceWithStorey(_context, id);
            SpaceWithStorey = getSpaces.GetSpaceWithStoreyDto();
            Id = SpaceWithStorey.Id;
        }

        public async Task<IActionResult> OnPost()
        {
            var deleteSpace = new DeleteSpace(_context, _mapper);
            await deleteSpace.RemoveSpace(Id);

            return RedirectToPage("Index");
        }
    }
}
