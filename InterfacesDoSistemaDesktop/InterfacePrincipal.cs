﻿using System;
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
            Form_PeriodoCompleto ObjFormPeriodoCompleto = new Form_PeriodoCompleto();
            ObjFormPeriodoCompleto.Show();
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
            Form_ValeTransporte Obj_FormValeTransporte = new Form_ValeTransporte();
            Obj_FormValeTransporte.Show();
        }

        private void calcularValeAlimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Obj_FormValeAlimentacao = new Form_ValeAlimentacao();
            Obj_FormValeAlimentacao.Show();
        }
    }
}