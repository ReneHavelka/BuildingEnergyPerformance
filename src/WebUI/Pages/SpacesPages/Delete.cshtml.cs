using Application.Common.Interfaces;
using Application.SpacesCQR.Commands;
using Application.SpacesCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.SpacesPages
{
	public class DeleteModel : PageModel
	{
		[BindProperty]
		public GetSpacesWithStoreys SpaceWithStorey { get; set; }

		IApplicationDbContext _context;

		public DeleteModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
		}

		public async Task OnGet(int id)
		{
			var getSpaces = new GetSpaceWithStorey(_context, id);
			SpaceWithStorey = getSpaces.GetSpaceWithStoreyDto();

			if (SpaceWithStorey == null)
			{
				RedirectToPage("Index");
			}

			Page();
		}

		public async Task<IActionResult> OnPost()
		{
			var deleteSpace = new DeleteSpace(_context);
			await deleteSpace.RemoveSpaceAsync(SpaceWithStorey);

			return RedirectToPage("Index");
		}
	}
}
