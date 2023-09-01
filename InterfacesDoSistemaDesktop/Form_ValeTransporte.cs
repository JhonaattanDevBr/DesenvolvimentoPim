
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
    public partial class Form_ValeTransporte : Form
    {
        public Form_ValeTransporte()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            FolhaPG ObjFolha = new FolhaPG();
            double retorno = ObjFolha.ContabilizarValeTransporte(Convert.ToDouble(txtSalarioBase.Text), Convert.ToDouble(txtPassagem.Text), Convert.ToInt16(txtDias.Text));
            txtRetorno.Text = "O valor do vale transporte a ser descontado/depositado é de R$ " + retorno.ToString();
        }

        private void períodoCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_PeriodoCompleto ObjForm_PeriodoCompleto = new Form_PeriodoCompleto();
            ObjForm_PeriodoCompleto.Show();
        }

        private void doisPeríodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DoisPeriodos objForm_DoisPeriodos = new Form_DoisPeriodos();
            objForm_DoisPeriodos.Show();
        }
    }
}
