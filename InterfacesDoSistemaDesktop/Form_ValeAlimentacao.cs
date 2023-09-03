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
            double retorno = ObjFolha.CalcularValeAlimentacao(Convert.ToDouble(txtValeAlimentacao.Text), Convert.ToInt16(txtDias.Text), Convert.ToInt16(txtPercentual.Text));
            txtRetorno.Text = retorno.ToString();
        }

        private void txtPercentual_TextChanged(object sender, EventArgs e)
        {
            // Preciso incluir na verificação para quando ele der focus ele altomaticamente retirar os numeros da caixa pois esta quebrando a funcionalidade da caixa.
            string validacao = txtPercentual.Text.Trim(); // O comando trim() remove espaços em branco extras do início e do final da entrada.
            if (string.IsNullOrEmpty(validacao)) // Aqui eu testo se o campo for vazio.
            {
                txtPercentual.Focus();
                return;
            }
            if (!int.TryParse(validacao, out int percentual)) // Aqui eu testo se no campo for inserido uma letra.
            {
                MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÂO");
                txtPercentual.Focus();
                return;
            }
            if (percentual > 20) // Aqui eu testo se o campo for maior que 20.
            {
                MessageBox.Show("Valores acima de 20% não são aceitos.", "ATENÇÂO");
                txtPercentual.Focus();
                return;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtValeAlimentacao.Clear();
            txtDias.Clear();
            txtPercentual.Clear();
            txtRetorno.Clear();
            txtValeAlimentacao.Focus();
        }

        private void txtDias_TextChanged(object sender, EventArgs e)
        {
            // Preciso incluir na verificação para quando ele der focus ele altomaticamente retirar os numeros da caixa pois esta quebrando a funcionalidade da caixa.
            string validacao = txtDias.Text.Trim();
            if(string.IsNullOrEmpty(validacao))
            {
                txtDias.Focus();
                return;
            }
            if(!int.TryParse(validacao,out int dias)) 
            {
                MessageBox.Show("Este campo não aceita letras ou caracteres.", "ATENÇÃO");
                txtDias.Focus();
                return;
            }
            if(dias > 22)
            {
                MessageBox.Show("Valores acima de 22 não são aceitos.", "ATENÇÃO");
                txtDias.Focus();
                return;

            }
        }
    }
}
