using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SpaceTemperaturesCQR.Commands
{
    public class CreateSpaceTemperature

    {
        private SpaceTemperaturesDto _spaceTemperatureDto;
        private IMapper _mapper;
        IApplicationDbContext _context;
        public CreateSpaceTemperature(SpaceTemperaturesDto spaceTemperatureDto, IMapper mapper, IApplicationDbContext context)
        {
            _spaceTemperatureDto = spaceTemperatureDto;
            _mapper = mapper;
            _context = context;
        }

        public async Task AddSpaceTemperature()
        {
            SpaceTemperatures spaceTemperatures = _mapper.Map<SpaceTemperatures>(_spaceTemperatureDto);
            await _context.SpaceTemperatures.AddAsync(spaceTemperatures);
            await _context.SaveChangesAsync();
        }
    }
}
