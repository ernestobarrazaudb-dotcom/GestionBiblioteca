using System;
using System.Windows.Forms;
using GestionBiblioteca.Models; // Importa el namespace
using System.IO;

namespace GestionBiblioteca
{
    public partial class MainForm : Form
    {
        private Biblioteca biblioteca;
        private readonly string dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"GestionBiblioteca");

        public MainForm()
        {
            InitializeComponent();
            biblioteca = new Biblioteca();
        }
        private void BtnGestionarLibros_Click(object sender, EventArgs e)
        {
            GestionarLibrosForm gestionarUsuariosForm = new GestionarLibrosForm(biblioteca);
            gestionarUsuariosForm.ShowDialog(); // Abre el formulario como un diálogo modal

        }

        private void BtnGestionarUsuarios_Click(object sender, EventArgs e)
        {
            GestionarUsuariosForm gestionarUsuariosForm = new GestionarUsuariosForm(biblioteca);
            gestionarUsuariosForm.ShowDialog(); // Abre el formulario como un diálogo modal
        }

        private void BtnGestionarPrestamos_Click(object sender, EventArgs e)
        {
            GestionarPrestamosForm gestionarPrestamosForm = new GestionarPrestamosForm(biblioteca);
            gestionarPrestamosForm.ShowDialog(); // Abre el formulario como un diálogo modal
        }
        private void BtnEstadisticas_Click(object sender, EventArgs e)
        {
            EstadisticasForm estadisticasForm = new EstadisticasForm(biblioteca);
            estadisticasForm.ShowDialog(); // Abre el formulario como un diálogo modal
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la aplicación
        }
    }
}
