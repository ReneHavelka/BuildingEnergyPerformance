using Application.Common.Interfaces;
using Application.SpaceCQR.Queries;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpacePages
{
	public class IndexModel : PageModel
	{
		private readonly IApplicationDbContext _context;

		public IList<GetSpacesWithStoreys> SpaceysList { get; set; }
		public IndexModel(IApplicationDbContext context)
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
