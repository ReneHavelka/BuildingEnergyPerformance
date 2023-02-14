using Application.Common.Interfaces;
using Application.LayerCQR.Queries;

namespace Application.LayerCQR.Commands
{
	public class DeleteLayer
	{
		IApplicationDbContext _context;

		public DeleteLayer(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task RemoveLayer(GetLayersWithBuildingElements LayerDto)
		{
			var layer = _context.Layers.Find(LayerDto.Id);
			_context.Layers.Remove(layer);
			await _context.SaveChangesAsync();

		}
	}
}
