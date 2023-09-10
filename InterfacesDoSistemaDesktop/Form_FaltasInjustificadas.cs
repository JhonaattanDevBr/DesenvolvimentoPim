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
    public partial class Form_FaltasInjustificadas : Form
    {
        FolhaPG folhaPG = new FolhaPG();
        public Form_FaltasInjustificadas()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdbSim_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSim.Checked)
            {
                gpbCalcularDsr.Visible = true;
            }
            else
            {
                gpbCalcularDsr.Visible &= false;
                txtDiasUteis.Clear();
                txtDiasNaoUteis.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string validacao = txtSalarioBase.Text.Trim();
                if (string.IsNullOrEmpty(validacao))
                {
                    txtSalarioBase.Clear();
                    txtSalarioBase.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÃO");
                    txtSalarioBase.Clear();
                    txtSalarioBase.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtDsr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string validacao = txtDsr.Text.Trim();
                if (string.IsNullOrEmpty(validacao))
                {
                    txtDsr.Clear();
                    txtDsr.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÃO");
                    txtDsr.Clear();
                    txtDsr.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtDiasUteis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string validacao = txtDiasUteis.Text.Trim();
                if (string.IsNullOrEmpty(validacao))
                {
                    txtDiasUteis.Clear();
                    txtDiasUteis.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÃO");
                    txtDiasUteis.Clear();
                    txtDiasUteis.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtDiasNaoUteis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string validacao = txtDiasNaoUteis.Text.Trim();
                if (string.IsNullOrEmpty(validacao))
                {
                    txtDiasNaoUteis.Clear();
                    txtDiasNaoUteis.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÃO");
                    txtDiasNaoUteis.Clear();
                    txtDiasNaoUteis.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtFaltas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string validacao = txtFaltas.Text.Trim();
                if (string.IsNullOrEmpty(validacao))
                {
                    txtFaltas.Clear();
                    txtFaltas.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÃO");
                    txtFaltas.Clear();
                    txtFaltas.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double retorno;
            int nulo1 = 0, nulo2 = 0;
            string mensagem = "Sim";
            try
            {
                if (rdbSim.Checked)
                {
                    retorno = folhaPG.CalcularFaltaInjustificada(Convert.ToDouble(txtSalarioBase.Text), Convert.ToInt32(txtFaltas.Text), Convert.ToInt32(txtDsr.Text), mensagem, Convert.ToInt32(txtDiasUteis.Text), Convert.ToInt32(txtDiasNaoUteis.Text));
                    txtRetorno.Text = $"{retorno:f2}".ToString();
                }
                else
                {
                    mensagem = "Nao";
                    retorno = folhaPG.CalcularFaltaInjustificada(Convert.ToDouble(txtSalarioBase.Text), Convert.ToInt32(txtFaltas.Text), Convert.ToInt32(txtDsr.Text), mensagem, nulo1, nulo2);
                    txtRetorno.Text = $"{retorno:f2}".ToString();
                }
               
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtSalarioBase.Clear();
            txtFaltas.Clear();
            txtDsr.Clear();
            txtDiasUteis.Clear();
            txtDiasNaoUteis.Clear();
            txtRetorno.Clear();
            txtSalarioBase.Focus();
        }
    }
}
