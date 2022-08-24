using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceTemperaturesCQR.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.SpaceTemperaturesCQR.Commands
{
    public class EditSpaceTemperature
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public EditSpaceTemperature(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SpaceTemperaturesDto GetSpaceTemperaturesDto(int id)
        {
            var getSpaceTemperaturesDto = new GetSpaceTemperatures(_context, _mapper);
            var spaceTemperatureList = getSpaceTemperaturesDto.SpaceTemperaturesDto;
            SpaceTemperaturesDto spaceTemperatureDto = spaceTemperatureList.FirstOrDefault(x => x.Id == id);
            return spaceTemperatureDto;
        }

        public void ModifySpaceTemperature(SpaceTemperaturesDto spaceTemperatureDto)
        {
            SpaceTemperatures spaceTemperature = _mapper.Map<SpaceTemperatures>(spaceTemperatureDto);
            _context.SpaceTemperatures.Update(spaceTemperature);
        }
    }
}
