using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ThermalConductivitiesCQR.Commands;
using Application.ThermalConductivitiesCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalConductivitiesPages
{
    public class EditModel : PageModel
    {
		[BindProperty]
		public ThermalConductivitiesDto ThermalConductivityDto { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;

        public EditModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

		public void OnGet(int id)
        {
            var getThermalConductivity = new GetThermalConductivity(_context, _mapper);
            ThermalConductivityDto = getThermalConductivity.GetThermalConductivityDto(id);
		}

        public async Task<IActionResult> OnPost()
        {
            var editThermalConductivity = new EditThermalConductivity(_context, _mapper);
            await editThermalConductivity.ModifyThermalConductivity(ThermalConductivityDto);

            return RedirectToPage("Index");
		}

    }
}
