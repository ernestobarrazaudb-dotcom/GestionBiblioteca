using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionBiblioteca.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int IdLibro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public Prestamo(int id, int idLibro, int idUsuario, DateTime fechaPrestamo, DateTime? fechaDevolucion = null)
        {
            Id = id;
            IdLibro = idLibro;
            IdUsuario = idUsuario;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
        }
    }
}
