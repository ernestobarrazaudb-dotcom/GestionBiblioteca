using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioteca.Models
{
    public class Biblioteca
    {
        private List<Libro> libros = new List<Libro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Prestamo> prestamos = new List<Prestamo>();

        // Funciones para gestionar libros
        public void AgregarLibro(Libro libro)
        {
            if (ValidarLibro(libro))
            {
                libros.Add(libro);
            }
        }

        public List<Libro> ListarLibros()
        {
            return libros;
        }

        public Libro ObtenerLibro(int id)
        {
            return libros.FirstOrDefault(l => l.Id == id);
        }

        public void ActualizarLibro(Libro libroActualizado)
        {
            var libro = ObtenerLibro(libroActualizado.Id);
            if (libro != null)
            {
                libro.Titulo = libroActualizado.Titulo;
                libro.Autor = libroActualizado.Autor;
                libro.AnioPublicacion = libroActualizado.AnioPublicacion;
            }
        }

        public void EliminarLibro(int id)
        {
            var libro = ObtenerLibro(id);
            if (libro != null)
            {
                libros.Remove(libro);
            }
        }

        // Funciones para gestionar usuarios
        public void AgregarUsuario(Usuario usuario)
        {
            if (ValidarUsuario(usuario))
            {
                usuarios.Add(usuario);
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            return usuarios;
        }

        public Usuario ObtenerUsuario(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void ActualizarUsuario(Usuario usuarioActualizado)
        {
            var usuario = ObtenerUsuario(usuarioActualizado.Id);
            if (usuario != null)
            {
                usuario.Nombre = usuarioActualizado.Nombre;
                usuario.Correo = usuarioActualizado.Correo;
            }
        }

        public void EliminarUsuario(int id)
        {
            var usuario = ObtenerUsuario(id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
            }
        }

        // Funciones para gestionar préstamos
        public void RegistrarPrestamo(Prestamo prestamo)
        {
            var libro = ObtenerLibro(prestamo.IdLibro);
            if (libro != null && libro.Disponible)
            {
                prestamos.Add(prestamo);
                libro.Disponible = false; // Marcar como no disponible
            }
        }

        public void DevolverLibro(int idPrestamo)
        {
            var prestamo = prestamos.FirstOrDefault(p => p.Id == idPrestamo);
            if (prestamo != null)
            {
                prestamo.FechaDevolucion = DateTime.Now;
                var libro = ObtenerLibro(prestamo.IdLibro);
                if (libro != null)
                {
                    libro.Disponible = true; // Marcar como disponible
                }
            }
        }

        public List<Prestamo> ListarPrestamos()
        {
            return prestamos;
        }

        // Validaciones
        private bool ValidarLibro(Libro libro)
        {
            // Validar campos obligatorios y duplicados
            return !string.IsNullOrWhiteSpace(libro.Titulo) &&
                   !string.IsNullOrWhiteSpace(libro.Autor) &&
                   !libros.Any(l => l.Titulo.Equals(libro.Titulo, StringComparison.OrdinalIgnoreCase) && l.Autor.Equals(libro.Autor, StringComparison.OrdinalIgnoreCase));
        }

        private bool ValidarUsuario(Usuario usuario)
        {
            // Validar campos obligatorios y duplicados
            return !string.IsNullOrWhiteSpace(usuario.Nombre) &&
                   !string.IsNullOrWhiteSpace(usuario.Correo) &&
                   !usuarios.Any(u => u.Correo.Equals(usuario.Correo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
