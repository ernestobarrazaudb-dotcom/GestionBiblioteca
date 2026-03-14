namespace GestionBiblioteca
{
    partial class GestionarPrestamosForm
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
            this.comboBoxLibros = new System.Windows.Forms.ComboBox();
            this.comboBoxUsuarios = new System.Windows.Forms.ComboBox();
            this.btnRegistrarPrestamo = new System.Windows.Forms.Button();
            this.btnDevolverLibro = new System.Windows.Forms.Button();
            this.listBoxPrestamos = new System.Windows.Forms.ListBox();
            this.SalirUsuario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxLibros
            // 
            this.comboBoxLibros.FormattingEnabled = true;
            this.comboBoxLibros.Location = new System.Drawing.Point(135, 78);
            this.comboBoxLibros.Name = "comboBoxLibros";
            this.comboBoxLibros.Size = new System.Drawing.Size(223, 21);
            this.comboBoxLibros.TabIndex = 0;
            // 
            // comboBoxUsuarios
            // 
            this.comboBoxUsuarios.FormattingEnabled = true;
            this.comboBoxUsuarios.Location = new System.Drawing.Point(135, 114);
            this.comboBoxUsuarios.Name = "comboBoxUsuarios";
            this.comboBoxUsuarios.Size = new System.Drawing.Size(222, 21);
            this.comboBoxUsuarios.TabIndex = 1;
            // 
            // btnRegistrarPrestamo
            // 
            this.btnRegistrarPrestamo.Location = new System.Drawing.Point(75, 150);
            this.btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            this.btnRegistrarPrestamo.Size = new System.Drawing.Size(119, 29);
            this.btnRegistrarPrestamo.TabIndex = 2;
            this.btnRegistrarPrestamo.Text = "Registrar Préstamo";
            this.btnRegistrarPrestamo.UseVisualStyleBackColor = true;
            this.btnRegistrarPrestamo.Click += new System.EventHandler(this.btnRegistrarPrestamo_Click);
            // 
            // btnDevolverLibro
            // 
            this.btnDevolverLibro.Location = new System.Drawing.Point(237, 150);
            this.btnDevolverLibro.Name = "btnDevolverLibro";
            this.btnDevolverLibro.Size = new System.Drawing.Size(121, 28);
            this.btnDevolverLibro.TabIndex = 3;
            this.btnDevolverLibro.Text = "Devolver Libro";
            this.btnDevolverLibro.UseVisualStyleBackColor = true;
            this.btnDevolverLibro.Click += new System.EventHandler(this.btnDevolverLibro_Click);
            // 
            // listBoxPrestamos
            // 
            this.listBoxPrestamos.FormattingEnabled = true;
            this.listBoxPrestamos.Location = new System.Drawing.Point(15, 204);
            this.listBoxPrestamos.Name = "listBoxPrestamos";
            this.listBoxPrestamos.Size = new System.Drawing.Size(460, 121);
            this.listBoxPrestamos.TabIndex = 4;
            // 
            // SalirUsuario
            // 
            this.SalirUsuario.Location = new System.Drawing.Point(387, 334);
            this.SalirUsuario.Name = "SalirUsuario";
            this.SalirUsuario.Size = new System.Drawing.Size(92, 24);
            this.SalirUsuario.TabIndex = 15;
            this.SalirUsuario.Text = "Volver al Menú";
            this.SalirUsuario.UseVisualStyleBackColor = true;
            this.SalirUsuario.Click += new System.EventHandler(this.SalirUsuario_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Seleccione Libro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Seleccione Usuario";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(357, 30);
            this.label5.TabIndex = 18;
            this.label5.Text = "GESTIÓN DE PRESTAMOS DE LIBROS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Listado de Préstamos";
            // 
            // GestionarPrestamosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 369);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SalirUsuario);
            this.Controls.Add(this.listBoxPrestamos);
            this.Controls.Add(this.btnDevolverLibro);
            this.Controls.Add(this.btnRegistrarPrestamo);
            this.Controls.Add(this.comboBoxUsuarios);
            this.Controls.Add(this.comboBoxLibros);
            this.Name = "GestionarPrestamosForm";
            this.Text = "Gestionar Prestamos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLibros;
        private System.Windows.Forms.ComboBox comboBoxUsuarios;
        private System.Windows.Forms.Button btnRegistrarPrestamo;
        private System.Windows.Forms.Button btnDevolverLibro;
        private System.Windows.Forms.ListBox listBoxPrestamos;
        private System.Windows.Forms.Button SalirUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}