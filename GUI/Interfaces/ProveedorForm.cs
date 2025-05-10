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
using DAL;
using EL;

namespace GUI.Interfaces
{
    public class ProveedorForm : Form
    {
        private readonly ProveedorBLL _proveedorBLL;

        private DataGridView dgv;
        private TextBox txtNombre, txtContacto, txtTelefono, txtDireccion;
        private Button btnAgregar, btnEditar, btnEliminar, btnLimpiar;
        private int? proveedorSeleccionadoId = null;

        public ProveedorForm()
        {
            _proveedorBLL = new ProveedorBLL(new DAL.ProveedorDAL(new InventarioDbContext()));
            InicializarComponentes();
            CargarDatos();
        }

        private void InicializarComponentes()
        {
            this.Text = "Gestión de Proveedores";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Label lblNombre = new Label() { Text = "Nombre", Location = new Point(20, 20), AutoSize = true };
            txtNombre = new TextBox() { Location = new Point(100, 20), Width = 200 };

            Label lblContacto = new Label() { Text = "Contacto", Location = new Point(320, 20), AutoSize = true };
            txtContacto = new TextBox() { Location = new Point(400, 20), Width = 200 };

            Label lblTelefono = new Label() { Text = "Teléfono", Location = new Point(20, 60), AutoSize = true };
            txtTelefono = new TextBox() { Location = new Point(100, 60), Width = 200 };

            Label lblDireccion = new Label() { Text = "Dirección", Location = new Point(320, 60), AutoSize = true };
            txtDireccion = new TextBox() { Location = new Point(400, 60), Width = 200 };

            btnAgregar = new Button() { Text = " + Agregar", Location = new Point(100, 100), Width = 100 ,};
            btnEditar = new Button() { Text = "Actualizar", Location = new Point(210, 100), Width = 100 };
            btnEliminar = new Button() { Text = "Eliminar", Location = new Point(320, 100), Width = 100 };
            btnLimpiar = new Button() { Text = "Limpiar", Location = new Point(430, 100), Width = 100 };

            btnAgregar.Click += BtnAgregar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;

            dgv = new DataGridView()
            {
                Location = new Point(20, 150),
                Size = new Size(640, 280),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgv.CellClick += Dgv_CellClick;

            Controls.AddRange(new Control[] {
                lblNombre, txtNombre,
                lblContacto, txtContacto,
                lblTelefono, txtTelefono,
                lblDireccion, txtDireccion,
                btnAgregar, btnEditar, btnEliminar, btnLimpiar,
                dgv
            });
        }

        private void CargarDatos()
        {
            dgv.DataSource = _proveedorBLL.ObtenerProveedor()
                .OrderByDescending(p => p.IdProveedor)
                .Select(p => new
                {
                    p.IdProveedor,
                    p.Nombre,
                    p.Contacto,
                    p.Telefono,
                    p.Direccion
                }).ToList();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            var proveedor = new Proveedor()
            {
                Nombre = txtNombre.Text.Trim(),
                Contacto = txtContacto.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            _proveedorBLL.AgregarProveedor(proveedor);
            MessageBox.Show("Proveedor agregado correctamente.");
            LimpiarFormulario();
            CargarDatos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un proveedor para editar.");
                return;
            }

            var proveedor = new Proveedor()
            {
                IdProveedor = proveedorSeleccionadoId.Value,
                Nombre = txtNombre.Text.Trim(),
                Contacto = txtContacto.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            _proveedorBLL.ActualizarProveedor(proveedor);
            MessageBox.Show("Proveedor actualizado correctamente.");
            LimpiarFormulario();
            CargarDatos();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.");
                return;
            }

            _proveedorBLL.EliminarProveedor(proveedorSeleccionadoId.Value);
            MessageBox.Show("Proveedor eliminado correctamente.");
            LimpiarFormulario();
            CargarDatos();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtContacto.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            proveedorSeleccionadoId = null;
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgv.Rows[e.RowIndex];
                proveedorSeleccionadoId = Convert.ToInt32(fila.Cells["IdProveedor"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtContacto.Text = fila.Cells["Contacto"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
            }
        }
    }
}
