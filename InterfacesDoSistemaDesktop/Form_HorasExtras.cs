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
    public partial class Form_HorasExtras : Form
    {
        FolhaPG folhaPG = new FolhaPG();
        
        public Form_HorasExtras()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                txtSalarioBase.Clear();
                txtTotalHoras.Clear();
                txtRetorno.Clear();
                txtHorasFechadas.Clear();
                txtMinutos.Clear();
                txtTotalHorasConvertidas.Clear();
                rdbNao.Checked = true;
                rdbCinquenta.Checked = true;
                gpbConversor.Visible = false;
                txtHorasFechadas.Visible = false;
                txtMinutos.Visible = false;
                txtTotalHorasConvertidas.Visible = false;
                txtSalarioBase.Focus();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação!");
            }
            

        }

        private void rdbSim_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbSim.Checked)
                {
                    gpbConversor.Visible = true;
                    lblHorasFechadas.Visible = true;
                    txtHorasFechadas.Visible = true;
                    lblMinutos.Visible = true;
                    txtMinutos.Visible = true;
                    lblTotalHorasConvertidas.Visible = true;
                    txtTotalHorasConvertidas.Visible = true;
                    btnConverter.Visible = true;
                }
                else
                {
                    gpbConversor.Visible = false;
                    lblHorasFechadas.Visible = false;
                    txtHorasFechadas.Visible = false;
                    lblMinutos.Visible = false;
                    txtMinutos.Visible = false;
                    lblTotalHorasConvertidas.Visible = false;
                    txtTotalHorasConvertidas.Visible = false;
                    btnConverter.Visible = false;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação!");
            }
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            try
            {
                double horasConvertidas = folhaPG.ConversorDeMinutosEmHoras(Convert.ToInt16(txtHorasFechadas.Text), Convert.ToInt16(txtMinutos.Text));
                txtTotalHorasConvertidas.Text = $"{horasConvertidas:f2}".ToString();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação!");
            }
        }

        private void rdbCinquenta_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbCinquenta.Checked)
                {
                    double cinquenta = 1.5;
                    double retorno = folhaPG.CalcularHoraExtra(Convert.ToDouble(txtSalarioBase.Text), cinquenta, Convert.ToInt16(txtTotalHoras.Text));
                    txtRetorno.Text = $"{retorno:f2}".ToString();
                }
                else if (rdbCem.Checked)
                {
                    double Cem = 2;
                    double retorno = folhaPG.CalcularHoraExtra(Convert.ToDouble(txtSalarioBase.Text), Cem, Convert.ToInt16(txtTotalHoras.Text));
                    txtRetorno.Text = $"{retorno:f2}".ToString();
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação!");
            }
        }
    }
}
