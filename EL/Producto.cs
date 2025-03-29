using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EL
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }

        [Required, StringLength(100)]
        [Column(name: "nombre")]
        public string Nombre { get; set; }

        [Column(name: "descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Column(name: "precio_compra", TypeName = "decimal(10,2)")]
        public decimal PrecioCompra { get; set; }

        [Required]
        [Column(name: "precio_venta", TypeName = "decimal(10,2)")]
        public decimal PrecioVenta { get; set; }

        [Column(name: "id_categoria")]
        public int? IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }

        [Column(name: "id_proveedor")]
        public int? IdProveedor { get; set; }

        [ForeignKey("IdProveedor")]
        public virtual Proveedor Proveedor { get; set; }

        [Column(name: "id_marca")]
        public int? IdMarca { get; set; }

        [ForeignKey("IdMarca")]
        public virtual Marca Marca { get; set; }
    }
}
