using FolhaDePagamento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfacesDoSistemaDesktop
{
    public partial class Form_Periculosidade_Insalubridade : Form
    {
        FolhaPG folhaPG = new FolhaPG();
        public Form_Periculosidade_Insalubridade()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdbInsalubridade_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbInsalubridade.Checked)
                {
                    gpbPericulosidade.Visible = false;
                    gpbInsalubridade.Visible = true;
                }
                else
                {
                    gpbPericulosidade.Visible = true;
                    gpbInsalubridade.Visible = false;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação");
            }
        }

        private void btnCalcularInsalubridade_Click(object sender, EventArgs e)
        {
            double retorno, salario = 0;
            int grauLeve = 10, grauMedio = 20, grauGrave = 40;
            string beneficio = "insalubridade";
            try
            {
                if (rdbGrauLeve.Checked)
                {
                    retorno = folhaPG.CalcularPericulosidadeInsalubridade(salario, grauLeve, beneficio);
                    txtRetornoInsalubridade.Text = $"{retorno:f2}".ToString();
                }
                else if (rdbGrauMedio.Checked)
                {
                    retorno = folhaPG.CalcularPericulosidadeInsalubridade(salario, grauMedio, beneficio);
                    txtRetornoInsalubridade.Text = $"{retorno:f2}".ToString();
                }
                else
                {
                    retorno = folhaPG.CalcularPericulosidadeInsalubridade(salario, grauGrave, beneficio);
                    txtRetornoInsalubridade.Text = $"{retorno:f2}".ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar a operação");
            }
        }

        private void btnLimparInsalubridade_Click(object sender, EventArgs e)
        {
            try
            {
                rdbGrauLeve.Checked = true;
                txtRetornoInsalubridade.Clear();
                txtRetornoInsalubridade.Focus();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação");
            }
        }

        private void btnCalcularPericulosidade_Click(object sender, EventArgs e)
        {
            string beneficio = "periculosidade";
            double retorno;
            int grau = 0;
            try
            {
                retorno = folhaPG.CalcularPericulosidadeInsalubridade(Convert.ToDouble(txtSalarioBase.Text), grau, beneficio);
                txtRetornoPericulosidade.Text = $"{retorno:f2}".ToString(); //ToString(new CultureInfo("pt-BR")); Se eu utilizar este parametro os números são exibidor no padrão do brasil.
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação");
            }
        }

        private void btnLimparPericulosidade_Click(object sender, EventArgs e)
        {
            try
            {
                txtSalarioBase.Clear();
                txtRetornoPericulosidade.Clear();
                txtSalarioBase.Focus();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação");
            }
        }
    }
}
