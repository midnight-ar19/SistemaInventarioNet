using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


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
                .Include(m => m.Producto)
                .OrderByDescending(m => m.Fecha)
                .ToList();
        }


        public void RegistrarMovimiento(MovimientoInventario movimiento)
        {
            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.MovimientoInventario.Add(movimiento);

                    var inventario = _db.Inventario.FirstOrDefault(i => i.IdProducto == movimiento.IdProducto);

                    // Si no existe el inventario y el movimiento es ENTRADA, lo creamos
                    if (inventario == null)
                    {
                        if (movimiento.Tipo == "ENTRADA")
                        {
                            inventario = new Inventario
                            {
                                IdProducto = movimiento.IdProducto,
                                Stock = movimiento.Cantidad,
                                StockMinimo = 5
                            };
                            _db.Inventario.Add(inventario);
                        }
                        else
                        {
                            throw new Exception("No se puede registrar una SALIDA para un producto sin inventario.");
                        }
                    }
                    else
                    {
                        if (movimiento.Tipo == "ENTRADA")
                            inventario.Stock += movimiento.Cantidad;
                        else if (movimiento.Tipo == "SALIDA")
                        {
                            if (inventario.Stock < movimiento.Cantidad)
                                throw new Exception("Stock insuficiente para salida");
                            inventario.Stock -= movimiento.Cantidad;
                        }
                    }

                    _db.SaveChanges();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error al registrar el movimiento y actualizar inventario: " + ex.Message);
                }
            }

        }
    }
    }
