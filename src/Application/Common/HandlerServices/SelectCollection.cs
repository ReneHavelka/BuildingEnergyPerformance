using Application.BuildingElementCQR.Queries;
using Application.Common.Interfaces;
using Application.SpaceCQR.Queries;
using AutoMapper;

namespace Application.Common.HandlerServices
{
	public class SelectCollection
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public SelectCollection(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public object GetCollection(string nextCategory, int selectedValue)
		{
			object selectedCollection = null;

			switch (nextCategory)
			{
				case "spaces":
					var spacesDtoList = new GetSpaces(_context, _mapper).GetSpaceDtoList();
					selectedCollection = spacesDtoList.Where(x => x.StoreyId == selectedValue).Select(x => new { x.Id, x.Name });
					break;
				case "buildingElements":
					var buildingElementsDtoList = new GetBuildingElements(_context, _mapper).GetBuildingElementDtoList();
					selectedCollection = buildingElementsDtoList.Where(x => x.SpaceId == selectedValue).Select(x => new { x.Id, x.Name });
					break;
			}

			return selectedCollection;
		}
	}
}
