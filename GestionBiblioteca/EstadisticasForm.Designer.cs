namespace GestionBiblioteca
{
    partial class EstadisticasForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstLibrosMasPrestados = new System.Windows.Forms.ListBox();
            this.lstUsuariosMasActivos = new System.Windows.Forms.ListBox();
            this.lblLibrosMasPrestados = new System.Windows.Forms.Label();
            this.lblUsuariosMasActivos = new System.Windows.Forms.Label();
            this.chartEstadisticas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.SalirUsuario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartEstadisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // lstLibrosMasPrestados
            // 
            this.lstLibrosMasPrestados.FormattingEnabled = true;
            this.lstLibrosMasPrestados.Location = new System.Drawing.Point(12, 25);
            this.lstLibrosMasPrestados.Name = "lstLibrosMasPrestados";
            this.lstLibrosMasPrestados.Size = new System.Drawing.Size(214, 95);
            this.lstLibrosMasPrestados.TabIndex = 0;
            // 
            // lstUsuariosMasActivos
            // 
            this.lstUsuariosMasActivos.FormattingEnabled = true;
            this.lstUsuariosMasActivos.Location = new System.Drawing.Point(12, 150);
            this.lstUsuariosMasActivos.Name = "lstUsuariosMasActivos";
            this.lstUsuariosMasActivos.Size = new System.Drawing.Size(214, 95);
            this.lstUsuariosMasActivos.TabIndex = 1;
            // 
            // lblLibrosMasPrestados
            // 
            this.lblLibrosMasPrestados.AutoSize = true;
            this.lblLibrosMasPrestados.Location = new System.Drawing.Point(12, 9);
            this.lblLibrosMasPrestados.Name = "lblLibrosMasPrestados";
            this.lblLibrosMasPrestados.Size = new System.Drawing.Size(111, 13);
            this.lblLibrosMasPrestados.TabIndex = 2;
            this.lblLibrosMasPrestados.Text = "Libros Más Prestados:";
            // 
            // lblUsuariosMasActivos
            // 
            this.lblUsuariosMasActivos.AutoSize = true;
            this.lblUsuariosMasActivos.Location = new System.Drawing.Point(12, 134);
            this.lblUsuariosMasActivos.Name = "lblUsuariosMasActivos";
            this.lblUsuariosMasActivos.Size = new System.Drawing.Size(112, 13);
            this.lblUsuariosMasActivos.TabIndex = 3;
            this.lblUsuariosMasActivos.Text = "Usuarios Más Activos:";
            // 
            // chartEstadisticas
            // 
            this.chartEstadisticas.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.Graphics;
            this.chartEstadisticas.Location = new System.Drawing.Point(232, 25);
            this.chartEstadisticas.Name = "chartEstadisticas";
            this.chartEstadisticas.Size = new System.Drawing.Size(477, 291);
            this.chartEstadisticas.TabIndex = 4;
            this.chartEstadisticas.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gráficas";
            // 
            // SalirUsuario
            // 
            this.SalirUsuario.Location = new System.Drawing.Point(617, 322);
            this.SalirUsuario.Name = "SalirUsuario";
            this.SalirUsuario.Size = new System.Drawing.Size(92, 24);
            this.SalirUsuario.TabIndex = 15;
            this.SalirUsuario.Text = "Volver al Menú";
            this.SalirUsuario.UseVisualStyleBackColor = true;
            this.SalirUsuario.Click += new System.EventHandler(this.SalirUsuario_Click);
            // 
            // EstadisticasForm
            // 
            this.ClientSize = new System.Drawing.Size(721, 358);
            this.Controls.Add(this.SalirUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartEstadisticas);
            this.Controls.Add(this.lblUsuariosMasActivos);
            this.Controls.Add(this.lblLibrosMasPrestados);
            this.Controls.Add(this.lstUsuariosMasActivos);
            this.Controls.Add(this.lstLibrosMasPrestados);
            this.Name = "EstadisticasForm";
            this.Text = "Estadísticas";
            ((System.ComponentModel.ISupportInitialize)(this.chartEstadisticas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox lstLibrosMasPrestados;
        private System.Windows.Forms.ListBox lstUsuariosMasActivos;
        private System.Windows.Forms.Label lblLibrosMasPrestados;
        private System.Windows.Forms.Label lblUsuariosMasActivos;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartEstadisticas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SalirUsuario;
    }
}
