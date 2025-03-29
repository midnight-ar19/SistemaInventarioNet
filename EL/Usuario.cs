using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required, StringLength(100)]
        [Column(name: "nombre")]
        public string Nombre { get; set; }

        [Required, StringLength(50)]
        [Column(name: "usuario")]
        [Index(IsUnique = true)]
        public string UsuarioNombre { get; set; }

        [Required, StringLength(255)]
        [Column(name: "contrasena")]
        public string Contrasena { get; set; }

        [Required, StringLength(10)]
        [Column(name: "rol")]
        public string Rol { get; set; }
    }
}
