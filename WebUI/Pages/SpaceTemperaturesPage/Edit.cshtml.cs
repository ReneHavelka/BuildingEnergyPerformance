using Application.Common.Models;
using Application.SpaceTemperaturesCQR.Commands;
using Application.StoreysCQR.Commands;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpaceTemperaturesPage
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public SpaceTemperaturesDto SpaceTemperatureDto { get; set; }

        ApplicationDbContext _context;
        IMapper _mapper;


        public EditModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var spaceTemperatureList = new EditSpaceTemperature(_context, _mapper);
            SpaceTemperatureDto = spaceTemperatureList.GetSpaceTemperatureDto(id);
        }

        public async Task<IActionResult> OnPost(SpaceTemperaturesDto SpaceTemperatureDto)
        {
            var editSpaceTemperature = new EditSpaceTemperature(_context, _mapper);
            await editSpaceTemperature.ModifySpaceTemperature(SpaceTemperatureDto);

            return RedirectToPage("Index");
        }
    }
}
