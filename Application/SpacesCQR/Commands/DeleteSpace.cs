using Application.Common.Interfaces;
using Application.Common.Models;
using Application.SpacesCQR.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.SpacesCQR.Commands
{
    public class DeleteSpace
    {
        private IMapper _mapper;
        IApplicationDbContext _context;

        public DeleteSpace(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public GetSpaces GetSpace(int id)
        {
            var getSpaceInst = new GetSpaces();
            GetSpaces getSpace = getSpaceInst.GetSpacesWithStoreys(_context).FirstOrDefault(x => x.Id == id);
            return getSpace;
        }

        public async void RemoveSpace(int id)
        {
            var space = _context.Spaces.Find(id);
            _context.Spaces.Remove(space);
        }
    }
}
