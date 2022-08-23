using Application.SpacesCQR.Commands;
using Application.SpacesCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebUI.Pages.SpacesPage
{
    public class DeleteModel : PageModel
    {
        public GetSpaces SpaceyWithStorey { get; set; }

        ApplicationDbContext _context;
        IMapper _mapper;

        [BindProperty]
        public int Id { get; set; }

        public DeleteModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void OnGet(int id)
        {
            var getSpaces = new DeleteSpace(_mapper, _context);
            SpaceyWithStorey = getSpaces.GetSpace(id);
            Id = id;
        }

        public async Task<IActionResult> OnPost()
        {
            Debug.WriteLine($"somar: {Id}");
            var createSpaces = new DeleteSpace(_mapper, _context);
            createSpaces.RemoveSpace(Id);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
