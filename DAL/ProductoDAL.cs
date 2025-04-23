using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public class ProductoDAL
    {
        private readonly InventarioDbContext _db;

        public ProductoDAL(InventarioDbContext db) 
        {
            _db = db;
        }

        //Obtencion de todos productos(listado)

        public List<Producto> ObtenerProductos()
        {
            try
            {
                return _db.Productos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos", ex);
            }

        }
        //Agregar producto
        public void AgregarProducto(Producto producto)
        {
            try
            {
                _db.Productos.Add(producto);
                _db.SaveChanges();
            }

            catch (Exception ex) 
            {
                throw new Exception("Error al agregar producto", ex);
            }
        }

        //Buscar producto
        public Producto BuscarProducto(int id) 
        {
            try 
            {
                return _db.Productos.Find(id);
            
            }
            catch (Exception ex) 
            {
                throw new Exception("error al buscar producto", ex);
            }
        }

        //actualizando producto
        public void ActualizarProducto(Producto producto) 
        {
            try 
            {
                _db.Entry(producto);
                _db.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error al actualizar producto", ex);
            }

        }

        //Eliminar producto
        public void EliminarProducto(int id) 
        {
            try 
            {
                var producto = _db.Productos.Find(id);
                if (producto != null) 
                {
                    _db.Productos.Remove(producto);
                    _db.SaveChanges();
                
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Producto", ex);
            }
        }
            

    }

}
