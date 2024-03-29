using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ThermalResistanceCQR.Commands;
using Application.ThermalResistanceCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalResistancePages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public ThermalResistanceDto ThermalResistanceDto { get; set; }
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public DeleteModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task OnGet(int id)
        {
            var getThermalResistance = new GetThermalResistance(_context, _mapper);
            ThermalResistanceDto = await getThermalResistance.GetThermalResistanceDtoAsync(id);

            if (ThermalResistanceDto == null)
            {
                RedirectToPage("Index");
            }

            Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var deleteThermalResistance = new DeleteThermalResistance(_context);
            await deleteThermalResistance.RemoveThermalResistanceAsync(ThermalResistanceDto);

            return RedirectToPage("Index");
        }
    }
}
