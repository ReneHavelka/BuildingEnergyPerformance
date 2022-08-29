using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.StoreysPages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public StoreysDto StoreyDto { get; set; }
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public CreateModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnPost(StoreysDto StoreysDto)
        {
            var createStoreys = new CreateStorey(_context, _mapper);
            await createStoreys.AddStorey(StoreyDto);

            return RedirectToPage("Index");
        }
    }
}
