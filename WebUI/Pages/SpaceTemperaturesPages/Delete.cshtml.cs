using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Commands;
using Application.SpacesCQR.Queries;
using Application.SpaceTemperaturesCQR.Commands;
using Application.SpaceTemperaturesCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebUI.Pages.SpaceTemperaturesPages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public SpaceTemperaturesDto SpaceTemperatureDto { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;

        public DeleteModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var spaceTemperatureList = new GetSpaceTemperature(_context, _mapper);
            SpaceTemperatureDto = spaceTemperatureList.GetSpaceTemperatureDto(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var deleteSpaceTemperature = new DeleteSpaceTemperature(_context, _mapper);
            await deleteSpaceTemperature.RemoveSpaceTemperature(SpaceTemperatureDto);

            return RedirectToPage("Index");
        }
    }
}
