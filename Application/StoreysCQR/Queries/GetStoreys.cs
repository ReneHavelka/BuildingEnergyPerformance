using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.StoreysCQR.Queries
{
    public class GetStoreys
    {
        public IList<StoreysDto> StoreysDto { get; set; }

        public GetStoreys(IApplicationDbContext context, IMapper mapper)
        {
            var list = context.Storeys.ToList();
            StoreysDto = mapper.Map<IList<StoreysDto>>(list);
        }

    }
}
