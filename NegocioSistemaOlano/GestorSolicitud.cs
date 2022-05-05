using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorSolicitud
    {

        /**
         * Registro una nueva solicitud indicando todos sus datos
         * 
        @param DateTime fecha, string dniTrabajador, Array array
        @roseuid 59C5EAFC01A4
        */
        public void RegistrarSolicitud(DateTime fecha, string dniTrabajador, Array lista)
        {
            Solicitud sol = new Solicitud
            {
                Fecha = fecha,
                DniTrabajador = new Trabajador{
                    DniTrabajador = dniTrabajador
                } 
            };

            List<Producto> listPro = lista.OfType<Producto>().ToList();

            sol.GuardarSolicitud(sol,listPro);
        }
    }
}
