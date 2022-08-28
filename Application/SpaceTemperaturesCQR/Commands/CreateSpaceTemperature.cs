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
        IApplicationDbContext _context;
        private IMapper _mapper;
        public CreateSpaceTemperature(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddSpaceTemperature(SpaceTemperaturesDto spaceTemperatureDto)
        {
            SpaceTemperatures spaceTemperatures = _mapper.Map<SpaceTemperatures>(spaceTemperatureDto);
            await _context.SpaceTemperatures.AddAsync(spaceTemperatures);
            await _context.SaveChangesAsync();
        }
    }
}
