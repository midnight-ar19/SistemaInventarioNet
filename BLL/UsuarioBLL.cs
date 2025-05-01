using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EL;

namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _usuarioDAL;

        public UsuarioBLL(UsuarioDAL usuarioDAL)
        {
            _usuarioDAL = usuarioDAL;

        }

        //Agrge este constructor vacio para poder iniciar todo automaticamnte 
        public UsuarioBLL() : this(new UsuarioDAL(new InventarioDbContext()))
        { 
        }

        // Registrar un nuevo usuario
        public bool RegistrarUsuario(Usuario usuario)
        {
            return _usuarioDAL.RegistrarUsuario(usuario);
        }

        // Iniciar sesión
        public Usuario IniciarSesionUsuario(string usuarioNombre, string contrasena)
        {
            return _usuarioDAL.IniciarSesionUsuario(usuarioNombre, contrasena);
        }

        // Listar todos los usuarios
        public List<Usuario> ListarUsuarios()
        {
            return _usuarioDAL.ListarUsuarios();
        }

        // Buscar usuario por ID
        public Usuario BuscarUsuarioPorId(int id)
        {
            return _usuarioDAL.BuscarUsuarioPorId(id);
        }

        // Actualizar un usuario existente
        public void ActualizarUsuario(Usuario usuario)
        {
            _usuarioDAL.ActualizarUsuario(usuario);
        }

        // Eliminar un usuario por ID
        public void EliminarUsuario(int id)
        {
            _usuarioDAL.EliminarUsuario(id);
        }
    }
}
