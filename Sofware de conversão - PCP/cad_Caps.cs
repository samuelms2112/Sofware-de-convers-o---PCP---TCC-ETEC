using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Sofware_de_conversão___PCP
{
    public partial class cad_Caps : Form
    {
        
        public cad_Caps()
        {
            InitializeComponent();
            tabela();
        }

        clsCaps objC = new clsCaps();

        private void dados()
        {
            // recupero os valores dos textboxs para as propriedades
            objC.Cod_desc = txtcod_desc.Text;
            objC.Nome = txtnome.Text;
            objC.Cor = txtcor.Text;
            objC.Pesominimo = Convert.ToDouble(txtminimo.Text);
            objC.Pesomedio = Convert.ToDouble(txtmedio.Text);
            objC.Pesomaximo = Convert.ToDouble(txtmaximo.Text);
        }

        private void limpar()
        {
            txtcod_desc.Text = "";
            txtnome.Text = "";
            txtcor.Text = "";
            txtminimo.Text = "";
            txtmedio.Text = "";
            txtmaximo.Text = "";
            txtmaximo.Focus();
        }

        private void tabela()
        {
            // se encontrar a quantidade de linhas maior que 0
            if (objC.consultar().Rows.Count > 0)
            {
                // Chamada do método Consultar
                dtGrid.DataSource = objC.consultar();
            }
            else
            {
                dtGrid.Columns.Clear(); // limpa as colunas

                MessageBox.Show("Não há registros!");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            dados();
            objC.incluir();
            tabela();
            limpar();
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // recuperando o código para a propriedade
                objC.Cod_desc = txtcod_desc.Text;

                // Chamada do método pesquisar
                DataTable tblDados = objC.pesquisar();

                // exibe no textbox o valor contido nas colunas da tabela (originada da consulta)
                txtnome.Text = tblDados.Rows[0]["Nome"].ToString();
                txtcor.Text = tblDados.Rows[0]["Cor"].ToString();
                txtminimo.Text = tblDados.Rows[0]["Pesominimo"].ToString();
                txtmedio.Text = tblDados.Rows[0]["Pesomedio"].ToString();
                txtmaximo.Text = tblDados.Rows[0]["Pesomaximo"].ToString();

            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Não há registros com esse código. Informe um código válido!");
                txtcod_desc.Focus();
            }
            catch (FormatException)
            {
                MessageBox.Show("Digite o Código antes de pesquisar");
                txtcod_desc.Focus();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            objC.Cod_desc = txtcod_desc.Text;
            dados();
            objC.excluir();
            tabela();
            limpar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            objC.Cod_desc = txtcod_desc.Text;
            dados();
            objC.alterar();
            tabela();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }       

        private void txtcod_desc_TextChanged(object sender, EventArgs e, KeyEventArgs i)
        {
            if ((i.KeyCode == Keys.Enter) || (i.KeyCode == Keys.Return))
            {
                txtnome.Focus();
            }
        }
    }
}
