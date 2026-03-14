using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionBiblioteca.Models
{
    public class Biblioteca
    {
        private List<Libro> libros = new List<Libro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Prestamo> prestamos = new List<Prestamo>();
        private int siguienteIdPrestamo = 1; // Para asignar IDs únicos a los préstamos

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
        public void RegistrarPrestamo(int idLibro, int idUsuario)
        {
            var libro = ObtenerLibro(idLibro);
            if (libro != null && libro.Disponible)
            {
                var prestamo = new Prestamo(siguienteIdPrestamo++, idLibro, idUsuario, DateTime.Now);
                prestamos.Add(prestamo);
                libro.Disponible = false; // Marcar como no disponible
            }
            else
            {
                throw new InvalidOperationException("El libro no está disponible para préstamo.");
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
            else
            {
                throw new InvalidOperationException("El préstamo no existe.");
            }
        }

        public List<Prestamo> ListarPrestamos()
        {
            return prestamos;
        }

        // Función para guardar datos en archivos
        public void GuardarDatos(string folder)
        {
            Directory.CreateDirectory(folder);
            var librosPath = Path.Combine(folder, "libros.txt");
            var usuariosPath = Path.Combine(folder, "usuarios.txt");
            var prestamosPath = Path.Combine(folder, "prestamos.txt");

            File.WriteAllLines(librosPath, this.ListarLibros().Select(l => $"{l.Id}|{Escape(l.Titulo)}"));
            File.WriteAllLines(usuariosPath, this.ListarUsuarios().Select(u => $"{u.Id}|{Escape(u.Nombre)}"));
            File.WriteAllLines(prestamosPath, this.ListarPrestamos().Select(p =>
                $"{p.Id}|{p.IdLibro}|{p.IdUsuario}|{p.FechaPrestamo:o}|{(p.FechaDevolucion.HasValue ? p.FechaDevolucion.Value.ToString("o") : "")}"));
        }

        public void CargarDatos(string folder)
        {
            if (!Directory.Exists(folder)) return;
            var librosPath = Path.Combine(folder, "libros.txt");
            var usuariosPath = Path.Combine(folder, "usuarios.txt");
            var prestamosPath = Path.Combine(folder, "prestamos.txt");

            if (File.Exists(librosPath))
            {
                var lines = File.ReadAllLines(librosPath);
                // limpiar lista interna de libros y volver a poblarla según la estructura de tu clase
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    var id = int.Parse(parts[0]);
                    var titulo = Unescape(parts[1]);
                    // Añadir/crear objeto Libro con id,titulo
                }
            }

            // Repetir similar para usuarios y préstamos; parsear fechas con DateTime.ParseExact(..., null, DateTimeStyles.RoundtripKind)
            if (File.Exists(usuariosPath))
            {
                var lines = File.ReadAllLines(usuariosPath);
                // limpiar lista interna de libros y volver a poblarla según la estructura de tu clase
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    var id = int.Parse(parts[0]);
                    var nombre = Unescape(parts[1]);
                    var correo = Unescape(parts[2]);
                    // Añadir/crear objeto Libro con id,titulo
                }
            }
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

        private string Escape(string s) => (s ?? "").Replace("|", "&#124;");
        private string Unescape(string s) => (s ?? "").Replace("&#124;", "|");
    }
}
