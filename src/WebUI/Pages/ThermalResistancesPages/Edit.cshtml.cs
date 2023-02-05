using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ThermalResistancesCQR.Commands;
using Application.ThermalResistancesCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalResistancesPages
{
    public class EditModel : PageModel
    {
		[BindProperty]
		public ThermalResistancesDto ThermalResistanceDto { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;

        public EditModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

		public async Task OnGet(int id)
        {
            var getThermalResistance = new GetThermalResistance(_context, _mapper);
            ThermalResistanceDto = await getThermalResistance.GetThermalResistanceDtoAsync(id);
		}

        public async Task<IActionResult> OnPost()
        {
            var editThermalResistance = new EditThermalResistance(_context, _mapper);
            await editThermalResistance.ModifyThermalResistanceAsync(ThermalResistanceDto);

            return RedirectToPage("Index");
		}

    }
}
