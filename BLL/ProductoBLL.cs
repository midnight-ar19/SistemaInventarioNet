

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DAL;
    using EL;

    namespace BLL
    {
        public class ProductoBLL
        {
            // Método para insertar un producto en la base de datos
            public void Insertar(Producto producto)
            {
                try
                {
                    using (var contexto = new InventarioDbContext())
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
                using (var contexto = new InventarioDbContext())
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
                using (var contexto = new InventarioDbContext())
                {
                    return contexto.Productos
                                   .Include("Categoria")
                                   .Include("Marca")
                                   .Include("Proveedor")
                                   .FirstOrDefault(p => p.IdProducto == id);
                }
            }

           //Método para buscar por nombre
           public Producto ObtenerPorNombre(string nombre) {

            using (var contexto = new InventarioDbContext())
            {
                return contexto.Productos
                               .Include("Categoria")
                               .Include("Marca")
                               .Include("Proveedor")
                               .FirstOrDefault(p => p.Nombre == nombre);
            }

           }
        }

    }

