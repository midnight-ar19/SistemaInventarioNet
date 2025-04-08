using DAL;
using EL;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class ProveedorBLL
    {
        public static List<Proveedor> ObtenerTodos()
        {
            using (var db = new AppDbContext())
            {
                return db.Proveedores.ToList();
            }
        }
    }
}

