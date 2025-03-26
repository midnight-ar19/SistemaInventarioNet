using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EL
{
    [Table("Proveedores")]
    public class Proveedores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idproveedores { get; set; }

        [Required, StringLength(150)]
        [Column(name: "nombre_proveedor")]
        public string NombreProveedor { get; set; }

        [Required, StringLength(20)]
        [Column(name: "telefono")]
        public string TelefonoProveedor { get; set; }

        [Required, StringLength(100)]
        [Column(name: "email")]
        public string emailProveedor { get; set; }



    }
}
