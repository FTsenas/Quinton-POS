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
    public partial class frmCustomerOrders : Form
    {
        public frmCustomerOrders()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

        }

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;


        private void timer1_Tick(object sender, EventArgs e)
        {
            clsProgressIndicator.timerOps(guna2WinProgressIndicator1, timer1);
        }

        private void frmCustomerOrders_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void frmCustomerOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            //clsAuthenticity.getPage(this, new frmSalesMenu());
            clsAuthenticity.showRunningForm();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select RTRIM(InvoiceNo) As [Order No],RTRIM(InvoiceDate) As [Order Date],dtb_InvoiceInfo_rws.CustomerID,CName,VAT,DiscountPer,AmountPaid,DiscountAmount,TotalPayment,Status From dtb_InvoiceInfo_rws,dtb_regCustomers_rws  Where InvoiceDate Between @D1 And @D2 order by InvoiceDate desc", con);
            cmd.Parameters.Add("@D1", OleDbType.DBDate, 30, "InvoiceDate").Value = guna2DateTimePicker1.Value;
            cmd.Parameters.Add("@D2", OleDbType.DBDate, 30, "InvoiceDate").Value = guna2DateTimePicker2.Value.Date;
            adp = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
           adp.Fill(ds, "dtb_InvoiceInfo_rws");
            adp.Fill(ds, "dtb_regCustomers_rws");

            
            guna2DataGridView1.DataSource = ds.Tables["dtb_InvoiceInfo_rws"].DefaultView;
            guna2DataGridView1.DataSource = ds.Tables["dtb_regCustomers_rws"].DefaultView;

            if (guna2DataGridView1.Rows.Count - 1 != 0)
            {
                foreach (DataGridViewRow r in this.guna2DataGridView1.Rows)
                {

               //     Int64 i = Convert.ToInt64(r.Cells[9].Value);
               //     Int64 j = Convert.ToInt64(r.Cells[10].Value);
                 //   Int64 k = Convert.ToInt64(r.Cells[11].Value);


                }

            }
            else
            {
                return;

            }

            con.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();

            guna2DataGridView1.DataSource = null;
            guna2DateTimePicker1.Value = DateTime.Today;
            guna2DateTimePicker2.Value = DateTime.Today;
            txtAP.Clear();
            txtPT.Clear();
            txtS.Clear();
            txtTP.Clear();

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox1.Text = guna2ComboBox1.Text.Trim();
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();
            cmd = new OleDbCommand("SELECT RTRIM(invoiceNo) as [Order No],RTRIM(InvoiceDate) as [Order Date],RTRIM(dtb_InvoiceInfo_rws.CustomerID) as [Customer ID],RTRIM(CName) as [Customer Name],RTRIM(VAT) as [VAT %],RTRIM(VATAmount) as [VAT Amount],RTRIM(DiscountPer) as [Discount %],RTRIM(DiscountAmount) as [Discount Amount],RTRIM(SubTotal) as [SubTotal],RTRIM(TotalPayment) as [Total Payment],RTRIM(PaymentType) as [Payment Type],RTRIM(Status) as [Status] From dtb_InvoiceInfo_rws,dtb_regCustomers_rws Where dtb_InvoiceInfo_rws.CustomerID=dtb_regCustomers_rws.CustomerID and CName='" + guna2ComboBox1.Text.Trim() + "' order by CName,InvoiceDate", con);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
           adp.Fill(ds, "dtb_InvoiceInfo_rws");
           adp.Fill(ds, "dtb_regCustomers_rws");
           guna2DataGridView2.DataSource = ds.Tables["dtb_regCustomers_rws"].DefaultView;
           guna2DataGridView2.DataSource = ds.Tables["dtb_InvoiceInfo_rws"].DefaultView;

           foreach (DataGridViewRow r in this.guna2DataGridView2.Rows)
            {
              //  Int64 i = Convert.ToInt64(r.Cells[9].Value);
             //   Int64 j = Convert.ToInt64(r.Cells[10].Value);
               // Int64 k = Convert.ToInt64(r.Cells[11].Value);
       
            }
            
            con.Close();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();
            cmd = new OleDbCommand("Select RTRIM(InvoiceNo) As [Order No],RTRIM(InvoiceDate) As [Order Date],dtb_InvoiceInfo_rws.CustomerID,CName,VAT,DiscountPer,AmountPaid,DiscountAmount,TotalPayment,PaymentDue,Status From dtb_InvoiceInfo_rws,dtb_regCustomers_rws  Where dtb_InvoiceInfo_rws.CustomerID=dtb_regCustomers_rws.CustomerID And InvoiceDate between @d1 And @d2  And PaymentDue > 0 order by InvoiceDate desc", con);
            cmd.Parameters.Add("@d1", OleDbType.DBDate, 30, "InvoiceDate").Value = guna2DateTimePicker3.Value.Date;
            cmd.Parameters.Add("@d2", OleDbType.DBDate, 30, "InvoiceDate").Value = guna2DateTimePicker4.Value.Date;
          OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
           adp.Fill(ds, "dtb_InvoiceInfo_rws");
            adp.Fill(ds, "dtb_regCustomers_rws");
            guna2DataGridView3.DataSource = ds.Tables["dtb_regCustomers_rws"].DefaultView;
            guna2DataGridView3.DataSource = ds.Tables["dtb_InvoiceInfo_rws"].DefaultView;
       

            foreach (DataGridViewRow r in this.guna2DataGridView3.Rows)
            {
             //   Int64 i = Convert.ToInt64(r.Cells[9].Value);
             //   Int64 j = Convert.ToInt64(r.Cells[10].Value);
               // Int64 k = Convert.ToInt64(r.Cells[11].Value);
         
            }
       
            con.Close();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            guna2DataGridView2.DataSource = null;
            guna2ComboBox1.Text = "";
            txtAP2.Clear();
            txtPT2.Clear();
            txtS2.Clear();
            txtTP2.Clear();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            guna2DataGridView3.DataSource = null;
            guna2DateTimePicker3.Value = DateTime.Today;
            guna2DateTimePicker4.Value = DateTime.Today;
           txtAP3.Clear();
           txtPT3.Clear();
           txtPD.Clear();
           txtTP3.Clear();
        }

        private void FrmCustomerOrders_Load(object sender, EventArgs e)
        {

        }
    }
}
