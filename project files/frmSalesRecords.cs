using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using ipt_val_fl;
using System.Diagnostics;
using System.IO;


namespace QuintonPOS
{
    public partial class frmSalesRecords : Form
    {
        public frmSalesRecords()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            gunaTransition1.AddToQueue(label4, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label7, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label39, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label38, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label37, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label36, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label35, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label34, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label30, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label33, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label32, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label10, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(guna2DataGridView1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label9, Guna.UI.Animation.AnimateMode.Show, true);


            gunaTransition2.AddToQueue(txtProductCode, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtCName, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtDiscount, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtDT, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtTotP, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtVAT, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtPT, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtIN, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtDueDT, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtDiscPerc, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtAP, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtAD, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(textBox11, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(guna2Button3, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition3.AddToQueue(btnBlcMgmt, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(btnReverseTrans, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(btnVReport, Guna.UI.Animation.AnimateMode.Show, true);



        }

        #region databaseObjects
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;
        #endregion
      

        int invoiceHolder1 = 0;
        int invoiceHolder2 = 0;
        int invoiceHolder3 = 0;


        private void frmSalesRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAuthenticity.showRunningForm();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (txtProductCode.Text != "")
            {
                searchProductCode();
            } 
              else
            {
                MessageBox.Show("No Product Code Provided!");
                return;

            }
         
        }

        private void searchProductCode()
        {
            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID From dtb_ProductsSold_rws Where ProductCode Like '%" + txtProductCode.Text + "%'", con);

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

    

        private void frmSalesRecords_Load(object sender, EventArgs e)
        {
          

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID From dtb_ProductsSold_rws",con);
             
            ds = new DataSet();

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);

           
            guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;
            guna2DataGridView2.DataSource = ds.Tables[0].DefaultView;
            guna2DataGridView3.DataSource = ds.Tables[0].DefaultView;

            con.Close();



            txtProductCode.Focus();


            try
            {
                invoiceHolder1 = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
                invoiceHolder2 = Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells[0].Value);
                invoiceHolder3 = Convert.ToInt32(guna2DataGridView3.SelectedRows[0].Cells[0].Value);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No Entries have been found in the table!");
                return;
            }

            InvoiceInfo1();
            InvoiceInfo2();
            InvoiceInfo3();

            getCustomerInfo1();
            getCustomerInfo2();
            getCustomerInfo3();



        }

      

        private void getCustomerInfo1()
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
                    txtCName.Clear();
                }

                rd.Close();
                con.Close();

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
                    txtCName2.Clear();
                }

                rd.Close();
                con.Close();

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
                    txtCName3.Clear();
                }

                rd.Close();
                con.Close();

            }
            catch (Exception ex)
            {

                return;
            }

        }

                private void InvoiceInfo1()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceDate,TotalPayment,PaymentType,OperatorName,TransTime,VATPer,DiscountAmount,AmountPaid,PaymentDue,Status,DiscountPer,DueDate,OperatorID From dtb_InvoiceInfo_rws Where InvoiceNo = " + guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {

                    txtDT.Text = rd[0].ToString();
                    txtTotP.Text = rd[1].ToString();
                    txtPT.Text = rd[2].ToString();
                    txtATT.Text = rd[3].ToString();
                    label6.Text = rd[4].ToString();
                    txtVAT.Text = rd[5].ToString();
                    txtDiscount.Text = rd[6].ToString();
                    txtAP.Text = rd[7].ToString();
                    txtAD.Text = rd[8].ToString();
                    label40.Text = rd[9].ToString();
                    txtDiscPerc.Text = rd[10].ToString();
                    txtDueDT.Text = rd[11].ToString();


                    if (label40.Text == "Balanced")
                    {
                        label40.ForeColor = Color.Lime;
                    }
                    else
                    {
                        label40.ForeColor = Color.Red;
                    }

                }
            }
            catch (Exception ex)
            {

                return;
            }
              
            }


        /// <summary>
        /// 
        /// TAB 2 INVOICEINFO RETRIEVAL
        /// 
        /// </summary>
        private void InvoiceInfo2()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceDate,TotalPayment,PaymentType,OperatorName,TransTime,VATPer,DiscountAmount,AmountPaid,PaymentDue,Status,DiscountPer,DueDate,OperatorID From dtb_InvoiceInfo_rws Where InvoiceNo = " + guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();


            
                    if (rd.Read() == true)
                    {

                        txtDT2.Text = rd[0].ToString();
                        txtTotP2.Text = rd[1].ToString();
                        txtPT2.Text = rd[2].ToString();
                        txtATT2.Text = rd[3].ToString();
                        label29.Text = rd[4].ToString();
                    txtVAT2.Text = rd[5].ToString();
                        txtDiscount2.Text = rd[6].ToString();
                        txtAP2.Text = rd[7].ToString();
                        txtAD2.Text = rd[8].ToString();
                       label26.Text = rd[9].ToString();
                       txtDiscPerc2.Text = rd[10].ToString();
                       txtDueDT2.Text = rd[11].ToString();


                        if(label26.Text == "Balanced")
                        {
                            label26.ForeColor = Color.Lime;
                        } else
                        {
                           label26.ForeColor = Color.Red;
                        }
        
                }
          

                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                return;

            }

        }

        private void InvoiceInfo3()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceDate,TotalPayment,PaymentType,OperatorName,TransTime,VATPer,DiscountAmount,AmountPaid,PaymentDue,Status,DiscountPer,DueDate,OperatorID From dtb_InvoiceInfo_rws Where InvoiceNo = " + guna2DataGridView3.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {

                    txtDT3.Text = rd[0].ToString();
                    txtTotP3.Text = rd[1].ToString();
                    txtPT3.Text = rd[2].ToString();
                    txtATT3.Text = rd[3].ToString();
                    label16.Text = rd[4].ToString();
                    txtVAT3.Text = rd[5].ToString();
                    txtDiscount3.Text = rd[6].ToString();
                    txtAP3.Text = rd[7].ToString();
                    txtAD3.Text = rd[8].ToString();
                    label51.Text = rd[9].ToString();
                    txtDiscPerc3.Text = rd[10].ToString();
                    txtDueDT3.Text = rd[11].ToString();


                    if (label51.Text == "Balanced")
                    {
                        label51.ForeColor = Color.Lime;
                    }
                    else
                    {
                        label51.ForeColor = Color.Red;
                    }

                }


                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                return;

            }

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (guna2DateTimePicker4.Value > guna2DateTimePicker3.Value)
            {
                MessageBox.Show("Due date cannot be a past date!");
                guna2DateTimePicker4.Value =System.DateTime.Now;
                guna2DateTimePicker3.Value = System.DateTime.Now;
  

            } 
            
            else

            {
                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("Select  dtb_ProductsSold_rws.InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,dtb_InvoiceInfo_rws.CustomerID,InvoiceDate From dtb_ProductsSold_rws,dtb_InvoiceInfo_rws Where dtb_ProductsSold_rws.InvoiceNo=dtb_InvoiceInfo_rws.InvoiceNo And InvoiceDate Between '" + guna2DateTimePicker4.Value + "' And '" + guna2DateTimePicker3.Value + "'", con);

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

          private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }


    
        private void searchInvoiceNo()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID From dtb_ProductsSold_rws Where InvoiceNo Like '%" + txtIN.Text + "%'", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);

                guna2DataGridView2.DataSource = ds.Tables[0].DefaultView;

                con.Close();
            }
            catch (Exception ex)
            {
                //NEED ERROR FIXING METHOD 
                return;
            }
          
        
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {

            if (txtIN.Text != "")
            {
                searchInvoiceNo();
            }
            else
            {
                MessageBox.Show("No Invoice Number Provided!");
                return;

            }
      
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {


        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
   //         guna2DataGridView3.DataSource = null;
            guna2DateTimePicker3.Value = DateTime.Today;
            guna2DateTimePicker4.Value = DateTime.Today;
        

        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            searchProductCode();
            InvoiceInfo1();
            getCustomerInfo1();
        }

        private void txtIN_TextChanged(object sender, EventArgs e)
        {
            searchInvoiceNo();
            InvoiceInfo2();
            getCustomerInfo2();
        }

        private void txtIN_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.integersOnly(sender, e);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                txtProductCode.Focus();

            } else if(tabControl1.SelectedIndex == 1)
            {
                txtIN.Focus();

            }
         
        }

        /// <summary>
        /// 
        /// TAB 1 AMOUNT DUE TEXTBOX DETECTION FOR INCOMPLETE PAYMENTS
        /// 
        /// </summary>
        private void txtAD_TextChanged(object sender, EventArgs e)
        {
            if(Convert.ToDouble(txtAD2.Text) <= 0)
            {
                txtAD2.ForeColor = Color.Lime;

            } else
            {
                txtAD2.ForeColor = Color.Red;
                toolTip1.Show("Click on 'Deduce Arrear' to settle payments",btnArrear2, 5000);
            }
        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            if (label40.Text == "Balanced")
            {
                MessageBox.Show("The selected Invoice is fully Paid!");
            }
            else if (label40.Text == "Pending")
            {


            }
        }

        /// <summary>
        /// 
        /// TAB 1 AMOUNT DUE TEXTBOX DETECTION FOR INCOMPLETE PAYMENTS
        /// 
        /// </summary>
        private void txtAD_TextChanged_1(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtAD.Text) <= 0)
            {
                txtAD.ForeColor = Color.Lime;

            }
            else
            {
                txtAD.ForeColor = Color.Red;
                toolTip1.Show("Click on 'Deduce Arrear' to settle payments",btnBlcMgmt,5000);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
          //  //    rptSuppliers rpt = new rptSuppliers();
           //     //The report you created.
       //    //     frmSuppliersReport frm = new frmSuppliersReport();
       //    //     SqlConnection myConnection = default(SqlConnection);
         ////       SqlCommand MyCommand = new SqlCommand();
         ////       SqlDataAdapter myDA = new SqlDataAdapter();
           ////     POS_DBDataSet myDS = new POS_DBDataSet();
                /////The DataSet you created.
         //   //    myConnection = new SqlConnection(cs.DBConn);
         /////       MyCommand.Connection = myConnection;
          //   //   MyCommand.CommandText = "select * from Supplier Order by SupplierName";
          ///      MyCommand.CommandType = CommandType.Text;
             ////   myDA.SelectCommand = MyCommand;
               //// myDA.Fill(myDS, "Supplier");
             ////   rpt.SetDataSource(myDS);
               //// frm.crystalReportViewer1.ReportSource = rpt;
            ////    frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridView3_Click(object sender, EventArgs e)
        {
            InvoiceInfo3();
            getCustomerInfo3();
            invoiceHolder3 = Convert.ToInt32(guna2DataGridView3.SelectedRows[0].Cells[0].Value);
        }

        /// <summary>
        /// 
        /// TAB 3 AMOUNT DUE TEXTBOX DETECTION FOR INCOMPLETE PAYMENTS
        /// 
        /// </summary>
        private void txtAD3_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtAD3.Text) <= 0)
            {
                txtAD3.ForeColor = Color.Lime;

            }
            else
            {
                txtAD3.ForeColor = Color.Red;
                toolTip1.Show("Click on 'Deduce Arrear' to settle payments",btnArrear3, 5000);
            }
        }

        private void btnBlcMgmt_Click(object sender, EventArgs e)
        {

         
            

        }

        private void guna2Button8_Click_2(object sender, EventArgs e)
        {

        
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {

           

        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
        
        }

        private void guna2DataGridView1_Click(object sender, EventArgs e)
        {
            InvoiceInfo1();
            getCustomerInfo1();
            invoiceHolder1 = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void guna2DataGridView2_Click(object sender, EventArgs e)
        {
            InvoiceInfo2();
            getCustomerInfo2();
            invoiceHolder2 = Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells[0].Value);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
         
        
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
       
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
         
        }

    /// <summary>
    /// 
    /// PROCESS REPORT FOR TAB 1 
    /// 
    /// </summary>
        private void processReport1()
        {

            try
            {

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                rptSalesReport theReport = new rptSalesReport();

                //The report you created.
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID From dtb_ProductsSold_rws Where ProductCode Like '%" + txtProductCode.Text + "%'", con);
                //      cmd.ExecuteNonQuery();

                // ds = new DataSet();
                DataTable dtb = new DataTable();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(dtb);


                theReport.Database.Tables["dtb_ProductsSold_rws"].SetDataSource(dtb);
                frmSalesReport frm = new frmSalesReport();
                frm.crystalReportViewer1.ReportSource = null;
                frm.crystalReportViewer1.ReportSource = theReport;
                frm.Visible = true;
                con.Close();
                con.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        /// <summary>
        /// 
        /// PROCESS REPORT FOR TAB 2
        /// 
        /// </summary>
        private void processReport2()
        {

            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                rptSalesReport theReport = new rptSalesReport();

                //The report you created.
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,CustomerID From dtb_ProductsSold_rws Where InvoiceNo Like '%" + txtIN.Text + "%'", con);
                //      cmd.ExecuteNonQuery();

                //     ds = new DataSet();
                DataTable dtb = new DataTable();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(dtb);


                theReport.Database.Tables["dtb_ProductsSold_rws"].SetDataSource(dtb);
                frmSalesReport frm = new frmSalesReport();
                frm.crystalReportViewer1.ReportSource = null;
                frm.crystalReportViewer1.ReportSource = theReport;
                frm.Visible = true;
                con.Close();
                con.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        /// <summary>
        /// 
        /// PROCESS REPORT FOR TAB 3
        /// 
        /// </summary>
        private void processReport3()
        {

            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                rptFilteredByDatePeriodReport theReport = new rptFilteredByDatePeriodReport();

                //The report you created.
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select  dtb_ProductsSold_rws.InvoiceNo,ProductCode,ProductName,Price,Quantity,TotalAmount,dtb_InvoiceInfo_rws.CustomerID,InvoiceDate From dtb_ProductsSold_rws,dtb_InvoiceInfo_rws Where dtb_ProductsSold_rws.InvoiceNo=dtb_InvoiceInfo_rws.InvoiceNo And InvoiceDate Between '" + guna2DateTimePicker4.Value + "' And '" + guna2DateTimePicker3.Value + "'", con);

                //      cmd.ExecuteNonQuery();

                ds = new DataSet();
                DataTable dtb = new DataTable();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(dtb);


                theReport.Database.Tables["DatePeriod"].SetDataSource(dtb);
                frmSalesReport frm = new frmSalesReport();
                
                frm.crystalReportViewer1.ReportSource = null;
                frm.crystalReportViewer1.ReportSource = theReport;
                frm.Visible = true;
                con.Close();
                con.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
         
        }

        private void btnBlcMgmt_Click_1(object sender, EventArgs e)
        {
            if (label40.Text == "Balanced")
            {
                MessageBox.Show("No balancing is required on fully paid invoices!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (label40.Text == "Pending")
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo From dtb_InvoiceInfo_rws Where InvoiceNo = " + guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {
                    clsBlcProps.InvoiceNumber = rd[0].ToString();
                }

                rd.Close();
                con.Close();

                clsBlcProps.TotalPayment = txtTotP.Text;
                clsBlcProps.AmountPaid = txtAP.Text;
                clsBlcProps.PaymentDue = txtAD.Text;

                clsAuthenticity.getPage("", this, new frmArrear());

            }
            else
            {
                MessageBox.Show("Select a record first", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnReverseTrans_Click(object sender, EventArgs e)
        {
            if (label40.Text == "Balanced" || label40.Text == "Pending")
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo From dtb_InvoiceInfo_rws Where InvoiceNo = " + guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {
                    clsBlcProps.InvoiceNumber = rd[0].ToString();
                }

                rd.Close();
                con.Close();
                clsAuthenticity.getPage("", this, new frmReverseTrans());
            }
            else
            {
                MessageBox.Show("Select record first!");
            }
        
        }

        private void btnVReport_Click(object sender, EventArgs e)
        {
            processReport1();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (label26.Text == "Balanced" || label26.Text == "Pending")
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo From dtb_InvoiceInfo_rws Where InvoiceNo = " + guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {
                    clsBlcProps.InvoiceNumber = rd[0].ToString();
                }

                rd.Close();
                con.Close();
                clsAuthenticity.getPage("", this, new frmReverseTrans());
            }
            else
            {
                MessageBox.Show("Select record first!");
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            processReport2();
        }

        private void btnArrear2_Click(object sender, EventArgs e)
        {
            if (label26.Text == "Balanced")
            {
                MessageBox.Show("No balancing is required on fully paid invoices!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (label26.Text == "Pending")
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo From dtb_InvoiceInfo_rws Where InvoiceNo = " + guna2DataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {
                    clsBlcProps.InvoiceNumber = rd[0].ToString();
                }

                rd.Close();
                con.Close();

                clsBlcProps.TotalPayment = txtTotP2.Text;
                clsBlcProps.AmountPaid = txtAP2.Text;
                clsBlcProps.PaymentDue = txtAD2.Text;

                clsAuthenticity.getPage("", this, new frmArrear());

            }
            else
            {
                MessageBox.Show("Select a record first", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            if (label51.Text == "Balanced")
            {
                MessageBox.Show("No balancing is required on fully paid invoices!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (label51.Text == "Pending")
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo From dtb_InvoiceInfo_rws Where InvoiceNo = " + guna2DataGridView3.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {
                    clsBlcProps.InvoiceNumber = rd[0].ToString();
                }

                rd.Close();
                con.Close();

                clsBlcProps.TotalPayment = txtTotP3.Text;
                clsBlcProps.AmountPaid = txtAP3.Text;
                clsBlcProps.PaymentDue = txtAD3.Text;

                clsAuthenticity.getPage("", this, new frmArrear());

            }
            else
            {
                MessageBox.Show("Select a record first", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            if (label51.Text == "Balanced" || label51.Text == "Pending")
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select InvoiceNo From dtb_InvoiceInfo_rws Where InvoiceNo = " + guna2DataGridView3.SelectedRows[0].Cells[0].Value.ToString() + "", con);
                rd = cmd.ExecuteReader();



                if (rd.Read() == true)
                {
                    clsBlcProps.InvoiceNumber = rd[0].ToString();
                }

                rd.Close();
                con.Close();
                clsAuthenticity.getPage("", this, new frmReverseTrans());
            }
            else
            {
                MessageBox.Show("Select record first!");
            }
        
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            processReport3(); 
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    InvoiceInfo1();
                    getCustomerInfo1();
                    invoiceHolder1 = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
                }

                if (tabControl1.SelectedTab == tabControl1.TabPages[1])
                {
                    InvoiceInfo2();
                    getCustomerInfo2();
                    invoiceHolder2 = Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells[0].Value);
                }

                if (tabControl1.SelectedTab == tabControl1.TabPages[2])
                {
                    InvoiceInfo3();
                    getCustomerInfo3();
                    invoiceHolder3 = Convert.ToInt32(guna2DataGridView3.SelectedRows[0].Cells[0].Value);
                }
            }
            catch (Exception exTAB)
            {
             
                return;
            }
          
        }
  
    }
}
