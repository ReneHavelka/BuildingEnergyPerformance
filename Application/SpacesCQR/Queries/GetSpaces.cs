﻿using Application.Common.Interfaces;
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
	public class GetSpaces
	{
        IApplicationDbContext _context;
        IMapper _mapper;

        public GetSpaces(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<SpacesDto> GetSpaceDtoList()
        {
            var spaces = _context.Spaces;
            var spacesDto = _mapper.Map<IList<SpacesDto>>(spaces);
            return spacesDto;
        }
    }
}
