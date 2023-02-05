using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ThermalResistancesCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalResistancesPages
{
    public class IndexModel : PageModel
    {
		public IList<ThermalResistancesDto> ThermalResistanceList { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;

        public IndexModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

		public void OnGet()
        {
            var getThermalResistances = new GetThermalResistances(_context, _mapper);
            ThermalResistanceList = getThermalResistances.GetThermalResistanceDtoList();
		}
    }
}
