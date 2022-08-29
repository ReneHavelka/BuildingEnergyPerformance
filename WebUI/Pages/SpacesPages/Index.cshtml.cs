using Application.Common.Interfaces;
using Application.SpacesCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebUI.Pages.SpacesPages
{
    public class IndexModel : PageModel
    {
        private readonly IApplicationDbContext _context;

        public IList<GetSpacesWithStoreys> SpaceysList { get; set; }
        public IndexModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public void OnGet()
        {
            var getSpaces = new GetSpacesWithStoreys();
            SpaceysList = getSpaces.GetSpacesWithStoreysList(_context);
        }
    }
}
