using System;
using System.Windows.Forms;
using GestionBiblioteca.Models; // Importa el namespace

namespace GestionBiblioteca
{
    public partial class MainForm : Form
    {
        private Biblioteca biblioteca;

        public MainForm()
        {
            InitializeComponent();
            biblioteca = new Biblioteca();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Gestión de Biblioteca";
            this.Size = new System.Drawing.Size(400, 300);

            // Botón para gestionar libros
            Button btnGestionarLibros = new Button();
            btnGestionarLibros.Text = "Gestionar Libros";
            btnGestionarLibros.Location = new System.Drawing.Point(50, 50);
            btnGestionarLibros.Click += BtnGestionarLibros_Click;
            this.Controls.Add(btnGestionarLibros);

            // Botón para gestionar usuarios
            Button btnGestionarUsuarios = new Button();
            btnGestionarUsuarios.Text = "Gestionar Usuarios";
            btnGestionarUsuarios.Location = new System.Drawing.Point(50, 100);
            btnGestionarUsuarios.Click += BtnGestionarUsuarios_Click;
            this.Controls.Add(btnGestionarUsuarios);

            // Botón para gestionar préstamos
            Button btnGestionarPrestamos = new Button();
            btnGestionarPrestamos.Text = "Gestionar Préstamos";
            btnGestionarPrestamos.Location = new System.Drawing.Point(50, 150);
            btnGestionarPrestamos.Click += BtnGestionarPrestamos_Click;
            this.Controls.Add(btnGestionarPrestamos);

            // Botón para salir
            Button btnSalir = new Button();
            btnSalir.Text = "Salir";
            btnSalir.Location = new System.Drawing.Point(50, 200);
            btnSalir.Click += BtnSalir_Click;
            this.Controls.Add(btnSalir);
        }

        private void BtnGestionarLibros_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir un nuevo formulario para gestionar libros
            MessageBox.Show("Abrir formulario de gestión de libros.");
        }

        private void BtnGestionarUsuarios_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir un nuevo formulario para gestionar usuarios
            MessageBox.Show("Abrir formulario de gestión de usuarios.");
        }

        private void BtnGestionarPrestamos_Click(object sender, EventArgs e)
        {
            // Aquí puedes abrir un nuevo formulario para gestionar préstamos
            MessageBox.Show("Abrir formulario de gestión de préstamos.");
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la aplicación
        }
    }
}
