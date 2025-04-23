using EL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class InventarioDAL
    {
        private readonly InventarioDbContext _db;

        public InventarioDAL(InventarioDbContext db)
        {
            _db = db;
        }

        public List<Inventario> ObtenerInventario()
        {
            return _db.Inventario
                .OrderBy(i => i.Producto.Nombre)
                .ToList();
        }

        public Inventario BuscarPorProducto(int idProducto)
        {
            return _db.Inventario
                .FirstOrDefault(i => i.IdProducto == idProducto);
        }

        public void ActualizarStock(int idProducto, int cantidad, bool esEntrada)
        {
            var inventario = BuscarPorProducto(idProducto);
            if (inventario == null)
                throw new Exception("No se encontró inventario para el producto");

            inventario.Stock += esEntrada ? cantidad : -cantidad;

            if (inventario.Stock < 0)
                throw new Exception("Stock insuficiente");

            _db.SaveChanges();
        }
    }
}
