using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaOlano
{
    public partial class IULogo : Form
    {
        #region "Singleton"

        private static IULogo frm;

        private IULogo()
        {
            InitializeComponent();
        }

        public static IULogo Crear(Form padre)
        {
            if (IULogo.frm == null)
            {
                IULogo.frm = new IULogo();
                IULogo.frm.MdiParent = padre;
                IULogo.frm.WindowState = FormWindowState.Maximized;
            }

            return IULogo.frm;
        }

        private void frmLogo_FormClosed(object sender, FormClosedEventArgs e)
        {
            IULogo.frm = null;
        }

        #endregion
    }
}
