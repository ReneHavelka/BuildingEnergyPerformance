using Application.Common.Interfaces;

namespace Application.SpaceCQR.Queries
{
	public class GetSpaceWithStorey
	{
		IApplicationDbContext _context;
		int _id;

		public GetSpaceWithStorey(IApplicationDbContext context, int id)
		{
			_context = context;
			_id = id;
		}

		public GetSpacesWithStoreys GetSpaceWithStoreyDto()
		{
			var getSpacesWithStoreys = new GetSpacesWithStoreys();
			var getSpacesWithStoreysList = getSpacesWithStoreys.GetSpacesWithStoreysList(_context);
			var getSpaceWithStoreyDto = getSpacesWithStoreysList.FirstOrDefault(x => x.Id == _id);

			return getSpaceWithStoreyDto;
		}
	}
}
