using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionBiblioteca.Models
{
    public class Biblioteca
    {
        private readonly string usuariosFilePath = "usuarios.txt";
        private readonly string librosFilePath = "libros.txt";
        private readonly string prestamosFilePath = "prestamos.txt";
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Libro> libros = new List<Libro>();
        private List<Prestamo> prestamos = new List<Prestamo>();

        public void AgregarUsuario(Usuario usuario)
        {
            if (ValidarUsuario(usuario))
            {
                usuario.Id = ObtenerSiguienteIdUsuario();
                usuarios.Add(usuario);
                GuardarUsuarios();
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            return CargarUsuarios();
        }

        public void ActualizarUsuario(Usuario usuarioActualizado)
        {
            var usuario = ObtenerUsuario(usuarioActualizado.Id);
            if (usuario != null)
            {
                usuario.Nombre = usuarioActualizado.Nombre;
                usuario.Correo = usuarioActualizado.Correo;
                GuardarUsuarios();
            }
        }

        public void EliminarUsuario(int id)
        {
            var usuario = ObtenerUsuario(id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
                GuardarUsuarios();
            }
        }

        public void AgregarLibro(Libro libro)
        {
            if (ValidarLibro(libro))
            {
                libro.Id = ObtenerSiguienteIdLibro();
                libros.Add(libro);
                GuardarLibros();
            }
        }

        public List<Libro> ListarLibros()
        {
            return CargarLibros();
        }

        public void ActualizarLibro(Libro libroActualizado)
        {
            var libro = ObtenerLibro(libroActualizado.Id);
            if (libro != null)
            {
                libro.Titulo = libroActualizado.Titulo;
                libro.Autor = libroActualizado.Autor;
                libro.AnioPublicacion = libroActualizado.AnioPublicacion;
                GuardarLibros();
            }
        }

        public void EliminarLibro(int id)
        {
            var libro = ObtenerLibro(id);
            if (libro != null)
            {
                libros.Remove(libro);
                GuardarLibros();
            }
        }

        public void RegistrarPrestamo(Prestamo prestamo)
        {
            var libro = ObtenerLibro(prestamo.IdLibro);
            if (libro != null && libro.Disponible)
            {
                prestamo.Id = ObtenerSiguienteIdPrestamo();
                prestamos.Add(prestamo); 

                // Marcar el libro como no disponible
                libro.Disponible = false;

                // Guardar los préstamos en el archivo
                GuardarPrestamos();
                GuardarLibros(); 
            }
            else
            {
                throw new InvalidOperationException("El libro no está disponible para préstamo.");
            }
        }
        public List<Prestamo> ListarPrestamos()
        {
            return CargarPrestamos();
        }

        public void DevolverLibro(int prestamoId)
        {
            var prestamo = prestamos.FirstOrDefault(p => p.Id == prestamoId);
            if (prestamo != null)
            {
                prestamo.FechaDevolucion = DateTime.Now; // Establecer la fecha de devolución
                var libro = ObtenerLibro(prestamo.IdLibro);
                if (libro != null)
                {
                    libro.Disponible = true; // Marcar el libro como disponible
                }
                GuardarPrestamos(); 
                GuardarLibros(); 
            }
            else
            {
                throw new InvalidOperationException("No se encontró el préstamo.");
            }
        }


        private int ObtenerSiguienteIdUsuario()
        {
            return usuarios.Count > 0 ? usuarios.Max(u => u.Id) + 1 : 1;
        }

        private int ObtenerSiguienteIdLibro()
        {
            return libros.Count > 0 ? libros.Max(l => l.Id) + 1 : 1;
        }

        private int ObtenerSiguienteIdPrestamo()
        {
            return prestamos.Count > 0 ? prestamos.Max(p => p.Id) + 1 : 1;
        }

        private void GuardarUsuarios()
        {
            using (StreamWriter writer = new StreamWriter(usuariosFilePath, false))
            {
                foreach (var usuario in usuarios)
                {
                    writer.WriteLine($"{usuario.Id},{usuario.Nombre},{usuario.Correo}");
                }
            }
        }

        private List<Usuario> CargarUsuarios()
        {
            usuarios = new List<Usuario>();
            if (File.Exists(usuariosFilePath))
            {
                using (StreamReader reader = new StreamReader(usuariosFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        usuarios.Add(new Usuario(int.Parse(data[0]), data[1], data[2]));
                    }
                }
            }
            return usuarios;
        }

        private void GuardarLibros()
        {
            using (StreamWriter writer = new StreamWriter(librosFilePath, false))
            {
                foreach (var libro in libros)
                {
                    writer.WriteLine($"{libro.Id},{libro.Titulo},{libro.Autor},{libro.AnioPublicacion},{libro.Disponible}");
                }
            }
        }

        private List<Libro> CargarLibros()
        {
            libros = new List<Libro>();
            if (File.Exists(librosFilePath))
            {
                using (StreamReader reader = new StreamReader(librosFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        libros.Add(new Libro(int.Parse(data[0]), data[1], data[2], int.Parse(data[3]), bool.Parse(data[4])));
                    }
                }
            }
            return libros;
        }

        private void GuardarPrestamos()
        {
            using (StreamWriter writer = new StreamWriter(prestamosFilePath))
            {
                foreach (var prestamo in prestamos)
                {
                    writer.WriteLine($"{prestamo.Id},{prestamo.IdUsuario},{prestamo.IdLibro},{prestamo.FechaPrestamo},{prestamo.FechaDevolucion}");
                }
            }
        }

        public List<Prestamo> CargarPrestamos()
        {
            prestamos = new List<Prestamo>(); // Inicializa la lista de préstamos

            if (File.Exists(prestamosFilePath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(prestamosFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] data = line.Split(',');

                            // Verifica que la línea contenga la cantidad correcta de datos
                            if (data.Length == 5)
                            {
                                int id = int.Parse(data[0]);
                                int idUsuario = int.Parse(data[1]);
                                int idLibro = int.Parse(data[2]);
                                DateTime fechaPrestamo = DateTime.Parse(data[3]);
                                DateTime? fechaDevolucion = string.IsNullOrWhiteSpace(data[4]) ? (DateTime?)null : DateTime.Parse(data[4]);

                                // Crea un nuevo objeto Prestamo y lo agrega a la lista
                                prestamos.Add(new Prestamo(id, idUsuario, idLibro, fechaPrestamo, fechaDevolucion));
                            }
                            else
                            {
                                // Manejo de líneas con formato incorrecto
                                throw new FormatException($"La línea no tiene el formato correcto: {line}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones, puedes registrar el error o mostrar un mensaje
                    MessageBox.Show("Error al cargar los préstamos: " + ex.Message);
                }
            }
            return prestamos; // Retorna la lista de préstamos
        }


        public Usuario ObtenerUsuario(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Libro ObtenerLibro(int id)
        {
            return libros.FirstOrDefault(l => l.Id == id);
        }

        private Prestamo ObtenerPrestamo(int id)
        {
            return prestamos.FirstOrDefault(p => p.Id == id);
        }

        private bool ValidarUsuario(Usuario usuario)
        {
            return !string.IsNullOrWhiteSpace(usuario.Nombre) &&
                   !string.IsNullOrWhiteSpace(usuario.Correo) &&
                   !usuarios.Any(u => u.Correo.Equals(usuario.Correo, StringComparison.OrdinalIgnoreCase));
        }

        private bool ValidarLibro(Libro libro)
        {
            return !string.IsNullOrWhiteSpace(libro.Titulo) &&
                   !string.IsNullOrWhiteSpace(libro.Autor) &&
                   !libros.Any(l => l.Titulo.Equals(libro.Titulo, StringComparison.OrdinalIgnoreCase) &&
                                  l.Autor.Equals(libro.Autor, StringComparison.OrdinalIgnoreCase));
        }
    }
}