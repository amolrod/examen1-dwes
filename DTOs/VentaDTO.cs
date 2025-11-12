namespace ProyectoExamen.DTOs
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal => Cantidad * Precio;
    }
}
