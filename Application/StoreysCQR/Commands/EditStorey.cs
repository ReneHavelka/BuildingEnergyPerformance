using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.StoreysCQR.Commands
{
    public class EditStorey
    {
        IApplicationDbContext _context;
        IMapper _mapper;
        public EditStorey(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public StoreysDto GetStorey(int id)
        {
            var getStoreys = new GetStoreys(_context, _mapper);
            var storeyList = getStoreys.StoreysDto;
            StoreysDto storeyDto = storeyList.FirstOrDefault(x => x.Id == id);
            return storeyDto;
        }
        
        public void ModifyStorey(StoreysDto storeyDto)
        {
            Storeys storey = _mapper.Map<Storeys>(storeyDto);
            _context.Storeys.Update(storey);
        }
    }
}
