using System;
using System.Threading;
using System.Windows.Forms;

namespace ErrorNoControladoProyectoA
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Para capturar todas las excepciones no capturadas con try..catch en procesos que no son de la la interfaz gráfica
            Application.ThreadException += new ThreadExceptionEventHandler(Tarea_Error_No_Interfaz);
            // Para capturar todas las excepciones no capturadas con try..catch en la interfaz gráfica de la aplicación
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Tarea_Error_Interfaz);

            // Inicio normal de la aplicación
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formErrorNoControlado());
        }

        // Tarea a realizar cuando se produce una excepción no capturada con try..catch en proceso que no es de la la interfaz gráfica
        static void Tarea_Error_No_Interfaz(object sender, ThreadExceptionEventArgs e)
        {
            Log.EsLog(mensaje: "Error no capturado en subproceso que no es de la interfaz gráfica: " +
                   e.Exception.Message, mostrarConsola: false, mostrarVisual: true);
        }

        // Tarea a realizar cuando se produce una excepción no capturada con try..catch en proceso que es de la interfaz gráfica
        static void Tarea_Error_Interfaz(object sender, UnhandledExceptionEventArgs e)
        {
            Log.EsLog(mensaje: "Error no capturado en subproceso de la interfaz gráfica: " +
                   (e.ExceptionObject as Exception), mostrarConsola: false, mostrarVisual: true);
        }
    }
}