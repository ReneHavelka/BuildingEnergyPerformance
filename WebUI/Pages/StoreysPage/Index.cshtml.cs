using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebUI.Pages.StoreysPage
{
    public class IndexModel : PageModel
    {
        private readonly IApplicationDbContext _context;
        private IMapper _mapper;

        public IEnumerable<StoreysDto> StoreyList { get; set; }
        public IndexModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var getStoreys = new GetStoreys(_context, _mapper);
            StoreyList = getStoreys.StoreysDto;
        }
    }
}
