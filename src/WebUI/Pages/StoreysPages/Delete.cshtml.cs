using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.StoreysPages
{
	public class DeleteModel : PageModel
	{
		[BindProperty]
		public StoreysDto StoreyDto { get; set; }
		private IApplicationDbContext _context;
		private IMapper _mapper;

		public DeleteModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task OnGet(int id)
		{
			var getStorey = new GetStorey(_context, _mapper);
			StoreyDto = await getStorey.GetStoreyDtoAsync(id);

			if (StoreyDto == null)
			{
				RedirectToPage("Index");
			}

			Page();
		}

		public async Task<IActionResult> OnPost()
		{
			var deleteStorey = new DeleteStorey(_context);
			await deleteStorey.RemoveStoreyAsync(StoreyDto);

			return RedirectToPage("Index");
		}
	}
}
