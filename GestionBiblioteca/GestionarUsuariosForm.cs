using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GestionBiblioteca.Models;

namespace GestionBiblioteca
{
    public partial class GestionarUsuariosForm : Form
    {
        private Biblioteca biblioteca;

        // Parameterless constructor required by the Windows Forms designer
        public GestionarUsuariosForm()
        {
            InitializeComponent();
            // Do not call runtime logic here; designer will use this constructor.
        }

        public GestionarUsuariosForm(Biblioteca biblioteca)
        {
            InitializeComponent();
            this.biblioteca = biblioteca;
            CargarUsuarios();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Usuario nuevoUsuario = new Usuario(0, nombre, correo);
            biblioteca.AgregarUsuario(nuevoUsuario);
            CargarUsuarios();
            LimpiarCampos();

            MessageBox.Show("Usuario agregado con éxito.");
            return;

        }

        private void CargarUsuarios()
        {
            lstUsuarios.Items.Clear();
            var usuarios = biblioteca.ListarUsuarios();
            foreach (var usuario in usuarios)
            {
                lstUsuarios.Items.Add(usuario);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
        }

        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario para actualizar.");
                return;
            }
            var usuarioSeleccionado = lstUsuarios.SelectedItem as Usuario;
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Selección inválida.");
                return;
            }

            Usuario usuarioActualizado = new Usuario(usuarioSeleccionado.Id, txtNombre.Text, txtCorreo.Text);
            biblioteca.ActualizarUsuario(usuarioActualizado);
            CargarUsuarios();
            LimpiarCampos();

            MessageBox.Show("Usuario actualizado con éxito.");
            return;

        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.");
                return;
            }
            var usuarioSeleccionado = lstUsuarios.SelectedItem as Usuario;
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Selección inválida.");
                return;
            }

            biblioteca.EliminarUsuario(usuarioSeleccionado.Id);
            CargarUsuarios();
            LimpiarCampos();

            MessageBox.Show("Usuario eliminado con éxito.");
            return;


        }
        private void SalirUsuario_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra formulario de gestión de usuarios
        }

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var usuarioSeleccionado = lstUsuarios.SelectedItem as Usuario;
            if (usuarioSeleccionado != null)
            {
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtCorreo.Text = usuarioSeleccionado.Correo;
            }
        }
    }
}
