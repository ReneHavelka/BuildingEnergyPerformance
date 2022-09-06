using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpaceTemperaturesCQR.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.SpaceTemperaturesCQR.Commands
{
    public class DeleteSpaceTemperature
    {
        IApplicationDbContext _context;
        private IMapper _mapper;

        public DeleteSpaceTemperature(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task RemoveSpaceTemperature(SpaceTemperaturesDto spaceTemperatureDto)
        {
            SpaceTemperatures spaceTemperature = _mapper.Map<SpaceTemperatures>(spaceTemperatureDto);
            _context.SpaceTemperatures.Remove(spaceTemperature);
            await _context.SaveChangesAsync();
        }
    }
}
