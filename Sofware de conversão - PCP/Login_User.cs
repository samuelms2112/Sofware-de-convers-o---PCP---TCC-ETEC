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
    public partial class Login_User : Form
    {
        public Login_User()
        {
            InitializeComponent();
        }

        claUsuario objU = new claUsuario();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //pega os dados do formulario                
                objU.Login = txtUsuario.Text;
                objU.Senha = txtSenha.Text;
                objU.Adm = "s".ToString();

                // pega os dados do banco de dados
                DataTable tbldados = objU.LOGAR();
                var login = tbldados.Rows[0]["Login"].ToString();
                var senha = tbldados.Rows[0]["Senha"].ToString();                
                var adm = tbldados.Rows[0]["adm"].ToString();
                
                // validação para o usuario real
                if (objU.Login.Equals(login) && objU.Senha.Equals(senha))
                {
                    this.Visible = false;

                    if (objU.Adm.Equals(adm))
                    {
                        menuPrincipal janela = new menuPrincipal();
                        janela.Show();
                    }
                    else
                    {
                        menuPrincipalII janela = new menuPrincipalII();
                        janela.Show();
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Usuário ou senha invalida!");
            }
            catch (FormatException)
            {
                MessageBox.Show("É necessário informar o código de usuario");
            }

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
