using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBiblioteca
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        /// Limpia los recursos que se están utilizando.
        /// <param name="disposing">true si los recursos administrados deben eliminarse; de lo contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// Método requerido para la compatibilidad con el Diseñador.
        /// No se puede modificar el contenido de este método con el editor de código.
        private void InitializeComponent()
        {
            this.btnGestionarLibros = new System.Windows.Forms.Button();
            this.btnGestionarUsuarios = new System.Windows.Forms.Button();
            this.btnGestionarPrestamos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestionarLibros
            // 
            this.btnGestionarLibros.Location = new System.Drawing.Point(258, 124);
            this.btnGestionarLibros.Name = "btnGestionarLibros";
            this.btnGestionarLibros.Size = new System.Drawing.Size(149, 40);
            this.btnGestionarLibros.TabIndex = 1;
            this.btnGestionarLibros.Text = "Gestionar Libros";
            this.btnGestionarLibros.UseVisualStyleBackColor = true;
            this.btnGestionarLibros.Click += new System.EventHandler(this.BtnGestionarLibros_Click);
            // 
            // btnGestionarUsuarios
            // 
            this.btnGestionarUsuarios.Location = new System.Drawing.Point(40, 123);
            this.btnGestionarUsuarios.Name = "btnGestionarUsuarios";
            this.btnGestionarUsuarios.Size = new System.Drawing.Size(149, 41);
            this.btnGestionarUsuarios.TabIndex = 0;
            this.btnGestionarUsuarios.Text = "Gestionar Usuarios";
            this.btnGestionarUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionarUsuarios.Click += new System.EventHandler(this.BtnGestionarUsuarios_Click);
            // 
            // btnGestionarPrestamos
            // 
            this.btnGestionarPrestamos.Location = new System.Drawing.Point(40, 195);
            this.btnGestionarPrestamos.Name = "btnGestionarPrestamos";
            this.btnGestionarPrestamos.Size = new System.Drawing.Size(149, 39);
            this.btnGestionarPrestamos.TabIndex = 2;
            this.btnGestionarPrestamos.Text = "Gestionar Préstamos";
            this.btnGestionarPrestamos.UseVisualStyleBackColor = true;
            this.btnGestionarPrestamos.Click += new System.EventHandler(this.BtnGestionarPrestamos_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Location = new System.Drawing.Point(258, 195);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(149, 39);
            this.btnEstadisticas.TabIndex = 0;
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.Click += new System.EventHandler(this.BtnEstadisticas_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(164, 286);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 72);
            this.label1.TabIndex = 4;
            this.label1.Text = "SISTEMA DE GESTION DE BIBLIOTECA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(454, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGestionarPrestamos);
            this.Controls.Add(this.btnGestionarUsuarios);
            this.Controls.Add(this.btnGestionarLibros);
            this.Controls.Add(this.btnEstadisticas);
            this.Name = "MainForm";
            this.Text = "Gestión de Biblioteca";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionarLibros;
        private System.Windows.Forms.Button btnGestionarUsuarios;
        private System.Windows.Forms.Button btnGestionarPrestamos;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnSalir;
        private Label label1;
        
    }
}
