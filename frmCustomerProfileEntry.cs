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
    public partial class frmCustomerProfileEntry : Form
    {
        public frmCustomerProfileEntry()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;
        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader dr;
        DataSet ds;

        short avatarPlaceHolderCount = 0;
        string avatarPlaceHolder = "";
        string cidHolder = clsKeyGen.getFullCustomerCode();

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            clsConfirmClose.cmdClose(this);
        }

        private void frmCustomerProfileEntry_Load(object sender, EventArgs e)
        {
         
 



     



        }

        private void frmCustomerProfileEntry_Activated(object sender, EventArgs e)
        {
            txtCustomerName.Focus();

        }

        private void frmCustomerProfileEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }

        private void frmCustomerProfileEntry_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Customer Name field cannot be blank!");
                txtCustomerName.Focus();
                return;
            }

            if (txtAddress.Text == "")
            {
                MessageBox.Show("Customer Address field cannot be blank!");
                txtAddress.Focus();
                return;
            }

            if (txtCty.Text == "")
            {
                MessageBox.Show("Customer City field cannot be blank!");
                txtCty.Focus();
                return;
            }

            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Customer Official Cell field cannot be blank!");
                txtContactNo.Focus();
                return;
            }

            if (txtContactNo1.Text == "")
            {
                MessageBox.Show("Customer Alternative Cell field cannot be blank!");
                txtContactNo1.Focus();
                return;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Customer Email Address field cannot be blank!");
                txtEmail.Focus();
                return;
            }

            if (txtNotes.Text == "")
            {
                MessageBox.Show("Customer Notes field cannot be blank!");
                txtNotes.Focus();
                return;
            }


            if (avatarPlaceHolderCount == 0)
            {
                avatarPlaceHolder = "Untitled";
            }
            else if (avatarPlaceHolderCount == 1)
            {
                avatarPlaceHolder = clsKeyGen.getFullCACode();
                
            }

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Insert Into dtb_regCustomers_rws (CustomerID,CName,Address,City,Phone1,Phone2,Email,Notes,Avatar) VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9)", con);
                cmd.Parameters.AddWithValue("@v1", cidHolder);
                cmd.Parameters.AddWithValue("@v2", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@v3", txtAddress.Text);
                cmd.Parameters.AddWithValue("@v4", txtCty.Text);
                cmd.Parameters.AddWithValue("@v5", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@v6", txtContactNo1.Text);
                cmd.Parameters.AddWithValue("@v7", txtEmail.Text);
                cmd.Parameters.AddWithValue("@v8", txtNotes.Text);
                cmd.Parameters.AddWithValue("@v9", cidHolder);
                cmd.ExecuteNonQuery();

                avatar.Image.Save(clsSysFolder.cfilePath + clsKeyGen.getFullCACode() + ".avt");

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not process request at the time, please try again!");
                return;
            }
         

        }

        private void getCustomerImage()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File |*.jpg; *.jpeg; *.png";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }
    }
}
