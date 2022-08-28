using Application.Common.Models;
using Application.SpaceTemperaturesCQR.Commands;
using Application.SpaceTemperaturesCQR.Queries;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Pages.SpaceTemperaturesPage
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public SpaceTemperaturesDto SpaceTemperatureDto { get; set; }

        ApplicationDbContext _context;
        IMapper _mapper;


        public CreateModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(SpaceTemperaturesDto SpaceTemperatureDto)
        {
            var createSpaceTemperature = new CreateSpaceTemperature(_context, _mapper);
            await createSpaceTemperature.AddSpaceTemperature(SpaceTemperatureDto);

            return RedirectToPage("Index");
        }
    }
}
