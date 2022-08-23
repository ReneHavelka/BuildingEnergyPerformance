using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.StoreysCQR.Commands
{
    public class CreateStorey
    {
        private StoreysDto _storeyDto;
        private IMapper _mapper;
        IApplicationDbContext _context;
        public CreateStorey(StoreysDto storeyDto, IMapper mapper, IApplicationDbContext context)
        {
            _storeyDto = storeyDto;
            _mapper = mapper;
            _context = context;
        }


        public async void AddStorey()
        {
            Storeys storey = _mapper.Map<Storeys>(_storeyDto);
            await _context.Storeys.AddAsync(storey);
        }
    }
}
