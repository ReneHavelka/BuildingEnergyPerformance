using Application.Common.Models;
using Application.StoreysCQR.Commands;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.StoreysPage
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public StoreysDto StoreyDto { get; set; }
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public int _id;

        public EditModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void OnGet(int id)
        {
            var getStoreys = new GetStoreys(_context, _mapper);
            var storeyList = getStoreys.StoreysDto;
            _id = id;
            StoreyDto = storeyList.FirstOrDefault(x => x.Id == _id);
        }

        public async Task<IActionResult> OnPost(StoreysDto StoreysDto)
        {
            var createStoreys = new EditStorey(StoreyDto, _mapper, _context);
            createStoreys.ModifyStorey(StoreyDto);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
