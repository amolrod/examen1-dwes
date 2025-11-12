using ProyectoExamen.Models;

namespace ProyectoExamen.Repositories
{
    public interface IVentaRepository
    {
        Task<IEnumerable<Venta>> GetAllAsync();
        Task<IEnumerable<Venta>> GetByProductoAsync(string producto);
        Task<Venta> GetByIdAsync(int id);
        Task AddAsync(Venta venta);
        Task DeleteAsync(int id);
    }
}
