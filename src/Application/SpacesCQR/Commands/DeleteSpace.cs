using Application.Common.Interfaces;
using Application.SpacesCQR.Queries;

namespace Application.SpacesCQR.Commands
{
	public class DeleteSpace
	{
		IApplicationDbContext _context;

		public DeleteSpace(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task RemoveSpace(GetSpacesWithStoreys spaceWithStorey)
		{
			var space = _context.Spaces.Find(spaceWithStorey.Id);
			_context.Spaces.Remove(space);
			await _context.SaveChangesAsync();
		}
	}
}
