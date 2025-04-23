using System;
using System.Collections.Generic;
using DAL;
using EL;

namespace BLL
{
    public class MovimientoInventarioBLL
    {
        private readonly MovimientoInventarioDAL _movimientoDAL;

        public MovimientoInventarioBLL(MovimientoInventarioDAL movimientoDAL)
        {
            _movimientoDAL = movimientoDAL;
        }

        // Obtener historial de movimientos
        public List<MovimientoInventario> ObtenerMovimientos()
        {
            return _movimientoDAL.ObtenerMovimientos();
        }

        // Registrar entrada o salida
        public void RegistrarMovimiento(MovimientoInventario movimiento)
        {
            _movimientoDAL.RegistrarMovimiento(movimiento);
        }
    }
}
