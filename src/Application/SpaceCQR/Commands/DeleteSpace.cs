using Application.Common.Interfaces;
using Application.SpaceCQR.Queries;

namespace Application.SpaceCQR.Commands
{
    public class DeleteSpace
    {
        IApplicationDbContext _context;

        public DeleteSpace(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RemoveSpaceAsync(GetSpacesWithStoreys spaceWithStorey)
        {
            var space = _context.Spaces.Find(spaceWithStorey.Id);
            _context.Spaces.Remove(space);
            await _context.SaveChangesAsync();
        }
    }
}
