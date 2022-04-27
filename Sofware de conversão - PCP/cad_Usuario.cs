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
    public partial class cad_Usuario : Form
    {    
        public cad_Usuario()
        {
            InitializeComponent();
            tabela();
        }

        claUsuario objU = new claUsuario();

        private void dados()
        {
            // recupero os valores dos textboxs para as propriedades
            objU.Nome = txtNome.Text;
            objU.Login = txtLogin.Text;
            objU.Senha = txtSenha.Text;
            objU.Adm = TXTaDM.Text;           
        }

        private void limpar()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
            TXTaDM.Text = "";
            txtCodigo.Focus();
        }

        private void tabela()
        {
            // se encontrar a quantidade de linhas maior que 0
            if (objU.consultar().Rows.Count > 0)
            {
                // Chamada do método Consultar
                dtGrid.DataSource = objU.consultar();
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
                
              if (objU.Senha == txtConfirmarSenha.Text) // verifico se os campos sao iguais
              {
                    objU.incluir(); // chama o metodo incluir
                    limpar();
                    tabela();
              }
              else
              {
                    MessageBox.Show("Senha Não compativel.", "Atenção");
                    txtSenha.Text = "";
                    txtConfirmarSenha.Text = "";
                    txtSenha.Focus();
              }          
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            objU.Cod_user = Convert.ToInt16(txtCodigo.Text);
            dados();
            objU.alterar();
            tabela();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                // recuperando o código para a propriedade
                objU.Cod_user =Convert.ToInt16(txtCodigo.Text);

                // Chamada do método pesquisar
                DataTable tblDados = objU.pesquisar();

                // exibe no textbox o valor contido nas colunas da tabela (originada da consulta)
                txtNome.Text = tblDados.Rows[0]["nome"].ToString();
                txtLogin.Text = tblDados.Rows[0]["login"].ToString();
                txtSenha.Text = tblDados.Rows[0]["senha"].ToString();
                txtConfirmarSenha.Text = tblDados.Rows[0]["senha"].ToString();
                TXTaDM.Text = tblDados.Rows[0]["adm"].ToString();

            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Não há registros com esse código. Informe um código válido!");
                txtCodigo.Focus();
            }
            catch (FormatException)
            {
                MessageBox.Show("Digite o Código antes de pesquisar");
                txtCodigo.Focus();
            }
        }
      
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            objU.Cod_user = Convert.ToInt16(txtCodigo.Text);
            dados();
            objU.excluir();
            tabela();
            limpar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
