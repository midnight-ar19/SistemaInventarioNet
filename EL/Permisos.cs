using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("Pernmisos")]
    public class Permisos
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPermiso { get; set; }

        [Required, StringLength(100)]
        [Column(name: "nombre_permiso")]
        public string nomnre_permiso { get; set; }
    }
}
