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
    public class EditModel : PageModel
    {
        public BuildingElementsDto BuildingElementDto { get; set; }
        public SelectList StoreySelectList { get; set; }
        public SelectList ContiguousSpaceSelectList { get; set; }

        IApplicationDbContext _context;
        IMapper _mapper;


        public EditModel(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var storeysDtoList = new GetStoreys(_context, _mapper).GetStoreyDtoList();
            StoreySelectList = new SelectList(storeysDtoList, "Id", "Name");
        }

        public JsonResult OnGetCollection(string selectedCategory, int selectedValue)
        {
            object selectedCollection = null;

            switch (selectedCategory)
            {
                case "spaces":
                    var spacesDtoList = new GetSpaces(_context, _mapper).GetSpaceDtoList();
                    selectedCollection = spacesDtoList.Where(x => x.StoreysId == selectedValue).Select(x => new { x.Id, x.Name });
                    break;
            }

            return new JsonResult(selectedCollection);
        }

        //public async Task<IActionResult> OnPost(BuildingElementsDto BuildingElementDto)
        //{
            
        //        Debug.WriteLine(BuildingElementDto.Name);
            
            
        //    var editBuildingElement = new EditBuildingElement(_context, _mapper);
        //    await editBuildingElement.AddBuildingElement(BuildingElementDto);

        //    return RedirectToPage("Index");
        //}
    }
}
