using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.SpacesCQR.Queries
{
    public class GetSpacesWithStoreys
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Temperature { get; set; }
        public string StoreyName { get; set; }


        public IList<GetSpacesWithStoreys> GetSpacesWithStoreysList(IApplicationDbContext context)
        {
            var spaces = context.Spaces;
            var storeys = context.Storeys;

            var spacesQueryable = from sp in spaces
                                  join st in storeys
                                  on sp.StoreysId equals st.Id
                                  select new GetSpacesWithStoreys() { Id = sp.Id, Name = sp.Name, Temperature = sp.Temperature, StoreyName = st.Name };

            IList<GetSpacesWithStoreys> spacesDto = spacesQueryable.ToList();

            return spacesDto;
        }
    }
}
