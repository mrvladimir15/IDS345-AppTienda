namespace Caja
{
    partial class frm_Factura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Factura));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.procMostrarDGVDetallesFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_Login = new Caja.DS_Login();
            this.procMostrarDatosClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_Login1 = new Caja.DS_Login();
            this.proc_MostrarDGVDetallesFacturaTableAdapter = new Caja.DS_LoginTableAdapters.proc_MostrarDGVDetallesFacturaTableAdapter();
            this.proc_MostrarDatosClienteTableAdapter = new Caja.DS_LoginTableAdapters.proc_MostrarDatosClienteTableAdapter();
            this.procMostrarDatosFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proc_MostrarDatosFacturaTableAdapter = new Caja.DS_LoginTableAdapters.proc_MostrarDatosFacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.procMostrarDGVDetallesFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procMostrarDatosClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Login1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procMostrarDatosFacturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DS_DetalleFactura";
            reportDataSource4.Value = this.procMostrarDGVDetallesFacturaBindingSource;
            reportDataSource5.Name = "DS_DatosCliente";
            reportDataSource5.Value = this.procMostrarDatosClienteBindingSource;
            reportDataSource6.Name = "DS_Facturas";
            reportDataSource6.Value = this.procMostrarDatosFacturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Caja.rpt_Factura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(585, 508);
            this.reportViewer1.TabIndex = 0;
            // 
            // procMostrarDGVDetallesFacturaBindingSource
            // 
            this.procMostrarDGVDetallesFacturaBindingSource.DataMember = "proc_MostrarDGVDetallesFactura";
            this.procMostrarDGVDetallesFacturaBindingSource.DataSource = this.dS_Login;
            // 
            // dS_Login
            // 
            this.dS_Login.DataSetName = "DS_Login";
            this.dS_Login.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // procMostrarDatosClienteBindingSource
            // 
            this.procMostrarDatosClienteBindingSource.DataMember = "proc_MostrarDatosCliente";
            this.procMostrarDatosClienteBindingSource.DataSource = this.dS_Login1;
            // 
            // dS_Login1
            // 
            this.dS_Login1.DataSetName = "DS_Login";
            this.dS_Login1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // proc_MostrarDGVDetallesFacturaTableAdapter
            // 
            this.proc_MostrarDGVDetallesFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // proc_MostrarDatosClienteTableAdapter
            // 
            this.proc_MostrarDatosClienteTableAdapter.ClearBeforeFill = true;
            // 
            // procMostrarDatosFacturaBindingSource
            // 
            this.procMostrarDatosFacturaBindingSource.DataMember = "proc_MostrarDatosFactura";
            this.procMostrarDatosFacturaBindingSource.DataSource = this.dS_Login;
            // 
            // proc_MostrarDatosFacturaTableAdapter
            // 
            this.proc_MostrarDatosFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // frm_Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 508);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Factura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.frm_Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.procMostrarDGVDetallesFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procMostrarDatosClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Login1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procMostrarDatosFacturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource procMostrarDGVDetallesFacturaBindingSource;
        private DS_Login dS_Login;
        private DS_LoginTableAdapters.proc_MostrarDGVDetallesFacturaTableAdapter proc_MostrarDGVDetallesFacturaTableAdapter;
        private System.Windows.Forms.BindingSource procMostrarDatosClienteBindingSource;
        private DS_Login dS_Login1;
        private DS_LoginTableAdapters.proc_MostrarDatosClienteTableAdapter proc_MostrarDatosClienteTableAdapter;
        private System.Windows.Forms.BindingSource procMostrarDatosFacturaBindingSource;
        private DS_LoginTableAdapters.proc_MostrarDatosFacturaTableAdapter proc_MostrarDatosFacturaTableAdapter;
    }
}