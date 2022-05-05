using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NegocioSistemaOlano;

namespace SistemaOlano
{
    public partial class IUIniciarSesion : Form
    {
        string[] tipo;

        //Contructor del formulario
        public IUIniciarSesion()
        {
            InitializeComponent();
        }

        //Permite que el sistema haga la validación del tipo de usuario para definir qué interfaz abrir a continuación
        public string[] ValidarCredenciales()
        {
            this.ShowDialog();

            return this.tipo;
        }

        //Realiza la validación de los datos ingresados en el formulario para verificar si son correctos
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            GestorTrabajador gT;
            if (this.ValidateChildren() == true)
            {
                string dni = this.textBox1.Text;
                string contrasenia = this.textBox2.Text;
                string[] tipo;
                gT = new GestorTrabajador();
                try
                {
                    tipo = gT.ValidarCredenciales(dni, contrasenia);
                    this.tipo = tipo;
                    if (Int32.Parse(tipo[0]) > 0)
                    {
                        MostrarMenu();
                    }
                    else
                    {
                        MessageBox.Show("Las credenciales no son validas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        this.textBox1.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //Cierra el formulario para dar paso a abrir la interfaz correspondiente
        private void MostrarMenu()
        {
            this.Close();
        }
    }
}
