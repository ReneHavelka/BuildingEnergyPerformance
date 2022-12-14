using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.StoreysPages
{
	public class EditModel : PageModel
	{
		[BindProperty]
		public StoreysDto StoreyDto { get; set; }
		private IApplicationDbContext _context;
		private IMapper _mapper;

		public EditModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task OnGet(int id)
		{
			var getStorey = new GetStorey(_context, _mapper);
			StoreyDto = await getStorey.GetStoreyDtoAsync(id);
		}

		public async Task<IActionResult> OnPost()
		{
			var editStoreys = new EditStorey(_context, _mapper);
			await editStoreys.ModifyStoreyAsync(StoreyDto);

			return RedirectToPage("Index");
		}
	}
}
