using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfacesDoSistemaDesktop
{
    public partial class Form_InterfaceAtrasos : Form
    {
        public Form_InterfaceAtrasos()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdbAtrasos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAtrasos.Checked == true)
            {
                rdbFaltaInjustificada.Checked = false;
            }
            else
            {
                rdbAtrasos.Checked = false;
                rdbFaltaInjustificada.Checked = true;
            }
        }

        
    }
}
