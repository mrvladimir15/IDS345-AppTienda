using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caja.DS_LoginTableAdapters;

namespace Caja
{
    public partial class frm_Cotizaciones : Form
    {
        public frm_Cotizaciones()
        {
            InitializeComponent();
        }

        // Objeto log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        DataTable tabla = new DataTable();
        public int IdCotizacion;
        public double TotalBruto, TotalITBIS, TotalNeto;
        public bool estadoCotizacion = false;

        // Adapters
        ClientesTableAdapter adapterClientes = new ClientesTableAdapter();
        CotizacionesTableAdapter adapterCotizaciones = new CotizacionesTableAdapter();
        CotizacionesDetalleTableAdapter adapterDetalleCotizaciones = new CotizacionesDetalleTableAdapter();
        ProductosTableAdapter adapterProductos = new ProductosTableAdapter();

        // Metodo para permitir solo el ingreso de numeros en los campos
        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        #region Eventos KeyPress
        private void txtIDCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
        #endregion

        // Boton nueva cotizacion
        private void btnNuevaCotizacion_Click(object sender, EventArgs e)
        {
            if (txtIDCliente.Text.Trim() != "")
            {
                try
                {
                    // Se llena el datatable con la información del cliente
                    tabla = adapterClientes.GetDataByClientes(int.Parse(txtIDCliente.Text));

                    // Si retorna filas, entonces el cliente existe y se puede facturar
                    if (tabla.Rows.Count > 0)
                    {
                        #region Crear nueva cotización
                        estadoCotizacion = true;
                        string RNC = tabla.Rows[0][5].ToString();

                        adapterCotizaciones.proc_InsertarCotizacion(int.Parse(txtIDCliente.Text), RNC);
                        ControlesCotizacion();

                        log.Info("Nueva cotización creada");
                        tabla.Rows.Clear(); // Insertada la informacion, se elimina la data del datatable
                        IdCotizacion = int.Parse(adapterCotizaciones.proc_UltimaCotizacion().ToString()); // Se guarda el ID creado para la cotizacion en curso
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("El ID ingresado no pertenece a ningún cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.Error("ID erróneo ingresado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    log.Error(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos para iniciar una nueva cotización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.Error("Campos incompletos para iniciar una nueva factura.");
            }
        }

        // Agregar productos
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCantidadProducto.Text.Trim() != "" && txtCodigoProducto.Text.Trim() != "" && txtCantidadProducto.Text.Trim() != "0" && txtCodigoProducto.Text.Trim() != "0")
                {
                    // Inserción del producto en la tabla detalle factura
                    adapterDetalleCotizaciones.proc_DetalleCotizacion(IdCotizacion, int.Parse(txtCodigoProducto.Text.Trim()), int.Parse(txtCantidadProducto.Text.Trim()));
                    log.Info("Detalle de cotización creado");

                    // Insertado el producto, se reestablecen los valores por defecto de los campos
                    txtCantidadProducto.Text = "0";
                    txtCodigoProducto.Text = "0";

                    // Actualización del datagridview para ver el detalle de la factura
                    dgvDetalleFactura.DataSource = adapterDetalleCotizaciones.GetDataByDetalleCotizacion(IdCotizacion);

                    TotalNeto = double.Parse(adapterDetalleCotizaciones.proc_MostrarTotalPagarCotizacion(IdCotizacion).ToString());
                    lblTotalPagar.Text = TotalNeto.ToString();

                    log.Info("Producto agregado");
                }
                else
                    MessageBox.Show("Complete todos los campos para agregar productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                log.Error(ex.Message);
            }
        }

        // Boton finalizar cotizacion
        private void button1_Click(object sender, EventArgs e)
        {
            // Si hay productos agregados en el DGV, se procede a facturar
            if (dgvDetalleFactura.Rows.Count > 0)
            {
                estadoCotizacion = false;
                ControlesCotizacion();
                MessageBox.Show("Cotización completada con éxito.", "Transacción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                log.Info("Cotización completada con éxito.");
            }
            else
                MessageBox.Show("Agregue al menos un producto para facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Eventos textbox
        // Evento enter txtCodigoProducto
        private void txtCodigoProducto_Enter(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text == "0")
                txtCodigoProducto.Text = "";
        }

        // Evento leave del txtCodigoProducto para validar si existe el producto
        private void txtCodigoProducto_Leave(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text.Trim() == "")
                txtCodigoProducto.Text = "0";
            else
            {
                // Si el adapter no retorna filas, entonces el producto no existe; se muestra una alerta
                if (adapterProductos.GetDataByProductos(int.Parse(txtCodigoProducto.Text)).Rows.Count == 0)
                    lblAlertaCodigoProducto.Text = "El código ingresado no existe. Intente con uno válido";
                else
                    lblAlertaCodigoProducto.Text = "";
            }
        }

        // Evento enter txtCantidad
        private void txtCantidadProducto_Enter(object sender, EventArgs e)
        {
            if (txtCantidadProducto.Text == "0")
                txtCantidadProducto.Text = "";
        }

        // Evento leave cantidad producto
        private void txtCantidadProducto_Leave(object sender, EventArgs e)
        {
            if (txtCantidadProducto.Text.Trim() == "")
                txtCantidadProducto.Text = "0";
        }
        #endregion

        // Controles de cotizacion
        public void ControlesCotizacion()
        {
            /* Si hay una factura creada, se deshabilita el panel para crear una factura y se habilita el panel
            para el detalle de factura, de lo contrario, se hace la operación inversa y se limpian los campos.*/
            switch (estadoCotizacion)
            {
                case true:
                    panelNuevaCotizacion.Enabled = false;
                    panelDetalleCotizacion.Enabled = true;
                    break;
                case false:
                    panelNuevaCotizacion.Enabled = true;
                    panelDetalleCotizacion.Enabled = false;
                    LimpiarCampos();
                    break;
                default:
                    break;
            }
        }

        // Limpiar campos
        private void LimpiarCampos()
        {
            txtIDCliente.Clear();
            txtIDCliente.Focus();
            lblSubtotal.Text = "";
            lblITBIS.Text = "";
            lblTotalPagar.Text = "";
            dgvDetalleFactura.DataSource = null;
        }
    }
}
