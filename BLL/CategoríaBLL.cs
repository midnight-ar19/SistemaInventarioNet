using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class CategoriaBLL
    {
        public static List<Categoria> ObtenerTodos()
        {
            using (var db = new InventarioDbContext())
            {
                return db.Categorias.ToList();
            }
        }
    }
}
