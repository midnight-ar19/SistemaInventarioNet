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
    public class FormMovimientoInventario : Form
    {
        private ComboBox cbProducto, cbTipo;
        private TextBox txtCantidad, txtObservacion;
        private Button btnRegistrar;
        private DataGridView dgv;
        private MovimientoInventarioBLL movimientoBLL;
        private ProductoBLL productoBLL;

        public FormMovimientoInventario()
        {
            movimientoBLL = new MovimientoInventarioBLL(new MovimientoInventarioDAL(new InventarioDbContext()));
            productoBLL = new ProductoBLL(new ProductoDAL(new InventarioDbContext()));

            Text = "Registro de Movimientos de Inventario";
            Width = 800;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;

            Label lblProducto = new Label { Text = "Producto", Top = 20, Left = 20 };
            cbProducto = new ComboBox { Top = 40, Left = 20, Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblTipo = new Label { Text = "Tipo", Top = 80, Left = 20 };
            cbTipo = new ComboBox { Top = 100, Left = 20, Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cbTipo.Items.AddRange(new string[] { "ENTRADA", "SALIDA" });

            Label lblCantidad = new Label { Text = "Cantidad", Top = 140, Left = 20 };
            txtCantidad = new TextBox { Top = 160, Left = 20, Width = 100 };

            Label lblObservacion = new Label { Text = "Observación", Top = 200, Left = 20 };
            txtObservacion = new TextBox { Top = 220, Left = 20, Width = 250 };

            btnRegistrar = new Button { Text = "Registrar Movimiento", Top = 270, Left = 20, Width = 200 };
            btnRegistrar.Click += BtnRegistrar_Click;



            dgv = new DataGridView
            {
                Top = 320,
                Left = 20,
                Width = 740,
                Height = 220,
                ReadOnly = true,
                AutoGenerateColumns = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false
            };




            Controls.AddRange(new Control[] {
                lblProducto, cbProducto, lblTipo, cbTipo,
                lblCantidad, txtCantidad, lblObservacion, txtObservacion,
                btnRegistrar, dgv
            });

            Load += FormMovimientoInventario_Load;
        }

        private void FormMovimientoInventario_Load(object sender, EventArgs e)
        {
            cbProducto.DataSource = productoBLL.ObtenerProductos();
            cbProducto.DisplayMember = "Nombre";
            cbProducto.ValueMember = "IdProducto";

            CargarMovimientos();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbProducto.SelectedItem == null || cbTipo.SelectedItem == null || string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show("Debe completar todos los campos obligatorios.");
                    return;
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida.");
                    return;
                }

                var movimiento = new MovimientoInventario
                {
                    IdProducto = (int)cbProducto.SelectedValue,
                    Tipo = cbTipo.SelectedItem.ToString(),
                    Cantidad = cantidad,
                    Observacion = txtObservacion.Text,
                    Fecha = DateTime.Now,
                    IdUsuario = 1
                };

                movimientoBLL.RegistrarMovimiento(movimiento);
                MessageBox.Show("Movimiento registrado correctamente.");

                txtCantidad.Clear();
                txtObservacion.Clear();
                cbTipo.SelectedIndex = -1;
                CargarMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar movimiento: " + ex.Message);
            }
        }

        private void CargarMovimientos()
        {
            var movimientos = movimientoBLL.ObtenerMovimientos()
                .Select(m => new
                {
                    Fecha = m.Fecha.ToString("g"),
                    Producto = m.Producto?.Nombre ?? "N/A",
                    Tipo = m.Tipo,
                    Cantidad = m.Cantidad,
                    Observacion = m.Observacion
                })
                .ToList();

            dgv.DataSource = movimientos;
        }

    }
}
