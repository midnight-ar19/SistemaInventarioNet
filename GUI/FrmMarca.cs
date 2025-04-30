using System;
using System.Windows.Forms;
using DAL; 
using EL;  

namespace GUI
{
    public partial class FrmMarca : Form
    {
        private readonly MarcaDAL _marcaDAL;

        public FrmMarca()
        {
            InitializeComponent();
            _marcaDAL = new MarcaDAL(new InventarioDbContext()); 
        }

        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
              
                Marca nuevaMarca = new Marca
                {
                    IdMarca = Convert.ToInt32(txtId.Text), 
                    Nombre = txtNombre.Text
                };

                
                _marcaDAL.AgregarMarca(nuevaMarca);
                MessageBox.Show("Marca agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Marca marcaActualizada = new Marca
                {
                    IdMarca = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text
                };

                _marcaDAL.ActualizarMarca(marcaActualizada);
                MessageBox.Show("Marca actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                _marcaDAL.EliminarMarca(id);
                MessageBox.Show("Marca eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                Marca marca = _marcaDAL.BuscarMarca(id);

                if (marca != null)
                {
                    txtNombre.Text = marca.Nombre;
                }
                else
                {
                    MessageBox.Show("Marca no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void FrmMarca_Load(object sender, EventArgs e)
        {
          
        }
    }
}