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
    public partial class frmStockMgmtFP : Form
    {
        public frmStockMgmtFP()
        {
            InitializeComponent();

            #region Anime
                   gunaTransition1.AddToQueue(txtPName, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(txtQ, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(txtPrice, Guna.UI.Animation.AnimateMode.Show, true);

                   gunaTransition2.AddToQueue(txtDesc, Guna.UI.Animation.AnimateMode.Show, true);
              

            #endregion

        }

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

        private void btnUInfo_Click(object sender, EventArgs e)
        {
            updateProduct();
            frmStockMgmt frm = new frmStockMgmt();
           frm.refreshPage();
           this.Close();
        }

        private void updateProduct()
        {
            if(txtPName2.Text == "")
            {
                MessageBox.Show("Any empty field has been detected!");
                txtPName2.Focus();
                return;
            }

            if (txtQ2.Text == "")
            {
                MessageBox.Show("Any empty field has been detected!");
                txtQ2.Focus();
                return;
            }

            if (txtDesc2.Text == "")
            {
                MessageBox.Show("Any empty field has been detected!");
               txtDesc2.Focus();
                return;
            }

            if (txtPrice2.Text == "")
            {
                MessageBox.Show("Any empty field has been detected!");
                txtPrice2.Focus();
                return;
            }

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();


                string query = "UPDATE dtb_Products_rws SET ProductName = @d1,ProductDescription = @d2, UnitPrice = @d3 WHERE ProductCode='" + txtCode.Text + "'";
                cmd = new OleDbCommand(query);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtPName2.Text);
                cmd.Parameters.AddWithValue("@d2", txtDesc2.Text);
                cmd.Parameters.AddWithValue("@d3", txtPrice2.Text);

 
                cmd.ExecuteNonQuery();


                string query2 = "UPDATE dtb_currentStock_rws SET Quantity = @q1 Where ProductCode = '" + txtCode.Text + "'";
                cmd = new OleDbCommand(query2);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@q1", txtQ2.Text);
                cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
    
          //      clsSystemTray.notifier("Detailes Updated!");
                MessageBox.Show("Details Updated!");
                this.Close();
            }
            catch (Exception exUPD)
            {

                MessageBox.Show("Could not perform the requested operation. Issue key: 0x1UPD");
                return;
            }

        }

        private void frmStockMgmtFP_Load(object sender, EventArgs e)
        {
            txtCode.Text = frmStockMgmt.PCode;
            txtDesc.Text = frmStockMgmt.PDescription;
            txtPName.Text = frmStockMgmt.PName;
            txtPrice.Text = frmStockMgmt.PPrice;
            txtQ.Text = frmStockMgmt.PQuantity;

            txtPName2.Text = txtPName.Text;
            txtDesc2.Text = txtDesc.Text;
            txtPrice2.Text = txtPrice.Text;
            txtQ2.Text = txtQ.Text;

            txtPName2.Select()
; txtPName2.Focus();
        }

        private void txtQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender,e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender,e);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if(txtPrice.Text == ".")
            {
                txtPrice.Clear();
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            updateProduct();
        }

        private void frmStockMgmtFP_Resize(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
