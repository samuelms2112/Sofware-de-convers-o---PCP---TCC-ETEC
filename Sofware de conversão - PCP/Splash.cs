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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pb1.Value < 100)
            {
                pb1.Value = pb1.Value + 2;
            }
            else
            {
                timer2.Enabled = false;
                this.Visible = false;
                Login_User login_user = new Login_User();
                //Login_User.show();
                login_user.ShowDialog();
            }
        }
    }
}
