using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EL;

namespace BLL
{
    public class MarcaBLL
    {
        private readonly MarcaDAL _marcaDAL;

        public MarcaBLL(MarcaDAL marcaDAL)
        {
            _marcaDAL = marcaDAL;
        }

        // Obtener todas las marcas
        public List<Marca> ObtenerMarcas()
        {   
            return _marcaDAL.ObtenerMarcas();
        }

        // Agregar una nueva marca
        public void AgregarMarca(Marca marca)
        {
            _marcaDAL.AgregarMarca(marca);
        }

        // Buscar una marca por ID
        public Marca BuscarMarca(int id)
        {
            return _marcaDAL.BuscarMarca(id);
        }

        // Actualizar una marca
        public void ActualizarMarca(Marca marca)
        {
            _marcaDAL.ActualizarMarca(marca);
        }

        // Eliminar una marca por ID
        public void EliminarMarca(int id)
        {
            _marcaDAL.EliminarMarca(id);
        }
    }
}

