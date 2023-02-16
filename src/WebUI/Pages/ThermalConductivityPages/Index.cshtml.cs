using Application.Common.Interfaces;
using Application.Common.Models;
using Application.ThermalConductivityCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.ThermalConductivityPages
{
	public class IndexModel : PageModel
	{
		public IList<ThermalConductivitieDto> ThermalConductivitieList { get; set; }

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
