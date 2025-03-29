using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("inventario")]
    public class Inventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInventario { get; set; }

        [Required]
        [Column(name: "id_producto")]
        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        [Required]
        [Column(name: "stock")]
        public int Stock { get; set; } = 0; 

        [Required]
        [Column(name: "stock_minimo")]
        public int StockMinimo { get; set; } = 5;
    }
}
