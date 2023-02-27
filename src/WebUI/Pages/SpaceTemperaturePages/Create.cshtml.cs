using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceTemperatureCQR.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpaceTemperaturePages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public SpaceTemperatureDto SpaceTemperatureDto { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;


        public CreateModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnPost(SpaceTemperatureDto SpaceTemperatureDto)
        {
            var createSpaceTemperature = new CreateSpaceTemperature(_context, _mapper);
            await createSpaceTemperature.AddSpaceTemperature(SpaceTemperatureDto);

            return RedirectToPage("Index");
        }
    }
}
