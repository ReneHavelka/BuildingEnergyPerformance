using Application.Common.Interfaces;

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
            var listSpaces = context.Spaces.ToList();
            var listStoreys = context.Storeys.ToList();

            var spacesEnumerable = from sp in listSpaces
                                   join st in listStoreys
                                   on sp.StoreysId equals st.Id
                                   select new GetSpacesWithStoreys() { Id = sp.Id, Name = sp.Name, Temperature = sp.Temperature, StoreyName = st.Name };

            IList<GetSpacesWithStoreys> spacesDto = spacesEnumerable.ToList();

            return spacesDto;
        }
    }
}
