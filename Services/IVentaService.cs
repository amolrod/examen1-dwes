using ProyectoExamen.DTOs;

namespace ProyectoExamen.Services
{
    public interface IVentaService
    {
        Task<IEnumerable<VentaDTO>> GetAllVentasAsync();
        Task<IEnumerable<VentaDTO>> GetVentasByProductoAsync(string producto);
        Task<(bool success, string message)> CreateVentaAsync(VentaDTO ventaDto);
        Task DeleteVentaAsync(int id);
    }
}
