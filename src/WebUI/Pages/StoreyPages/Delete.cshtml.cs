using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreyCQR.Commands;
using Application.StoreyCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.StoreyPages
{
	public class DeleteModel : PageModel
	{
		[BindProperty]
		public StoreyDto StoreyDto { get; set; }
		private IApplicationDbContext _context;
		private IMapper _mapper;

		public DeleteModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task OnGetAsync(int id)
		{
			var getStorey = new GetStorey(_context, _mapper);
			StoreyDto = await getStorey.GetStoreyDtoAsync(id);

			if (StoreyDto == null)
			{
				RedirectToPage("Index");
			}

			Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var deleteStorey = new DeleteStorey(_context, _mapper);
			await deleteStorey.RemoveStoreyAsync(StoreyDto);

			return RedirectToPage("Index");
		}
	}
}
