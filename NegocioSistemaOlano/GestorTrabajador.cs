using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSistemaOlano;

namespace NegocioSistemaOlano
{
    public class GestorTrabajador
    {
        /**
         * Carga el nombre del trabajador segun su dni
         * 
        @param string dniTrabajador
        @return string nombre
        @roseuid 59C5EAFC0180
        */
        public string CargarNombreTrabajador(string dniTrabajador)
        {
            string nombre;

            Trabajador tra = new Trabajador();

            nombre = tra.ObtenerNombreTrabajador(dniTrabajador);

            return nombre;
        }

        /**
         * Verifica la existencia del trabajador en la base de datos gracias a su dni y contraseña
         * 
        @param string dni
        @param string contrasenia
        @return string[] tipo
        @roseuid 59C5EAFC0181
        */
        public string[] ValidarCredenciales(string dni, string contrasenia)
        {
            string[] tipo;
            Trabajador t = new Trabajador();
            tipo = t.ValidarCredenciales(dni, contrasenia);
            return tipo;
        }

        /**
         * Carga los trabajadores cuyo nombre coincide con el ingresado en la interfaz
         * 
         @param string nombre
         @return Array trabajadores
         @roseuid 59C5EAFC0182
        */
        public Array CargarTrabajadores(string nombre)
        {
            Array trabajadores;

            Trabajador t = new Trabajador();

            trabajadores = t.ObtenerTrabajadores(nombre).ToArray();

            return trabajadores;
        }

        /**
        * Registra un trabajador ingresando todos sus datos
        * 
        @param string dni, string nombre, string direccion, string telefono, int codTipoTrabajador, string contraseña
        @roseuid 59C5EAFC0183
       */
        public void RegistrarTrabajador(string dni, string nombre, string direccion, string telefono, int codTipoTrabajador, string contraseña)
        {
            Trabajador t = new Trabajador
            {
                DniTrabajador = dni,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                CodTipoTrabajador = new TipoTrabajador
                {
                    CodTipoTrabajador = codTipoTrabajador
                },
                Contraseña = contraseña
            };

            t.GuardarTrabajador(t);
        }

        /**
        * Actualiza los datos de un trabajador brindados a traves de la interfaz
        * 
         @param string dni, string nombre, string direccion, string telefono, int codTipoTrabajador,bool dadoBaja, string contraseña
         @roseuid 59C5EAFC0184
        */
        public void ModificarTrabajador(string dni, string nombre, string direccion, string telefono, int codTipoTrabajador, bool dadoBaja, string contraseña)
        {
            Trabajador t = new Trabajador
            {
                DniTrabajador = dni,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                CodTipoTrabajador = new TipoTrabajador
                {
                    CodTipoTrabajador = codTipoTrabajador
                },
                Contraseña = contraseña,
                DadoBaja = dadoBaja
            };

            t.ActualizarTrabajador(t);
        }
    }
}
