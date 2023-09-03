using FolhaDePagamento;
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
    public partial class Form_ConvenioOdontologico : Form
    {
        public Form_ConvenioOdontologico()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtSalarioBase.Clear();
            txtRetorno.Clear();
            txtSalarioBase.Focus();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            FolhaPG folhaPG = new FolhaPG();
            double retorno; // Vou fazer essa variavel receber o retorno do valor calculado na formula.
        }
    }
}
