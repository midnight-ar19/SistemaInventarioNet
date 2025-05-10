using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmDashboard : Form
    {
        private Panel sidebarPanel;
        private Panel contentPanel;

        public FrmDashboard()
        {
            // Configuración del formulario
            this.Text = "Sistema de Gestión";
            this.Size = new Size(1000, 700);
            this.MinimumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Resize += (s, e) => AdjustLayout();

            // Crear el menú lateral (Sidebar)
            sidebarPanel = new Panel
            {
                Size = new Size(250, this.ClientSize.Height),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(26, 32, 40),
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(sidebarPanel);

            // Crear el panel de contenido (vacío)
            contentPanel = new Panel
            {
                Size = new Size(this.ClientSize.Width - 250, this.ClientSize.Height),
                Location = new Point(250, 0),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(contentPanel);

            // Crear logo o nombre en el sidebar
            Label lblLogo = new Label
            {
                Text = "Sistema de Gestión",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Size = new Size(230, 30),
                Location = new Point(10, 20),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft
            };
            sidebarPanel.Controls.Add(lblLogo);

            // Crear botones del menú lateral
            string[] menuItems = { "Categorías", "Marcas", "Proveedores", "Usuarios", "Productos", "Gestión de Inventario" };
            for (int i = 0; i < menuItems.Length; i++)
            {
                Button btn = new Button
                {
                    Text = menuItems[i],
                    Size = new Size(230, 50),
                    Location = new Point(10, 80 + (i * 60)),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(26, 32, 40),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Hand,
                    Tag = menuItems[i]
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 65);
                btn.Click += OpenForm;
                sidebarPanel.Controls.Add(btn);
            }
        }

        private void AdjustLayout()
        {
            sidebarPanel.Size = new Size(250, this.ClientSize.Height);
            contentPanel.Size = new Size(this.ClientSize.Width - 250, this.ClientSize.Height);
            contentPanel.Location = new Point(250, 0);
        }

        private void OpenForm(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string section = btn.Tag.ToString();

            Form formToOpen = null;
            switch (section)
            {
                case "Categorías":
                    formToOpen = new Interfaces.CategoriaForm();
                    break;
                case "Marcas":
                    formToOpen = new Interfaces.MarcaForm();
                    break;
                case "Proveedores":
                    formToOpen = new Interfaces.ProveedorForm();
                    break;
                case "Usuarios":
                    formToOpen = new Form { Text = "Gestión de Usuarios", Size = new Size(600, 400) };
                    break;
                case "Productos":
                    formToOpen = new Interfaces.FormProductos();
                    break;
                case "Gestión de Inventario":
                    formToOpen = new Form { Text = "Gestión de Inventario", Size = new Size(600, 400) };
                    break;
            }

            if (formToOpen != null)
            {
                formToOpen.StartPosition = FormStartPosition.CenterParent;
                formToOpen.ShowDialog();
            }
        }


        private void FrmDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}