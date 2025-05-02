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
using GUI.Producto;

namespace GUI
{
    public partial class FrmCategorias : Form
    {
        private CategoriaBLL _categoriaBLL;
        private DataGridView dgvCategorias; 
        private TextBox txtNombre; 
        private Button btnAgregar; 
        private Button btnActualizar; 
        private Button btnEliminar; 
        private Button btnLimpiar; 
        private Label lblTitle; 
        private int? selectedCategoriaId = null;

        public FrmCategorias()
        {
            _categoriaBLL = new CategoriaBLL();

            // Configuración del formulario
            this.Text = "Gestión de Categorías";
            this.Size = new Size(800, 600);
            this.MinimumSize = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            // Título
            lblTitle = new Label
            {
                Text = "Administración de Categorías",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Size = new Size(500, 30),
                Location = new Point(20, 20),
                ForeColor = Color.FromArgb(26, 32, 40)
            };
            this.Controls.Add(lblTitle);

            // Etiqueta y campo para Nombre
            Label lblNombre = new Label
            {
                Text = "Nombre de la Categoría:",
                Font = new Font("Segoe UI", 12),
                Size = new Size(200, 20),
                Location = new Point(20, 70),
                ForeColor = Color.FromArgb(26, 32, 40)
            };
            this.Controls.Add(lblNombre);

            txtNombre = new TextBox
            {
                Size = new Size(300, 30),
                Location = new Point(20, 95),
                Font = new Font("Segoe UI", 12),
                MaxLength = 100
            };
            this.Controls.Add(txtNombre);

            // Botones
            btnAgregar = new Button
            {
                Text = "Agregar",
                Size = new Size(100, 40),
                Location = new Point(20, 145),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.Click += BtnAgregar_Click;
            this.Controls.Add(btnAgregar);

            btnActualizar = new Button
            {
                Text = "Actualizar",
                Size = new Size(100, 40),
                Location = new Point(130, 145),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.Click += BtnActualizar_Click;
            this.Controls.Add(btnActualizar);

            btnEliminar = new Button
            {
                Text = "Eliminar",
                Size = new Size(100, 40),
                Location = new Point(240, 145),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Click += BtnEliminar_Click;
            this.Controls.Add(btnEliminar);

            btnLimpiar = new Button
            {
                Text = "Limpiar",
                Size = new Size(100, 40),
                Location = new Point(350, 145),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.Click += BtnLimpiar_Click;
            this.Controls.Add(btnLimpiar);

            // Tabla de categorías
            dgvCategorias = new DataGridView
            {
                Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 210),
                Location = new Point(20, 200),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            dgvCategorias.SelectionChanged += DgvCategorias_SelectionChanged;
            this.Controls.Add(dgvCategorias);

            // Ajustar diseño al redimensionar
            this.Resize += (s, e) => AdjustLayout();

            // Cargar datos iniciales
            LoadCategorias();
        }

        private void AdjustLayout()
        {
            dgvCategorias.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 210);
        }

        private void LoadCategorias()
        {
            try
            {
                var categorias = _categoriaBLL.ObtenerTodas();
                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = categorias;
                dgvCategorias.Columns["IdCategoria"].HeaderText = "ID";
                dgvCategorias.Columns["Nombre"].HeaderText = "Nombre de la Categoría";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre de la categoría es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var categoria = new EL.Categoria { Nombre = txtNombre.Text.Trim() };
                _categoriaBLL.Insertar(categoria);
                MessageBox.Show("Categoría agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategorias();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!selectedCategoriaId.HasValue)
                {
                    MessageBox.Show("Selecciona una categoría para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre de la categoría es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var categoria = _categoriaBLL.Buscar(selectedCategoriaId.Value);
                if (categoria == null)
                {
                    MessageBox.Show("La categoría seleccionada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                categoria.Nombre = txtNombre.Text.Trim();
                _categoriaBLL.Actualizar(categoria);
                MessageBox.Show("Categoría actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategorias();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!selectedCategoriaId.HasValue)
                {
                    MessageBox.Show("Selecciona una categoría para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta categoría?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _categoriaBLL.Eliminar(selectedCategoriaId.Value);
                    MessageBox.Show("Categoría eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategorias();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void DgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                selectedCategoriaId = (int)dgvCategorias.SelectedRows[0].Cells["IdCategoria"].Value;
                txtNombre.Text = dgvCategorias.SelectedRows[0].Cells["Nombre"].Value.ToString();
            }
            else
            {
                selectedCategoriaId = null;
            }
        }

        private void ClearForm()
        {
            txtNombre.Text = string.Empty;
            selectedCategoriaId = null;
            dgvCategorias.ClearSelection();
        }


        private void FrmCategorias_Load(object sender, EventArgs e)
        {

        }
    }
}
