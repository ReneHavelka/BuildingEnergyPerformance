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

        public void OnGet(int id)
        {
            var storeyDtoList = new GetStorey(_context, _mapper);
            StoreyDto = storeyDtoList.GetStoreyDto(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var deleteStoreys = new DeleteStorey(_context);
            await deleteStoreys.RemoveStorey(StoreyDto);

            return RedirectToPage("Index");
        }
    }
}
