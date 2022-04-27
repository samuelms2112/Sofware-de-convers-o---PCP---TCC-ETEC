using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Sofware_de_conversão___PCP
{
    public partial class menuPrincipal : Form
    {
        public menuPrincipal()
        {         
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Bem vindos ao Software de Conversão de Capsulas";
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString().ToString(); // data dd/mm/aaaa
            toolStripStatusLabel3.Text = DateTime.Now.ToShortTimeString().ToString(); // hora hh:mm:ss
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cad_Usuario janela = new cad_Usuario();
            var resultado =MessageBox.Show("Deseja realmente abrir essa rotina?","Cadastro Usuarios",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                janela.MdiParent = this;
                janela.Show();
            }
            
        }

        private void capsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cad_Caps janela = new cad_Caps();
            var resultado = MessageBox.Show("Deseja realmente abrir essa rotina?", "Cadastro Caps",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                janela.MdiParent = this;
                janela.Show();
            }
        }

        private void converçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cal_Caps janela = new cal_Caps();
            var resultado = MessageBox.Show("Deseja realmente abrir essa rotina?", "conversão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                janela.MdiParent = this;
                janela.Show();
            }
        }

        private void aDMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login_User janela = new Login_User();
            janela.ShowDialog();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            recuperaUser janela = new recuperaUser();
            var resultado = MessageBox.Show("Deseja realmente abrir essa rotina?", "Recupera Usuario",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                janela.MdiParent = this;
                janela.Show();
            }
        }

        private void capsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RecuperaCaps janela = new RecuperaCaps();
            var resultado = MessageBox.Show("Deseja realmente abrir essa rotina?", "Recupera Caps",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                janela.MdiParent = this;
                janela.Show();
            }
        }

    }
}
