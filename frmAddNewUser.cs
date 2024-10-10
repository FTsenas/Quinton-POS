using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data.OleDb;


namespace QuintonPOS
{
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
            gunaTransition1.AddToQueue(Label2, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label5, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label6, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label19, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label20, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label21, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition2.AddToQueue(guna2Button3, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(groupBox1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(btnSave, Guna.UI.Animation.AnimateMode.Show, true);


            txtEnrolDT.Value = DateTime.Today;

        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

        short avatarPlaceHolderCount = 0;
        string avatarPlaceHolder = "";
        string userIDHolder = clsKeyGen.getFullUSERCode();
   
              

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            if(txtFName.Text == "")
            {
                MessageBox.Show("First name field cannot be empty!");
                txtFName.Focus();
                return;
            }

            if (txtLName.Text == "")
            {
                MessageBox.Show("Last Name field cannot be empty!");
                txtLName.Focus();
                return;
            }

            if (txtContact.Text == "")
            {
                MessageBox.Show("Contact field cannot be empty!");
                txtContact.Focus();
                return;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email field cannot be empty!");
                txtEmail.Focus();
                return;
            }

     try
     {
         con = new OleDbConnection(connectionString.DBConn);
         con.Open();

         string query = "insert Into dtb_Registration_rws(UID,FName,LName,ContactNo,Email,EnrollMentDate,NationalID,Notes) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
         cmd = new OleDbCommand(query);
         cmd.Connection = con;
         cmd.Parameters.AddWithValue("@d1", userIDHolder);
         cmd.Parameters.AddWithValue("@d2", txtFName.Text);
         cmd.Parameters.AddWithValue("@d3", txtLName.Text);
         cmd.Parameters.AddWithValue("@d4", txtContact.Text);
         cmd.Parameters.AddWithValue("@d5", txtEmail.Text);
         cmd.Parameters.AddWithValue("@d6", txtEnrolDT.Text);
         cmd.Parameters.AddWithValue("@d7", txtNID.Text);
         cmd.Parameters.AddWithValue("@d8", txtNotes.Text);
         cmd.ExecuteNonQuery();

         con.Close();
      

         MessageBox.Show("Done");
         this.Close();
     
     }
     catch (Exception exHLN)
     {
         MessageBox.Show("Something went wrong! Issue key: 0x1HLN");
         return;
     }
     

        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
      
       
        }

        private void gunaGradientButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtPDesc_TextChanged(object sender, EventArgs e)
        {
            txtMirror.Text = txtLName.Text;
        }

        private void frmAddNewProduct_Load(object sender, EventArgs e)
        {
            txtUID.Text = userIDHolder;
        }

        private void guna2GradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender,e);
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            txtMirror.Text = txtNotes.Text;
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
