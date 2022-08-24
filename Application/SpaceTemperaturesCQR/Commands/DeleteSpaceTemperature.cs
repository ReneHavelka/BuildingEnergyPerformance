using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceTemperaturesCQR.Queries;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SpaceTemperaturesCQR.Commands
{
    public class DeleteSpaceTemperature
    {
        SpaceTemperaturesDto _spaceTemperatureDto;
        private IMapper _mapper;
        IApplicationDbContext _context;

        public DeleteSpaceTemperature(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public SpaceTemperaturesDto GetSpaceTemperatureDto(int id)
        {
            var getSpaceTemperatures = new GetSpaceTemperatures(_context, _mapper);
            var spaceTemperatureList = getSpaceTemperatures.SpaceTemperaturesDto;
            SpaceTemperaturesDto spaceTemperatureDto = spaceTemperatureList.FirstOrDefault(x => x.Id == id);
            return spaceTemperatureDto;
        }

        public void RemoveSpaceTemperature(SpaceTemperaturesDto spaceTemperatureDto)
        {
            SpaceTemperatures spaceTemperature = _mapper.Map<SpaceTemperatures>(spaceTemperatureDto);
            _context.SpaceTemperatures.Remove(spaceTemperature);
        }
    }
}
