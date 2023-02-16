using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreyCQR.Commands;
using Application.StoreyCQR.Queries;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.StoreyPages
{
	public class EditModel : PageModel
	{
		[BindProperty]
		public StoreyDto StoreyDto { get; set; }
		private IApplicationDbContext _context;
		private IMapper _mapper;

		public EditModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task OnGetAsync(int id)
		{
			var getStorey = new GetStorey(_context, _mapper);
			StoreyDto = await getStorey.GetStoreyDtoAsync(id);
		}

		public async Task<IActionResult> OnPostAsync()
		{
			StoreyCommandValidator storeyCommandValidator = new(StoreyDto, _context);
			await storeyCommandValidator.ValidateAndThrowAsync(StoreyDto);

			var editStoreys = new EditStorey(_context, _mapper);
			await editStoreys.ModifyStoreyAsync(StoreyDto);

			return RedirectToPage("Index");
		}
	}
}
