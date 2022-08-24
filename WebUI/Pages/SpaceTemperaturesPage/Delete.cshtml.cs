using Application.Common.Models;
using Application.SpacesCQR.Commands;
using Application.SpacesCQR.Queries;
using Application.SpaceTemperaturesCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebUI.Pages.SpaceTemperaturesPage
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public SpaceTemperaturesDto SpaceTemperatureDto { get; set; }

        ApplicationDbContext _context;
        IMapper _mapper;

        public DeleteModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var spaceTemperatureList = new DeleteSpaceTemperature(_context, _mapper);
            SpaceTemperatureDto = spaceTemperatureList.GetSpaceTemperatureDto(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var deleteSpaceTemperature = new DeleteSpaceTemperature(_context, _mapper);
            deleteSpaceTemperature.RemoveSpaceTemperature(SpaceTemperatureDto);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
