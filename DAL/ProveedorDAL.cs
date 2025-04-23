using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //Obtener listado de todos los proveedores

        public List<Proveedor> ObtenerProveedores(
        {
            try
            {
                return _db.Proveedores.Tolist();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los proveedor", ex);
            }
        }
        //Agregar nuevo proveedor
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
        //Buscar proveedor
        public Proveedor BuscarProveedor(int id)
        {
            try
            {
                return _db.Proveedor.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar proveedor", ex);
            }
        }
        //Actualizar proveedor
        public void ActualizarProveedor(Proveedor proveedor)
        {
            try
            {
                _db.Entry(proveedor);
                _db.SaveChanger();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el proveedor")
            }
        }
        //Eliminar proveedor
        public void EliminarProveedor(int id)
        {
            try
            {
                var proveedor = _db.Proveedor.Find(id);
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
