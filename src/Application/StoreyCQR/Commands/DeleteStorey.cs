using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System.Diagnostics;

namespace Application.StoreyCQR.Commands
{
	public class DeleteStorey
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public DeleteStorey(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task RemoveStoreyAsync(StoreyDto storeyDto)
		{
			Storey storey = _mapper.Map<Storey>(storeyDto);

			_context.Storeys.Remove(storey);
			Task saveChanges = _context.SaveChangesAsync();
			await saveChanges;
		}
	}
}
