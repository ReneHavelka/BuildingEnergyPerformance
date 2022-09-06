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
            _context = context;
            _mapper = mapper;
        }
        
        public async Task ModifyStorey(StoreysDto storeyDto)
        {
            Storeys storey = _mapper.Map<Storeys>(storeyDto);
            _context.Storeys.Update(storey);
            await _context.SaveChangesAsync();
        }
    }
}
