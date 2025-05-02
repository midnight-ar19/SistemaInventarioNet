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

namespace GUI
{
    public partial class FormProveedor : Form
    {
        private readonly ProveedorDAL _proveedorDAL;

        public FormProveedor()
        {
            InitializeComponent();
            _proveedorDAL = new ProveedorDAL(new InventarioDbContext());

        }

        private void FormProveedor_Load(object sender, EventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor nuevoProveedor = new Proveedor
                {
                    Nombre = textBoxNombreProveedor.Text,
                    Contacto = textBoxContacto.Text,
                    Direccion = textBoxDireccion.Text,
                    Telefono = textBoxTelefono.Text,
                };

                _proveedorDAL.AgregarProveedor(nuevoProveedor);
                MessageBox.Show("Proveedor agregado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar proveedor: {ex.Message}");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxIDProveedor.Text))
            {
                MessageBox.Show("Ingrese un ID de proveedor");
                return;
            }
            try
            {
                int idProveedor = Convert.ToInt32(textBoxIDProveedor.Text);
                Proveedor proveedor = _proveedorDAL.BuscarProveedor(idProveedor);

                if (proveedor != null)
                {
                    textBoxNombreProveedor.Text = proveedor.Nombre;
                    textBoxContacto.Text = proveedor.Contacto;
                    textBoxDireccion.Text = proveedor.Direccion;
                    textBoxTelefono.Text = proveedor.Telefono;
                }
                else
                {
                    MessageBox.Show("Proveedor no encontrado");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxIDProveedor.Text))
            {
                MessageBox.Show("Ingrese un ID de proveedor");
                return;
            }
            try
            {
                Proveedor proveedorActualizado = new Proveedor
                {
                    IdProveedor = Convert.ToInt32(textBoxIDProveedor.Text),
                    Nombre = textBoxNombreProveedor.Text,
                    Contacto = textBoxContacto.Text,
                    Direccion = textBoxDireccion.Text,
                    Telefono = textBoxTelefono.Text,
                };

                _proveedorDAL.ActualizarProveedor(proveedorActualizado);
                MessageBox.Show("Se ha actualizado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error, no se pudo actualizar: {ex.Message}");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxIDProveedor.Text))
            {
                MessageBox.Show("Ingrese un ID de proveedor");
                return;
            }
            try
            {
                int idProveedor = Convert.ToInt32(textBoxIDProveedor.Text);

                if (MessageBox.Show("¿Seguro que deseas eliminar este proveedor?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _proveedorDAL.EliminarProveedor(idProveedor);
                    MessageBox.Show("El proveedor ha sido eliminado correctamente");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error, no se pudo eliminar: {ex.Message}");
            }
        }
    }
}