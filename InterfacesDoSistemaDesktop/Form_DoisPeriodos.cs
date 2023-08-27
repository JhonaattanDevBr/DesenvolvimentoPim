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
    public partial class Form_DoisPeriodos : Form
    {
        public Form_DoisPeriodos()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdbSim_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSim.Checked == true)
            {
                lblQuantidade.Enabled = true;
                txtQuantidade.Enabled = true;
            }
            else if (rdbSim.Checked == false)
            {
                lblQuantidade.Enabled = false;
                txtQuantidade.Enabled = false;
            }
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {

        }

        private void gpbDoisPeriodos_Enter(object sender, EventArgs e)
        {

        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("As férias foram agendadas com sucesso!", "Atividade concluida");
            Close();
        }

       
    }
}
