using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sofware_de_conversão___PCP
{
    public partial class recuperaUser : Form
    {
        public recuperaUser()
        {
            InitializeComponent();
            tabela();
        }
        claUsuario objU = new claUsuario();
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void tabela()
        {
            // se encontrar a quantidade de linhas maior que 0
            if (objU.consultarRecupera().Rows.Count > 0)
            {
                // Chamada do método Consultar
                dtGrid.DataSource = objU.consultarRecupera();
            }
            else
            {
                dtGrid.Columns.Clear(); // limpa as colunas

                MessageBox.Show("Não há registros!");
            }
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            objU.Cod_user =int.Parse(txtCodigo.Text);
            objU.Ativar();
            tabela();
        }
    }
}
