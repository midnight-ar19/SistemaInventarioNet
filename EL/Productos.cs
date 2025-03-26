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
    [Table("Productos")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [ForeignKey("Categoria")]
        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [ForeignKey("Marca")]
        [Column("marca_id")]
        public int MarcaId { get; set; }

        [Required]
        [Column("stock")]
        public int Stock { get; set; }

        [Required]
        [Column("precio", TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        [Column("fecha_creacion", TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación con Categoria
        public Categoria Categoria { get; set; }

        // Relación con Marca
        public Marcas Marca { get; set; }
    }
}
