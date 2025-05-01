using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EL;
using DAL;
using BLL;

namespace GUI
{
    public partial class IngresarUsuario : Form
    {
        public IngresarUsuario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuarioNombre = textUsuario.Text.Trim();
            string contrasenña = textContraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuarioNombre) || string.IsNullOrWhiteSpace(contrasenña))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Usuario nuevoUsuario = new Usuario
            {
                UsuarioNombre = usuarioNombre,
                Contrasena = contrasenña
            };

            try
            {
                var bll = new BLL.UsuarioBLL(); // Usa tu constructor corregido
                bool registrado = bll.RegistrarUsuario(nuevoUsuario);

                if (registrado)
                {
                    MessageBox.Show("Usuario registrado con éxito.");
                    this.Close(); // o limpiar campos si prefieres
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar nuevo usuario: " + ex.Message);
            }
        }
    }
}
