using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StoreysCQR.Queries
{
    public class GetStorey
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public GetStorey(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public StoreysDto GetStoreyDto(int id)
        {
            var storey = _context.Storeys.Find(id);
            var storeyDto = _mapper.Map<StoreysDto>(storey);
            return storeyDto;
        }
    }
}
