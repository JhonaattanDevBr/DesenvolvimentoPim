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
    public partial class Form_Fgts : Form
    {
        public Form_Fgts()
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
            double retorno = folhaPG.CalcularFgts(Convert.ToDouble(txtSalarioBase.Text));
            txtRetorno.Text = retorno.ToString();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtSalarioBase.Clear();
            txtRetorno.Clear();
            txtSalarioBase.Focus();
        }

        private void txtSalarioBase_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtSalarioBase.Text.Trim();
            if (string.IsNullOrEmpty(validacao))
            {
                txtSalarioBase.Focus();
                btnCalcular.Enabled = false;
                return;
            }
            else
            {
                btnCalcular.Enabled = true;
            }
            if (!int.TryParse(validacao, out int valor))
            {
                MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÃO");
                txtSalarioBase.Focus();
                return;
            }
        }
    }
}
