using Application.Common.Interfaces;

namespace Application.LayersCQR.Queries
{
	public class GetLayerWithBuildingElement
	{
		IApplicationDbContext _context;
		int _id;
		public GetLayerWithBuildingElement(IApplicationDbContext context, int id)
		{
			_context = context;
			_id = id;
		}

		public GetLayersWithBuildingElements GetLayerWithBuildingElementDto()
		{
			var getLayersWithBuildingElements = new GetLayersWithBuildingElements();
			var getLayersWithBuildingElementList = getLayersWithBuildingElements.GetLayersWithBuildingElementsList(_context);
			var getLayerWithBuildingElement = getLayersWithBuildingElementList.FirstOrDefault(x => x.Id == _id);
			return getLayerWithBuildingElement;
		}
	}
}
