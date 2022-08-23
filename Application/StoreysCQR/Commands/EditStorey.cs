using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StoreysCQR.Commands
{
    public class EditStorey
    {
        private StoreysDto _storeyDto;
        private IMapper _mapper;
        IApplicationDbContext _context;
        public EditStorey(StoreysDto storeyDto, IMapper mapper, IApplicationDbContext context)
        {
            _storeyDto = storeyDto;
            _mapper = mapper;
            _context = context;
        }


        public async void ModifyStorey(StoreysDto storeyDto)
        {
            Storeys storey = _mapper.Map<Storeys>(storeyDto);
            _context.Storeys.Update(storey);
        }
    }
}
