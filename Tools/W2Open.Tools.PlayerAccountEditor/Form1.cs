using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using W2Open.Common.Utility;
using W2Open.DataServer;

namespace W2Open.Tools.PlayerAccountEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateEmptyAccount_Click(object sender, EventArgs e)
        {
            UPlayerAccount playerAcc = W2Marshal.CreateZeroInitialized<UPlayerAccount>();

            playerAcc.Login = txtLogin.Text;
            playerAcc.Password = txtPsw.Text;

            var result = PlayerAccountCRUD.TrySaveAccount(playerAcc);
            
            MessageBox.Show(result.ToString());
        }
    }
}