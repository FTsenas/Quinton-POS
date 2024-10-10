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


namespace QuintonPOS
{
    public partial class frmSupplierProfileEntry : Form
    {
        public frmSupplierProfileEntry()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;
        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader dr;

    
        string avatarPlaceHolder = "";
        string previousAvatar = "";
       bool deliveryYesNo;
       string supIDHolder = clsKeyGen.getFullSupplierCode();


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            clsConfirmClose.cmdClose(this);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmSupplierProfileEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
 
        }

  
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            avatar.Image = Image.FromFile(openFileDialog1.FileName);
            previousAvatar = Path.GetFileNameWithoutExtension(openFileDialog1.FileName); 
       
        }

        private void txtDelivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender,e);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(txtSupName.Text == "")
            {
                MessageBox.Show("Supplier Name field cannot be blank!");
                txtSupName.Focus();
                return;
            }

            if (txtAddress.Text == "")
            {
                MessageBox.Show("Address field cannot be blank!");
                txtAddress.Focus();
                return;
            }

            if (txtCty.Text == "")
            {
                MessageBox.Show("City field cannot be blank!");
                txtCty.Focus();
                return;
            }

            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Contact Number field cannot be blank!");
                txtContactNo.Focus();
                return;
            }

            if (txtContactNo1.Text == "")
            {
                MessageBox.Show("Contact nUmber field cannot be blank!");
                txtContactNo1.Focus();
                return;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email field cannot be blank!");
                txtEmail.Focus();
                return;
            }

            if(txtDelivery.Text == "")
            {
                txtDelivery.Text = "0.00";
            }

            if (txtNotes.Text == "")
            {
                MessageBox.Show("Notes field cannot be blank!");
                txtNotes.Focus();
                return;
            }


            if (avatarPlaceHolder != "Untitled")
            {
                previousAvatar = clsKeyGen.getFullSACode();
                avatar.Image.Save(clsSysFolder.sfilePath + previousAvatar + ".avt");
                clsCleanUps.addSupImageToGarbageList(avatarPlaceHolder);
            }
            else
            {
                if (previousAvatar == avatarPlaceHolder)
                {
                    MessageBox.Show("Item details Updated except for the Avatar since it was never reassigned!");
                }
                else
                {
                    previousAvatar = clsKeyGen.getFullSACode();
                    avatar.Image.Save(clsSysFolder.sfilePath + previousAvatar + ".avt");
                }


            }

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Insert Into dtb_regSuppliers_rws (SupplierID,SupplierName,Address,City,Contact1,Contact2,Email,Notes,DeliveryAmount,Avatar) VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@10)", con);
                cmd.Parameters.AddWithValue("@v1", txtSupID.Text);
                cmd.Parameters.AddWithValue("@v2", txtSupName.Text);
                cmd.Parameters.AddWithValue("@v3", txtAddress.Text);
                cmd.Parameters.AddWithValue("@v4", txtCty.Text);
                cmd.Parameters.AddWithValue("@v5", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@v6", txtContactNo1.Text);
                cmd.Parameters.AddWithValue("@v7", txtEmail.Text);
                cmd.Parameters.AddWithValue("@v8", txtNotes.Text);
                cmd.Parameters.AddWithValue("@v9", txtDelivery.Text);
                cmd.Parameters.AddWithValue("@v10", previousAvatar);
                cmd.ExecuteNonQuery();


                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                MessageBox.Show("" + txtSupName.Text + " has been added to Suppliers.","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                clsSystemTray.notifier("Details Updated, outdated files have been added to Garbage List");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not process request at the time, please try again!");
                return;
            }
         
            }
               
      
        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender, e);

        }

        private void txtContactNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender, e);

        }

        private void txtDelivery_MouseClick(object sender, MouseEventArgs e)
        {
            txtDelivery.Clear();
        }

        private void txtDelivery_Click(object sender, EventArgs e)
        {

            txtDelivery.Clear();
        }

        private void frmSupplierProfileEntry_Load(object sender, EventArgs e)
        {

        }

        private void frmSupplierProfileEntry_Load_1(object sender, EventArgs e)
        {
            txtSupID.Text = supIDHolder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File |*.jpg; *.jpeg; *.png";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

        }

     
    }
}
