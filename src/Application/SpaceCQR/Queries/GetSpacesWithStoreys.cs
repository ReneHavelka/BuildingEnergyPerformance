using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.SpaceCQR.Queries
{
    public record GetSpacesWithStoreys : IdNameDto
    {
        public float Temperature { get; set; }
        public string StoreyName { get; set; }


        public IList<GetSpacesWithStoreys> GetSpacesWithStoreysList(IApplicationDbContext context)
        {
            var spaces = context.Spaces;
            var storeys = context.Storeys;

            var spacesQueryable = from sp in spaces
                                  join st in storeys
                                  on sp.StoreyId equals st.Id
                                  select new GetSpacesWithStoreys() { Id = sp.Id, Name = sp.Name, Temperature = sp.Temperature, StoreyName = st.Name };

            IList<GetSpacesWithStoreys> spacesWithStoreysDto = spacesQueryable.ToList();

            return spacesWithStoreysDto;
        }
    }
}
