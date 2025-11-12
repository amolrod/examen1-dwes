using Microsoft.EntityFrameworkCore;
using ProyectoExamen.Data;
using ProyectoExamen.Models;

namespace ProyectoExamen.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly ApplicationDbContext _context;

        public VentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            return await _context.Ventas.ToListAsync();
        }

        public async Task<IEnumerable<Venta>> GetByProductoAsync(string producto)
        {
            return await _context.Ventas
                .Where(v => v.Producto.Contains(producto))
                .ToListAsync();
        }

        public async Task<Venta> GetByIdAsync(int id)
        {
            return await _context.Ventas.FindAsync(id);
        }

        public async Task AddAsync(Venta venta)
        {
            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var venta = await GetByIdAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
