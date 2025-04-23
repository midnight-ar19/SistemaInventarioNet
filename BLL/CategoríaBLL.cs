using System.Collections.Generic;
using DAL;
using EL;

namespace BLL
{
    public class CategoriaBLL
    {
        private readonly CategoriaDAL _categoriaDAL;

        public CategoriaBLL()
        {
            _categoriaDAL = new CategoriaDAL(new InventarioDbContext());
        }

        public List<Categoria> ObtenerTodas()
        {
            return _categoriaDAL.GetAll();
        }

        public void Insertar(Categoria categoria)
        {
            _categoriaDAL.AgregarCategoria(categoria);
        }

        public Categoria Buscar(int id)
        {
            return _categoriaDAL.BuscarCategoria(id);
        }

        public void Actualizar(Categoria categoria)
        {
            _categoriaDAL.ActualizarCategoria(categoria);
        }

        public void Eliminar(int id)
        {
            _categoriaDAL.EliminarCategoria(id);
        }
    }
}
