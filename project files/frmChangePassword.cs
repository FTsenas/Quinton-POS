using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;



namespace QuintonPOS
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            #region GUNADESIGN

            guna2Transition1.AddToQueue(Label4, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(Label1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(Label3, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(Label2, Guna.UI2.AnimatorNS.AnimateMode.Show, true);

            guna2Transition2.AddToQueue(txtUName, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtOPassword, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtNPassword, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtCPassword, Guna.UI2.AnimatorNS.AnimateMode.Show, true);

            guna2Transition3.AddToQueue(btnConfirm, Guna.UI2.AnimatorNS.AnimateMode.Show, true);

            #endregion



        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;

        



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            txtUName.Focus();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //CODE TO SAVE CHANGES!!!
            Application.Restart();

        }

        private void frmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
      

        }

        private void frmChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsProgressIndicator.timerOps(guna2WinProgressIndicator1, timer1);
        }

        private void txtUName_TextChanged(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();

        }

        private void txtOPassword_TextChanged(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();
        }


        private void txtNPassword_TextChanged(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();
        }

        private void txtCPassword_TextChanged(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            performOpp();
        }

        private void performOpp()
        {
            try
            {
                if (txtUName.Text == "")
                {
                    MessageBox.Show("One or more special field(s) is blank!");
                    txtUName.Focus();
                    return;
                }

                if (txtOPassword.Text == "")
                {
                    MessageBox.Show("One or more special field(s) is blank!");
                    txtOPassword.Focus();
                    return;
                }

                if (txtNPassword.Text == "")
                {
                    MessageBox.Show("One or more special field(s) is blank!");
                    txtNPassword.Focus();
                    return;
                }

                if (txtCPassword.Text == "")
                {
                    MessageBox.Show("One or more special field(s) is blank!");
                    txtCPassword.Focus();
                    return;
                }

                if (txtOPassword.Text == txtNPassword.Text)
                {
                    MessageBox.Show("The New Password cannot be the same as the Old Password!");
                    txtNPassword.Focus();
                    return;
                }

                if (txtNPassword.Text != txtCPassword.Text)
                {
                    MessageBox.Show("The New Password fields do not match!");
                    txtNPassword.Focus();
                    return;
                }



                con = new OleDbConnection(connectionString.DBConn);
                con.Open();



                if (txtUName.Text == clsAuthenticity.username && txtOPassword.Text == clsAuthenticity.password)
                {
                    if (MessageBox.Show("Application will automatically restart now, any unsaved work will be lost. Continue?", "QPOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {

                        cmd = new OleDbCommand("UPDATE  dtb_Login_rws  SET [Password] = '" + txtNPassword.Text + "' WHERE [Username] = '" + txtUName.Text + "' AND [Password] = '" + txtOPassword.Text + "'", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated.");
                        Application.Restart();

                    }
                    else
                    {
                        MessageBox.Show("Operation cancelled, changes were not saved!");
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect Username Or Password!");
                }

                con.Close();

           
            }
            catch (Exception exCon)
            {

                MessageBox.Show("An error occurred, try again later. Issue key 0x1Con");
            }
         

        }

        private void clearInputs()
        {
            txtUName.Clear();
            txtNPassword.Clear();
            txtOPassword.Clear();
            txtCPassword.Clear();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void txtCPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                performOpp();
            }
        }

        private void txtCPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
     
        }

        private void txtNPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                performOpp();
            }
        }

        private void txtOPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                performOpp();
            }
        }

        private void txtUName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                performOpp();
            }
        }
    }
}
