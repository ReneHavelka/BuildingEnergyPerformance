using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.StoreysCQR.Commands
{
    public class DeleteStorey
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public DeleteStorey(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RemoveStorey(StoreysDto storeyDto)
        {
            int id = storeyDto.Id;
            var storey = _context.Storeys.Find(id);
            _context.Storeys.Remove(storey);
            await _context.SaveChangesAsync();
        }
    }
}
