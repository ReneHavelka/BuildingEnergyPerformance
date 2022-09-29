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

        public DeleteSpaceTemperature(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RemoveSpaceTemperature(SpaceTemperaturesDto spaceTemperatureDto)
        {
            int id = spaceTemperatureDto.Id;
            var spaceTemperature = _context.SpaceTemperatures.Find(id);
            _context.SpaceTemperatures.Remove(spaceTemperature);
            await _context.SaveChangesAsync();
        }
    }
}
