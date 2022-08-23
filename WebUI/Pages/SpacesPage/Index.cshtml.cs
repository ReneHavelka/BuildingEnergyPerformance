using Application.Common.Interfaces;
using Application.SpacesCQR.Queries;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebUI.Pages.SpacesPage
{
    public class IndexModel : PageModel
    {
        private readonly IApplicationDbContext _context;

        public IEnumerable<GetSpaces> SpaceysList { get; set; }
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var getSpaces = new GetSpaces();
            SpaceysList = getSpaces.GetSpacesWithStoreys(_context);
        }
    }
}
