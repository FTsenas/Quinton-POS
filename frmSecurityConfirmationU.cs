using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace QuintonPOS
{
    public partial class frmSecurityConfirmationU : Form
    {
        public frmSecurityConfirmationU()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;
        }

        #region DatabaseObjects
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;

        #endregion


        private void frmSecurityConfirmationU_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            logInside();
        }

        private void logInside()
        {
            if (txtUName.Text.Trim() == clsAuthenticity.username && txtOPassword.Text.Trim() == clsAuthenticity.password)
            {
                frmChangePassword frm = new frmChangePassword();
                frm.ShowDialog(this);
                txtUName.Clear();
                txtOPassword.Clear();
            }
            else
            {
                MessageBox.Show("Details should be of the currently logged in User!");
                txtUName.Clear();
                txtOPassword.Clear();
            }

        }

        private void frmSecurityConfirmationU_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAuthenticity.showRunningForm();
        }

        private void txtOPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                logInside();
            }
        }
    }
}
