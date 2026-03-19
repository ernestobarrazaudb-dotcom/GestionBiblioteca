using GestionBiblioteca.Models;
using System;
using System.Windows.Forms;

namespace GestionBiblioteca
{
    public partial class GestionarLibrosForm : Form
    {
        private Biblioteca biblioteca;
        public GestionarLibrosForm()
        {
            InitializeComponent();
            // Designer-only constructor: no runtime logic here
        }

        public GestionarLibrosForm(Biblioteca biblioteca)
        {
            InitializeComponent();
            this.biblioteca = biblioteca;
            CargarLibros();
        }

        private void CargarLibros()
        {
            listBoxLibros.Items.Clear();
            foreach (var libro in biblioteca.ListarLibros())
            {
                listBoxLibros.Items.Add($"{libro.Id} - {libro.Titulo} - {libro.Autor} - {libro.AnioPublicacion} (Disponible: {libro.Disponible})");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtAutor.Text) || !int.TryParse(txtAnioPublicacion.Text, out int anioPublicacion) || anioPublicacion <= 0)
                {
                    MessageBox.Show("Por favor, completa todos los campos correctamente.");
                    return;
                }

                var libro = new Libro(0, txtTitulo.Text, txtAutor.Text, anioPublicacion, true); // 'true' indica que el libro está disponible
                biblioteca.AgregarLibro(libro);
                CargarLibros();
                LimpiarCampos();
                MessageBox.Show("Libro agregado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el libro: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (listBoxLibros.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un libro para actualizar.");
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtAutor.Text) || !int.TryParse(txtAnioPublicacion.Text, out int anioPublicacion) || anioPublicacion <= 0)
                {
                    MessageBox.Show("Por favor, completa todos los campos correctamente.");
                    return;
                }

                var selectedItem = listBoxLibros.SelectedItem.ToString();
                var id = int.Parse(selectedItem.Split(new[] { " - " }, StringSplitOptions.None)[0]);
                var libroActualizado = new Libro(id, txtTitulo.Text, txtAutor.Text, anioPublicacion, true); // 'true' indica que el libro está disponible
                biblioteca.ActualizarLibro(libroActualizado);
                CargarLibros();
                LimpiarCampos();
                MessageBox.Show("Libro actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el libro: " + ex.Message);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listBoxLibros.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un libro para eliminar.");
                return;
            }

            try
            {
                var selectedItem = listBoxLibros.SelectedItem.ToString();
                var id = int.Parse(selectedItem.Split(new[] { " - " }, StringSplitOptions.None)[0]);
                biblioteca.EliminarLibro(id);
                CargarLibros();
                LimpiarCampos();
                MessageBox.Show("Libro eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtAutor.Clear();
            txtAnioPublicacion.Clear();
        }

        // Evento para llenar los campos al seleccionar un libro
        public void listBoxLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxLibros.SelectedItem != null)
            {
                var selectedItem = listBoxLibros.SelectedItem.ToString();
                var id = int.Parse(selectedItem.Split(new[] { " - " }, StringSplitOptions.None)[0]);
                var libro = biblioteca.ObtenerLibro(id);

                if (libro != null)
                {
                    txtTitulo.Text = libro.Titulo;
                    txtAutor.Text = libro.Autor;
                    txtAnioPublicacion.Text = libro.AnioPublicacion.ToString();
                }
            }
        }

        private void SalirUsuario_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra formulario de gestión de usuarios
        }
    }
}
