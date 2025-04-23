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

namespace GUI.Producto
{
    public partial class FormProducto : Form
    {
        private readonly ProductoBLL _productoBLL;
        public FormProducto()
        {
            InitializeComponent();
            _productoBLL = new ProductoBLL();
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos obligatorios no estén vacíos
                if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecioCompraProducto.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecioVentaProducto.Text))
                {
                    MessageBox.Show("Los campos Nombre, Precio Compra y Precio Venta son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear un nuevo objeto Producto con los datos del formulario
                var producto = new EL.Producto
                {
                    Nombre = txtNombreProducto.Text,
                    Descripcion = txtDescripcionProducto.Text,
                    PrecioCompra = decimal.Parse(txtPrecioCompraProducto.Text),
                    PrecioVenta = decimal.Parse(txtPrecioVentaProducto.Text),
                    IdCategoria = comboCategoria.SelectedValue != null ? (int?)comboCategoria.SelectedValue : null,
                    IdMarca = comboMarca.SelectedValue != null ? (int?)comboMarca.SelectedValue : null,
                    IdProveedor = comboProveedor.SelectedValue != null ? (int?)comboProveedor.SelectedValue : null
                };

                // Llamar al método Insertar de la BLL
                _productoBLL.AgregarProducto(producto);

                // Mostrar mensaje de éxito
                MessageBox.Show("Producto insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el formulario y actualizar el DataGridView
                LimpiarFormulario();
                ActualizarGrid();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores válidos para Precio Compra y Precio Venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombreProducto.Clear();
            txtDescripcionProducto.Clear();
            txtPrecioCompraProducto.Clear();
            txtPrecioVentaProducto.Clear();
            comboCategoria.SelectedIndex = -1;
            comboMarca.SelectedIndex = -1;
            comboProveedor.SelectedIndex = -1;
        }

        private void ActualizarGrid()
        {
            this.productosTableAdapter.Fill(this.inventarioDBv2DataSet3.productos);
            dgvProductos.DataSource = this.inventarioDBv2DataSet3.productos;
        }

        // Otros eventos que no modificaremos por ahora
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboMarca_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtNombreProducto_TextChanged(object sender, EventArgs e) { }
        private void txtDescripcionProducto_TextChanged(object sender, EventArgs e) { }
        private void txtPrecioCompraProducto_TextChanged(object sender, EventArgs e) { }
        private void txtPrecioVentaProducto_TextChanged(object sender, EventArgs e) { }



        private void FormProducto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'inventarioDB.categorias' Puede moverla o quitarla según sea necesario.
            //this.categoriasTableAdapter1.Fill(this.inventarioDB.categorias);
            // TODO: esta línea de código carga datos en la tabla 'inventarioDBv2DataSet3.productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.inventarioDBv2DataSet3.productos);
            // TODO: esta línea de código carga datos en la tabla 'inventarioDBv2DataSet2.proveedores' Puede moverla o quitarla según sea necesario.
            this.proveedoresTableAdapter.Fill(this.inventarioDBv2DataSet2.proveedores);
            // TODO: esta línea de código carga datos en la tabla 'inventarioDBv2DataSet1.marcas' Puede moverla o quitarla según sea necesario.
            this.marcasTableAdapter.Fill(this.inventarioDBv2DataSet1.marcas);
            // TODO: esta línea de código carga datos en la tabla 'inventarioDBv2DataSet.categorias' Puede moverla o quitarla según sea necesario.
            this.categoriasTableAdapter.Fill(this.inventarioDBv2DataSet.categorias);

            // Configurar los ComboBox
            comboCategoria.DataSource = this.inventarioDBv2DataSet.categorias;
            comboCategoria.DisplayMember = "nombre"; // Coincide con la propiedad Nombre de Categoria
            comboCategoria.ValueMember = "IdCategoria";

            comboMarca.DataSource = this.inventarioDBv2DataSet1.marcas;
            comboMarca.DisplayMember = "nombre"; // Coincide con la propiedad Nombre de Marca
            comboMarca.ValueMember = "IdMarca";

            comboProveedor.DataSource = this.inventarioDBv2DataSet2.proveedores;
            comboProveedor.DisplayMember = "nombre"; // Coincide con la propiedad Nombre de Proveedor
            comboProveedor.ValueMember = "IdProveedor";

        }


        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productosTableAdapter.FillBy(this.inventarioDBv2DataSet3.productos);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

    }
}
