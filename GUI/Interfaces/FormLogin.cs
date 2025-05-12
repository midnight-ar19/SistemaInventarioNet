using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using EL;

namespace GUI.Interfaces
{
    public class FormLogin : Form
    {
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnLogin;
        private Label lblError;
        private UsuarioBLL usuarioBLL;

        public FormLogin()
        {
            usuarioBLL = new UsuarioBLL();

            Text = "Iniciar Sesión";
            Width = 400;
            Height = 300;
            StartPosition = FormStartPosition.CenterScreen;

            Label lblUsuario = new Label { Text = "Usuario", Left = 30, Top = 40, Width = 100 };
            txtUsuario = new TextBox { Left = 30, Top = 60, Width = 300 };

            Label lblContrasena = new Label { Text = "Contraseña", Left = 30, Top = 100, Width = 100 };
            txtContrasena = new TextBox { Left = 30, Top = 120, Width = 300, PasswordChar = '•' };

            btnLogin = new Button { Text = "Ingresar", Left = 30, Top = 170, Width = 300 };
            btnLogin.Click += BtnLogin_Click;

            lblError = new Label
            {
                ForeColor = Color.Red,
                Left = 30,
                Top = 210,
                Width = 300,
                Visible = false
            };

            Controls.AddRange(new Control[] {
                lblUsuario, txtUsuario,
                lblContrasena, txtContrasena,
                btnLogin, lblError
            });
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                lblError.Text = "Debe ingresar usuario y contraseña.";
                lblError.Visible = true;
                return;
            }

            Usuario usuarioLogueado = usuarioBLL.IniciarSesionUsuario(usuario, contrasena);
            if (usuarioLogueado == null)
            {
                lblError.Text = "Credenciales incorrectas.";
                lblError.Visible = true;
                return;
            }

            Hide();
            FrmDashboard dashboard = new FrmDashboard(usuarioLogueado);
            dashboard.FormClosed += (s, args) => Close();
            dashboard.Show();
        }
    }
}
