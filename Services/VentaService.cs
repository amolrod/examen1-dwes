using ProyectoExamen.DTOs;
using ProyectoExamen.Models;
using ProyectoExamen.Repositories;

namespace ProyectoExamen.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _repository;

        public VentaService(IVentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VentaDTO>> GetAllVentasAsync()
        {
            var ventas = await _repository.GetAllAsync();
            return ventas.Select(v => new VentaDTO
            {
                IdVenta = v.IdVenta,
                Producto = v.Producto,
                Cantidad = v.Cantidad,
                Precio = v.Precio
            });
        }

        public async Task<IEnumerable<VentaDTO>> GetVentasByProductoAsync(string producto)
        {
            var ventas = await _repository.GetByProductoAsync(producto);
            return ventas.Select(v => new VentaDTO
            {
                IdVenta = v.IdVenta,
                Producto = v.Producto,
                Cantidad = v.Cantidad,
                Precio = v.Precio
            });
        }

        public async Task<(bool success, string message)> CreateVentaAsync(VentaDTO ventaDto)
        {
            var venta = new Venta
            {
                Producto = ventaDto.Producto,
                Cantidad = ventaDto.Cantidad,
                Precio = ventaDto.Precio
            };

            await _repository.AddAsync(venta);
            return (true, "Venta creada correctamente");
        }

        public async Task DeleteVentaAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
