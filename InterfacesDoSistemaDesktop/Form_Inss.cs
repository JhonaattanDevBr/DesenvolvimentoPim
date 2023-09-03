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
    public partial class Form_Inss : Form
    {
        FolhaPG folhaPG = new FolhaPG();
        public Form_Inss()
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
            gpbMensagem.Visible = false;
            lblMensagemFaixa.Visible = false;
            lblMensagemPorcentagem.Visible = false;
            lblMensagemFaixa.Text = string.Empty;
            lblMensagemPorcentagem.Text = string.Empty;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double retorno = folhaPG.CalcularInss(Convert.ToDouble(txtSalarioBase.Text));

            if (retorno <= 99.00)
            {
                txtRetorno.Text = retorno.ToString();
                gpbMensagem.Visible = true;
                lblMensagemFaixa.Visible = true;
                lblMensagemPorcentagem.Visible = true;
                lblMensagemFaixa.Text = ("O salário se estabelece na primeira faixa da tabela.");
                lblMensagemPorcentagem.Text = ("Desconto do INSS realizado sobre 7,5%.");
            }
            else if (retorno <= 112.62)
            {
                txtRetorno.Text = retorno.ToString();
                gpbMensagem.Visible = true;
                lblMensagemFaixa.Visible = true;
                lblMensagemPorcentagem.Visible = true;
                lblMensagemFaixa.Text = ("O salário se estabelece na segunda faixa da tabela.");
                lblMensagemPorcentagem.Text = ("Desconto do INSS realizado sobre 9,0%");
            }
            else if (retorno <= 154.28)
            {
                txtRetorno.Text = retorno.ToString();
                gpbMensagem.Visible = true;
                lblMensagemFaixa.Visible = true;
                lblMensagemPorcentagem.Visible = true;
                lblMensagemFaixa.Text = ("O salário se estabelece na terceira faixa da tabela.");
                lblMensagemPorcentagem.Text = ("Desconto do INSS realizado sobre 12,00%");
            }
            else if (retorno <= 511.06)
            {
                txtRetorno.Text = retorno.ToString();
                gpbMensagem.Visible = true;
                lblMensagemFaixa.Visible = true;
                lblMensagemPorcentagem.Visible = true;
                lblMensagemFaixa.Text = ("O salário se estabelece na quarta faixa da tabela.");
                lblMensagemPorcentagem.Text = ("Desconto do INSS realizado sobre 14,00%");
            }
            else
            {
                txtRetorno.Text = retorno.ToString();
                gpbMensagem.Visible = true;
                lblMensagemFaixa.Visible = true;
                lblMensagemPorcentagem.Visible = true;
                lblMensagemFaixa.Text = ("O salário não se estabelece em nenhuma faixa pois excede o teto do INSS.");
                lblMensagemPorcentagem.Text = ("Teto do INSS R$ 876.96");
            }
        }

        private void txtSalarioBase_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtSalarioBase.Text.Trim();
            if(string.IsNullOrEmpty(validacao))
            {
                txtSalarioBase.Clear();
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
            }
        }
    }
}
