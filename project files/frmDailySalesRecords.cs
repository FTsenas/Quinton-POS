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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace QuintonPOS
{
    public partial class frmDailySalesRecords : Form
    {
        public frmDailySalesRecords()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            guna2Transition1.AddToQueue(guna2GradientPanel2, Guna.UI2.AnimatorNS.AnimateMode.Show, true);


            guna2Transition2.AddToQueue(avatar, Guna.UI2.AnimatorNS.AnimateMode.Show, true);

            guna2Transition3.AddToQueue(btnFCD, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition3.AddToQueue(btnReport, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition3.AddToQueue(btnRT, Guna.UI2.AnimatorNS.AnimateMode.Show, true);

         
        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;


        List<string> cashIDs = new List<string>();

        private void FrmDailySalesRecords_Load(object sender, EventArgs e)
        {

              
            toolStripStatusLabel4.Text = dateTimePicker1.Text;
            toolStripStatusLabel2.Text = clsAuthenticity.username;

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select dtb_ProductsSold_rws.InvoiceNo, ProductCode, ProductName, Price, Quantity, TotalAmount, dtb_ProductsSold_rws.CustomerID From dtb_ProductsSold_rws,dtb_InvoiceInfo_rws Where dtb_ProductsSold_rws.InvoiceNo = dtb_InvoiceInfo_rws.InvoiceNo And dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);

                try
                {
       
                    cashList.Text = cashList.Items[0].ToString();
                }
                catch (Exception ex)
                {
                    
                    
                }

               
                    ds = new DataSet();

                    adp = new OleDbDataAdapter(cmd);
                    adp.Fill(ds);

              
                salesDTG.DataSource = ds.Tables[0].DefaultView;

                    con.Close();

                loadAttendants();
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
               // MessageBox.Show("An error occurred, try again later!");
            }
          
      

         
        }

        private void getSelectedRecords()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select dtb_ProductsSold_rws.InvoiceNo, ProductCode, ProductName, Price, Quantity, TotalAmount, dtb_ProductsSold_rws.CustomerID,OperatorName,OperatorID From dtb_ProductsSold_rws,dtb_InvoiceInfo_rws Where dtb_ProductsSold_rws.InvoiceNo = dtb_InvoiceInfo_rws.InvoiceNo And dtb_InvoiceInfo_rws.OperatorID = '" + cashIDs[cashList.SelectedIndex] + "' And dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);



            ds = new DataSet();

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);

            salesDTG.DataSource = ds.Tables[0].DefaultView;

            con.Close();


        }

        /// <summary>
        /// 
        /// ACCUMULATES THE CASHIER COMBOBOX WITH NAMES OF ATTENDANTS THAT SERVED ON THE PRESENT DAY
        /// 
        /// </summary>
        private void loadAttendants()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();



            try
            {
            
            cmd = new OleDbCommand("Select distinct dtb_InvoiceInfo_rws.OperatorID,dtb_InvoiceInfo_rws.OperatorName,InvoiceDate From dtb_Shifts_rws,dtb_InvoiceInfo_rws Where dtb_InvoiceInfo_rws.OperatorID  = dtb_Shifts_rws.OperatorID And dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);
            rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                   
                    cashIDs.Add(rd[0].ToString()); //Collection of Cashier IDs.
                    cashList.Items.Add(rd[1].ToString());
            

                }

                if (rd.HasRows)
                {
                    //DO ABSOLUTELY NOTHING...

                } else
                {
                    cashList.Items.Add("ALL");
                    cashList.Enabled = false;
                    MessageBox.Show("No sales have been peformed today!");
                   
                }


                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
              
                MessageBox.Show("An error occurred, try again later");
                return;
            }


        }

        private void CashList_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSelectedRecords();
        }

        private void FrmDailySalesRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAuthenticity.showRunningForm();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            processDailySalesReport();
        }

        private void processDailySalesReport()
        {

            if(cashList.Text == "")
            {


                if (MessageBox.Show("No User has been selected, the system will generate a report for all Users.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {

                    try
                    {

                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                        rptDailySalesReport theReport = new rptDailySalesReport();

                        //The report you created.
                        con = new OleDbConnection(connectionString.DBConn);
                        con.Open();

                        cmd = new OleDbCommand("Select dtb_ProductsSold_rws.InvoiceNo, ProductCode, ProductName, Price, Quantity, TotalAmount, dtb_ProductsSold_rws.CustomerID From dtb_ProductsSold_rws,dtb_InvoiceInfo_rws Where dtb_ProductsSold_rws.InvoiceNo = dtb_InvoiceInfo_rws.InvoiceNo And dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);
                        //      cmd.ExecuteNonQuery();

                        // ds = new DataSet();
                        DataTable dtb = new DataTable();

                        adp = new OleDbDataAdapter(cmd);

                        adp.Fill(dtb);


                        theReport.Database.Tables["DailySales"].SetDataSource(dtb);

                        frmDailySalesReport frm = new frmDailySalesReport();

                        TextObject txtTeller = (TextObject)theReport.ReportDefinition.Sections["Section2"].ReportObjects["txtTeller"];
                        txtTeller.Text = "ALL";


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
                } else
                {
                    return;
                }

            } else
            {
                try
                {

                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    rptDailySalesReport theReport = new rptDailySalesReport();

                    //The report you created.
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("Select dtb_ProductsSold_rws.InvoiceNo, ProductCode, ProductName, Price, Quantity, TotalAmount, dtb_ProductsSold_rws.CustomerID From dtb_ProductsSold_rws,dtb_InvoiceInfo_rws Where dtb_ProductsSold_rws.InvoiceNo = dtb_InvoiceInfo_rws.InvoiceNo And dtb_InvoiceInfo_rws.OperatorID = '" + cashIDs[cashList.SelectedIndex] + "' And dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);
                    //      cmd.ExecuteNonQuery();

                    // ds = new DataSet();
                    DataTable dtb = new DataTable();

                    adp = new OleDbDataAdapter(cmd);

                    adp.Fill(dtb);


                    theReport.Database.Tables["DailySales"].SetDataSource(dtb);

                    frmDailySalesReport frm = new frmDailySalesReport();

                    TextObject txtTeller = (TextObject)theReport.ReportDefinition.Sections["Section2"].ReportObjects["txtTeller"];
                    txtTeller.Text = cashList.Text;


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


        }

        private void btnRT_Click(object sender, EventArgs e)
        {
            if(cashList.Text == "")
            {
                   if (MessageBox.Show("No User has been selected, the system will generate a report for all Users.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                   {
                       con = new OleDbConnection(connectionString.DBConn);
                       con.Open();

                       cmd = new OleDbCommand("Select InvoiceNo, CustomerID, VATAmount, TotalPayment, PaymentDue, DiscountAmount, AmountPaid From dtb_InvoiceInfo_rws Where dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);
                       rd = cmd.ExecuteReader();


                       if (rd.HasRows)
                       {
                           double addUp = 0;

                           while (rd.Read())
                           {
                               addUp += Convert.ToDouble(rd[6].ToString());
                           }


                           rd.Close();
                           try
                           {
                               System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                               rptDailyCashSalesReport theReport = new rptDailyCashSalesReport();


                               DataSet rptDtb = new DataSet();

                               adp = new OleDbDataAdapter(cmd);
                               adp.Fill(rptDtb);

                               theReport.Database.Tables["DailyCashSales"].SetDataSource(rptDtb.Tables[0]);
                               //  frmUserDailySalesReport frm = new frmUserDailySalesReport();

                               frmDailyCashSalesReport frm = new frmDailyCashSalesReport();


                               TextObject totalTotal = (TextObject)theReport.ReportDefinition.Sections["Section4"].ReportObjects["txtTotal"];
                               TextObject txtUser = (TextObject)theReport.ReportDefinition.Sections["Section2"].ReportObjects["txtUser"];
                               totalTotal.Text = addUp.ToString();
                               txtUser.Text = "ALL";

                               frm.crystalReportViewer1.ReportSource = null;
                               frm.crystalReportViewer1.ReportSource = theReport;
                               frm.Visible = true;




                           }
                           catch (Exception ex)
                           {
                               MessageBox.Show("" + ex);

                               // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           }

                           System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                       }
                       else
                       {

                           MessageBox.Show("User hasn't sold anything today!");

                       }

                       con.Close();


                   } 
                   else
                   {
                       return;
                   }
            }
            else
            {
           
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("Select InvoiceNo, CustomerID, VATAmount, TotalPayment, PaymentDue, DiscountAmount, AmountPaid From dtb_InvoiceInfo_rws Where dtb_InvoiceInfo_rws.OperatorID = '" + cashIDs[cashList.SelectedIndex] + "' And dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);
                    rd = cmd.ExecuteReader();


                    if (rd.HasRows)
                    {
                        double addUp = 0;

                        while (rd.Read())
                        {
                            addUp += Convert.ToDouble(rd[6].ToString());
                        }


                        rd.Close();
                        try
                        {
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                            rptDailyCashSalesReport theReport = new rptDailyCashSalesReport();


                            DataSet rptDtb = new DataSet();

                            adp = new OleDbDataAdapter(cmd);
                            adp.Fill(rptDtb);

                            theReport.Database.Tables["DailyCashSales"].SetDataSource(rptDtb.Tables[0]);
                            //  frmUserDailySalesReport frm = new frmUserDailySalesReport();

                            frmDailyCashSalesReport frm = new frmDailyCashSalesReport();


                            TextObject totalTotal = (TextObject)theReport.ReportDefinition.Sections["Section4"].ReportObjects["txtTotal"];
                            TextObject txtUser = (TextObject)theReport.ReportDefinition.Sections["Section2"].ReportObjects["txtUser"];
                            totalTotal.Text = addUp.ToString();
                            txtUser.Text = cashList.Text;

                            frm.crystalReportViewer1.ReportSource = null;
                            frm.crystalReportViewer1.ReportSource = theReport;
                            frm.Visible = true;




                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);

                            // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    }
                    else
                    {

                        MessageBox.Show("User hasn't sold anything today!");

                    }

                    con.Close();


                }
           
            
        }

    }
}
