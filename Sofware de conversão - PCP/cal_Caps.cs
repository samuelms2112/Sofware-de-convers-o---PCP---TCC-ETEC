using System;
using System.Data;
using System.Windows.Forms;

namespace Sofware_de_conversão___PCP
{
    public partial class cal_Caps : Form
    {
        public cal_Caps()
        {
            InitializeComponent();
            tabela();
        }

        clsCaps objC = new clsCaps();

        private void tabela()
        {
            // se encontrar a quantidade de linhas maior que 0
            if (objC.pesquisarRegistro().Rows.Count > 0)
            {
                // Chamada do método Consultar
                dtGrid.DataSource = objC.pesquisarRegistro();
            }
            else
            {
                dtGrid.Columns.Clear(); // limpa as colunas

                MessageBox.Show("Não há registros!");
            }
        }

        private void limpar()
        {
            // limpa os valores do TextBoxs
            txtCod_Descr1.Text = "";
            txtCod_Descr2.Text = "";
            txtmedio2.Text = "";
            txtNome1.Text = "";
            txtNome2.Text = "";
            txtPeso.Text = "";
            txtPesoMedio1.Text = "";
            txtResultado1.Text = "";
            txtResultado2.Text = "";
            txtValor.Text = ""; 
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                // recuperando o código para a propriedade
                objC.Cod_desc = txtCod_Descr1.Text;

                // Chamada do método pesquisar
                DataTable tblDados = objC.pesquisar();

                // exibe no textbox o valor contido nas colunas da tabela (originada da consulta)
                txtNome1.Text = tblDados.Rows[0]["Nome"].ToString();
                txtPesoMedio1.Text = tblDados.Rows[0]["Pesomedio"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                // Exebir Mensagem se o codigo não estiver conforme ao banco de dados
                MessageBox.Show("Não há registros com esse código. Informe um código válido!");
                txtCod_Descr1.Focus();
            }
            catch (FormatException)
            {
                // Exebir Mensagem se nao informar o codigo
                MessageBox.Show("Digite o Código antes de pesquisar");
                txtCod_Descr1.Focus();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCod_Descr1.Focus();
            limpar();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            objC.Valor = Convert.ToDouble(txtValor.Text);
            objC.Pesomedio = Convert.ToDouble(txtPesoMedio1.Text);
            txtResultado1.Text= objC.calcularUnidade().ToString();
        }

        private void btnCalcular2_Click_1(object sender, EventArgs e)
        {
            objC.Valor = Convert.ToDouble(txtPeso.Text);
            objC.Pesomedio = Convert.ToDouble(txtmedio2.Text);
            txtResultado2.Text = Math.Round(objC.calcularPeso()).ToString();
        }

        private void btnLimpar2_Click(object sender, EventArgs e)
        {
            txtCod_Descr2.Focus();
            limpar();
        }

        private void btnPesquisar2_Click(object sender, EventArgs e)
        {
            try
            {
                // recuperando o código para a propriedade
                objC.Cod_desc = txtCod_Descr2.Text;

                // Chamada do método pesquisar
                DataTable tblDados = objC.pesquisar();

                // exibe no textbox o valor contido nas colunas da tabela (originada da consulta)
                txtNome2.Text = tblDados.Rows[0]["Nome"].ToString();
                txtmedio2.Text = tblDados.Rows[0]["Pesomedio"].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                // Exebir Mensagem se o codigo não estiver conforme ao banco de dados
                MessageBox.Show("Não há registros com esse código. Informe um código válido!");
                txtCod_Descr1.Focus();
            }
            catch (FormatException)
            {
                // Exebir Mensagem se nao informar o codigo
                MessageBox.Show("Digite o Código antes de pesquisar");
                txtCod_Descr1.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnSalvarRegistro_Click(object sender, EventArgs e)
        {
            objC.Peso =txtResultado1.Text;
            objC.Cod_desc = txtCod_Descr1.Text;
            objC.Quantidade = txtValor.Text;
            objC.incluirRegistro();
            tabela();
        }

        private void btnSalvarRegistro2_Click(object sender, EventArgs e)
        {
            objC.Peso = txtPeso.Text;
            objC.Cod_desc = txtCod_Descr2.Text;
            objC.Quantidade = txtResultado2.Text;
            objC.incluirRegistro();
            tabela();
        }
    }
}
