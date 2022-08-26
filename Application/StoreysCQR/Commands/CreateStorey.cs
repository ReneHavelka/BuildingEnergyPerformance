using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.StoreysCQR.Commands
{
    public class CreateStorey
    {
        private StoreysDto _storeyDto;
        IApplicationDbContext _context;
        private IMapper _mapper;
        
        public CreateStorey(StoreysDto storeyDto, IApplicationDbContext context, IMapper mapper)
        {
            _storeyDto = storeyDto;
            _mapper = mapper;
            _context = context;
        }


        public async Task AddStorey()
        {
            Storeys storey = _mapper.Map<Storeys>(_storeyDto);
            await _context.Storeys.AddAsync(storey);
            await _context.SaveChangesAsync();
        }
    }
}
