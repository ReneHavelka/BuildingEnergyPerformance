using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceTemperatureCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpaceTemperaturePages
{
	public class IndexModel : PageModel
	{
		public IList<SpaceTemperatureDto> SpaceTemperatureList { get; set; }

		private IApplicationDbContext _context;
		private IMapper _mapper;
		public IndexModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public void OnGet()
		{
			var getSpacesTemperatures = new GetSpaceTemperatures(_context, _mapper);
			SpaceTemperatureList = getSpacesTemperatures.GetSpaceTemperaturesDtoList();
		}
	}
}
