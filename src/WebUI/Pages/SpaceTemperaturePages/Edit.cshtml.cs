using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceTemperatureCQR.Commands;
using Application.SpaceTemperatureCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpaceTemperaturePages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public SpaceTemperatureDto SpaceTemperatureDto { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;


        public EditModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var getSpaceTemperature = new GetSpaceTemperature(_context, _mapper);
            SpaceTemperatureDto = getSpaceTemperature.GetSpaceTemperatureDto(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var editSpaceTemperature = new EditSpaceTemperature(_context, _mapper);
            await editSpaceTemperature.ModifySpaceTemperature(SpaceTemperatureDto);

            return RedirectToPage("Index");
        }
    }
}
