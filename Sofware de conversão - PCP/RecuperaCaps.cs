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
    public partial class RecuperaCaps : Form
    {
        public RecuperaCaps()
        {
            InitializeComponent();
            tabela();
        }

        clsCaps objC = new clsCaps();

        private void tabela()
        {
            // se encontrar a quantidade de linhas maior que 0
            if (objC.consultarRecupera().Rows.Count > 0)
            {
                // Chamada do método Consultar
                dtGrid.DataSource = objC.consultarRecupera();
            }
            else
            {
                dtGrid.Columns.Clear(); // limpa as colunas

                MessageBox.Show("Não há registros!");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            objC.Cod_desc = txtCodigo.Text;
            objC.Ativar();
            tabela();
        }
    }
}
