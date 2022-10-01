using Application.BuildingElementsCQR.Commands;
using Application.BuildingElementsCQR.Queries;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Commands;
using Application.SpacesCQR.Queries;
using Application.StoreysCQR.Queries;
using Application.ThermalResistancesCQR.Queries;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace WebUI.Pages.BuildingElementsPages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public GetBuildingElementsWithSpaces BuildingElementWithSpace { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;


        public DeleteModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet(int id)
        {
            var getBuildingElement = new GetBuildingElementWithSpace(_context, id);
            BuildingElementWithSpace = getBuildingElement.GetBuildingElementWithSpaceDto();

            //?
            BuildingElementWithSpace.ContiguousSpaceName = "--Vonkajší priestor--";
            //?
        }

        public async Task<IActionResult> OnPost()
        {
            var deleteBuildingElement = new DeleteBuildingElement(_context);
            await deleteBuildingElement.RemoveBuildingElement(BuildingElementWithSpace);

            return RedirectToPage("Index");
        }
    }
}
