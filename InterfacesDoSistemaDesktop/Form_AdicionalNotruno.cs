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
    public partial class Form_AdicionalNotruno : Form
    {
        FolhaPG folhaPG = new FolhaPG();
        public Form_AdicionalNotruno()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdbSim_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbSim.Checked == true)
            {
                gpbConversor.Visible = true;
                txtTotalHoras.Enabled = false;
                txtTotalHoras.Clear();
                txtRetorno.Clear();
            }
            else
            {
                txtTotalHoras.Enabled = true;
                txtTotalHoras.Clear();
                gpbConversor.Visible = false;
                txtTotalHorasConvertidas.Clear();
                txtHorasFechadas.Clear();
                txtMinutos.Clear();
                txtRetorno.Clear();
            }
        }

        private void txtHorasFechadas_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtHorasFechadas.Text.Trim();

            if (string.IsNullOrEmpty(validacao))
            {
                txtHorasFechadas.Clear();
                txtHorasFechadas.Focus();
                return;
            }
            if(!int.TryParse(validacao, out int val))
            {
                MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÃO");
                txtHorasFechadas.Clear();
                txtHorasFechadas.Focus();
                return;
            }
        }

        private void txtMinutos_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtMinutos.Text.Trim();
            
            if (string.IsNullOrEmpty(validacao))
            {
                txtMinutos.Clear();
                txtMinutos.Focus();
                return;
            }
            if (!int.TryParse(validacao, out int val))
            {
                
                MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÃO");
                txtMinutos.Clear();
                //txtMinutos.Focus();
                return;
            }
            if(val > 60)
            {
                MessageBox.Show("Este campo não aceita valores acima de 60.", "ATENÇÃO");
                txtMinutos.Clear();
                txtMinutos.Focus();
                return;
            }
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            double retorno;
            try
            {
                retorno = folhaPG.ConversorDeMinutosEmHoras(Convert.ToInt32(txtHorasFechadas.Text), Convert.ToInt32(txtMinutos.Text));
                txtTotalHorasConvertidas.Text = $"{retorno:f2}".ToString();                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtSalarioBase_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtSalarioBase.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(validacao))
                {
                    txtSalarioBase.Clear();
                    txtSalarioBase.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letra ou caracteres.", "ATENÇÃO");
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtSalarioBase.Clear();
            txtRetorno.Clear();
            txtHorasFechadas.Clear();
            txtMinutos.Clear();
            txtTotalHorasConvertidas.Clear();
            txtTotalHoras.Clear();
            txtSalarioBase.Focus();
        }

        private void txtTotalHoras_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtTotalHoras.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(validacao))
                {
                    txtTotalHoras.Clear();
                    txtTotalHoras.Focus();
                    return;
                }
                if (!int.TryParse(validacao,out int valor))
                {
                    MessageBox.Show("Este campo não aceita letra ou caracteres.", "ATENÇÃO");
                    txtTotalHoras.Clear();
                    txtTotalHoras.Focus();
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
            try
            {
                if (rdbSim.Checked == true)
                {
                    retorno = folhaPG.CalcularAdicionalNoturno(Convert.ToDouble(txtSalarioBase.Text), Convert.ToDouble(txtTotalHorasConvertidas.Text));
                    txtRetorno.Text = $"{retorno:f2}".ToString();
                }
                else
                {
                    retorno = folhaPG.CalcularAdicionalNoturno(Convert.ToDouble(txtSalarioBase.Text), Convert.ToInt32(txtTotalHoras.Text));
                    txtRetorno.Text = $"{retorno:f2}".ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
