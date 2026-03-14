using GestionBiblioteca.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionBiblioteca
{
    public partial class EstadisticasForm : Form
    {
        private Biblioteca biblioteca;

        public EstadisticasForm(Biblioteca biblioteca)
        {
            InitializeComponent();
            // Asegurar que existan al menos dos ChartAreas para permitir series con tipos distintos
            if (chartEstadisticas.ChartAreas.Count == 0)
            {
                var area1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea("ChartArea1");
                chartEstadisticas.ChartAreas.Add(area1);
                var area2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea("ChartArea2");
                chartEstadisticas.ChartAreas.Add(area2);
            }

            chartEstadisticas.Titles.Clear();
            var title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            title1.Name = "Title1";
            title1.Text = "Libros más prestados";
            title1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
            title1.Docking = Docking.Top;
            chartEstadisticas.Titles.Add(title1);

            var title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            title2.Name = "Title2";
            title2.Text = "Usuarios más activos";
            title2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
            title2.Docking = Docking.Top;
            chartEstadisticas.Titles.Add(title2);

            // Organizar inicialmente y en redimensionado
            ArrangeChartAreasAndDecorations();
            chartEstadisticas.Resize += (s, e) => ArrangeChartAreasAndDecorations();

            this.biblioteca = biblioteca;
            MostrarEstadisticas();
        }

        private void ArrangeChartAreasAndDecorations()
        {
            // Asegurarse de tener las áreas necesarias
            if (chartEstadisticas.ChartAreas.Count < 2)
                return;

            var area1 = chartEstadisticas.ChartAreas["ChartArea1"];
            var area2 = chartEstadisticas.ChartAreas["ChartArea2"];
            if (area1 == null || area2 == null)
                return;

            var w = chartEstadisticas.ClientSize.Width;
            var h = chartEstadisticas.ClientSize.Height;

            // Posicionar áreas: lado a lado si ancho >= alto, sino apiladas
            if (w >= h)
            {
                area1.Position = new ElementPosition(0f, 10f, 50f, 85f);
                area2.Position = new ElementPosition(50f, 10f, 50f, 85f);
            }
            else
            {
                area1.Position = new ElementPosition(5f, 5f, 90f, 45f);
                area2.Position = new ElementPosition(5f, 50f, 90f, 45f);
            }

            // Ajustar InnerPlotPosition para dar margen a títulos/leyendas
            area1.InnerPlotPosition = new ElementPosition(10f, 10f, 80f, 80f);
            area2.InnerPlotPosition = new ElementPosition(10f, 10f, 80f, 80f);

            // No usar leyendas (se eliminaron)

            // Posicionar títulos: usar Titles con Docking=None para manejar posición manual
            var t1 = chartEstadisticas.Titles.FindByName("Title1");
            var t2 = chartEstadisticas.Titles.FindByName("Title2");
            if (t1 != null)
            {
                t1.Docking = Docking.Top;
                t1.Position = new ElementPosition(area1.Position.X + 2f, area1.Position.Y - 6f, area1.Position.Width - 4f, 6f);
                t1.Alignment = ContentAlignment.MiddleCenter;
            }
            if (t2 != null)
            {
                t2.Docking = Docking.Top;
                t2.Position = new ElementPosition(area2.Position.X + 2f, area2.Position.Y - 6f, area2.Position.Width - 4f, 6f);
                t2.Alignment = ContentAlignment.MiddleCenter;
            }
        }

        private void MostrarEstadisticas()
        {
            // Obtener los libros más prestados
            var librosMasPrestados = biblioteca.ListarPrestamos()
                .GroupBy(p => p.IdLibro)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => new
                {
                    Libro = biblioteca.ListarLibros().FirstOrDefault(l => l.Id == g.Key)?.Titulo,
                    Cantidad = g.Count()
                }).ToList();

            // Mostrar los libros más prestados en el ListBox
            lstLibrosMasPrestados.Items.Clear();
            foreach (var item in librosMasPrestados)
            {
                lstLibrosMasPrestados.Items.Add($"{item.Libro}: {item.Cantidad} veces");
            }

            // Configurar el gráfico para los libros más prestados
            chartEstadisticas.Series.Clear();
            var seriesLibros = chartEstadisticas.Series.Add("Libros Más Prestados");
            seriesLibros.ChartType = SeriesChartType.Column;
            seriesLibros.ChartArea = chartEstadisticas.ChartAreas[0].Name;

            foreach (var item in librosMasPrestados)
            {
                Debug.WriteLine($"Libro: {item.Libro}, Cantidad: {item.Cantidad}");
                seriesLibros.Points.AddXY(item.Libro, item.Cantidad);
            }

            // Obtener los usuarios más activos
            var usuariosMasActivos = biblioteca.ListarPrestamos()
                .GroupBy(p => p.IdUsuario)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => new
                {
                    Usuario = biblioteca.ListarUsuarios().FirstOrDefault(u => u.Id == g.Key)?.Nombre,
                    Cantidad = g.Count()
                }).ToList();

            // Mostrar los usuarios más activos en el ListBox
            lstUsuariosMasActivos.Items.Clear();
            foreach (var item in usuariosMasActivos)
            {
                lstUsuariosMasActivos.Items.Add($"{item.Usuario}: {item.Cantidad} préstamos");
            }

            // Configurar el gráfico para los usuarios más activos
            var seriesUsuarios = chartEstadisticas.Series.Add("Usuarios Más Activos");
            // Asignar esta serie a un segundo ChartArea para permitir usar SeriesChartType.Bar
            seriesUsuarios.ChartType = SeriesChartType.Bar;
            seriesUsuarios.ChartArea = "ChartArea2";

            foreach (var item in usuariosMasActivos)
            {
                Debug.WriteLine($"Usuario: {item.Usuario}, Cantidad: {item.Cantidad}");
                seriesUsuarios.Points.AddXY(item.Usuario, item.Cantidad);
            
            }
        }

        private void SalirUsuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
