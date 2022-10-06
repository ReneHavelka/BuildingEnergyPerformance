using Application.Common.Interfaces;
using Application.SpacesCQR.Queries;
using AutoMapper;

namespace Application.Common.HandlerServices
{
	public class SelectSpaceTemperature
	{
		GetSpace getSpace;
		public SelectSpaceTemperature(IApplicationDbContext context, IMapper mapper)
		{
			getSpace = new GetSpace(context, mapper);
		}

		public float GetSpaceTemperature(int id) 
		{
			var space = getSpace.GetSpaceDto(id);
			var temperature = space.Temperature;
			return temperature;
		}
	}
}
