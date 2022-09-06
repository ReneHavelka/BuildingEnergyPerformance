using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SpaceTemperaturesCQR.Queries
{
    public class GetSpaceTemperatures
    {
        IApplicationDbContext _context;
        IMapper _mapper;
        public GetSpaceTemperatures(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IList<SpaceTemperaturesDto> GetSpaceTemperaturesDtoList()
        {
            var spaceTemperatures = _context.SpaceTemperatures;
            var spaceTemperaturesDto = _mapper.Map<IList<SpaceTemperaturesDto>>(spaceTemperatures);
            return spaceTemperaturesDto;
        }
    }
}
