using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaOlano
{
    static class Program
    {
        public static string[] tipo;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUIniciarSesion frm;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmGestionarTrabajador()); 

            //Application.Run(new IUAdministrador("12345678"));


            frm = new IUIniciarSesion();
            Program.tipo = frm.ValidarCredenciales();
            if (Program.tipo != null)
            {
                switch (Program.tipo[0])
                {
                    case "1": Application.Run(new IUAdministrador(tipo[1])); break;
                    case "2": Application.Run(new IUVendedor(tipo[1])); break;
                    case "3": Application.Run(new IUCajero(tipo[1])); break;
                    case "4": Application.Run(new IUEncargadoAlmacen(tipo[1])); break;
                }
            }
        }
    }
}
