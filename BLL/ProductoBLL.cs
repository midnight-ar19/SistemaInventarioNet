using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DAL;      // Referencia al proyecto DAL
    using EL;       // Referencia al proyecto EL

    namespace BLL
    {
        public class ProductoBLL
        {
            // Método para insertar un producto en la base de datos
            public void Insertar(Producto producto)
            {
                try
                {
                    using (var contexto = new AppDbContext())
                    {
                        contexto.Productos.Add(producto);
                        contexto.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el producto: " + ex.Message);
                }
            }

            // Método para obtener todos los productos
            public List<Producto> ObtenerTodos()
            {
                using (var contexto = new AppDbContext())
                {
                    return contexto.Productos
                                   .Include("Categoria")
                                   .Include("Marca")
                                   .Include("Proveedor")
                                   .ToList();
                }
            }

            // Método para obtener un producto por su ID
            public Producto ObtenerPorId(int id)
            {
                using (var contexto = new AppDbContext())
                {
                    return contexto.Productos
                                   .Include("Categoria")
                                   .Include("Marca")
                                   .Include("Proveedor")
                                   .FirstOrDefault(p => p.IdProducto == id);
                }
            }
        }
    }

}
