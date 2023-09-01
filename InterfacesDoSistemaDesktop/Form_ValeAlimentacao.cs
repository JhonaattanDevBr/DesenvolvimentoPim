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
    public partial class Form_ValeAlimentacao : Form
    {
        public Form_ValeAlimentacao()
        {
            InitializeComponent();
        }

        private void btnCalculcar_Click(object sender, EventArgs e)
        {
            FolhaPG ObjFolha = new FolhaPG();
            double retorno = ObjFolha.CalcularValeAlimentacao(Convert.ToDouble(txtSalarioBase.Text), Convert.ToDouble(txtValeAlimentacao.Text), Convert.ToInt16(txtDias.Text), Convert.ToInt16(txtPercentual.Text));
            txtRetorno.Text = "Valor valor do vale alimentação R$ " + retorno.ToString();
            // O valor ficou fixado e não se altera, preciso arrumar isso.
        }

        private void txtPercentual_TextChanged(object sender, EventArgs e)
        {
            string validacao = txtPercentual.Text.Trim(); // O comando trim() remove espaços em branco extras do início e do final da entrada.
            do
            {
                if (string.IsNullOrEmpty(validacao)) // Aqui eu testo se o campo for vazio.
                {
                    MessageBox.Show("O campo não pode ser vazio", "ATENÇÂO");
                    txtPercentual.Focus();
                    return;
                }
                if (!int.TryParse(validacao, out int percentual)) // Aqui eu testo se no campo for inserido uma letra.
                {
                    MessageBox.Show("Valor invalido", "ATENÇÂO");
                    txtPercentual.Focus();
                    return;
                }
                if (percentual > 20) // Aqui eu testo se o campo for maior que 20.
                {
                    MessageBox.Show("Valores acima de 20% não são aceitos", "ATENÇÂO");
                    txtPercentual.Focus();
                    return;
                }
            } while (Convert.ToInt16(txtPercentual.Text) > 20);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
