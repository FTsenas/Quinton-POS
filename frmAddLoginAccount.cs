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
    public partial class frmAddLoginAccount : Form
    {
        public frmAddLoginAccount()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

         
            #region loadAnimation
            guna2Transition2.AddToQueue(guna2GradientPanel1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(guna2GradientPanel5, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(guna2GradientPanel2, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(guna2CirclePictureBox1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnSave, Guna.UI2.AnimatorNS.AnimateMode.Show, false);
            #endregion

            List<string> userRight = new List<string>();

            userRight.AddRange(new List<string>() { "Standard","Administrator"});

            payMethCombo.DataSource = userRight;

        }


        #region DatabaseObjects

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rdr;
        DataSet ds;

        #endregion

        string userType;
        string accUserID = clsAuthenticity.accUserID;

        private void frmAddLoginAccount_Load(object sender, EventArgs e)
        {
       
           
            gunaTransition4.HideSync(guna2TextBox1);
            guna2TextBox1.Text = clsAuthenticity.accUserFirstName + " " + clsAuthenticity.accUserLastName;
            gunaTransition4.ShowSync(guna2TextBox1);

            txtUName.Focus();
            txtUName.Select();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
         
        }

        private void payMethCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gunaTransition4.HideSync(payMethCombo);
            gunaTransition4.ShowSync(payMethCombo);

            txtUName.Focus();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
        
         

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtUName.Text == "")
            {
                MessageBox.Show("One or more field(s) is empty!");
                txtUName.Focus();
                return;
            }

            if (txtNPassword.Text == "")
            {
                MessageBox.Show("One or more field(s) is empty!");
                txtNPassword.Focus();
                return;
            }

            if (txtCPassword.Text == "")
            {
                MessageBox.Show("One or more field(s) is empty!");
                txtCPassword.Focus();
                return;
            }

            if (txtNPassword.Text != txtCPassword.Text)
            {
                MessageBox.Show("The provided passwords do not match!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNPassword.Focus();
                return;
            }



            if (payMethCombo.SelectedValue.ToString() == "Standard")
            {
                userType = "Cashier";

            }
            else if (payMethCombo.SelectedValue.ToString() == "Administrator")
            {
                userType = "Admin";

            }

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("INSERT INTO dtb_Login_rws (UID,Username,Password,UType) VALUES (@v1,@v2,@v3,@v4)", con);
                cmd.Parameters.AddWithValue("@v1", accUserID);
                cmd.Parameters.AddWithValue("@v2", txtUName.Text);
                cmd.Parameters.AddWithValue("@v3", txtNPassword.Text);
                cmd.Parameters.AddWithValue("@v4", userType);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Done");

                clsSystemTray.notifier("Login Account Successfully Created.");

                this.Close();
            }
            catch (Exception exBYA)
            {

                MessageBox.Show("" + exBYA);
            }
        }



    }
}
