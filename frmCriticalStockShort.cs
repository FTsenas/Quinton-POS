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
    public partial class frmCriticalStockShort : Form
    {
        public frmCriticalStockShort()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            gunaTransition1.AddToQueue(btnPASL, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(btnReport, Guna.UI.Animation.AnimateMode.Show, true);
          

            gunaTransition2.AddToQueue(guna2DataGridView1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(groupBox4, Guna.UI.Animation.AnimateMode.Show, true);

        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;
     


   public static  List<string> EgradeLQuantities = new List<string>();


        List<DateTime> stockDates = new List<DateTime>();

       string EntryAmt = "";

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void frmCriticalStock_Load(object sender, EventArgs e)
        {

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,dtb_Products_rws.ProductName,RTRIM(dtb_currentStock_rws.Quantity) As [Quantity Remaining],RTRIM(dtb_Stock_rws.Quantity) As [Original Quantity] From dtb_Products_rws,dtb_currentStock_rws,dtb_Stock_rws Where dtb_Products_rws.ProductCode=dtb_Stock_rws.ProductCode And dtb_currentStock_rws.ProductCode=dtb_Stock_rws.ProductCode", con);

            ds = new DataSet();

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);
            datagridRst.DataSource = ds.Tables[0].DefaultView;
    
            con.Close();

          
            gradding();     //Determining progressbar colors for the 1st item in the Datagridview!!!
      
            //getDates();
            getLowQuantities();
            getLowQuantityEntries1();
    
            selectedPs.Focus();
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

        private void getLowQuantities()
        {


            for (int i = 0; i <= datagridRst.Rows.Count - 2; i++)
            {
                double rq = 0;
                double oq = 0;
                double result = 0;

                if (datagridRst.Rows.Count > 0)
                {
                    rq = Convert.ToDouble(datagridRst.Rows[i].Cells[2].Value);       //rq = Remaining Quantity;
                    oq = Convert.ToDouble(datagridRst.Rows[i].Cells[3].Value);      //oq = Original Quantity;

                    result = Convert.ToDouble((rq / oq) * 100);
                }
             

                if (result <= 30)
                {
                    EgradeLQuantities.Add(datagridRst.Rows[i].Cells[0].Value.ToString());

                }

            }

        }

        /// <summary>
        /// METHOD TO GET THE QUANTITY AT FIRST 
        /// </summary>
        private string getEntryAmount()
        {
            

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

             //   cmd = new OleDbCommand("Select Quantity From dtb_Stock_rws, dtb_Products_rws Where dtb_Stock_rws.ProductCode = dtb_Products_rws.ProductCode And StockDate = '" + dateList.SelectedValue + "'",con);
                rd = cmd.ExecuteReader();

           
            
    
                while (rd.Read())
                {
                    EntryAmt = rd[0].ToString();
                }


                rd.Close();
                con.Close();

             
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
                EntryAmt = "";

            }

            return EntryAmt;
            
        }


        /// <summary>
        /// METHOD TO POPULLATE STOCKDATES COMBOBOX WITH DISTINCT STOCK ENTRY DATES
        /// </summary>
        private void getDates()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select  StockDate From dtb_Stock_rws, dtb_Products_rws Where dtb_Stock_rws.ProductCode = dtb_Products_rws.ProductCode",con);
            rd = cmd.ExecuteReader();

            try
            {

                while (rd.Read())
                {
            //        dateList.Items.Add(rd[0].ToString()); //Collection of stock dates for indexing with stockDates Combobox
                  stockDates.Add(Convert.ToDateTime(rd[0].ToString())); //Collection of stock DAtes.
                }

          //      dateList.DataSource = stockDates;

                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred!");
                return;
            }
   
            

        }

        private void frmCriticalStock_FormClosing(object sender, FormClosingEventArgs e)
        {
          

        }

        private void frmCriticalStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void datagridRst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        /// <summary>
        /// 
        /// ITERATING ALL PRODUCTS WITH VERY LOW QUANTITIES!!!
        /// 
        /// </summary>
        private void getLowQuantityEntries()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,dtb_Products_rws.ProductName,RTRIM(dtb_currentStock_rws.Quantity) As [Quantity Remaining],RTRIM(dtb_Stock_rws.Quantity) As [Original Quantity] From dtb_Products_rws,dtb_currentStock_rws,dtb_Stock_rws Where dtb_Products_rws.ProductCode=dtb_Stock_rws.ProductCode And dtb_currentStock_rws.ProductCode=dtb_Stock_rws.ProductCode And dtb_Products_rws.ProductCode = '" + selectedPs.Text +  "'", con);
         

            ds = new DataSet();

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);

            guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;

          
            con.Close();
            calPercentage();    //Calculating rq % for the 1st item in the Datagridview!!!
        }

        private void getLowQuantityEntries1()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();


            for (int i = 0; i <= EgradeLQuantities.Count - 1; i++)
            {

                cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,dtb_Products_rws.ProductName,RTRIM(dtb_currentStock_rws.Quantity) As [Quantity Remaining],RTRIM(dtb_Stock_rws.Quantity) As [Original Quantity] From dtb_Products_rws,dtb_currentStock_rws,dtb_Stock_rws Where dtb_Products_rws.ProductCode=dtb_Stock_rws.ProductCode And dtb_currentStock_rws.ProductCode=dtb_Stock_rws.ProductCode And dtb_Products_rws.ProductCode = '" + EgradeLQuantities[i] + "'", con);


                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);

                foreach (DataRow dtRow in ds.Tables[0].Rows)
                {
                    int n = dataGridView1.Rows.Add();
                       
                    dataGridView1.Rows[n].Cells[0].Value = dtRow["ProductCode"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dtRow["ProductName"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dtRow["Quantity Remaining"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dtRow["Original Quantity"].ToString();
               

                }

            }

            con.Close();
            calPercentage();    //Calculating rq % for the 1st item in the Datagridview!!!
        }

        private void datagridRst_Click(object sender, EventArgs e)
        {
         
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

            if (guna2DataGridView1.Rows.Count > 0)
            {

                rq = Convert.ToDouble(guna2DataGridView1.Rows[0].Cells[2].Value);       //rq = Remaining Quantity;
                oq = Convert.ToDouble(guna2DataGridView1.Rows[0].Cells[3].Value);      //oq = Original Quantity;

                result = Convert.ToDouble((rq / oq) * 100);
                guna2VProgressBar1.Value = Convert.ToInt32(result);
               
            }

           
        }

        private void calPercentage1()
        {
            try
            {
                double rq = 0;
                double oq = 0;
                double result = 0;

                rq = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);       //rq = Remaining Quantity;
                oq = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value);      //oq = Original Quantity;

                result = Convert.ToDouble((rq / oq) * 100);
                guna2VProgressBar1.Value = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                guna2VProgressBar1.Value = 0;
                return;
            }

         

        }
 
        private void frmCriticalStock_Shown(object sender, EventArgs e)
        {
           // getLowQuantities();
           // getLowQuantityEntries();
        }


        private void selectedPs_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
      

        }

     
        private void selectedPs_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            getLowQuantityEntries();
        }

        private void dateList_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void statsGroup_Enter(object sender, EventArgs e)
        {

        }



        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            clsAuthenticity.getPage("", this, new frmAllStockLevels());
        }

        private void guna2GradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private DataTable cloneTheDGVTable(DataGridView dg)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Product Code");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Quantity Remaining");
            dt.Columns.Add("Original Quantity");

            //   foreach(DataGridViewColumn col in dg.Columns)
            //   {
            //     dt.Columns.Add(col.Name);
            //  }

            foreach (DataGridViewRow row in dg.Rows)
            {

                DataRow dRow = dt.NewRow();
               foreach(DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;

                }

                dt.Rows.Add(dRow);

              

            }

            return dt;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            processReport();
        }

        private void processReport()
        {

            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                rptLowStock theReport = new rptLowStock();

           

                DataSet rptDtb = new DataSet();

                DataTable dt = new DataTable();

                dt = cloneTheDGVTable(dataGridView1);

               // dt.Columns.Add("Product Code");
                // dt.Columns.Add("Product Name");
                // dt.Columns.Add("Quantity Remaining");
               //  dt.Columns.Add("Original Quantity");

                rptDtb.Tables.Add(dt);

             //   foreach(DataGridViewRow dtGrRow in dataGridView1.Rows)
              //  {
               //     rptDtb.Tables[0].Rows.Add(dtGrRow.Clone());
                //  rptDtb.Rows.Add((DataRow)dtGrRow);
              //  }

           
              //  rptDtb = ((DataTable) dataGridView1.DataSource);

               //theReport.SetDataSource(rptDtb.Tables[0]);
          //    theReport.Database.Tables[0].SetDataSource(rptDtb);

            theReport.Database.Tables["LowStock"].SetDataSource(rptDtb.Tables[0]);
                frmLowStockReport frm = new frmLowStockReport();
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            calPercentage1();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
