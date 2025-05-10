using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EL;

namespace DAL
{

    public class ProveedorDAL
    {
        private readonly InventarioDbContext _db;


        public ProveedorDAL(InventarioDbContext db)
        {
            _db = db;
        }

        // Obtener listado de todos los proveedores
        public List<Proveedor> ObtenerProveedores()
        {
            try
            {
                return _db.Proveedores.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los proveedores", ex);
            }
        }

        // Agregar nuevo proveedor
        public void AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                _db.Proveedores.Add(proveedor);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar proveedor", ex);
            }
        }

        // Buscar proveedor
        public Proveedor BuscarProveedor(int id)
        {
            try
            {
                return _db.Proveedores.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar proveedor", ex);
            }
        }

        // Actualizar proveedor
        public void ActualizarProveedor(Proveedor proveedor)
        {
            try
            {
                var existente = _db.Proveedores.Find(proveedor.IdProveedor);
                if (existente != null)
                {
                    existente.Nombre = proveedor.Nombre;
                    existente.Contacto = proveedor.Contacto;
                    existente.Telefono = proveedor.Telefono;
                    existente.Direccion = proveedor.Direccion;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el proveedor", ex);
            }
        }


        // Eliminar proveedor
        public void EliminarProveedor(int id)
        {
            try
            {
                var proveedor = _db.Proveedores.Find(id);
                if (proveedor != null)
                {
                    _db.Proveedores.Remove(proveedor);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar proveedor", ex);
            }
        }
    }
}
