using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;


namespace DAL
{
    // Clase Usuario con propiedades necesarias
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string ContraseñaHash { get; set; }

        public DateTime FechaRegistro { get; set; }
    }

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
                // Manejar error de duplicados (ej: correo ya registrado)
                throw new Exception("Error al registrar el usuario: " + ex.InnerException?.Message);
            }
        }

        // Iniciar sesión (buscar por correo y contraseña)
        public Usuario IniciarSesionUsuario(string correo, string contraseñaHash)
        {
            try
            {
                return _db.Usuarios
                    .FirstOrDefault(u => u.Correo == correo && u.ContraseñaHash == contraseñaHash);
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
            object value = _db.Usuarios.Update(usuario);
            
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
