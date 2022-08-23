using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpaceTemperaturesPage
{
    public class IndexModel : PageModel
    {
        public IEnumerable<SpaceTemperaturesDto> SpaceTemperatureList { get; set; }
        
        private readonly IApplicationDbContext _context;
        private IMapper _mapper;
        public IndexModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var getSpacesTemperatures = new GetSpacesTemperatures();
            SpaceTemperatureList = getSpacesTemperatures.GetSpacesWithStoreys(_context);
        }
    }
}
