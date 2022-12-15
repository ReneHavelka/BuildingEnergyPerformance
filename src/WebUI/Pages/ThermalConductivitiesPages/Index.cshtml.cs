using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ThermalConductivitiesCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalConductivitiesPages
{
    public class IndexModel : PageModel
    {
		public IList<ThermalConductivitiesDto> ThermalConductivitieList { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;

        public IndexModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

		public void OnGet()
        {
            var getThermalConductivities = new GetThermalConductivities(_context, _mapper);
            ThermalConductivitieList = getThermalConductivities.GetThermalConductivitiesDtoList();
		}
    }
}
