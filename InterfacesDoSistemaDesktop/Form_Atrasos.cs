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
    public partial class Form_Atrasos : Form
    {
        FolhaPG folhaPG = new FolhaPG();
        public Form_Atrasos()
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
                gpbConverter.Visible = true;
                txtTotalHorasAtraso.Enabled = false;
                txtTotalHorasAtraso.Clear();
                txtTotalHorasAtraso.Clear();
            }
            else
            {
                gpbConverter.Visible = false;
                txtTotalHorasAtraso.Enabled = true;
                txtHorasFechadas.Clear();
                txtMinutos.Clear();
                txtTotalHorasConvertidas.Clear();
            }
        }

        private void txtHorasFechadas_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtHorasFechadas.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(validacao))
                {
                    txtHorasFechadas.Clear();
                    txtHorasFechadas.Focus();
                    return;
                }
                if(!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letras e caracteres.", "ATENÇÃO");
                    txtHorasFechadas.Clear();
                    txtHorasFechadas.Focus();
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtMinutos_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtMinutos.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(validacao))
                {
                    txtMinutos.Clear();
                    txtMinutos.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letras e caracteres.", "ATENÇÃO");
                    txtMinutos.Clear();
                    txtMinutos.Focus();
                    return;
                }
                if(valor > 60)
                {
                    MessageBox.Show("Este campo não aceita valores acima de 60.", "ATENÇÃO");
                    txtMinutos.Clear();
                    txtMinutos.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            double horaConvertida;
            horaConvertida = folhaPG.ConversorDeMinutosEmHoras(Convert.ToInt32(txtHorasFechadas.Text), Convert.ToInt32(txtMinutos.Text));
            txtTotalHorasConvertidas.Text = $"{horaConvertida:f2}".ToString();
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
                    MessageBox.Show("Este campo não aceita letras e caracteres.", "ATENÇÃO");
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

        private void txtTotalHoras_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtTotalHorasAtraso.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(validacao))
                {
                    txtTotalHorasAtraso.Clear();
                    txtTotalHorasAtraso.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letras e caracteres.", "ATENÇÃO");
                    txtTotalHorasAtraso.Clear();
                    txtTotalHorasAtraso.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtJornada_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtJornada.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(validacao))
                {
                    txtJornada.Clear();
                    txtJornada.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int valor))
                {
                    MessageBox.Show("Este campo não aceita letras e caracteres.", "ATENÇÃO");
                    txtJornada.Clear();
                    txtJornada.Focus();
                    return;
                }
                if (valor > 220)
                {
                    MessageBox.Show("Este campo não aceita valores acima de 220.", "ATENÇÃO");
                    txtJornada.Clear();
                    txtJornada.Focus();
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
            if (rdbSim.Checked)
            {
                retorno = folhaPG.CalcularAtraso(Convert.ToDouble(txtSalarioBase.Text), Convert.ToDouble(txtTotalHorasConvertidas.Text), Convert.ToInt32(txtJornada.Text));
                txtRetorno.Text = $"{retorno:f2}".ToString();
            }
            else
            {
                retorno = folhaPG.CalcularAtraso(Convert.ToDouble(txtSalarioBase.Text), Convert.ToInt32(txtTotalHorasAtraso.Text), Convert.ToInt32(txtJornada.Text));
                txtRetorno.Text = $"{retorno:f2}".ToString();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtSalarioBase.Clear();
            txtJornada.Clear();
            txtTotalHorasAtraso.Clear();
            txtRetorno.Clear();
            txtHorasFechadas.Clear();
            txtMinutos.Clear();
            txtTotalHorasConvertidas.Clear();
            txtRetorno.Clear();
            txtSalarioBase.Focus();
        }
    }
}
