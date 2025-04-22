using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MarcaDAL
    {
        private readonly InventarioDbContext _db;

       
        public MarcaDAL(InventarioDbContext db)
        {
            _db = db;
        }

        //Obtener todas las marcas
        public List<Marca> ObtenerMarcas()
        {
            try
            {
                return _db.Marcas.ToList(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener marcas", ex);
            }
        }

       
        public void AgregarMarca(Marca marca)
        {
            try
            {
                _db.Marcas.Add(marca); 
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar marca", ex);
            }
        }

        
        public Marca BuscarMarca(int id)
        {
            try
            {
                return _db.Marcas.Find(id); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar marca", ex);
            }
        }

       
        public void ActualizarMarca(Marca marca)
        {
            try
            {
                _db.Entry(marca);
                _db.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar marca", ex);
            }
        }

        
        public void EliminarMarca(int id)
        {
            try
            {
                var marca = _db.Marcas.Find(id); 
                if (marca != null)
                {
                    _db.Marcas.Remove(marca); 
                    _db.SaveChanges(); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar marca", ex);
            }
        }
    }
}
