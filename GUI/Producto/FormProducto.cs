using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.CategoriaBLL;

namespace GUI.Producto
{
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos guardados exitosamente");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarCategorias()
        {
            CategoriaBLL categoria = new CategoriaBLL();
            var categorias = CategoriaBLL.ObtenerTodos();
            comboCategoria.DataSource = categorias;
            comboCategoria.DisplayMember = "Nombre"; // Ajusta esto según el nombre de tu propiedad
            comboCategoria.ValueMember = "Id"; // Ajusta esto según el nombre del ID en tu entidad
        }
    }
}
