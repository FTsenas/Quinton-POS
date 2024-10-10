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
    public partial class frmAllStockLevels : Form
    {
        public frmAllStockLevels()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            gunaTransition1.AddToQueue(groupBox1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(datagridRst, Guna.UI.Animation.AnimateMode.Show, true);


            gunaTransition2.AddToQueue(guna2VProgressBar1, Guna.UI.Animation.AnimateMode.Show, true);


            gunaTransition1.AddToQueue(gunaShadowPanel1, Guna.UI.Animation.AnimateMode.Show, true);
        }


        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;


        private void frmAllStockLevels_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,dtb_Products_rws.ProductName,RTRIM(dtb_currentStock_rws.Quantity) As [Quantity Remaining],RTRIM(dtb_Stock_rws.Quantity) As [Original Quantity] From dtb_Products_rws,dtb_currentStock_rws,dtb_Stock_rws Where dtb_Products_rws.ProductCode=dtb_Stock_rws.ProductCode And dtb_currentStock_rws.ProductCode=dtb_Stock_rws.ProductCode", con);

            ds = new DataSet();

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);
            datagridRst.DataSource = ds.Tables[0].DefaultView;

            con.Close();

            calPercentage();    //Calculating rq % for the 1st item in the Datagridview!!!
            gradding();     //Determining progressbar colors for the 1st item in the Datagridview!!!
            txtSearch.Focus();
        }

        /// <summary>
        /// 
        /// CALCULATING THE PERCENTAGE OF THE QUANTITY REMAINING OF A PRODUCT!!!
        /// 
        /// </summary>
        private void calPercentage()
        {
            double rq = 0;
            double oq = 0;
            double result = 0;


            rq = Convert.ToDouble(datagridRst.SelectedRows[0].Cells[2].Value);       //rq = Remaining Quantity;
            oq = Convert.ToDouble(datagridRst.SelectedRows[0].Cells[3].Value);      //oq = Original Quantity;

            result = Convert.ToDouble((rq / oq) * 100);
            guna2VProgressBar1.Value = Convert.ToInt32(result);

        }

        /// <summary>
        /// 
        /// CLASSIFYING PROGRESSBAR COLORS BY PERCENTAGE RANGE!!!
        /// 
        /// </summary>
        private void gradding()
        {

            if (guna2VProgressBar1.Value >= 80)
            {
                guna2VProgressBar1.ProgressColor = Color.DarkGreen;
                guna2VProgressBar1.ProgressColor2 = Color.Green;
            }
            else if (guna2VProgressBar1.Value >= 60)
            {
                guna2VProgressBar1.ProgressColor = Color.Green;
                guna2VProgressBar1.ProgressColor2 = Color.Lime;
            }

            else if (guna2VProgressBar1.Value >= 35)
            {
                guna2VProgressBar1.ProgressColor = Color.Orange;
                guna2VProgressBar1.ProgressColor2 = Color.Yellow;
            }
            else if (guna2VProgressBar1.Value >= 20)
            {
                guna2VProgressBar1.ProgressColor = Color.MediumVioletRed;
                guna2VProgressBar1.ProgressColor2 = Color.HotPink;
            }
            else if (guna2VProgressBar1.Value >= 0)
            {
                guna2VProgressBar1.ProgressColor = Color.DarkRed;
                guna2VProgressBar1.ProgressColor2 = Color.Red;
            }
        }

   


        private void datagridRst_Click(object sender, EventArgs e)
        {
            calPercentage();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,dtb_Products_rws.ProductName,RTRIM(dtb_currentStock_rws.Quantity) As [Quantity Remaining],RTRIM(dtb_Stock_rws.Quantity) As [Original Quantity] From dtb_Products_rws,dtb_currentStock_rws,dtb_Stock_rws Where dtb_Products_rws.ProductCode=dtb_Stock_rws.ProductCode And dtb_currentStock_rws.ProductCode=dtb_Stock_rws.ProductCode And ProductName Like '%" + txtSearch.Text + "%'", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);
                datagridRst.DataSource = ds.Tables[0].DefaultView;

                con.Close();
            }
            catch (OleDbException ex)
            {

                MessageBox.Show("Character not supported!");
                txtSearch.Clear();

            }
    
        }

        private void guna2GradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2Button7_Click(object sender, EventArgs e)
        {
            processReport();
            
        }

        private void processReport()
        {

            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
              rptAllStockLevelsReport theReport = new rptAllStockLevelsReport();

                //The report you created.
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,dtb_Products_rws.ProductName,RTRIM(dtb_currentStock_rws.Quantity) As [Quantity Remaining],RTRIM(dtb_Stock_rws.Quantity) As [Original Quantity] From dtb_Products_rws,dtb_currentStock_rws,dtb_Stock_rws Where dtb_Products_rws.ProductCode=dtb_Stock_rws.ProductCode And dtb_currentStock_rws.ProductCode=dtb_Stock_rws.ProductCode And ProductName Like '%" + txtSearch.Text + "%'", con);
                //      cmd.ExecuteNonQuery();

                // ds = new DataSet();
                DataTable dtb = new DataTable();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(dtb);


                theReport.Database.Tables["AllStockLevels"].SetDataSource(dtb);
               frmAllStockLevelsReport frm = new frmAllStockLevelsReport();
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

        private void FrmAllStockLevels_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
