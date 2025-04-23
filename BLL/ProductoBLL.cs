

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DAL;
    using EL;

    namespace BLL
    {
        public class ProductoBLL
        {
        private readonly ProductoDAL _productoDAL;

        public ProductoBLL(ProductoDAL productoDAL)
        {
            _productoDAL = productoDAL;
        }

        // Obtener todos los productos
        public List<Producto> ObtenerProductos()
        {
            return _productoDAL.ObtenerProductos();
        }

        // Agregar producto
        public void AgregarProducto(Producto producto)
        {
            _productoDAL.AgregarProducto(producto);
        }

        // Buscar producto por ID
        public Producto BuscarProducto(int id)
        {
            return _productoDAL.BuscarProducto(id);
        }

        // Actualizar producto
        public void ActualizarProducto(Producto producto)
        {
            _productoDAL.ActualizarProducto(producto);
        }

        // Eliminar producto
        public void EliminarProducto(int id)
        {
            _productoDAL.EliminarProducto(id);
        }
    }

    }

