using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System.Diagnostics;

namespace Application.StoreysCQR.Commands
{
	public class CreateStorey
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public CreateStorey(IApplicationDbContext context, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task AddStorey(StoreysDto storeyDto)
		{
			//Exception - the name of the storey should not be null or empty.
			if (storeyDto.Name == null || storeyDto.Name == String.Empty) throw new ArgumentException($"Storey name must not be null or empty.");
			//Exception - the name must consist of 4 characters at least.
			if (storeyDto.Name.Length < 4) throw new ArgumentException("Storey name must consist of 4 characters at least.");
			//Exception - the name must beginn with a capital letter.
			var firstChar = storeyDto.Name[0];
			if (!char.IsLetter(firstChar) || !char.IsUpper(firstChar)) throw new ArgumentException("The name of the storey must beginn with a capital letter.");
			//Exception - the name must cosist of the maximum of 14 characters.
			if (storeyDto.Name.Length > 14) throw new ArgumentException("Storey name must consist of the maximum of 14 characters.");

			Storeys storey = _mapper.Map<Storeys>(storeyDto);
			await _context.Storeys.AddAsync(storey);
			await _context.SaveChangesAsync();
		}
	}
}
