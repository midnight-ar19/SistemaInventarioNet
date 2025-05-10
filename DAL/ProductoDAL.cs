using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        // Obtención de todos los productos (listado)
        public List<Producto> ObtenerProductos()
        {
            try
            {
                return _db.Productos
                    .Include(p => p.Categoria)
                    .Include(p => p.Proveedor)
                    .Include(p => p.Marca)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos", ex);
            }
        }

        // Agregar producto
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

        // Buscar producto
        public Producto BuscarProducto(int id)
        {
            try
            {
                return _db.Productos
                    .Include(p => p.Categoria)
                    .Include(p => p.Proveedor)
                    .Include(p => p.Marca)
                    .FirstOrDefault(p => p.IdProducto == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar producto", ex);
            }
        }

        // Actualizando producto
        public void ActualizarProducto(Producto producto)
        {
            try
            {
                var existente = _db.Productos.Find(producto.IdProducto);
                if (existente != null)
                {
                    existente.Nombre = producto.Nombre;
                    existente.Descripcion = producto.Descripcion;
                    existente.PrecioCompra = producto.PrecioCompra;
                    existente.PrecioVenta = producto.PrecioVenta;
                    existente.IdCategoria = producto.IdCategoria;
                    existente.IdMarca = producto.IdMarca;
                    existente.IdProveedor = producto.IdProveedor;

                    _db.SaveChanges();
                }
                else
                {
                    throw new Exception("Producto no encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto", ex);
            }
        }


        // Eliminar producto
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
                throw new Exception("Error al eliminar producto", ex);
            }
        }
    }
}
