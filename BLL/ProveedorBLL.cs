using DAL;
using EL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BLL
{
    public class ProveedorBLL
    {
        public static List<Proveedor> ObtenerTodos()
        {
            using (var db = new InventarioDbContext())
            {
                return db.Proveedores.ToList();
            }
        }
    }
}

