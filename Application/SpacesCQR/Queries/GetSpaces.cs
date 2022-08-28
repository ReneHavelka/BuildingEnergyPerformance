using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.SpacesCQR.Queries
{
    public class GetSpaces
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public GetSpaces(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 
        public IList<SpacesDto> GetSpaceList()
        {
            var spaces = _context.Spaces;
            var spacesDto = _mapper.Map<IList<SpacesDto>>(spaces);
            
            return spacesDto;
        }

    }
}
