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
    public partial class frmReversedTransactions : Form
    {
        public frmReversedTransactions()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

        }

        #region databaseObjects
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;
        #endregion


        #region TransMoreInfo
       public static string theReversalDate = "";
       public static string theReversalDate2 = "";
       public static string theReversalDate3 = "";
        public static string theReversalApprover = "";
        public static string theReversalApprover2 = "";
        public static string theReversalApprover3 = "";
        public static  string theReversalTime = "";
        public static string theReversalTime2 = "";
        public static string theReversalTime3 = "";


        public static short parameta = 0;
        #endregion


        private void frmReversedTransactions_Load(object sender, EventArgs e)
        {

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID From dtb_ReversalDetails_rws", con);

            ds = new DataSet();

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);


            guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;
            guna2DataGridView2.DataSource = ds.Tables[0].DefaultView;
            guna2DataGridView3.DataSource = ds.Tables[0].DefaultView;

            con.Close();



            txtInvoiceNum.Focus();


            TransactionInfo1();
            TransactionInfo2();
            TransactionInfo3();
            getCustomerInfo1();
            getCustomerInfo2();
            getCustomerInfo3();


            getApproverInfo1();
            getApproverInfo2();
            getApproverInfo3();

            parameta = 1;
        }

        private void getCustomerInfo1()
        {
            try
            {
                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("Select CustomerID,CName From dtb_regCustomers_rws Where CustomerID = '" + guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString() + "'", con);
                    rd = cmd.ExecuteReader();

                    if (rd.Read() == true)
                    {

                        txtCName.Text = rd[1].ToString();

                    }
                    else
                    {
                        txtCName.Text = "n/a";
                    }

                    rd.Close();
                    con.Close();
                }
                catch (ArgumentOutOfRangeException exARG1)
                {
                     txtCName.Clear();
                }

            }
            catch (Exception ex)
            {
               
                return;
            }

        }

        private void getCustomerInfo2()
        {
            try
            {

                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("Select CustomerID,CName From dtb_regCustomers_rws Where CustomerID = '" + guna2DataGridView2.SelectedRows[0].Cells[6].Value.ToString() + "'", con);
                    rd = cmd.ExecuteReader();

                    if (rd.Read() == true)
                    {

                        txtCName2.Text = rd[1].ToString();

                    }
                    else
                    {
                        txtCName2.Text = "n/a";
                    }

                    rd.Close();
                    con.Close();

                }
                catch (ArgumentOutOfRangeException exARG2)
                {
                    txtCName2.Clear();
                }

             
            }
            catch (Exception ex)
            {

                return;
            }

        }

        private void getCustomerInfo3()
        {
            try
            {

                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("Select CustomerID,CName From dtb_regCustomers_rws Where CustomerID = '" + guna2DataGridView3.SelectedRows[0].Cells[6].Value.ToString() + "'", con);
                    rd = cmd.ExecuteReader();

                    if (rd.Read() == true)
                    {

                        txtCName3.Text = rd[1].ToString();

                    }
                    else
                    {
                        txtCName3.Text = "n/a";
                    }

                    rd.Close();
                    con.Close();
                }
                catch (ArgumentOutOfRangeException exARG3)
                {

                    txtCName3.Clear();
                }
               

            }
            catch (Exception ex)
            {

                return;
            }

        }


        private void getApproverInfo1()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select UID,Username From dtb_Login_rws Where UID = '" + txtApproverID.Text.Trim() + "'", con);
                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {

                theReversalApprover = rd[1].ToString();

                }
              

                rd.Close();
                con.Close();

            }
            catch (Exception ex)
            {
    
                return;
            }

        }

        private void getApproverInfo2()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select UID,Username From dtb_Login_rws Where UID = '" + txtApproverID2.Text.Trim() + "'", con);
                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {

                    theReversalApprover2 = rd[1].ToString();

                }


                rd.Close();
                con.Close();

            }
            catch (Exception ex)
            {
          
                return;
            }

        }

        private void getApproverInfo3()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select UID,Username From dtb_Login_rws Where UID = '" + txtApproverID3.Text.Trim() + "'", con);
                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {

                    theReversalApprover3 = rd[1].ToString();

                }


                rd.Close();
                con.Close();

            }
            catch (Exception ex)
            {
              
                return;
            }

        }



        private void txtInvoiceNum_TextChanged(object sender, EventArgs e)
        {
            searchInvoiceNumber();
        }

        private void searchInvoiceNumber()
        {
            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID From dtb_ReversalDetails_rws Where InvoiceNo Like '%" + txtInvoiceNum.Text + "%'", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);

                guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;

                con.Close();
            }
            catch (Exception ex)
            {
              
                return;
            }

        }

        private void TransactionInfo1()
        {
        

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceDate,Subtotal,VATPer,DiscountPer,DiscountAmount,TotalPayment,PaymentType,CustomerID,Status,AmountPaid,VATAmount,PaymentDue,DueDate,OperatorName,TransTime,OperatorID,ReversalDate,ReversedBy,ReversalTime,InvoiceNo From dtb_Reversals_rws Where InvoiceNo = " + guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {

                    txtDT.Text = rd[0].ToString();
                    txtTotP.Text = rd[5].ToString();
                    txtPT.Text = rd[6].ToString();
                    label6.Text = rd[14].ToString();
                    txtATT.Text = rd[13].ToString();
                   txtStatus.Text = rd[8].ToString();
                    txtVAT.Text = rd[2].ToString();
                    txtDiscount.Text = rd[4].ToString();
                    txtAP.Text = rd[9].ToString();
                    txtAD.Text = rd[11].ToString();
                    txtDiscPerc.Text = rd[3].ToString();
                    txtDueDT.Text = rd[12].ToString();
                    theReversalDate = rd[16].ToString();
              txtApproverID.Text = rd[17].ToString();
                    theReversalTime = rd[18].ToString ();
                   txtPID.Text = rd[19].ToString ();
                    txtCName.Text = rd[7].ToString ();


         }
            }
            catch (Exception ex)
            {

                return;
            }

        }



        private void TransactionInfo2()
        {


            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceDate,Subtotal,VATPer,DiscountPer,DiscountAmount,TotalPayment,PaymentType,CustomerID,Status,AmountPaid,VATAmount,PaymentDue,DueDate,OperatorName,TransTime,OperatorID,ReversalDate,ReversedBy,ReversalTime,InvoiceNo From dtb_Reversals_rws Where InvoiceNo = " + guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {

                    txtDT2.Text = rd[0].ToString();
                    txtTotP2.Text = rd[5].ToString();
                    txtPT2.Text = rd[6].ToString();
                    txtATT2.Text = rd[13].ToString();
                    label29.Text = rd[14].ToString();
                    txtStatus2.Text = rd[8].ToString();
                    txtVAT2.Text = rd[2].ToString();
                    txtDiscount2.Text = rd[4].ToString();
                    txtAP2.Text = rd[9].ToString();
                    txtAD2.Text = rd[11].ToString();
                    txtDiscPerc2.Text = rd[3].ToString();
                    txtDueDT2.Text = rd[12].ToString();
                    theReversalDate2 = rd[16].ToString();
                    txtApproverID2.Text = rd[17].ToString();
                    theReversalTime2 = rd[18].ToString();
                    txtPID.Text = rd[19].ToString();
                    txtCName2.Text = rd[7].ToString();


                }
            }
            catch (Exception ex)
            {

                return;
            }

        }

        private void TransactionInfo3()
        {


            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceDate,Subtotal,VATPer,DiscountPer,DiscountAmount,TotalPayment,PaymentType,CustomerID,Status,AmountPaid,VATAmount,PaymentDue,DueDate,OperatorName,TransTime,OperatorID,ReversalDate,ReversedBy,ReversalTime,InvoiceNo From dtb_Reversals_rws Where InvoiceNo = " + guna2DataGridView3.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {

                    txtDT3.Text = rd[0].ToString();
                    txtTotP3.Text = rd[5].ToString();
                    txtPT3.Text = rd[6].ToString();
                    label16.Text = rd[14].ToString();
                    txtATT3.Text = rd[13].ToString();
                    txtStatus3.Text = rd[8].ToString();
                    txtVAT3.Text = rd[2].ToString();
                    txtDiscount3.Text = rd[4].ToString();
                    txtAP3.Text = rd[9].ToString();
                    txtAD3.Text = rd[11].ToString();
                    txtDiscPerc3.Text = rd[3].ToString();
                    txtDueDT3.Text = rd[12].ToString();
                    theReversalDate3 = rd[16].ToString();
                    txtApproverID3.Text = rd[17].ToString();
                    theReversalTime3 = rd[18].ToString();
                    txtPID.Text = rd[19].ToString();
                    txtCName3.Text = rd[7].ToString();


                }
            }
            catch (Exception ex)
            {

                return;
            }

        }

        private void clearFields1()
        {

            txtDT.Clear();
            txtTotP.Clear();
            txtPT.Clear();
            label6.Text = "--:--";
            txtATT.Clear();
            txtStatus.Clear();
            txtVAT.Clear();
            txtDiscount.Clear();
            txtAP.Clear();
            txtAD.Clear();
            txtDiscPerc.Clear();
            txtDueDT.Clear();
            theReversalDate = "";
            txtApproverID.Clear();
            theReversalTime = "";
            txtPID.Clear();
            txtCName.Clear();

        }


        private void clearFields2()
        {

            txtDT2.Clear();
            txtTotP2.Clear();
            txtPT2.Clear();
            label29.Text = "--:--";
            txtATT2.Clear();
            txtStatus2.Clear();
            txtVAT2.Clear();
            txtDiscount2.Clear();
            txtAP2.Clear();
            txtAD2.Clear();
            txtDiscPerc2.Clear();
            txtDueDT2.Clear();
            theReversalDate2 = "";
            txtApproverID2.Clear();
            theReversalTime2 = "";
            txtPID2.Clear();
            txtCName2.Clear();

        }


        private void clearFields3()
        {

            txtDT3.Clear();
            txtTotP3.Clear();
            txtPT3.Clear();
            label16.Text = "--:--";
            txtATT3.Clear();
            txtStatus3.Clear();
            txtVAT3.Clear();
            txtDiscount3.Clear();
            txtAP3.Clear();
            txtAD3.Clear();
            txtDiscPerc3.Clear();
            txtDueDT3.Clear();
            theReversalDate3 = "";
            txtApproverID3.Clear();
            theReversalTime3 = "";
            txtPID3.Clear();
            txtCName3.Clear();

        }


        private void searchProductCode()
        {
            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID From dtb_ReversalDetails_rws Where ProductCode Like '%" + txtPCode.Text + "%'", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);

                guna2DataGridView2.DataSource = ds.Tables[0].DefaultView;

                con.Close();
            }
            catch (Exception ex)
            {
        
                return;
            }

        }

        private void txtInvoiceNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender,e);
        }

        private void txtIN_TextChanged(object sender, EventArgs e)
        {
            searchProductCode();
        }

        private void guna2DataGridView2_Click(object sender, EventArgs e)
        {
            TransactionInfo2();
            getCustomerInfo2();
            getApproverInfo2();
            parameta = 2;
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if(parameta == 0)
            {
                MessageBox.Show("Select a record first!");
                return;
            }

            clsAuthenticity.getPage("",this, new frmMoreTransInfo(parameta));
        }

        private void guna2DataGridView1_Click(object sender, EventArgs e)
        {
            TransactionInfo1();
            getCustomerInfo1();
            getApproverInfo1();
            parameta = 1;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (guna2DateTimePicker4.Value > guna2DateTimePicker3.Value)
            {
                MessageBox.Show("Due date cannot be a past date!");
                guna2DateTimePicker4.Value = System.DateTime.Now;
                guna2DateTimePicker3.Value = System.DateTime.Now;


            }

            else
            {
                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("Select  dtb_ReversalDetails_rws.InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,dtb_Reversals_rws.CustomerID,InvoiceDate From dtb_ReversalDetails_rws,dtb_Reversals_rws Where dtb_ReversalDetails_rws.InvoiceNo=dtb_Reversals_rws.InvoiceNo And InvoiceDate Between '" + guna2DateTimePicker4.Value + "' And '" + guna2DateTimePicker3.Value + "'", con);

                    ds = new DataSet();

                    adp = new OleDbDataAdapter(cmd);
                    adp.Fill(ds);

                    guna2DataGridView3.DataSource = ds.Tables[0].DefaultView;

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            }

        }

        private void guna2DataGridView3_Click(object sender, EventArgs e)
        {
            TransactionInfo3();
            getCustomerInfo3();
            getApproverInfo3();
            parameta = 3;
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    TransactionInfo1();
                    getCustomerInfo1();
                    getApproverInfo1();
                    parameta = 1;
                }

                if (tabControl1.SelectedTab == tabControl1.TabPages[1])
                {
                    TransactionInfo2();
                    getCustomerInfo2();
                    getApproverInfo2();
                    parameta = 2;
                }

                if (tabControl1.SelectedTab == tabControl1.TabPages[2])
                {
                    TransactionInfo3();
                    getCustomerInfo3();
                    getApproverInfo3();
                    parameta = 3;
                }
            }
            catch (Exception exTAB)
            {
                parameta = 0;
                return;
            }
          
        }

    }
}
