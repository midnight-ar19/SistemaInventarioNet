using EL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class MovimientoInventarioDAL
    {
        private readonly InventarioDbContext _db;

        public MovimientoInventarioDAL(InventarioDbContext db)
        {
            _db = db;
        }

        public List<MovimientoInventario> ObtenerMovimientos()
        {
            return _db.MovimientoInventario
                .OrderByDescending(m => m.Fecha)
                .ToList();
        }

        public void RegistrarMovimiento(MovimientoInventario movimiento)
        {
            try
            {
                var trans = _db.Database.BeginTransaction();

                _db.MovimientoInventario.Add(movimiento);

                var inventario = _db.Inventario.FirstOrDefault(i => i.IdProducto == movimiento.IdProducto);
                if (inventario == null)
                    throw new Exception("Inventario no encontrado para el producto");

                if (movimiento.Tipo == "ENTRADA")
                    inventario.Stock += movimiento.Cantidad;
                else if (movimiento.Tipo == "SALIDA")
                {
                    if (inventario.Stock < movimiento.Cantidad)
                        throw new Exception("Stock insuficiente para salida");
                    inventario.Stock -= movimiento.Cantidad;
                }

                _db.SaveChanges();
                trans.Commit();
            }
            catch (Exception)
            {
                throw new Exception("Error al registrar el movimiento y actualizar inventario.");
            }
        }
    }
}
