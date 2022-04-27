using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sofware_de_conversão___PCP
{
    public class clsDados
    {
        private MySqlConnection objConexao = null;

        private void conectar()
        {
            string server = "localhost";

            string user = "root";

            string password = "samuel21";

            string database = "bdconverte";

            string port = "3306";

            string strStringConexao = "SERVER=" + server + ";PORT="+ port + ";DATABASE=" + database + ";UID=" + user + ";PASSWORD=" + password + ";";

            objConexao = new MySqlConnection(strStringConexao);

            objConexao.Open();
        }

        private void desconectar()
        {
            objConexao.Close();
        }


        //pega o codigo SQL e retorna o Nº de linhas afetadas pelo comando
        public int ConvertSqlToInt(string p_strComandoSQL, params MySqlParameter[] p_arrParametros)
        {
            //Conecto ao Banco
            conectar();

            int linhasAfetadas = 0;

            try
            {
                //Instancio meu objeto de comando sql
                MySqlCommand objComandoSQL = new MySqlCommand();

                //Instancio a string de conexão do banco
                objComandoSQL.Connection = objConexao;

                //Percorro comando SQL passando os parâmetros informados
                objComandoSQL.CommandText = p_strComandoSQL;

                if (p_arrParametros != null)
                {
                    foreach (MySqlParameter objParametro in p_arrParametros)
                    {

                        objComandoSQL.Parameters.Add(objParametro);

                    }
                }

               objComandoSQL.ExecuteNonQuery();

            }
            finally
            {
                desconectar();
            }
            return linhasAfetadas;

        }


        // pega o codigo SQL e retorna em forma de uma Tabela para conseguir manipular od registros
        public DataTable ConvertSqlToDataTable(string p_strComandoSQL, params MySqlParameter[] p_arrParametros)
        {
            conectar(); // cria conexão com o Banco de Dados

            DataTable tblResultado = new DataTable(); // instanciação de uma DataTable de resultado

            try
            {
                MySqlCommand objComandoSQL = new MySqlCommand(); // Instancia um comando SQL a ser executado

                objComandoSQL.Connection = objConexao;

                objComandoSQL.CommandText = p_strComandoSQL;

                if (p_arrParametros != null) // Verificando se existe parâmetros
                {
                    foreach (MySqlParameter objParametro in p_arrParametros)
                    {
                        objComandoSQL.Parameters.Add(objParametro);
                    }
                }

                MySqlDataAdapter objAdaptador = new MySqlDataAdapter(); // executa o comando SQL; DataAdapter faz comunicação entre sistema e Banco de Dados

                objAdaptador.SelectCommand = objComandoSQL;
                objAdaptador.Fill(tblResultado); // preenche o resultado do comando executado
                objAdaptador.Update(tblResultado);

            }
            finally
            {
                desconectar();
            }

            return tblResultado;
        }

        
        public DataTable ConvertSqlToDataTable(string p_strComandoSQL)
        {
            return ConvertSqlToDataTable(p_strComandoSQL, null);
        }
    }
}
