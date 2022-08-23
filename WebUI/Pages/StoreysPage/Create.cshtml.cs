using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.StoreysPage
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public StoreysDto StoreyDto { get; set; }
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CreateModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(StoreysDto StoreysDto)
        {
            var createStoreys = new CreateStorey(StoreyDto, _mapper, _context);
            createStoreys.AddStorey();
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
