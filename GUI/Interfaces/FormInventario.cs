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
    public class FormInventario : Form
    {
        private DataGridView dgv;
        private Button btnActualizar;
        private InventarioBLL inventarioBLL;
        private ProductoBLL productoBLL;

        public FormInventario()
        {
            inventarioBLL = new InventarioBLL(new InventarioDAL(new InventarioDbContext()));
            productoBLL = new ProductoBLL(new ProductoDAL(new InventarioDbContext()));

            Text = "Inventario Actual";
            Width = 600;
            Height = 450;
            StartPosition = FormStartPosition.CenterScreen;

            dgv = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 350,
                ReadOnly = true,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false
            };

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Producto",
                Width = 200
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "Stock",
                Width = 100
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StockMinimo",
                HeaderText = "Stock Mínimo",
                Width = 120
            });


            btnActualizar = new Button
            {
                Text = "Actualizar",
                Width = 100,
                Height = 35,
                Top = 360,
                Left = 20
            };
            btnActualizar.Click += BtnActualizar_Click;

            Controls.Add(dgv);
            Controls.Add(btnActualizar);

            Load += FormInventario_Load;
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            CargarInventario();
            dgv.RowPrePaint += Dgv_RowPrePaint;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void CargarInventario()
        {
            try
            {
                var inventario = inventarioBLL.ObtenerInventario()
                    .Select(i => new
                    {
                        NombreProducto = i.Producto?.Nombre ?? "N/A",
                        Stock = i.Stock,
                        StockMinimo = i.StockMinimo
                    })
                    .ToList();

                dgv.DataSource = inventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario: " + ex.Message);
            }
        }


        private void Dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgv.Rows[e.RowIndex];
            var data = row.DataBoundItem;

            // Usamos reflexión para obtener el valor del stock
            var stockProp = data.GetType().GetProperty("Stock");
            if (stockProp != null)
            {
                int stock = (int)stockProp.GetValue(data);
                if (stock <= 5)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormInventario
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "FormInventario";
            this.Load += new System.EventHandler(this.FormInventario_Load_1);
            this.ResumeLayout(false);

        }

        private void FormInventario_Load_1(object sender, EventArgs e)
        {

        }
    }
}
