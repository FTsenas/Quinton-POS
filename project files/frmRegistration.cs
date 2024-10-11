using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipt_val_fl;
using System.Data.OleDb;


namespace QuintonPOS
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;
        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Something went wrong....App restarting now");
                Application.Exit();

            }
           

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            

        }

        private void frmRegistration_Activated(object sender, EventArgs e)
        {
            txtUName.Focus();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtUID.Clear();
            txtUName.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtID.Clear();
            payMethCombo.Text = "";
            txtPassword.Clear();
            txtNotes.Clear();

        }

        private void frmRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.integersOnly(sender, e);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (txtUName.Text == "")
            {
                MessageBox.Show("Username field cannot be blank!");
                txtUName.Focus();
                return;
            }

            if (txtFName.Text == "")
            {
                MessageBox.Show("Firstname field cannot be blank!");
                txtFName.Focus();
                return;
            }

            if (txtLName.Text == "")
            {
                MessageBox.Show("Lastname field cannot be blank!");
                txtLName.Focus();
                return;
            }

            if (txtContact.Text == "")
            {
                MessageBox.Show("Contact Number field cannot be blank!");
                txtContact.Focus();
                return;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email field cannot be blank!");
                txtEmail.Focus();
                return;
            }

            if (txtID.Text == "")
            {
                MessageBox.Show("ID field cannot be blank!");
                txtID.Focus();
                return;
            }

            if(payMethCombo.Text == "")
            {
                MessageBox.Show("Select user type!");
                payMethCombo.Focus();
                return;
            }
           
            if (txtNotes.Text == "")
            {
                MessageBox.Show("Notes field cannot be blank!");
                txtNotes.Focus();
                return;
            }

          

            try
            {
                txtUID.Text = clsKeyGen.getFullUSERCode();
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();


                cmd = new OleDbCommand("Insert Into dtb_Registration_rws(UID,FName,LName,ContactNo,Email,EnrollmentDate,NationalID,Notes) VALUES(@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8)", con);
                cmd.Parameters.AddWithValue("@v1", txtUID.Text);
                cmd.Parameters.AddWithValue("@v2", txtFName.Text);
                cmd.Parameters.AddWithValue("@v3", txtLName.Text);
                cmd.Parameters.AddWithValue("@v4", txtContact.Text);
                cmd.Parameters.AddWithValue("@v5", txtEmail.Text);
                cmd.Parameters.AddWithValue("@v6", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@v7", txtID.Text);
                cmd.Parameters.AddWithValue("@v8", txtNotes.Text);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("Insert Into dtb_Login_rws (,UID,Username,Password,UType) VALUES(@v1,@v2,@v3,@v4)", con);
                cmd.Parameters.AddWithValue("@v1", txtUID.Text);
                cmd.Parameters.AddWithValue("@v2", txtUName.Text);
                cmd.Parameters.AddWithValue("@v3", txtPassword.Text);
                cmd.Parameters.AddWithValue("@v4", payMethCombo.Text);
                cmd.ExecuteNonQuery();
       

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                MessageBox.Show("" + txtFName.Text + " has been added to Users.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsSystemTray.notifier("Details Updated, outdated files have been added to Garbage List");
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("" + ex);
               // MessageBox.Show("Could not process request at the time, please try again!");
                //return;
                throw;
            }
         
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {

        }

    }
}
