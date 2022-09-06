using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Queries;
using Application.SpaceTemperaturesCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpaceTemperaturesPages
{
    public class IndexModel : PageModel
    {
        public IList<SpaceTemperaturesDto> SpaceTemperatureList { get; set; }
        
        private IApplicationDbContext _context;
        private IMapper _mapper;
        public IndexModel(ApplicationDbContext context, IMapper mapper)
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
