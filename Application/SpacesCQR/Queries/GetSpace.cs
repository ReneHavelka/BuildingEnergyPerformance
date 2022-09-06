using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SpacesCQR.Queries
{
    public class GetSpace
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public GetSpace(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SpacesDto GetSpaceDto(int id)
        {
            var space = _context.Spaces.Find(id);
            var spaceDto = _mapper.Map<SpacesDto>(space);
            return spaceDto;
        }
    }
}
