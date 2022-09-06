using Application.BuildingElementsCQR.Queries;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Queries;
using Application.StoreysCQR.Queries;
using Application.ThermalResistancesCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace WebUI.Pages.BuildingElementsPages
{
    public class CreateModel : PageModel
    {
        public BuildingElementsDto BuildingElementDto { get; set; }
        public SelectList StoreySelectList { get; set; }
        [BindProperty]
        public SelectList SpaceSelectList { get; set; }
        public SelectList EmbededInSelectList { get; set; }
        public SelectList ThermalResistanceSelectList { get; set; }
        public SelectList ContiguousSpaceSelectList { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;


        public CreateModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var storeysDtoList = new GetStoreys(_context, _mapper).GetStoreyDtoList();
            StoreySelectList = new SelectList(storeysDtoList, "Id", "Name");
            var embededInDtoList = new GetBuildingElements(_context, _mapper).GetBuildingElementDtoList();
            EmbededInSelectList = new SelectList(embededInDtoList, "Id", "Name");
            var thermalResistanceDtoList = new GetThermalResistances(_context, _mapper).GetThermalResistanceDtoList();
            ThermalResistanceSelectList = new SelectList(thermalResistanceDtoList, "Id", "Name");
            ContiguousSpaceSelectList = SpaceSelectList;
        }

        public JsonResult OnGetTest()
        {
            var spacesDtoList = new GetSpaces(_context, _mapper).GetSpaceDtoList();
            var SpaceSelectCollection = spacesDtoList.Select(x => new { x.Id, x.Name });

            return new JsonResult(SpaceSelectCollection);
        }
    }
}
