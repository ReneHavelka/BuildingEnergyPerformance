using Application.Common.Models;
using Application.SpacesCQR.Commands;
using Application.SpaceTemperaturesCQR.Queries;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace WebUI.Pages.SpacesPage
{
    public class CreateModel : PageModel
    {
        public SpacesDto SpaceDto { get; set; }
        public SelectList SpaceTemperaturesSelectList { get; set; }
        public SelectList StoreysSelectList { get; set; }

        ApplicationDbContext _context;
        IMapper _mapper;


        public CreateModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var storeysDtoList = new GetStoreys(_context, _mapper).StoreysDto;
            StoreysSelectList = new SelectList(storeysDtoList, "Id", "Name", 1);
            var spaceTemperaturesDtoList = new GetSpaceTemperatures(_context, _mapper).SpaceTemperaturesDto;
            for (int i = 0; i < spaceTemperaturesDtoList.Count; i++) { spaceTemperaturesDtoList[i].Name += ": " + spaceTemperaturesDtoList[i].Temperature + "�C"; }
            SpaceTemperaturesSelectList = new SelectList(spaceTemperaturesDtoList, "Temperature", "Name", 1);
        }

        public async Task<IActionResult> OnPost(SpacesDto SpaceDto)
        {
            var createSpace = new CreateSpace(SpaceDto, _mapper, _context);
            createSpace.AddSpace();
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}