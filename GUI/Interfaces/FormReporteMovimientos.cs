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

namespace GUI.Interfaces
{
    public class FormReporteMovimientos : Form
    {
        private DateTimePicker dtpDesde, dtpHasta;
        private ComboBox cbTipo;
        private Button btnBuscar;
        private Button btnExportarPDF;
        private DataGridView dgvReporte;
        private MovimientoInventarioBLL movimientoBLL;

        public FormReporteMovimientos()
        {
            movimientoBLL = new MovimientoInventarioBLL(new DAL.MovimientoInventarioDAL(new InventarioDbContext()));

            Text = "Reporte de Movimientos de Inventario";
            Width = 800;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;

            Label lblDesde = new Label { Text = "Desde:", Top = 20, Left = 20 };
            dtpDesde = new DateTimePicker { Top = 40, Left = 20, Width = 200 };

            Label lblHasta = new Label { Text = "Hasta:", Top = 20, Left = 240 };
            dtpHasta = new DateTimePicker { Top = 40, Left = 240, Width = 200 };

            Label lblTipo = new Label { Text = "Tipo:", Top = 20, Left = 460 };
            cbTipo = new ComboBox
            {
                Top = 40,
                Left = 460,
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbTipo.Items.Add("TODOS");
            cbTipo.Items.Add("ENTRADA");
            cbTipo.Items.Add("SALIDA");
            cbTipo.SelectedIndex = 0;

            btnBuscar = new Button { Text = "Buscar", Top = 40, Left = 600, Width = 100 };
            btnBuscar.Click += BtnBuscar_Click;

            btnExportarPDF = new Button { Text = "Exportar a PDF", Top = 40, Left = 710, Width = 120 };
            btnExportarPDF.Click += BtnExportarPDF_Click;

            Controls.Add(btnExportarPDF);


            dgvReporte = new DataGridView
            {
                Top = 90,
                Left = 20,
                Width = 740,
                Height = 440,
                ReadOnly = true,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            Controls.AddRange(new Control[] {
                lblDesde, dtpDesde, lblHasta, dtpHasta, lblTipo, cbTipo, btnBuscar, dgvReporte
            });
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);
            string tipo = cbTipo.SelectedItem.ToString();

            var movimientos = movimientoBLL.ObtenerMovimientos();

            var filtrado = movimientos
                .Where(m => m.Fecha >= desde && m.Fecha <= hasta)
                .Where(m => tipo == "TODOS" || m.Tipo == tipo)
                .Select(m => new
                {
                    Fecha = m.Fecha,
                    Producto = m.Producto?.Nombre ?? "N/A",
                    Tipo = m.Tipo,
                    Cantidad = m.Cantidad,
                    Observación = m.Observacion
                })
                .ToList();

            dgvReporte.DataSource = filtrado;
        }

        private void BtnExportarPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "ReporteMovimientos.pdf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var stream = new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create))
                        {
                            var doc = new iTextSharp.text.Document();
                            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, stream);
                            doc.Open();

                            var fontTitle = iTextSharp.text.FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);
                            var title = new iTextSharp.text.Paragraph("Reporte de Movimientos de Inventario", fontTitle);
                            title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                            doc.Add(title);
                            doc.Add(new iTextSharp.text.Paragraph(" ")); // espacio

                            var table = new iTextSharp.text.pdf.PdfPTable(dgvReporte.Columns.Count);
                            foreach (DataGridViewColumn column in dgvReporte.Columns)
                            {
                                table.AddCell(new iTextSharp.text.Phrase(column.HeaderText));
                            }

                            foreach (DataGridViewRow row in dgvReporte.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.AddCell(cell.Value?.ToString() ?? "");
                                }
                            }

                            doc.Add(table);
                            doc.Close();
                            stream.Close();

                            MessageBox.Show("Reporte exportado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar PDF: " + ex.Message);
                    }
                }
            }
        }

    }
}
