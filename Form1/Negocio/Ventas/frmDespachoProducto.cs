using BEs.Clases.Negocio.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheeseLogix.Negocio.Ventas
{
    public partial class frmDespachoProducto : Form
    {
        private Venta _ventaActual;

        public frmDespachoProducto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que recibe la venta para el despacho
        /// </summary>
        /// <param name="venta">Venta a despachar</param>
        public frmDespachoProducto(Venta venta) : this()
        {
            _ventaActual = venta;
            // TODO: Implementar lógica de despacho
        }

        private void frmCobroVenta_Load(object sender, EventArgs e)
        {
            // TODO: Cargar datos de la venta para despacho
            if (_ventaActual != null)
            {
                // Configurar datos del formulario
                this.Text = $"Despacho de Productos - Venta #{_ventaActual.Id}";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnFirmarConforme_Click(object sender, EventArgs e)
        {
            // TODO: Implementar lógica para marcar como entregada
            try
            {
                if (_ventaActual != null)
                {
                    // Aquí se implementará la lógica para cambiar estado a "Entregada"
                    MessageBox.Show("Producto despachado y entregado exitosamente.", "Despacho confirmado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar el despacho: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {

        }

        private void cboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
