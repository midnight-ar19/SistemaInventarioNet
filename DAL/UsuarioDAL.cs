using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EL;


namespace DAL
{

    // Clase UsuarioDAL
    public class UsuarioDAL
    {
        private readonly InventarioDbContext _db;

        // Constructor con inyección de dependencia
        public UsuarioDAL(InventarioDbContext db)
        {
            _db = db;
        }

        // Registrar un nuevo usuario
        public bool RegistrarUsuario(Usuario usuario)
        {
            try
            {
                _db.Usuarios.Add(usuario);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al registrar el usuario: " + ex.InnerException?.Message);
            }
        }

        // Iniciar sesión (buscar por correo y contraseña)
        public Usuario IniciarSesionUsuario(string usuario, string contrasena)
        {
            try
            {
                return _db.Usuarios
                    .FirstOrDefault(u => u.UsuarioNombre == usuario && u.Contrasena == contrasena);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            return _db.Usuarios.ToList();
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return _db.Usuarios.Find(id);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            {
                var usuarioExistente = _db.Usuarios.Find(usuario.IdUsuario);
                if (usuarioExistente == null)
                {
                    throw new Exception("El usuario no existe.");
                }

                _db.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
                _db.SaveChanges();
            }
        }

        public void EliminarUsuario(int id)
        {
            var usuario = _db.Usuarios.Find(id);
            if (usuario != null)
            {
                _db.Usuarios.Remove(usuario);
                _db.SaveChanges();
            }
        }
    }
}
