using BLL;
using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Interfaces
{
    public class FormProductos : Form
    {
        private TextBox txtNombre, txtDescripcion, txtPrecioCompra, txtPrecioVenta;
        private ComboBox cbCategoria, cbMarca, cbProveedor;
        private Button btnAgregar, btnActualizar, btnEliminar;
        private DataGridView dgv;
        private ProductoBLL bll = new ProductoBLL(new DAL.ProductoDAL(new InventarioDbContext()));
        private CategoriaBLL categoriaBLL = new CategoriaBLL();
        private MarcaBLL marcaBLL = new MarcaBLL(new DAL.MarcaDAL(new InventarioDbContext()));
        private ProveedorBLL proveedorBLL = new ProveedorBLL(new DAL.ProveedorDAL(new InventarioDbContext()));
        private int? selectedId = null;
        private Button btnLimpiar;
        private List<EL.Producto> listaOriginal = new List<EL.Producto>();



        public FormProductos()
        {
            Text = "Gestión de Productos";
            Width = 1000;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;

            Label lblNombre = new Label { Text = "Nombre", Top = 20, Left = 20 };
            txtNombre = new TextBox { Top = 40, Left = 20, Width = 200 };

            Label lblDescripcion = new Label { Text = "Descripción", Top = 80, Left = 20 };
            txtDescripcion = new TextBox { Top = 100, Left = 20, Width = 200 };

            Label lblPrecioCompra = new Label { Text = "Precio Compra", Top = 140, Left = 20 };
            txtPrecioCompra = new TextBox { Top = 160, Left = 20, Width = 200 };

            Label lblPrecioVenta = new Label { Text = "Precio Venta", Top = 200, Left = 20 };
            txtPrecioVenta = new TextBox { Top = 220, Left = 20, Width = 200 };

            Label lblCategoria = new Label { Text = "Categoría", Top = 20, Left = 250 };
            cbCategoria = new ComboBox { Top = 40, Left = 250, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblMarca = new Label { Text = "Marca", Top = 80, Left = 250 };
            cbMarca = new ComboBox { Top = 100, Left = 250, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblProveedor = new Label { Text = "Proveedor", Top = 140, Left = 250 };
            cbProveedor = new ComboBox { Top = 160, Left = 250, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            btnAgregar = new Button { Text = "Agregar", Top = 300, Left = 20, Width = 100 };
            btnActualizar = new Button { Text = "Actualizar", Top = 300, Left = 130, Width = 100 };
            btnEliminar = new Button { Text = "Eliminar", Top = 300, Left = 240, Width = 100 };
            btnLimpiar = new Button { Text = "Limpiar", Top = 300, Left = 350, Width = 100 };
            btnLimpiar.Click += (s, e) => Limpiar();


            dgv = new DataGridView
            {
                Top = 350,
                Left = 20,
                Width = 940,
                Height = 200,
                ReadOnly = true,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false
            };


            Controls.AddRange(new Control[] {
            lblNombre, txtNombre, lblDescripcion, txtDescripcion,
            lblPrecioCompra, txtPrecioCompra, lblPrecioVenta, txtPrecioVenta,
            lblCategoria, cbCategoria, lblMarca, cbMarca, lblProveedor, cbProveedor,
            btnAgregar, btnActualizar, btnEliminar, btnLimpiar, dgv
        });

            Load += FrmProductos_Load;
            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            dgv.CellClick += Dgv_CellClick;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarProductos();
        }

        private void CargarCombos()
        {
            cbCategoria.DataSource = categoriaBLL.ObtenerTodas();
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "IdCategoria";

            cbMarca.DataSource = marcaBLL.ObtenerMarcas();
            cbMarca.DisplayMember = "Nombre";
            cbMarca.ValueMember = "IdMarca";

            cbProveedor.DataSource = proveedorBLL.ObtenerProveedor();
            cbProveedor.DisplayMember = "Nombre";
            cbProveedor.ValueMember = "IdProveedor";
        }

        private void CargarProductos()
        {
            listaOriginal = bll.ObtenerProductos().OrderByDescending(p => p.IdProducto).ToList();

            var vista = listaOriginal.Select(p => new
            {
                p.IdProducto,
                p.Nombre,
                p.Descripcion,
                p.PrecioCompra,
                p.PrecioVenta,
                Categoria = p.Categoria?.Nombre,
                Marca = p.Marca?.Nombre,
                Proveedor = p.Proveedor?.Nombre
            }).ToList();

            dgv.DataSource = null;
            dgv.Columns.Clear();
            dgv.DataSource = vista;

            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdProducto", HeaderText = "ID" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descripcion", HeaderText = "Descripción" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioCompra", HeaderText = "Precio Compra" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioVenta", HeaderText = "Precio Venta" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoría" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Proveedor", HeaderText = "Proveedor" });
        }



        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var  p = new EL.Producto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                    IdCategoria = (int)cbCategoria.SelectedValue,
                    IdMarca = (int)cbMarca.SelectedValue,
                    IdProveedor = (int)cbProveedor.SelectedValue
                };

                bll.AgregarProducto(p);
                MessageBox.Show("Producto agregado correctamente");
                Limpiar();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (selectedId == null) return;

            try
            {
                var p = new EL.Producto
                {
                    IdProducto = selectedId.Value,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                    PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                    IdCategoria = (int)cbCategoria.SelectedValue,
                    IdMarca = (int)cbMarca.SelectedValue,
                    IdProveedor = (int)cbProveedor.SelectedValue
                };

                bll.ActualizarProducto(p);
                MessageBox.Show("Producto actualizado correctamente");
                Limpiar();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedId == null) return;

            if (MessageBox.Show("¿Deseas eliminar el producto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bll.EliminarProducto(selectedId.Value);
                MessageBox.Show("Producto eliminado correctamente");
                Limpiar();
                CargarProductos();
            }
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
                var producto = listaOriginal.FirstOrDefault(p => p.IdProducto == id);
                if (producto != null)
                {
                    selectedId = producto.IdProducto;
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    txtPrecioCompra.Text = producto.PrecioCompra.ToString();
                    txtPrecioVenta.Text = producto.PrecioVenta.ToString();
                    cbCategoria.SelectedValue = producto.IdCategoria ?? 0;
                    cbMarca.SelectedValue = producto.IdMarca ?? 0;
                    cbProveedor.SelectedValue = producto.IdProveedor ?? 0;
                }
            }
        }


        private void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            cbCategoria.SelectedIndex = 0;
            cbMarca.SelectedIndex = 0;
            cbProveedor.SelectedIndex = 0;
            selectedId = null;
        }
    }
}
