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
    public partial class frmReverseTrans : Form
    {
        public frmReverseTrans()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            gunaTransition1.AddToQueue(groupBox1, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition2.AddToQueue(btnProceed, Guna.UI.Animation.AnimateMode.Show, true);

        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

        List<string> productIDs = new List<string>();
        List<string> productQs = new List<string>();
        List<string> productNames = new List<string>();
        List<string> Prices = new List<string>();
        List<string> totalAmounts = new List<string>();
        List<string> customerIDs = new List<string>();

        private void frmReverseTrans_Load(object sender, EventArgs e)
        {
           

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID From dtb_ProductsSold_rws Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber) + "", con);

            rd = cmd.ExecuteReader();

          while(rd.Read())
            {
                    productIDs.Add(rd[1].ToString());
                    productNames.Add(rd[2].ToString());
                    Prices.Add(rd[3].ToString());
                    productQs.Add(rd[4].ToString());
                    totalAmounts.Add(rd[5].ToString());
                    customerIDs.Add(rd[6].ToString());
             
            }



          con.Close();

            label1.Text = clsBlcProps.InvoiceNumber;
        }

        private void reversalInfoRetrieval()
        {

            #region InvoiceDetailFields
            string theInvoiceNum = "";
            string theInvoiceDate = "";
            string theSubtotal = "";
            string theVATPer = "";
            string theDiscountPer = "";
            string theDiscountAmt = "";
            string theTotalPayment = "";
            string thePaymentType = "";
            string theCustomerID = "";
            string theAmountPaid = "";
            string theVATAmt = "";
            string theStatus = "";
            string thePaymentDue = "";
            string theDueDate = "";
            string theOperatorName = "";
            string theTransTime = "";
            string theOperatorID = "";
            string theReversalDate = tm.Text;
            string theReversalApprover = clsAuthenticity.userID;
            string theReversalTime = DateTime.Now.ToShortTimeString();
            #endregion

            #region retrieveFromInvoiceInfo
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select * From dtb_InvoiceInfo_rws Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber) + "", con);

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    theInvoiceNum = rd[0].ToString();
                    theInvoiceDate = rd[1].ToString();
                    theSubtotal = rd[2].ToString();
                    theVATPer = rd[3].ToString();
                    theDiscountPer = rd[4].ToString();
                    theDiscountAmt = rd[5].ToString();
                    theTotalPayment = rd[6].ToString();
                    thePaymentType = rd[7].ToString();
                    theCustomerID = rd[8].ToString();
                    theStatus = rd[9].ToString();
                    theAmountPaid = rd[10].ToString();
                    theVATAmt = rd[11].ToString();
                    thePaymentDue = rd[12].ToString();
                    theDueDate = rd[13].ToString();
                    theOperatorName = rd[14].ToString();
                    theTransTime = rd[15].ToString();
                    theOperatorID = rd[16].ToString();


                }

                con.Close();

            }
            catch (Exception exGET)
            {

                MessageBox.Show("Something went wrong! Issue key: 0xGET1");
                return;
            }
            #endregion
        

            #region feedToReversals
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Insert Into dtb_Reversals_rws(InvoiceNo,InvoiceDate,SubTotal,VATPer,DiscountPer,DiscountAmount,TotalPayment,PaymentType,CustomerID,Status,AmountPaid,VATAmount,PaymentDue,DueDate,OperatorName,TransTime,OperatorID,ReversalDate,ReversedBy,ReversalTime) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@15,@16,@17,@18,@19,@20)", con);
                cmd.Parameters.AddWithValue("@d1", theInvoiceNum);
                cmd.Parameters.AddWithValue("@d2", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@d3", theSubtotal);
                cmd.Parameters.AddWithValue("@d4", theVATPer);
                cmd.Parameters.AddWithValue("@d5", theDiscountPer);
                cmd.Parameters.AddWithValue("@d6", theDiscountAmt);
                cmd.Parameters.AddWithValue("@d7", theTotalPayment);
                cmd.Parameters.AddWithValue("@d8", thePaymentType);
                cmd.Parameters.AddWithValue("@d9", theCustomerID);
                cmd.Parameters.AddWithValue("@d10", theStatus);
                cmd.Parameters.AddWithValue("@d11", theAmountPaid);
                cmd.Parameters.AddWithValue("@d12", theVATAmt);
                cmd.Parameters.AddWithValue("@d13", thePaymentDue);
                cmd.Parameters.AddWithValue("@d14", theDueDate);
                cmd.Parameters.AddWithValue("@d15", theOperatorName);
                cmd.Parameters.AddWithValue("@d16", theTransTime);
                cmd.Parameters.AddWithValue("@d17", theOperatorID);
                cmd.Parameters.AddWithValue("@d18", theReversalDate);
                cmd.Parameters.AddWithValue("@d19", theReversalApprover);
                cmd.Parameters.AddWithValue("@d20", theReversalTime);
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception exFID)
            {

               MessageBox.Show("Something went wrong! Issue key: 0xFID1");
               return;
             
            }
            #endregion

       

            #region feedToReversalDetails
            try
            {
                for (int i = 0; i <= productIDs.Count - 1; i++)
                {
                    con = new OleDbConnection(connectionString.DBConn);

                    string query2 = "insert Into dtb_ReversalDetails_rws(InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID) VALUES (@d1,@d3,@d4,@d5,@d6,@d7,@d8)";
                    cmd = new OleDbCommand(query2);
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@d1", theInvoiceNum);
                    cmd.Parameters.AddWithValue("@d3", productIDs[i].ToString());
                    cmd.Parameters.AddWithValue("@d4", productNames[i].ToString());
                    cmd.Parameters.AddWithValue("@d5", Prices[i].ToString());
                    cmd.Parameters.AddWithValue("@d6", productQs[i].ToString());
                    cmd.Parameters.AddWithValue("@d7", totalAmounts[i].ToString());
                    cmd.Parameters.AddWithValue("@d8", customerIDs[i].ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception exFIDRD)
            {

                MessageBox.Show("An error occurred. Issue key: 0xFIDRD1");
                return;
            }
            #endregion
         

          
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            reversalInfoRetrieval();

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            for (int i = 0; i <= productIDs.Count - 1;i++ )
            {
                cmd = new OleDbCommand("Update dtb_currentStock_rws Set Quantity = Quantity + " + productQs[i] + " Where ProductCode = '" + productIDs[i] + "'", con);
                cmd.ExecuteNonQuery();
            }

            cmd = new OleDbCommand("Delete From dtb_InvoiceInfo_rws Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber),con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("Delete From dtb_ProductsSold_rws Where InvoiceNo = " + Convert.ToInt32(clsBlcProps.InvoiceNumber), con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Transaction reversal complete!");
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
         tm.Text = dateTimePicker1.Text;
        }
    }
}
