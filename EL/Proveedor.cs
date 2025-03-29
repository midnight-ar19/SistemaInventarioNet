using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EL
{
    [Table("proveedores")]
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProveedor { get; set; }

        [Required, StringLength(100)]
        [Column(name: "nombre")]
        public string Nombre { get; set; }

        [StringLength(100)]
        [Column(name: "contacto")]
        public string Contacto { get; set; }

        [StringLength(20)]
        [Column(name: "telefono")]
        public string Telefono { get; set; }

        [Column(name: "direccion")]
        public string Direccion { get; set; }
    }
}
