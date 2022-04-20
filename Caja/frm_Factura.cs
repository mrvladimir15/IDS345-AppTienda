using Caja.DS_LoginTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caja
{
    public partial class frm_Factura : Form
    {
        // Objeto log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        FacturasTableAdapter adapterFacturas = new FacturasTableAdapter();
        ClientesTableAdapter adapterClientes = new ClientesTableAdapter();

        public frm_Factura()
        {
            InitializeComponent();
        }

        private void frm_Factura_Load(object sender, EventArgs e)
        {
            int IdFactura = int.Parse(adapterFacturas.proc_UltimaFactura().ToString()); // Se guarda el ID creado para la factura en curso
            this.proc_MostrarDatosFacturaTableAdapter.Fill(this.dS_Login.proc_MostrarDatosFactura, IdFactura);
            this.proc_MostrarDGVDetallesFacturaTableAdapter.Fill(this.dS_Login.proc_MostrarDGVDetallesFactura, IdFactura);

            int IdCliente = int.Parse(adapterClientes.proc_ObtenerIDCliente(IdFactura).ToString()); // Se guarda el ID creado para la factura en curso
            this.proc_MostrarDatosClienteTableAdapter.Fill(this.dS_Login1.proc_MostrarDatosCliente, IdCliente);

            this.reportViewer1.RefreshReport();
            log.Info("Factura impresa");
        }
    }
}
