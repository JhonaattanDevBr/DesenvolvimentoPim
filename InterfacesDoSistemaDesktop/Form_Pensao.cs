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
    public partial class Form_Pensao : Form
    {
        public Form_Pensao()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            FolhaPG folhaPG = new FolhaPG();
            double retorno = folhaPG.CalcularPensao(Convert.ToInt16(txtPorcentagem.Text));
            txtRetorno.Text = retorno.ToString();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPorcentagem.Clear();
            txtRetorno.Clear();
            txtPorcentagem.Focus();
        }
    }
}
