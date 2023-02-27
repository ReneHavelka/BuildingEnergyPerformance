using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreyCQR.Commands;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.StoreyPages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public StoreyDto StoreyDto { get; set; }
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public CreateModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            StoreyCommandValidator storeyCommandValidator = new(StoreyDto, _context);
            await storeyCommandValidator.ValidateAndThrowAsync(StoreyDto);

            var createStoreys = new CreateStorey(_context, _mapper);
            await createStoreys.AddStoreyAsync(StoreyDto);

            return RedirectToPage("Index");
        }
    }
}
