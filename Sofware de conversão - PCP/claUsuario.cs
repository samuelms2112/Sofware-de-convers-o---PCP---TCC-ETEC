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
   public class claUsuario
    {
        private int cod_user;
        private string nome;
        private string login;
        private string senha;
        private string adm;        
        
        clsDados objDados = new clsDados();

        public int Cod_user { get => cod_user; set => cod_user = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Adm { get => adm; set => adm = value; }

        public void incluir()
        {
            // será retornada uma mensagem de sucesso na inclusão(try)
            try
            {
                objDados.ConvertSqlToInt(@"INSERT INTO tblogin (nome, login, senha, adm) VALUES (@Nome,@Login,@Senha,@Adm)",
                  new MySqlParameter("@Nome", Nome),
                  new MySqlParameter("@Login", Login),
                  new MySqlParameter("@Senha", Senha),
                  new MySqlParameter("@Adm", Adm));
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
                objDados.ConvertSqlToInt(@"UPDATE tblogin SET
                   nome= @Nome, login= @Login, senha= @Senha, adm=@Adm WHERE cod_user= @Cod_user",
                   new MySqlParameter("@Cod_user", Cod_user),
                   new MySqlParameter("@Nome", Nome),
                   new MySqlParameter("@Login", Login),
                   new MySqlParameter("@Senha", Senha),
                   new MySqlParameter("@Adm", Adm));
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
                if (objDados.ConvertSqlToInt(@"UPDATE tblogin SET Ativo='n' WHERE Cod_user=@Cod_user",
                   new MySqlParameter("@Cod_user", Cod_user)) == 0)
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

        public void Ativar()
        {
            try
            {
                // se encontrar registro, o valor será != de 0
                if (objDados.ConvertSqlToInt(@"UPDATE tblogin SET Ativo='s' WHERE Cod_user=@Cod_user",
                   new MySqlParameter("@Cod_user", Cod_user)) == 0)
                {

                    MessageBox.Show("Registro Ativado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não há registros com esse código!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível realizar a Ativasão!");
            }
        }

        public DataTable consultar()
        {
            DataTable tblrecuperada = objDados.ConvertSqlToDataTable("select COD_USER AS CODIGO, " +
                "NOME AS NOME, LOGIN AS LOGIN " +
                "from  tblogin where Ativo = 's'");

            return tblrecuperada;
        }

        public DataTable consultarRecupera()
        {
            DataTable tblrecuperada = objDados.ConvertSqlToDataTable("select COD_USER AS CODIGO, " +
                "NOME AS NOME, LOGIN AS LOGIN " +
                "from  tblogin where Ativo = 'n'");

            return tblrecuperada;
        }

        public DataTable pesquisar()
        {
            DataTable tblrecuperada = objDados.ConvertSqlToDataTable("SELECT * FROM tblogin " +
                "WHERE cod_user= @Cod_user and Ativo = 's'", 
                new MySqlParameter("@Cod_user", Cod_user));

            return tblrecuperada;
        }       
        
        public DataTable LOGAR()
        {
            DataTable tblresultado = objDados.ConvertSqlToDataTable("SELECT * FROM tblogin WHERE " +
               "login=@login and senha=@Senha and Ativo = 's'",
                new MySqlParameter("@login", Login),
                new MySqlParameter("@Senha", Senha));

            return tblresultado;
        }

    }
}
