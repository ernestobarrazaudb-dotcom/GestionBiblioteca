using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GestionBiblioteca.Models;

namespace GestionBiblioteca
{
    public partial class GestionarPrestamosForm : Form
    {
        private Biblioteca biblioteca;
        private readonly string dataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "GestionBiblioteca");
        // Parameterless constructor required by the Windows Forms designer
        public GestionarPrestamosForm()
        {
            InitializeComponent();
            // Designer-only constructor: no runtime logic here
        }

        public GestionarPrestamosForm(Biblioteca biblioteca)
        {
            InitializeComponent();
            this.biblioteca = biblioteca;
            CargarLibros();
            CargarUsuarios();
            CargarPrestamos();
        }

        private void CargarLibros()
        {
            comboBoxLibros.Items.Clear();
            foreach (var libro in biblioteca.ListarLibros())
            {
                comboBoxLibros.Items.Add($"{libro.Id} - {libro.Titulo}");
            }
        }

        private void CargarUsuarios()
        {
            comboBoxUsuarios.Items.Clear();
             foreach (var usuario in biblioteca.ListarUsuarios()) { 
                 comboBoxUsuarios.Items.Add($"{usuario.Id} - {usuario.Nombre}"); 
             }
        }

        private void CargarPrestamos()
        {
            listBoxPrestamos.Items.Clear();
            foreach (var prestamo in biblioteca.ListarPrestamos())
            {
                listBoxPrestamos.Items.Add($"Préstamo ID: {prestamo.Id}, Libro ID: {prestamo.IdLibro}, Usuario ID: {prestamo.IdUsuario}, Fecha: {prestamo.FechaPrestamo}, Devolución: {prestamo.FechaDevolucion?.ToString("d") ?? "Pendiente"}");
            }
        }

        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxLibros.SelectedItem == null || comboBoxUsuarios.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un libro y un usuario.");
                    return;
                }

                var libroId = int.Parse(comboBoxLibros.SelectedItem.ToString().Split('-')[0].Trim());
                var usuarioId = int.Parse(comboBoxUsuarios.SelectedItem.ToString().Split('-')[0].Trim());

                biblioteca.RegistrarPrestamo(libroId, usuarioId);
                CargarPrestamos();
                MessageBox.Show("Préstamo registrado exitosamente.");
                comboBoxLibros.SelectedItem = null;
                comboBoxUsuarios.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDevolverLibro_Click(object sender, EventArgs e)
        {
            if (listBoxPrestamos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un préstamo para devolver.");
                return;
            }

            try
            {
                var selectedItem = listBoxPrestamos.SelectedItem.ToString();
                var prestamoId = int.Parse(selectedItem.Split(new[] { "Préstamo ID: " }, StringSplitOptions.None)[1].Split(',')[0]);

                biblioteca.DevolverLibro(prestamoId);
                CargarPrestamos();
                MessageBox.Show("Libro devuelto exitosamente.");
                comboBoxLibros.Items.Clear();
                comboBoxUsuarios.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalirUsuario_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario de gestión de préstamos
        }
    }
}

