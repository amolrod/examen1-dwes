using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamen.Models
{
    [Table("VENTA")]
    public class Venta
    {
        [Key]
        [Column("ID_VENTA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenta { get; set; }

        [Column("PRODUCTO")]
        [Required]
        public string Producto { get; set; }

        [Column("CANTIDAD")]
        [Required]
        public int Cantidad { get; set; }

        [Column("PRECIO")]
        [Required]
        public decimal Precio { get; set; }
    }
}
