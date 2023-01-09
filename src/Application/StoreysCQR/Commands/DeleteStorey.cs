using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.StoreysCQR.Commands
{
	public class DeleteStorey
	{
		IApplicationDbContext _context;

		public DeleteStorey(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task RemoveStoreyAsync(StoreysDto storeyDto)
		{
			int id = storeyDto.Id;
			var storey = _context.Storeys.Find(id);
			_context.Storeys.Remove(storey);
			Task saveChanges = _context.SaveChangesAsync();
			await saveChanges;
		}
	}
}
