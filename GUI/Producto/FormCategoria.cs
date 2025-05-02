using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Producto
{
    public partial class dgvCategorias : Form
    {
        // Lista para almacenar las categorías
        private List<Categoria> categorias = new List<Categoria>();

        public dgvCategorias()
        {
            InitializeComponent();

            // Configurar el DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Descripcion", "Descripción");

            // Cargar datos iniciales (opcional)
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            // Datos de ejemplo
            categorias.Add(new Categoria("Electrónicos", "Productos electrónicos"));
            categorias.Add(new Categoria("Ropa", "Prendas de vestir"));

            // Mostrar en el DataGridView
            ActualizarDataGridView();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'inventarioDB.categorias' Puede moverla o quitarla según sea necesario.
            this.categoriasTableAdapter.Fill(this.inventarioDB.categorias);
            // Puedes dejar esto vacío o usarlo para inicializaciones adicionales
        }

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            // Comportamiento opcional al hacer clic en el campo de descripción
            if (txtDescripcion.Text == "Ingrese descripción")
            {
                txtDescripcion.Text = "";
            }
        }

        private void txtNombre_Click(object sender, EventArgs e)
        {
            // Comportamiento opcional al hacer clic en el campo de nombre
            if (textnombre.Text == "Ingrese nombre")
            {
                textnombre.Text = "";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(textnombre.Text))
            {
                MessageBox.Show("Por favor ingrese un nombre para la categoría", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear nueva categoría
            Categoria nuevaCategoria = new Categoria(
                textnombre.Text,
                txtDescripcion.Text
            );

            // Agregar a la lista
            categorias.Add(nuevaCategoria);

            // Actualizar DataGridView
            ActualizarDataGridView();

            // Limpiar campos
            textnombre.Text = "";
            txtDescripcion.Text = "";

            MessageBox.Show("Categoría agregada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var categoria in categorias)
            {
                dataGridView1.Rows.Add(categoria.Nombre, categoria.Descripcion);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Puedes implementar lógica para editar/eliminar categorías aquí
            if (e.RowIndex >= 0)
            {
                var categoriaSeleccionada = categorias[e.RowIndex];
                textnombre.Text = categoriaSeleccionada.Nombre;
                txtDescripcion.Text = categoriaSeleccionada.Descripcion;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Este parece ser un control que no está siendo usado, puedes dejarlo así
        }

        private void textnombre_TextChanged(object sender, EventArgs e)
        {
            // Puedes implementar validación en tiempo real aquí si lo deseas
        }
    }

    // Clase auxiliar para representar una categoría
    public class Categoria
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
