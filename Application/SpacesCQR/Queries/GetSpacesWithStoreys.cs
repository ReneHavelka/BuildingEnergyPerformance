using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.SpacesCQR.Queries
{
    public class GetSpacesWithStoreys : IdNameDto
    {
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

            IList<GetSpacesWithStoreys> spacesWithStoreysDto = spacesQueryable.ToList();

            return spacesWithStoreysDto;
        }
    }
}
