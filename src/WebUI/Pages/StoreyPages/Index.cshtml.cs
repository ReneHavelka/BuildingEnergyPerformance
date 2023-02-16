using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreyCQR.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebUI.Pages.StoreyPages
{
	public class IndexModel : PageModel
	{
		private readonly IApplicationDbContext _context;
		private IMapper _mapper;

		public IList<StoreyDto> StoreyList { get; set; }
		public IndexModel(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task OnGetAsync()
		{
			var getStoreys = new GetStoreys(_context, _mapper);
			StoreyList = await getStoreys.GetStoreyDtoListAsync();
		}
	}
}
