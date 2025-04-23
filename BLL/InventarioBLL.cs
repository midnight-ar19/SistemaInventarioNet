using System;
using System.Collections.Generic;
using DAL;
using EL;

namespace BLL
{
    public class InventarioBLL
    {
        private readonly InventarioDAL _inventarioDAL;

        public InventarioBLL(InventarioDAL inventarioDAL)
        {
            _inventarioDAL = inventarioDAL;
        }

        // Obtener todo el inventario
        public List<Inventario> ObtenerInventario()
        {
            return _inventarioDAL.ObtenerInventario();
        }

        // Buscar inventario por producto
        public Inventario BuscarPorProducto(int idProducto)
        {
            return _inventarioDAL.BuscarPorProducto(idProducto);
        }

        // Actualizar stock (entrada o salida)
        public void ActualizarStock(int idProducto, int cantidad, bool esEntrada)
        {
            _inventarioDAL.ActualizarStock(idProducto, cantidad, esEntrada);
        }
    }
}
