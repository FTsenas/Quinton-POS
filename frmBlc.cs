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
    public partial class frmArrear : Form
    {
        public frmArrear()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            gunaTransition1.AddToQueue(txtAP, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtAD, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtDA, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtTotal, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtTP, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition2.AddToQueue(label1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label2, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label3, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label4, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label5, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition3.AddToQueue(btnSave, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(btnVAR, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(btnDeposit, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(btnETE, Guna.UI.Animation.AnimateMode.Show, true);


        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;


        private void frmBlc_Load(object sender, EventArgs e)
        {
           txtAD.Text = clsBlcProps.PaymentDue;
           txtAP.Text = clsBlcProps.AmountPaid;
           txtTP.Text = clsBlcProps.TotalPayment;

           txtTotal.Focus();
        }

        private void txtDA_KeyPress(object sender, KeyPressEventArgs e)
        {
    
        }

        private void txtTotD_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
     
            try
            {
                double result = 0.00;

                result = Convert.ToDouble(txtAP.Text) + Convert.ToDouble(txtDA.Text);

                if (result > Convert.ToDouble(txtTP.Text))
                {
                    if (MessageBox.Show("The deposit provided exceeds the amount required to settle the payment, do you wish to ignore this issue?", "QPOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        txtTotal.Text = result.ToString(); 

                    }

                }
                else if (result <= Convert.ToDouble(txtTP.Text))
                {
                    txtTotal.Text = result.ToString();

                }
                else
                {
                    result = 0.00;
                    txtTP.Text = "0";
                }

            }
            catch (Exception ex)
            {
       
                return;
            }
       
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double defaultAmt = 0.00;
            double totalP = Convert.ToDouble(clsBlcProps.AmountPaid) + Convert.ToDouble(txtDA.Text);
            double totalDeduct = Convert.ToDouble(clsBlcProps.TotalPayment) - Convert.ToDouble(txtTotal.Text);

            if (Convert.ToDouble(txtTotal.Text) >= Convert.ToDouble(txtTP.Text))
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Update dtb_InvoiceInfo_rws Set PaymentDue = " + totalDeduct + " Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber) + "", con);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("Update dtb_InvoiceInfo_rws Set AmountPaid = '" + totalP + "' Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber) + "", con);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("Update dtb_InvoiceInfo_rws Set Status = '" + "Balanced" + "' Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber) + "", con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("" + clsBlcProps.InvoiceNumber + "'s is now fully paid!");
                this.Close();
               
            }


            if (Convert.ToDouble(txtTotal.Text) < Convert.ToDouble(txtTP.Text))
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Update dtb_InvoiceInfo_rws Set PaymentDue = " + totalDeduct + " Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber) + "", con);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("Update dtb_InvoiceInfo_rws Set AmountPaid = '" + totalP + "' Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber) + "", con);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("Update dtb_InvoiceInfo_rws Set Status = '" + "Pending" + "' Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber) + "", con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Invoice: " + clsBlcProps.InvoiceNumber + "'s pending balance is now " + totalDeduct);
                this.Close();
            }

       
        }

        private void btnVAR_Click(object sender, EventArgs e)
        {

        }

        private void txtDA_TextChanged(object sender, EventArgs e)
        {
            if(txtDA.Text == ".")
            {
                txtDA.Clear();
            }
        }
    }
}
