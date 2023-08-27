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
    public partial class Form_PeriodoCompleto : Form
    {
        public Form_PeriodoCompleto()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdbSim_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSim.Checked == true) 
            {
                lblQuantidade.Enabled = true;
                txtQuantidade.Enabled = true;
            }else if (rdbSim.Checked == false)
            {
                lblQuantidade.Enabled = false;
                txtQuantidade.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("As férias foram agendadas com sucesso!","Atividade concluida");
            Close();
        }
    }
}
