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
    public partial class Form_Irrf : Form
    {
        FolhaPG folhaPG = new FolhaPG();

        public Form_Irrf()
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
            gpbMensagem.Visible = false;
            lblMensagamFaixa.Visible = false;
            lblMensagemPorcentagem.Visible = false;
            lblMensagemFormaDeCalculo.Visible = false;
            txtSalarioBase.Focus();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double retorno = folhaPG.CalcularIrrf(Convert.ToDouble(txtSalarioBase.Text));
                if (retorno == 0)
                {
                    txtRetorno.Text = retorno.ToString();
                    gpbMensagem.Visible = true;
                    lblMensagamFaixa.Visible = true;
                    lblMensagemPorcentagem.Visible = true;
                    lblMensagemFormaDeCalculo.Visible = true;
                    lblMensagamFaixa.Text = ("A base de calculo se estabelece na primeira faixa.");
                    lblMensagemPorcentagem.Text = ("Funcionário está isento do desconto de IRRF.");
                    lblMensagemFormaDeCalculo.Text = folhaPG.MensagemIRRF;
                }
                else if (retorno <= 158.40)
                {
                    txtRetorno.Text = retorno.ToString();
                    gpbMensagem.Visible = true;
                    lblMensagamFaixa.Visible = true;
                    lblMensagemPorcentagem.Visible = true;
                    lblMensagemFormaDeCalculo.Visible = true;
                    lblMensagamFaixa.Text = ("A base de calculo se estabelece na segunda faixa.");
                    lblMensagemPorcentagem.Text = ("Desconto do IRRF realizado sobre 7,5%");
                    lblMensagemFormaDeCalculo.Text = folhaPG.MensagemIRRF;
                }
                else if (retorno <= 370.40)
                {
                    txtRetorno.Text = retorno.ToString();
                    gpbMensagem.Visible = true;
                    lblMensagamFaixa.Visible = true;
                    lblMensagemPorcentagem.Visible = true;
                    lblMensagemFormaDeCalculo.Visible = true;
                    lblMensagamFaixa.Text = ("A base de calculo se estabelece na terceira faixa.");
                    lblMensagemPorcentagem.Text = ("Desconto do IRRF realizado sobre 15,00%");
                    lblMensagemFormaDeCalculo.Text = folhaPG.MensagemIRRF;
                }
                else if (retorno <= 651.73)
                {
                    txtRetorno.Text = retorno.ToString();
                    gpbMensagem.Visible = true;
                    lblMensagamFaixa.Visible = true;
                    lblMensagemPorcentagem.Visible = true;
                    lblMensagemFormaDeCalculo.Visible = true;
                    lblMensagamFaixa.Text = ("A base de calculo se estabelece na quarta faixa.");
                    lblMensagemPorcentagem.Text = ("Desconto do IRRF realizado sobre 22,50%");
                    lblMensagemFormaDeCalculo.Text = folhaPG.MensagemIRRF;
                }
                else
                {
                    txtRetorno.Text = retorno.ToString();
                    gpbMensagem.Visible = true;
                    lblMensagamFaixa.Visible = true;
                    lblMensagemPorcentagem.Visible = true;
                    lblMensagemFormaDeCalculo.Visible = true;
                    lblMensagamFaixa.Text = ("A base de calculo se estabelece acima da quarta faixa.");
                    lblMensagemPorcentagem.Text = ("Desconto do IRRF realizado sobre 27,50%");
                    lblMensagemFormaDeCalculo.Text = folhaPG.MensagemIRRF;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao realizar a operação." + ex); ;
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
                return;
            }
            if (!int.TryParse(validacao, out int valor))
            {
                MessageBox.Show("Este campo nao aceita letras ou caracteres.", "ATENÇÃO");
                txtSalarioBase.Clear();
                txtSalarioBase.Focus();
                return;
            }
        }
    }
}
