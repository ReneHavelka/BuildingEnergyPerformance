using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StoreysCQR.Commands
{
    public class DeleteStorey
    {
        private StoreysDto _storeyDto;
        private IMapper _mapper;
        IApplicationDbContext _context;
        public DeleteStorey(IApplicationDbContext context, IMapper mapper)
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

        public async void RemoveStorey(StoreysDto storeyDto)
        {
            Storeys storey = _mapper.Map<Storeys>(storeyDto);
            _context.Storeys.Remove(storey);
        }
    }
}
