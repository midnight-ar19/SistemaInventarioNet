using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("movimientos_inventario")]
    public class MovimientoInventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMovimiento { get; set; }

        [Required]
        [Column(name: "id_producto")]
        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        [Required, StringLength(7)]
        [Column(name: "tipo")]
        public string Tipo { get; set; }

        [Required]
        [Column(name: "cantidad")]
        public int Cantidad { get; set; }

        [Column(name: "fecha", TypeName = "datetime")]
        public DateTime Fecha { get; set; } = DateTime.Now; // Valor predeterminado en memoria

        [Column(name: "id_usuario")]
        public int? IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        [Column(name: "observacion")]
        public string Observacion { get; set; }
    }
}
