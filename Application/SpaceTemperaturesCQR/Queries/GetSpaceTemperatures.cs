using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SpaceTemperaturesCQR.Queries
{
    public class GetSpaceTemperatures
    {
        public IList<SpaceTemperaturesDto> SpaceTemperaturesDto { get; set; }

        public GetSpaceTemperatures(IApplicationDbContext context, IMapper mapper)
        {
            var list = context.SpaceTemperatures.ToList();
            SpaceTemperaturesDto = mapper.Map<IList<SpaceTemperaturesDto>>(list);
        }
    }
}
