using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace Sofware_de_conversão___PCP
{
    public class clsCaps
    {        
        private string cod_desc;
        private string nome;
        private string cor;
        private double pesominimo;
        private double pesomedio;
        private double pesomaximo;
        private double valor;
        private string user;
        private string peso;
        private string quantidade;

        clsDados objDados = new clsDados();

        public string Cod_desc { get => cod_desc; set => cod_desc = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cor { get => cor; set => cor = value; }
        public double Pesominimo { get => pesominimo; set => pesominimo = value; }
        public double Pesomedio { get => pesomedio; set => pesomedio = value; }
        public double Pesomaximo { get => pesomaximo; set => pesomaximo = value; }
        public double Valor { get => valor; set => valor = value; }
        public string User { get => user; set => user = value; }
        public string Peso { get => peso; set => peso = value; }
        public string Quantidade { get => quantidade; set => quantidade = value; }

        public void incluir()
        {
            // será retornada uma mensagem de sucesso na inclusão(try)
            try
            {
                objDados.ConvertSqlToInt(@"INSERT INTO tbCaps (cod_desc, Nome, Cor, Pesominimo, Pesomedio, Pesomaximo) VALUES (@Cod_desc, @Nome, @Cor, @Pesominimo, @Pesomedio, @Pesomaximo)",
                  new MySqlParameter("@Cod_desc", Cod_desc),
                  new MySqlParameter("@Nome", Nome),
                  new MySqlParameter("@Cor", Cor),
                  new MySqlParameter("@Pesominimo", Pesominimo),
                  new MySqlParameter("@Pesomedio", Pesomedio),
                  new MySqlParameter("@Pesomaximo", Pesomaximo));
                MessageBox.Show("Inclusão realizada com sucesso!");

            }
            // gerou erro, exibe uma mensagem de impossibilidade da inclusão (catch)
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível realizar a inclução!");
            }
        }

        public void alterar()
        {
            try
            {
                objDados.ConvertSqlToInt(@"UPDATE tbCaps SET
                    Nome= @Nome, Cor= @Cor, Pesominimo= @Pesominimo, Pesomedio=@Pesomedio, Pesomaximo=@Pesomaximo WHERE cod_desc= @Cod_desc",
                   new MySqlParameter("@Cod_desc", Cod_desc),
                  new MySqlParameter("@Nome", Nome),
                  new MySqlParameter("@Cor", Cor),
                  new MySqlParameter("@Pesominimo", Pesominimo),
                  new MySqlParameter("@Pesomedio", Pesomedio),
                  new MySqlParameter("@Pesomaximo", Pesomaximo));
                MessageBox.Show("Alteração realizada com sucesso!");
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível realizar a Alteração!");
            }
        }

        public void excluir()
        {
            try
            {
                // se encontrar registro, o valor será != de 0
                if (objDados.ConvertSqlToInt(@"UPDATE tbCaps SET Ativo='n' WHERE cod_desc=@cod_desc",
                   new MySqlParameter("@cod_desc", Cod_desc)) != 0)
                {
                    MessageBox.Show("Registro Excluído com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não há registros com esse código!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível realizar a Exclusão!");
            }
        }

        public void incluirRegistro()
        {
            // será retornada uma mensagem de sucesso na inclusão(try)
            try
            {
                objDados.ConvertSqlToInt(@"INSERT INTO tbRegistro (cod_desc, peso, quantidade) VALUES (@Cod_desc, @Peso, @Quantidade)",
                  new MySqlParameter("@Cod_desc", Cod_desc),
                  new MySqlParameter("@Peso", Peso),
                  new MySqlParameter("@Quantidade", Quantidade));
                MessageBox.Show("Inclusão realizada com sucesso!");
            }
            // gerou erro, exibe uma mensagem de impossibilidade da inclusão (catch)
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível realizar a inclução!");
            }
        }

        public void Ativar()
        {
            try
            {
                // se encontrar registro, o valor será != de 0
                if (objDados.ConvertSqlToInt(@"UPDATE tbCaps SET Ativo='s' WHERE cod_desc=@cod_desc",
                   new MySqlParameter("@cod_desc", Cod_desc)) != 0)
                {
                    MessageBox.Show("Registro Excluído com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não há registros com esse código!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível realizar a Exclusão!");
            }
        }

        public DataTable consultar()
        {
            string caps = "SELECT cod_desc AS COD_DESCR, Nome AS NOME, Cor AS COR, " +
                "Pesominimo AS PESO_MINIMO, Pesomedio AS PESO_MEDIO, " +
                "Pesomaximo AS PESO_MAXIMO FROM tbCaps where Ativo='s'";

            DataTable tblrecuperada = objDados.ConvertSqlToDataTable(caps);

            return tblrecuperada;
        }

        public DataTable consultarRecupera()
        {
            string caps = "SELECT cod_desc AS COD_DESCR, Nome AS NOME, Cor AS COR, " +
                "Pesominimo AS PESO_MINIMO, Pesomedio AS PESO_MEDIO, " +
                "Pesomaximo AS PESO_MAXIMO FROM tbCaps where Ativo='n'";

            DataTable tblrecuperada = objDados.ConvertSqlToDataTable(caps);

            return tblrecuperada;
        }

        public DataTable pesquisar()
        {
            DataTable tblrecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM tbCaps " +
                "WHERE cod_desc= @cod_desc and Ativo='s'", 
                new MySqlParameter("@cod_desc", cod_desc));

            return tblrecuperada;
        }

        public DataTable pesquisarRegistro()
        {
            DataTable tblrecuperada = objDados.ConvertSqlToDataTable("select C.Nome Descrição, r.peso Peso, r.quantidade Quantidade from  tbRegistro R, tbCaps C where c.cod_desc=r.cod_desc;");

            return tblrecuperada;
        }

        public Double calcularUnidade()
        {           
            double Peso_KG = pesomedio / 1000000;
            double ValorFinal = (Peso_KG * Valor);

            return ValorFinal;
        }

        public Double calcularPeso()
        {
            double Peso_KG = pesomedio / 1000000;
            double ValorFinal = (Valor / Peso_KG) - 0.06;

            return ValorFinal;
        }
    }
}
