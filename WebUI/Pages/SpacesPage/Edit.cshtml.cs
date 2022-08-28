using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Commands;
using Application.SpacesCQR.Queries;
using Application.SpaceTemperaturesCQR.Queries;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Pages.SpacesPage
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public SpacesDto SpaceDto { get; set; }
        public SelectList SpaceTemperaturesSelectList { get; set; }
        public SelectList StoreysSelectList { get; set; }

        ApplicationDbContext _context;
        IMapper _mapper;

        public int _id;

        public EditModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void OnGet(int id)
        {
            var spaceTemperaturesDtoList = new GetSpaceTemperatures(_context, _mapper).SpaceTemperaturesDto;
            for (int i = 0; i < spaceTemperaturesDtoList.Count; i++) { spaceTemperaturesDtoList[i].Name += ": " + spaceTemperaturesDtoList[i].Temperature + "°C"; }
            SpaceTemperaturesSelectList = new SelectList(spaceTemperaturesDtoList, "Temperature", "Name", 1);
            SpaceDto = new EditSpace(_context, _mapper).GetSpace(id);
            var storeysDtoList = new GetStoreys(_context, _mapper).StoreysDto;
            StoreysSelectList = new SelectList(storeysDtoList, "Id", "Name", SpaceDto.StoreysId);
        }

        public async Task<IActionResult> OnPost()
        {
            var editSpace = new EditSpace(_context, _mapper);
            await editSpace.ModifySpace(SpaceDto);

            return RedirectToPage("Index");
        }
    }
}
