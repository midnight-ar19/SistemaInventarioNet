using DAL;
using EL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BLL
{
    public class ProveedorBLL
    {
        private readonly ProveedorDAL _proveedorDAL;

        public ProveedorBLL(ProveedorDAL proveedorDAL)
        {
            _proveedorDAL = proveedorDAL;
        }
        //obtener todos los proveedores
        public List<Proveedor> ObtenerProveedor()
        {
            return _proveedorDAL.ObtenerProveedores();
        }

        //agregar un nuevo proveedor
        public void AgregarProveedor(Proveedor proveedor)
        {
            _proveedorDAL.AgregarProveedor(proveedor);
        } 

        //Buscar proveedor por su ID
        public Proveedor BuscarProveedor(int id)
        {
            return _proveedorDAL.BuscarProveedor(id);
        }

        //Actualizar un proveedor
        public void ActualizarProveedor(Proveedor proveedor)
        {
            _proveedorDAL.ActualizarProveedor(proveedor);
        }

        //Eliminar un proveedor por su ID
        public void EliminarProveedor(int id)
        {
            _proveedorDAL.EliminarProveedor(id);
        }
    }
}

