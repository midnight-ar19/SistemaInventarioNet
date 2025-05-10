using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using EL;

namespace GUI.Interfaces
{
    public class CategoriaForm : Form
    {
        private Label lblNombre;
        private TextBox txtNombre;
        private Button btnAgregar, btnActualizar, btnEliminar, btnLimpiar;
        private DataGridView dgvCategorias;
        private CategoriaBLL categoriaBLL;
        private int? categoriaSeleccionadaId = null;

        public CategoriaForm()
        {
            categoriaBLL = new CategoriaBLL();

            Text = "Gestión de Categorías";
            Size = new Size(700, 500);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            lblNombre = new Label()
            {
                Text = "Nombre de la categoría:",
                Location = new Point(30, 30),
                AutoSize = true
            };

            txtNombre = new TextBox()
            {
                Location = new Point(30, 60),
                Width = 400,
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            btnAgregar = CrearBoton("➕ Agregar", new Point(30, 100), Color.FromArgb(34, 197, 94));
            btnActualizar = CrearBoton("✏️ Actualizar", new Point(150, 100), Color.FromArgb(251, 191, 36));
            btnEliminar = CrearBoton("🗑️ Eliminar", new Point(290, 100), Color.FromArgb(239, 68, 68));
            btnLimpiar = CrearBoton("🔄 Limpiar", new Point(430, 100), Color.FromArgb(107, 114, 128));

            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnLimpiar.Click += (s, e) => LimpiarFormulario();

            dgvCategorias = new DataGridView()
            {
                Location = new Point(30, 160),
                Size = new Size(620, 280),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                MultiSelect = false,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White
            };
            dgvCategorias.CellClick += DgvCategorias_CellClick;

            Controls.AddRange(new Control[]
            {
                lblNombre, txtNombre,
                btnAgregar, btnActualizar, btnEliminar, btnLimpiar,
                dgvCategorias
            });

            CargarDatos();
        }

        private void CargarDatos()
        {
            var categorias = categoriaBLL.ObtenerTodas()
                                         .OrderByDescending(c => c.IdCategoria) // o c.Nombre
                                         .ToList();
            dgvCategorias.DataSource = categorias;
            dgvCategorias.ClearSelection();
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                categoriaBLL.Insertar(new Categoria { Nombre = txtNombre.Text.Trim() });
                CargarDatos();
                LimpiarFormulario();
                MessageBox.Show("Categoría agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la categoría:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (categoriaSeleccionadaId == null)
            {
                MessageBox.Show("Selecciona una categoría primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cat = new Categoria
                {
                    IdCategoria = categoriaSeleccionadaId.Value,
                    Nombre = txtNombre.Text.Trim()
                };
                categoriaBLL.Actualizar(cat);
                CargarDatos();
                LimpiarFormulario();
                MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la categoría:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (categoriaSeleccionadaId == null)
            {
                MessageBox.Show("Selecciona una categoría primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show("¿Estás seguro de eliminar esta categoría?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    categoriaBLL.Eliminar(categoriaSeleccionadaId.Value);
                    CargarDatos();
                    LimpiarFormulario();
                    MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la categoría:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvCategorias.Rows[e.RowIndex];
                categoriaSeleccionadaId = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            categoriaSeleccionadaId = null;
            dgvCategorias.ClearSelection();
        }

        private Button CrearBoton(string texto, Point ubicacion, Color colorFondo)
        {
            return new Button()
            {
                Text = texto,
                Location = ubicacion,
                Size = new Size(100, 35),
                BackColor = colorFondo,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand
            };
        }


    }
}
