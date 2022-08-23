using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Application.SpacesCQR.Queries
{
    public class GetSpaces
    {
        public int Id;
        public string Name;
        public float Temperature;
        public string StoreysName;

        public IApplicationDbContext _context;

        public IList<GetSpaces> GetSpacesWithStoreys(IApplicationDbContext context)
        {
            var listSpaces = context.Spaces.ToList();
            var listStoreys = context.Storeys.ToList();

            var spacesEnumerable = from sp in listSpaces
                                   join st in listStoreys
                                   on sp.StoreysId equals st.Id
                                   select new GetSpaces { Id = sp.Id, Name = sp.Name, Temperature = sp.Temperature, StoreysName = st.Name };

            IList<GetSpaces> spacesDto = spacesEnumerable.ToList();

            return spacesDto;
        }

    }
}
