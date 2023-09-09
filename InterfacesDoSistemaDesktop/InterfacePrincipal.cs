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
    public partial class InterfacePrincipal : Form
    {
        public InterfacePrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void agendarFériasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Eu tentei fazer a janela fehcar essa janela e abrir a outra sem ficar com duas janelas abertas mas não consegui
             depois eu tento fazer isso, por enquanto vou fazer a interface do formulario que o professor solicitou.
            InterfaceAgendarFerias ObjInterfaceAgendarFerias = new InterfaceAgendarFerias();
            ObjInterfaceAgendarFerias.Show();
            */
        }

        private void períodoCompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_PeriodoCompleto form_PeriodoCompleto = new Form_PeriodoCompleto();
            form_PeriodoCompleto.Show();
        }

        private void doisPeríodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DoisPeriodos form_DoisPeriodos = new Form_DoisPeriodos();
            form_DoisPeriodos.Show();
        }

        private void trêsPeríodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void calcularValeTransporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ValeTransporte form_ValeTransporte = new Form_ValeTransporte();
            form_ValeTransporte.Show();
        }

        private void calcularValeAlimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_ValeAlimentacao = new Form_ValeAlimentacao();
            form_ValeAlimentacao.Show();
        }

        private void calcularAdiantamentoQuinzenalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_AdiantamentoQuinzenal form_AdiantamentoQuinzenal = new Form_AdiantamentoQuinzenal();
            form_AdiantamentoQuinzenal.Show();
        }

        private void calcularConvênioOdontológicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ConvenioOdontologico form_ConvenioOdontologico = new Form_ConvenioOdontologico();
            form_ConvenioOdontologico.Show();
        }

        private void calcularConvênioMédicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ConvenioMedico form_ConvenioMedico = new Form_ConvenioMedico();
            form_ConvenioMedico.Show();
        }

        private void calcularDependentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Dependentes form_Dependentes = new Form_Dependentes();
            form_Dependentes.Show();
        }

        private void calcularPensãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Pensao form_Pensao = new Form_Pensao();
            form_Pensao.Show();
        }

        private void calcularFGTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Fgts form_Fgts = new Form_Fgts();
            form_Fgts.Show();
        }

        private void calcularINSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Inss form_Inss = new Form_Inss();
            form_Inss.Show();
        }

        private void calcularIRRFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Irrf form_Irrf = new Form_Irrf();
            form_Irrf.Show();
        }

        private void calcularHorasExtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_HorasExtras form_HorasExtras = new Form_HorasExtras();
            form_HorasExtras.Show();
        }

        private void calcularPericulosidadeEInsalubridadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Periculosidade_Insalubridade form_Periculosidade_Insalubridade = new Form_Periculosidade_Insalubridade();
            form_Periculosidade_Insalubridade.Show();
        }
    }
}
