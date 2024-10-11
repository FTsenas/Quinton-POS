using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;


namespace QuintonPOS
{
    public partial class frmQuotation : Form
    {
        public frmQuotation(List<string> salesDetails)
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

        }

        #region DatabaseObjects
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rdr;
        #endregion

        string companyName1 = "";
        string companyName2 = "";
        string officialNumber = "";
        string alternateNumber = "";

        private void frmQuotation_Load(object sender, EventArgs e)
        {
            getPhoneNumbers();

            richTextBox1.AppendText("                              " + companyName1+"\n");
            richTextBox1.AppendText("                          " + companyName2 + "\n");
            richTextBox1.AppendText("                            " + "QUOTATION" + "\n");
            richTextBox1.AppendText("-------------------------------------------------------------");
            richTextBox1.AppendText("\n" + "\n");

            foreach (ListViewItem item in frmSalesMenu.transListView.Items)
            {
                richTextBox1.AppendText(item.SubItems[1].Text + "\n" + item.SubItems[2].Text + "\t" + "X" + "\t" + "US$" + item.SubItems[3].Text + "\t" + "\t" + "US$" + item.SubItems[4].Text + "\n" + "\n");
            }

      
            richTextBox1.AppendText("-------------------------------------------------------------");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("PREFERRED PAYMENT METHOD: " + "\n" + frmSalesMenu.paymentMethod + "\n" + "\n" + "\n");
            richTextBox1.AppendText("TAX: " + "\t" + frmSalesMenu.qTAX  + "\n" + "\n" + "\n");
            richTextBox1.AppendText("DISCOUNT: " + "\t" + frmSalesMenu.qDiscount  + "\n" + "\n" + "\n");
            richTextBox1.AppendText("TOTAL COST: " + "$" + frmSalesMenu.ItTotalCost + "\n" + "\n");
            richTextBox1.AppendText("-------------------------------------------------------------");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("TELLER: " + frmSalesMenu.tellerName + "\n" + "\n");
            richTextBox1.AppendText("<<C@NTACT US>>" + "\n");
            richTextBox1.AppendText("       "+ officialNumber + "\n" + "       " + alternateNumber);
       
        }

        private void getPhoneNumbers()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select [Caption] From dtb_Settings_rws WHERE [Item] = 'CompanyName'", con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read() == true)
            {
                companyName1 = rdr[0].ToString();
            }
          

            cmd = new OleDbCommand("Select Caption From dtb_Settings_rws WHERE [Item] = 'CompanyType'", con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read() == true)
            {
                companyName2 = rdr[0].ToString();
            }
          
        

            cmd = new OleDbCommand("Select Caption From dtb_Settings_rws WHERE [Item] = 'OfficialCell'",con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read() == true)
            {
                officialNumber = rdr[0].ToString();
            }
          
 

            cmd = new OleDbCommand("Select Caption From dtb_Settings_rws WHERE [Item] = 'AlternateCell'", con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read() == true)
            {
                alternateNumber = rdr[0].ToString();
            }
          
        
            con.Close();

        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void GunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
