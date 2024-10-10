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
    public partial class frmAddNewProduct : Form
    {
        public frmAddNewProduct()
        {
            InitializeComponent();
            gunaTransition1.AddToQueue(Label2, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label5, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label6, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label19, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label20, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(Label21, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition2.AddToQueue(guna2Button3, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(btnDialog, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(groupBox1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(btnSave, Guna.UI.Animation.AnimateMode.Show, true);


        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

        short avatarPlaceHolderCount = 0;
        string avatarPlaceHolder = "";
        string pCodeHolder = clsKeyGen.getFullItemCode();
        string stCodeHolder = clsKeyGen.getFullSTCode();
              

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            if(txtPName.Text == "")
            {
                MessageBox.Show("Product name field cannot be empty!");
                txtPName.Focus();
                return;
            }

            if (txtPDesc.Text == "")
            {
                MessageBox.Show("Product description field cannot be empty!");
                txtPDesc.Focus();
                return;
            }

            if (txtUP.Text == "")
            {
                MessageBox.Show("Unit Price field cannot be empty!");
                txtUP.Focus();
                return;
            }

            if (txtQ.Text == "")
            {
                MessageBox.Show("Quantity field cannot be empty!");
                txtQ.Focus();
                return;
            }

     if(avatarPlaceHolderCount == 0)
     {
         avatarPlaceHolder = "Untitled";
     }
     else if (avatarPlaceHolderCount == 1)
     {
         avatarPlaceHolder = clsKeyGen.getFullITACode();
     }

     try
     {
         con = new OleDbConnection(connectionString.DBConn);
         con.Open();

         string query = "insert Into dtb_Products_rws(ProductCode,ProductName,ProductDescription,UnitPrice,Avatar) VALUES (@d1,@d2,@d3,@d4,@d5)";
         cmd = new OleDbCommand(query);
         cmd.Connection = con;
         cmd.Parameters.AddWithValue("@d1", pCodeHolder);
         cmd.Parameters.AddWithValue("@d2", txtPName.Text);
         cmd.Parameters.AddWithValue("@d3", txtPDesc.Text);
         cmd.Parameters.AddWithValue("@d4", txtUP.Text);
         cmd.Parameters.AddWithValue("@d5", avatarPlaceHolder);

         cmd.ExecuteNonQuery();

         string query2 = "insert Into dtb_Stock_rws(StockCode,StockDate,Quantity,ProductCode) VALUES (@d1,@d2,@d3,@d4)";
         cmd = new OleDbCommand(query2);
         cmd.Connection = con;
         cmd.Parameters.AddWithValue("@d1", stCodeHolder);
         cmd.Parameters.AddWithValue("@d2", System.DateTime.Now.ToShortDateString());
         cmd.Parameters.AddWithValue("@d3", txtQ.Text);
         cmd.Parameters.AddWithValue("@d4", pCodeHolder);
         cmd.ExecuteNonQuery();

         string query3 = "insert Into dtb_currentStock_rws(StockCode,Quantity,ProductCode) VALUES (@d1,@d2,@d3)";
         cmd = new OleDbCommand(query3);
         cmd.Connection = con;
         cmd.Parameters.AddWithValue("@d1", stCodeHolder);
         cmd.Parameters.AddWithValue("@d2", txtQ.Text);
         cmd.Parameters.AddWithValue("@d3", pCodeHolder);
         cmd.ExecuteNonQuery();


         avatar.Image.Save(clsSysFolder.ifilePath + clsKeyGen.getFullITACode() + ".avt");
         con.Close();
         avatarPlaceHolderCount = 0;

         MessageBox.Show("Done");
     
     }
     catch (Exception ex)
     {
         MessageBox.Show("Could not process request at the time, please try again!");
         return;
     }
     

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "Image File |*.jpg; *.jpeg; *.png";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
       
          avatar.Image = Image.FromFile(openFileDialog1.FileName);
          avatarPlaceHolderCount = 1;
       
        }

        private void gunaGradientButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUP_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender,e);
        }

        private void txtQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender,e);
        }

        private void txtPDesc_TextChanged(object sender, EventArgs e)
        {
            txtMirror.Text = txtPDesc.Text;
        }

        private void frmAddNewProduct_Load(object sender, EventArgs e)
        {
            
            txtCode.Text = pCodeHolder;
            txtSTCode.Text = stCodeHolder;
        }

        private void guna2GradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
