using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.SpaceTemperatureCQR.Commands
{
    public class DeleteSpaceTemperature
    {
        IApplicationDbContext _context;

        public DeleteSpaceTemperature(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RemoveSpaceTemperature(SpaceTemperatureDto spaceTemperatureDto)
        {
            int id = spaceTemperatureDto.Id;
            var spaceTemperature = _context.SpaceTemperatures.Find(id);
            _context.SpaceTemperatures.Remove(spaceTemperature);
            await _context.SaveChangesAsync();
        }
    }
}
