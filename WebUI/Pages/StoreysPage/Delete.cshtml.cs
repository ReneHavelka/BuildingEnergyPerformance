using Application.Common.Models;
using Application.StoreysCQR.Commands;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.StoreysPage
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public StoreysDto StoreyDto { get; set; }
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public int _id;

        public DeleteModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var storeyDtoList = new DeleteStorey(_context, _mapper);
            StoreyDto = storeyDtoList.GetStorey(id);
        }

        public async Task<IActionResult> OnPost(StoreysDto StoreysDto)
        {
            var deleteStoreys = new DeleteStorey(_context, _mapper);
            deleteStoreys.RemoveStorey(StoreyDto);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
