using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Confirmation;
using ipt_val_fl;
using System.Diagnostics;
using System.Data.OleDb;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;






namespace QuintonPOS
{
    public partial class frmSalesMenu : Form
    {

        private bool go;
        private int dx = 1;

        public frmSalesMenu()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;


            #region GUNADESIGN
    
            guna2Transition1.AddToQueue(avatar, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
            guna2Transition1.AddToQueue(txtRTGSCSH, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(txtRANDCSH, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(txtUSDBNK, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(txtRTGSBNK, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(txtRTGSECO, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(txtUSDECO, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(groupBox1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            //guna2Transition1.AddToQueue(btnDelete, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
         //   guna2Transition1.AddToQueue(btnClear, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnAddToCart, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnPerformSale, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnViewQuot, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(menuStrip1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(groupBox6, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(groupBox7, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
             guna2Transition1.AddToQueue(guna2Button3, Guna.UI2.AnimatorNS.AnimateMode.Show, true);


            guna2Transition2.AddToQueue(panel3, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(listView1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(searchRst, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(pictureBox2, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(label1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(label3, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(label9, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(label14, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(label15, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(label4, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(pictureBox1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);


            #endregion
      
           }

        #region DatabaseComponents

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

        #endregion
     

        #region FilePathz

         private static string filePathDDR = Application.StartupPath + "//qpos_DDR.ini";
        private static string filePathEMC = Application.StartupPath + "//qpos_EMC.ini";
        private static string filePathDCL = Application.StartupPath + "//qpos_DCL.ini";

        #endregion

        #region FloatVariableFields

        double tot = 0.00;
        double tot1 = 0.00;
        double subt = 0.00;
        double finale = 0.00;
        double holder = 0.00;
        double remainda = 0.00;
        double totAmt = 0.00;
        double afterTax = 0.00;
        double afterDisc = 0.00;
        double afterAll = 0.00;

        #endregion

        #region Quotation

        public static ListView transListView = new ListView();
        public static string paymentMethod = "";
        public static double ItTotalCost = 0.00;
        public static string tellerName = "";
        public static double qTAX = 0.00;
        public static double qDiscount = 0.00;


        #endregion

        double totalItems = 0;
        string USDCASH = "";

        int hrs = System.DateTime.Now.TimeOfDay.Hours;
        int mins = System.DateTime.Now.TimeOfDay.Minutes;
        string timeSeparator = ":";

        List<string> salesDetails = new List<string>();


       
        private void frmSalesMenu_Load(object sender, EventArgs e)
        {
          

            // TODO: This line of code loads data into the 'pOSDataSet.dtb_Products_rws' table. You can move, or remove it, as needed.
         
            // TODO: This line of code loads data into the 'pOSDataSet.dtb_Products_rws' table. You can move, or remove it, as needed.

            DateTime dt = new DateTime();
            dt = System.DateTime.Now;

            toolStripStatusLabel4.Text = dateTimePicker1.Text;
            toolStripStatusLabel2.Text = clsAuthenticity.username;
            txtSearch.Focus();

            getRates();//GET RATES INFO!!

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity FROM dtb_Products_rws,dtb_currentStock_rws WHERE dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode order by ProductName asc", con);
              ds = new DataSet();

            

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);
           

            searchRst.DataSource = ds.Tables[0].DefaultView;

            rd = cmd.ExecuteReader();

            if (rd.Read() == true)
            {
                txtICode.Text = rd[0].ToString();
                txtPName.Text = rd[1].ToString();
                txtStock.Text = rd[5].ToString();
                txtPrice.Text = rd[3].ToString();
                txtDesc.Text = rd[2].ToString();

                clsRetrievImage.retrieveImage(avatar, rd[4].ToString());

                if (Convert.ToDouble(txtStock.Text) <= 0)
                {
                    txtSalesQ.Text = "";
                    txtSalesQ.Enabled = false;
                    soldOut.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\nomore.avt");
                    soldOut.Visible = true;
                }
                else
                {
                    txtSalesQ.Text = "1";
                    txtSalesQ.Enabled = true;
                    soldOut.Visible = false;
                }

            }

            con.Close();

            DDR();
            EMC();
 

        }

        private void getRates()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();


            //ZWL RTGS CASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'ZWL_RTGS_CASH'", con);
            rd = cmd.ExecuteReader();


            if(rd.Read() == true) 
            {
                
                    txtRTGSCSH.Text = rd[1].ToString();
                    payMethCombo.Items.Add(rd[0].ToString());
                  
            }

            rd.Close();

            //SA RAND CASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'SA_RAND_CASH'", con);
            rd = cmd.ExecuteReader();

            if (rd.Read() == true)
            {

                   txtRANDCSH.Text = rd[1].ToString();
                   payMethCombo.Items.Add(rd[0].ToString());

            }

            rd.Close();

            //USD BANK TRANSFER
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'USD_BANK_TRANSFER'", con);
            rd = cmd.ExecuteReader();

            if (rd.Read() == true)
            {
            
                    txtUSDBNK.Text = rd[1].ToString();
                    payMethCombo.Items.Add(rd[0].ToString());

            }

            rd.Close();


            //ZWL RTGS BANK TRANSFER
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'ZWL_RTGS_BANK_TRANSFER'", con);
            rd = cmd.ExecuteReader();

            if (rd.Read() == true)
            {

                    txtRTGSBNK.Text = rd[1].ToString();
                    payMethCombo.Items.Add(rd[0].ToString());

            }

            rd.Close();


            //ZWL RTGS ECOCASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'ZWL_RTGS_ECOCASH'", con);
            rd = cmd.ExecuteReader();

            if (rd.Read() == true)
            {

                     txtRTGSECO.Text = rd[1].ToString();
                     payMethCombo.Items.Add(rd[0].ToString());

            }

            rd.Close();

            
            //USD ECOCASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'USD_ECOCASH'", con);
            rd = cmd.ExecuteReader();

            if (rd.Read() == true)
            {
                 
    txtUSDECO.Text = rd[1].ToString();
    payMethCombo.Items.Add(rd[0].ToString());

            }

            //USD CASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'USD_CASH'", con);
            rd = cmd.ExecuteReader();

            if (rd.Read() == true)
            {

                USDCASH = rd[1].ToString();
                payMethCombo.Items.Add(rd[0].ToString());
                payMethCombo.Text = rd[0].ToString();

            }


          
            rd.Close();

            con.Close();  
        }

        private void customerManagementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          

        }

        private void payMethCombo_KeyUp(object sender, KeyEventArgs e)
        {
            //comboBoxMgmt(Convert.ToString(payMethCombo.Items[0]));
            //clsComboRestrict.comboBoxMgmt(payMethCombo, Convert.ToString(payMethCombo.Items[0]));


            
        }

        

        //DATETIMEPICKER CONCATENATION
        private String appendDate()
        {
            return "\n(" + dateTimePicker1.Value + ")";
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                clsAuthenticity.getPage("", this, new frmAboutQuintonPOS());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops, could not retreive object...try again later.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtSalesQ_TextChanged(object sender, EventArgs e)
        {

            if (txtSalesQ.Text == "0")
            {
                txtSalesQ.Clear();
                return;
            }

            int a = 0;
            int b = 0;

            int.TryParse(txtSalesQ.Text, out a);
            int.TryParse(txtStock.Text, out b);

            if (a > b)
            {
                MessageBox.Show("The selected quantity exceeds the current stock available!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalesQ.Clear();
                txtSearch.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            try
            {
                guna2WinProgressIndicator1.Visible = true;
                timer1.Start();

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity From dtb_Products_rws,dtb_currentStock_rws Where dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode AND ProductName Like '%" + txtSearch.Text + "%'", con);


                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);


                searchRst.DataSource = ds.Tables[0].DefaultView;

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {

                    txtICode.Text = rd[0].ToString();
                    txtPName.Text = rd[1].ToString();
                    txtStock.Text = rd[5].ToString();
                    txtPrice.Text = rd[3].ToString();
                    txtDesc.Text = rd[2].ToString();

                    clsRetrievImage.retrieveImage(avatar, rd[4].ToString());

                    if (Convert.ToDouble(txtStock.Text) <= 0)
                    {
                        txtSalesQ.Text = "";
                        txtSalesQ.Enabled = false;
                        soldOut.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\nomore.avt");
                        soldOut.Visible = true;
                    }
                    else
                    {
                        txtSalesQ.Text = "1";
                        txtSalesQ.Enabled = true;
                        soldOut.Visible = false;
                    }

                }

                con.Close();
       
            }
            catch (OleDbException ex)
            {

                MessageBox.Show("Character not supported!");
                txtSearch.Clear();

            }
         
        }

    
           
        private void txtSalesQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.integersOnly(sender, e);
        }

        private void txtTAX_KeyPress(object sender, KeyPressEventArgs e)
        {

            inputValidation.withDecimalPoints(sender, e);
        }

        private void txtAmtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void txtTotalSales_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage(this,new frmPlaceOrder());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("",this,new frmCustomerProfileEntry());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth(this,new frmStockMgmt());
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            clsProgressIndicator.timerOps(guna2WinProgressIndicator1, timer1);


        }

   
        private void payMethCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnViewQuot.Enabled = false;
            btnPerformSale.Enabled = false;
            txtAmtPaid.Enabled = false;
            txtDiscount.Text = "0.00";
            txtTAX.Text = "0.00";
            txtTAXAmount.Text = "0.00";
            txtDiscountA.Text = "0.00";
            txtAmtPaid.Text = "0.00";
            txtChange.Text = "0.00";
            txtTotalSales.Text = "0.00";



            if (payMethCombo.SelectedIndex == 0)
            {
                txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtRTGSCSH.Text));

            }
            else if (payMethCombo.SelectedIndex == 1)
            {
                txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtRANDCSH.Text));

            }
            else if (payMethCombo.SelectedIndex == 2)
            {
                txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtUSDBNK.Text));

            }
            else if (payMethCombo.SelectedIndex == 3)
            {
                txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtRTGSBNK.Text));

            }
            else if (payMethCombo.SelectedIndex == 4)
            {
                txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtRTGSECO.Text));

            }
            else if (payMethCombo.SelectedIndex == 5)
            {
                txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtUSDECO.Text));

            }
            else if (payMethCombo.SelectedIndex == 6)
            {
                txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(USDCASH));

            }



       
      
         
         //   txtSearch.Focus();
        }

        private void customerMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("",this,new frmReceiveOrders());

        }

        private void tAXReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
         

        }

        private void placeAnOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage("",this,new frmPlaceOrder());
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createQuotation();
        }

        private void ratesExceptionsToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {



        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            
            clsAuthenticity.getPage(this,new frmLogin(""));

        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("", this, new frmRegistration());

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void configureRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            clsAuthenticity.getAuth(this, new frmRateControl());
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage(this,new frmSecurityConfirmationU());
        }

        private void loginDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth(this,new frmAccountMgmt());
        }

        private void explorerBranchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth(this,new frmBranchMenu());
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
      
        }

        private void viewAllOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("",this,new frmCreateOrder());
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
         
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage(this,new frmCreateQuotation());
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth( this, new frmCustomerMainMenu());
        }

        private void generalSalesRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth(this, new frmSalesRecords());
        }

        private void frmSalesMenu_FormClosed(object sender, FormClosedEventArgs e)
        {

            string combinedtimeString = Convert.ToString(hrs + timeSeparator + mins);

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Update dtb_Shifts_rws Set EndTime = '" + System.DateTime.Now.ToShortTimeString() + "' Where OperatorName = '" + toolStripStatusLabel2.Text + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();

                Application.Restart();
                

            }
            catch (Exception exLWE)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1LWE");
            }
          

        }

        private void btnAddToCart_MouseHover_1(object sender, EventArgs e)
        {
            btnAddToCart.ImageSize = new Size(0, 0);


        }

        private void btnAddToCart_MouseLeave_1(object sender, EventArgs e)
        {
            btnAddToCart.ImageSize = new Size(23, 20);

        }

        private double subTotal()
        {
            int i = 0;
            double subTot = 0.00;

            for (i = 0; i <= listView1.Items.Count - 1; i++)
            {
                subTot = Convert.ToDouble(listView1.Items[i].SubItems[4].Text);
            }


            return subTot;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
   
               }

        private void oFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsAuthenticity.userRight == "Admin")
            {
                clsSystemTray.turnOFF();
            }
            else
            {
                MessageBox.Show("You do not have the authority  to do that!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
    

        }

        private void searchRst_MouseMove(object sender, MouseEventArgs e)
        {
      

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtbProductsrwsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
            previewAvatar previewAvatarInst = new previewAvatar(avatar.Image,txtPrice.Text);
            previewAvatarInst.ShowDialog(this);
        }

        private void avatar_MouseHover(object sender, EventArgs e)
        {

            avatar.BackColor = Color.LightGray;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void searchRst_Click(object sender, EventArgs e)
        {

          

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity From dtb_Products_rws,dtb_currentStock_rws Where dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode AND ProductName = @v1", con);
                cmd.Parameters.AddWithValue("v1", searchRst.SelectedCells[0].Value.ToString());

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtICode.Text = rd[0].ToString();
                    txtPName.Text = rd[1].ToString();
                    txtStock.Text = rd[5].ToString();
                    txtPrice.Text = rd[3].ToString();
                    txtDesc.Text = rd[2].ToString();

                    clsRetrievImage.retrieveImage(avatar, rd[4].ToString());

                    if (Convert.ToDouble(txtStock.Text) <= 0)
                    {
                        txtSalesQ.Text = "";
                        txtSalesQ.Enabled = false;
                        soldOut.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\nomore.avt");
                        soldOut.Visible = true;
                    }
                    else
                    {
                        txtSalesQ.Text = "1";
                        txtSalesQ.Enabled = true;
                        soldOut.Visible = false;
                    }

                }

                con.Close();


                txtSearch.Focus();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Issue key: 0x31");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
         
        }

        private void txtSalesQ_Click(object sender, EventArgs e)
        {
            txtSalesQ.Clear();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
        
        }

        private void calculations()
        {

           

           

            if (txtTAX.Text != "")
            {
       
           

            }
            if (txtDiscount.Text != "")
            {
        
         
            }


     



        }

        private void btnPerformSale_Click(object sender, EventArgs e)
        {
       
            if(txtAmtPaid.Text == "")
            {
                MessageBox.Show("Invalid input!");
                gunaTransition4.HideSync(txtAmtPaid);
                gunaTransition4.ShowSync(txtAmtPaid);
                txtAmtPaid.Focus();
                return;
            }

            if(Convert.ToDouble(txtAmtPaid.Text) < Convert.ToDouble(txtTotalSales.Text))
            {
                MessageBox.Show("Process failed due to insufficient amount provided!");
                gunaTransition4.HideSync(txtAmtPaid);
                gunaTransition4.ShowSync(txtAmtPaid);
                txtAmtPaid.Focus(); 
            }
            else
            {

                int invoiceNum = clsKeyGen.InvoiceGen();
                double placeholder = 0.00;


                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    string query = "insert Into dtb_InvoiceInfo_rws(InvoiceNo,InvoiceDate,CustomerID,SubTotal,VATPer,VATAmount,DiscountPer,DiscountAmount,Status,AmountPaid,TotalPayment,PaymentType,PaymentDue,DueDate,OperatorName,OperatorID,TransTime) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@15,@16,@17)";
                    cmd = new OleDbCommand(query);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", invoiceNum);
                    cmd.Parameters.AddWithValue("@d2", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@d3", "n/a");
                    cmd.Parameters.AddWithValue("@d4", Convert.ToDouble(txtSubTotal.Text));
                    cmd.Parameters.AddWithValue("@d5", Convert.ToDouble(txtTAX.Text));
                    cmd.Parameters.AddWithValue("@d6", Convert.ToDouble(txtTAXAmount.Text));
                    cmd.Parameters.AddWithValue("@d7", Convert.ToDouble(txtDiscount.Text));
                    cmd.Parameters.AddWithValue("@d8", Convert.ToDouble(txtDiscountA.Text));
                    cmd.Parameters.AddWithValue("@d9", "Balanced");
                    cmd.Parameters.AddWithValue("@d10", Convert.ToDouble(txtAmtPaid.Text));
                    cmd.Parameters.AddWithValue("@d11", Convert.ToDouble(txtTotalSales.Text));
                    cmd.Parameters.AddWithValue("@d12", payMethCombo.Text);
                    cmd.Parameters.AddWithValue("@d13", placeholder);
                    cmd.Parameters.AddWithValue("@d14", toolStripStatusLabel4.Text);
                    cmd.Parameters.AddWithValue("@d15", toolStripStatusLabel2.Text);
                    cmd.Parameters.AddWithValue("@d16", clsAuthenticity.userID);
                    cmd.Parameters.AddWithValue("@d17", DateTime.Now.ToShortTimeString());
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error occurred. Issue key: 0x21");
                    return;
                }



                try
                {
                    for (int i = 0; i <= listView1.Items.Count - 1; i++)
                    {
                        con = new OleDbConnection(connectionString.DBConn);

                        string query2 = "insert Into dtb_ProductsSold_rws(InvoiceNo,CustomerID,ProductCode,ProductName,Price,Quantity,TotalAmount) VALUES (@d1,@d3,@d4,@d5,@d6,@d7,@d8)";
                        cmd = new OleDbCommand(query2);
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@d1", invoiceNum);
                        cmd.Parameters.AddWithValue("@d3", "n/a");
                        cmd.Parameters.AddWithValue("@d4", listView1.Items[i].SubItems[0].Text);
                        cmd.Parameters.AddWithValue("@d5", listView1.Items[i].SubItems[1].Text);
                        cmd.Parameters.AddWithValue("@d6", listView1.Items[i].SubItems[3].Text);
                        cmd.Parameters.AddWithValue("@d7", listView1.Items[i].SubItems[2].Text);
                        cmd.Parameters.AddWithValue("@d8", listView1.Items[i].SubItems[4].Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error occurred. Issue key: 0x12");
                    return;
                }


                try
                {
                    for (int i = 0; i <= listView1.Items.Count - 1; i++)
                    {
                        con = new OleDbConnection(connectionString.DBConn);
                        con.Open();
                        string query3 = "update dtb_currentStock_rws set Quantity = Quantity - " + listView1.Items[i].SubItems[2].Text + " Where ProductCode= '" + listView1.Items[i].SubItems[0].Text + "'";
                        cmd = new OleDbCommand(query3);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error occurred. Issue key: 0x22");
                }
          
             
                MessageBox.Show("Transaction Complete", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            }

            txtSearch.Focus();
        }

        private void txtAmtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAmtPaid.Text == ".")
                {
                    txtAmtPaid.Text = "";
                }

                if (txtAmtPaid.Text != "")
                {

                    if (Convert.ToDouble(txtAmtPaid.Text) > 0)
                    {
                        if (Convert.ToDouble(txtAmtPaid.Text) > Convert.ToDouble(txtTotalSales.Text))
                        {
                            remainda = Convert.ToDouble(txtAmtPaid.Text) - Convert.ToDouble(txtTotalSales.Text);
                            txtChange.Text = remainda.ToString();
                        }

                        if (Convert.ToDouble(txtAmtPaid.Text) < Convert.ToDouble(txtTotalSales.Text))
                        {

                            txtChange.Text = "0.00";
                        }

                    }
                }  
      
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred. Issue key: 0x23");
            }
          
        }

        private void txtSalesQ_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtSalesQ_MouseLeave(object sender, EventArgs e)
        {
            if (txtSalesQ.Text == "")
            {
                Convert.ToInt32(txtSalesQ.Text == "0");
            }
        }

        private void txtTAX_TextChanged(object sender, EventArgs e)
        {
            txtTotalSales.Text = "0.00";
            txtTAXAmount.Text = "0.00";
            txtAmtPaid.Text = "0.00";
            txtAmtPaid.Enabled = false;
            btnPerformSale.Enabled = false;
            btnViewQuot.Enabled = false;
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            txtTotalSales.Text = "0.00";
            txtDiscountA.Text = "0.00";
            txtAmtPaid.Text = "0.00";
            txtAmtPaid.Enabled = false;
            btnPerformSale.Enabled = false;
            btnViewQuot.Enabled = false;
        }

        private void calTAX()
        {

            try
            {
                if (txtTAX.Text == ".")
                {

                    txtTAXAmount.Text = "0.00";
                    txtTAX.Text = "";
                    return;
                }

                if (txtTAX.Text == "")
                {

                    txtTAXAmount.Text = "0.00";
                    txtTAX.Text = "";
                    return;
                }

                if (Convert.ToDouble(txtTAX.Text) <= 0)
                {
                    txtTAXAmount.Text = "0.00";
                    return;
                }

                if (Convert.ToDouble(txtSubTotal.Text) > 0)
                {

                    double num = 0.00;

                    double.TryParse(txtTAX.Text, out num);




                    if (num <= 100)
                    {
                        txtTAXAmount.Text = "0.00";

                        if (num > 0.0)
                        {
                            afterTax = (tot * num) / 100;
                        }
                        else
                        {
                            afterTax = (tot * 1) / 100;
                        }

                        afterAll = afterTax;
                        txtTAXAmount.Text = Convert.ToString(afterAll);
                        tot += Convert.ToDouble(txtTAXAmount.Text);


                    }
                    else
                    {
                        MessageBox.Show("TAX input value cannot be greater than 100", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTAX.Clear();
                        txtDiscount.Focus();


                    }

                }
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Issue key: 0x24");
            }
         
        }

        private void calDiscount()
        {
            try
            {
                if (txtDiscount.Text == ".")
                {
                    txtDiscount.Text = "";
                    return;
                }

                if (txtDiscount.Text == "")
                {

                    txtDiscountA.Text = "0.00";
                    txtDiscount.Text = "";
                    return;
                }

                if (Convert.ToDouble(txtDiscount.Text) <= 0)
                {
                    txtDiscountA.Text = "0.00";
                    return;
                }


                if (Convert.ToDouble(txtSubTotal.Text) > 0)
                {
                    double num = 0.00;
                    double.TryParse(txtDiscount.Text, out num);

                    if (num <= 100)
                    {
                        txtDiscountA.Text = "0.00";

                        if (num > 0.0)
                        {
                            afterDisc = (afterTax * num) / 100;
                        }
                        else
                        {
                            afterDisc = (afterTax * 1) / 100;
                        }

                        afterAll = afterDisc;
                        txtDiscountA.Text = Convert.ToString(afterAll);
                        tot -= Convert.ToDouble(txtDiscountA.Text);


                    }
                    else
                    {
                        MessageBox.Show("Discount input value cannot be greater than 100", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDiscount.Clear();
                        txtDiscount.Focus();

                    }

                }
           
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred. Issue key: 0x25");
            }
           
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtSubTotal.Text) > 0)
                {
                    gunaTransition3.HideSync(txtSubTotal);

                    txtTAX.Enabled = true;
                    txtDiscount.Enabled = true;
                    payMethCombo.Enabled = true;
                    btnCal.Enabled = true;

                    gunaTransition3.ShowSync(txtSubTotal);
                }
                else
                {
                    txtTAX.Enabled = false;
                    txtDiscount.Enabled = false;

                }

                if (Convert.ToDouble(txtSubTotal.Text) <= 0)
                {
                    txtTAX.Enabled = false;
                    txtDiscount.Enabled = false;
                    txtDiscount.Text = "0.00";
                    txtTAX.Text = "0.00";
                    txtTAXAmount.Text = "0.00";
                    txtDiscountA.Text = "0.00";
                    txtAmtPaid.Text = "0.00";
                    txtChange.Text = "0.00";
                    txtTotalSales.Text = "0.00";
                    txtAmtPaid.Enabled = false;
                    btnViewQuot.Enabled = false;
                    btnPerformSale.Enabled = false;
                    payMethCombo.Enabled = false;
                    btnCal.Enabled = false;
                    btnViewQuot.Enabled = false;
                    ViewSaleAsQuotation.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred. Issue key: 0x26");
            }
            
            
        }

        private void txtSalesQ_DoubleClick(object sender, EventArgs e)
        {
            txtSalesQ.Clear();

        }

        private void txtSalesQ_MouseClick(object sender, MouseEventArgs e)
        {
            txtSalesQ.Clear();
        }

        private void txtSalesQ_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtSalesQ.Clear();
        }

        private void txtTotalSales_TextChanged(object sender, EventArgs e)
        {
            gunaTransition3.HideSync(txtTotalSales);
            gunaTransition3.ShowSync(txtTotalSales);
        }

        private void btnViewQuot_Click(object sender, EventArgs e)
        {
            createQuotation();
        }

       private void createQuotation()
        {
            transListView = listView1;
            paymentMethod = payMethCombo.Text;
            ItTotalCost = Convert.ToDouble(txtTotalSales.Text);
            tellerName = toolStripStatusLabel2.Text;
            qTAX = Convert.ToDouble(txtTAX.Text);
            qDiscount = Convert.ToDouble(txtDiscount.Text);
            clsAuthenticity.getPage("", this, new frmQuotation(this.salesDetails));
            txtSearch.Focus();
        }

        private void txtAmtPaid_Click(object sender, EventArgs e)
        {
    
            txtAmtPaid.Clear();

        }

        private void txtAmtPaid_MouseClick(object sender, MouseEventArgs e)
        {
            txtAmtPaid.Clear();

        }

        private void txtAmtPaid_DoubleClick(object sender, EventArgs e)
        {
            txtAmtPaid.Clear();

        }

        private void txtTAX_Click(object sender, EventArgs e)
        {
            txtTAX.Clear();

        }

        private void txtTAX_MouseClick(object sender, MouseEventArgs e)
        {
            txtTAX.Clear();

        }

        private void txtTAX_DoubleClick(object sender, EventArgs e)
        {
            txtTAX.Clear();

        }

        private void txtDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            txtDiscount.Clear();

        }

        private void txtDiscount_DoubleClick(object sender, EventArgs e)
        {
            txtDiscount.Clear();

        }

        private void txtDiscount_Click(object sender, EventArgs e)
        {
            txtDiscount.Clear();

        }

        private void txtTAX_Leave(object sender, EventArgs e)
        {
            if(txtTAX.Text == "")
            {
                txtTAX.Text = "0.00";

            }
        }

        private void txtTAX_MouseLeave(object sender, EventArgs e)
        {
            if (txtTAX.Text == "")
            {
                txtTAX.Text = "0.00";

            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0.00";

            }
        }

        private void txtAmtPaid_Leave(object sender, EventArgs e)
        {

           

            if(txtAmtPaid.Text == "")
            {
                txtAmtPaid.Text = "0.00";

            }


        }

        private void txtAmtPaid_MouseLeave(object sender, EventArgs e)
        {
            if (txtAmtPaid.Text == "")
            {
                txtAmtPaid.Text = "0.00";

            }
        }

        private void txtDiscount_MouseLeave(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0.00";

            }
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void oNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsAuthenticity.userRight == "Admin")
            {
                 clsSystemTray.turnON();
            } else
            {
                MessageBox.Show("You do not have the authority to do that!","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
           
      
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth(this, new frmSuppliersMainMenu());
        }

        private void FrmSalesMenu_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void DailySalesRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();



            try
            {

                cmd = new OleDbCommand("Select distinct dtb_InvoiceInfo_rws.OperatorID,dtb_InvoiceInfo_rws.OperatorName,InvoiceDate From dtb_Shifts_rws,dtb_InvoiceInfo_rws Where dtb_InvoiceInfo_rws.OperatorID  = dtb_Shifts_rws.OperatorID And dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);
                rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    clsAuthenticity.getAuth(this, new frmDailySalesRecords());

                }
                else
                {
                  
                    MessageBox.Show("No sales have been peformed today!");

                }


                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred. Issue key: 0x27");
                return;
            }


         
        }

        private void ViewReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select InvoiceNo, CustomerID, VATAmount, TotalPayment, PaymentDue, DiscountAmount, AmountPaid From dtb_InvoiceInfo_rws Where dtb_InvoiceInfo_rws.OperatorID = '" + clsAuthenticity.userID + "' And dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);
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
                    rptUserDailyCashSalesReport theReport = new rptUserDailyCashSalesReport();

                    
                        DataSet rptDtb = new DataSet();

                    adp = new OleDbDataAdapter(cmd);
                    adp.Fill(rptDtb);

                        theReport.Database.Tables["Sales"].SetDataSource(rptDtb.Tables[0]);
                      //  frmUserDailySalesReport frm = new frmUserDailySalesReport();

                        frmUserDailyCashSalesReport frm = new frmUserDailyCashSalesReport();


                        TextObject totalSum = (TextObject)theReport.ReportDefinition.Sections["Section4"].ReportObjects["txtSum"];
                        TextObject txtTeller = (TextObject)theReport.ReportDefinition.Sections["Section2"].ReportObjects["txtTeller"];
                        totalSum.Text = addUp.ToString();
                        txtTeller.Text = clsAuthenticity.username;

                        frm .crystalReportViewer1.ReportSource = null;
                        frm.crystalReportViewer1.ReportSource = theReport;
                        frm.Visible = true;
               



                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("An error occurred. Issue key: 0x28");
               
                    }

                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            else
            {

                MessageBox.Show("User hasn't sold anything today!");

            }

            con.Close();


        }

        private void shiftSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    rptUserDailySalesReport theReport = new rptUserDailySalesReport();

                    //The report you created.
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("Select dtb_ProductsSold_rws.InvoiceNo, ProductCode, ProductName, Price, Quantity, TotalAmount, dtb_ProductsSold_rws.CustomerID From dtb_ProductsSold_rws,dtb_InvoiceInfo_rws Where dtb_ProductsSold_rws.InvoiceNo = dtb_InvoiceInfo_rws.InvoiceNo And dtb_InvoiceInfo_rws.OperatorID = '" + clsAuthenticity.userID + "' And dtb_InvoiceInfo_rws.InvoiceDate = '" + dateTimePicker1.Text + "'", con);
                    //      cmd.ExecuteNonQuery();

                    // ds = new DataSet();
                    DataTable dtb = new DataTable();

                    adp = new OleDbDataAdapter(cmd);

                    adp.Fill(dtb);


                    theReport.Database.Tables["UserDailySales"].SetDataSource(dtb);

                    frmUserDailySalesReport frm = new frmUserDailySalesReport();

                    TextObject txtUser = (TextObject)theReport.ReportDefinition.Sections["Section2"].ReportObjects["txtUser"];
                    txtUser.Text = clsAuthenticity.username;


                    frm.crystalReportViewer1.ReportSource = null;
                    frm.crystalReportViewer1.ReportSource = theReport;
                    frm.Visible = true;
                    con.Close();
                    con.Dispose();

                }
                catch (NullReferenceException exREF)
                {

                    MessageBox.Show("No sales found for this User!");
                }
            
            }
            catch (Exception ex)
            {
               MessageBox.Show("An error occurred. Issue key: 0x29");
            
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
           
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void SettingstoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth(this,new frmSettings());
        }

        private void DDR()
        {
            try
            {
              
                    string OnOff = File.ReadAllText(filePathDDR);

                    if (OnOff == "1")
                    {
                        panel1.Visible = true;
                        lblHeader.Visible = false;

                    }
                    else if (OnOff == "0")
                    {
                       panel1.Visible = false;
                       lblHeader.Visible = true;
                    }
                    else
                    {
                        //WHEN THE TEXT CONTENT IS NOT RECOGNISED(NOT 1 or 0)
                        MessageBox.Show("Some system files are damaged, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        File.WriteAllText(filePathDDR, "1");
                        Application.Restart();
                    }

            }
            catch (FileNotFoundException ex1)
            {
                //WHEN THE FILE GETS DELETED OR MISSING
                MessageBox.Show("Some system files are missing, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.WriteAllText(filePathDDR, "1");
                Application.Restart();

            }
        }

        private void EMC()
        {
            try
            {

                string OnOff = File.ReadAllText(filePathEMC);

                if (OnOff == "1")
                {
                    label8.Visible = true;
                    payMethCombo.Visible = true;

                }
                else if (OnOff == "0")
                {
                    label8.Visible = false;
                    payMethCombo.Visible = false;
                }
                else
                {
                    //WHEN THE TEXT CONTENT IS NOT RECOGNISED(NOT 1 or 0)
                    MessageBox.Show("Some system files are damaged, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.WriteAllText(filePathEMC, "1");
                    Application.Restart();
                }

            }
            catch (FileNotFoundException ex1)
            {
                //WHEN THE FILE GETS DELETED OR MISSING
                MessageBox.Show("Some system files are missing, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.WriteAllText(filePathEMC, "1");
                Application.Restart();

            }
        }



        private void frmSalesMenu_Validated(object sender, EventArgs e)
        {

        }

        private void frmSalesMenu_Shown(object sender, EventArgs e)
        {
          
        }

        private void frmSalesMenu_Activated(object sender, EventArgs e)
        {

        }

        private void guna2Transition2_AnimationCompleted(object sender, Guna.UI2.AnimatorNS.AnimationCompletedEventArg e)
        {
          
        }

        private void guna2Transition1_AnimationCompleted(object sender, Guna.UI2.AnimatorNS.AnimationCompletedEventArg e)
        {
       
        }

        private void CompanyLogo_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            toolStripStatusLabel4.Text = dateTimePicker1.Text;

  

            foreach (Control con in panel1.Controls)
            {
                if (con.ForeColor == Color.Lime)
                {
                    con.ForeColor = Color.Red;

                } 
                else if (con.ForeColor == Color.Red)
                {
                    con.ForeColor = Color.Lime;
                }


            }


           
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender,e);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

          

            try
            {

                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("There are no selected items to delete!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    try
                    {
                        double getCellValue = Convert.ToDouble(listView1.SelectedItems[0].SubItems[2].Text);
                        totalItems -= getCellValue;
                        btnOrderCount.Text = totalItems.ToString();

                    }
                    catch (ArgumentOutOfRangeException ex)
                    {

                        return;
                    }

                    double holder = 0.00;
                    double.TryParse(listView1.SelectedItems[0].SubItems[4].Text, out holder);
                    listView1.SelectedItems[0].Remove();

                    //RESET CURRENCY CONVERSION
                    payMethCombo.Text = payMethCombo.Items[6].ToString();
                    toolTip1.Show("Reselect Payment Method!", payMethCombo, 5000);
                    txtSubTotal.Text = Convert.ToString(totAmt - holder);
                    double.TryParse(txtSubTotal.Text, out totAmt);
                    double.TryParse(txtSubTotal.Text, out tot); //Suspect!!!

                
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                //MessageBox.Show("Could not complete requested task! Issue Key: ex001", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            animatePromotion();

            txtSearch.Focus();

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {

     
            try
            {
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("There are no items to clear on list!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    gunaTransition4.HideSync(groupBox1);
                    gunaTransition4.HideSync(groupBox7);
                    gunaTransition4.HideSync(listView1);

                    listView1.Items.Clear();
                    payMethCombo.Text = payMethCombo.Items[6].ToString();
                    tot = 0;
                    totAmt = 0;
                    txtSubTotal.Text = "0.00";
                    totalItems = 0;
                    btnOrderCount.Text = "0";

                    gunaTransition4.ShowSync(listView1);
                    gunaTransition4.ShowSync(groupBox1);
                    gunaTransition4.ShowSync(groupBox7);
                }

           
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Issue key: 0x32");

            }

            animatePromotion();

            txtSearch.Focus();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            try
            {
                txtAmtPaid.Enabled = true;
                btnViewQuot.Enabled = true;
                ViewSaleAsQuotation.Enabled = true;
                btnPerformSale.Enabled = true;
                txtAmtPaid.Text = "0.00";
                txtChange.Text = "0.00";

                if (payMethCombo.SelectedIndex == 0)
                {
                    txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtRTGSCSH.Text));
                    tot = totAmt * Convert.ToDouble(txtRTGSCSH.Text);
                    calTAX();
                    calDiscount();
                    txtTotalSales.Text = Convert.ToString(tot);

                }
                else if (payMethCombo.SelectedIndex == 1)
                {
                    txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtRANDCSH.Text));
                    tot = totAmt * Convert.ToDouble(txtRANDCSH.Text);
                    calTAX();
                    calDiscount();
                    txtTotalSales.Text = Convert.ToString(tot);

                }
                else if (payMethCombo.SelectedIndex == 2)
                {
                    txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtUSDBNK.Text));
                    tot = totAmt * Convert.ToDouble(txtUSDBNK.Text);
                    calTAX();
                    calDiscount();
                    txtTotalSales.Text = Convert.ToString(tot);

                }
                else if (payMethCombo.SelectedIndex == 3)
                {
                    txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtRTGSBNK.Text));
                    tot = totAmt * Convert.ToDouble(txtRTGSBNK.Text);
                    calTAX();
                    calDiscount();
                    txtTotalSales.Text = Convert.ToString(tot);

                }
                else if (payMethCombo.SelectedIndex == 4)
                {
                    txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtRTGSECO.Text));
                    tot = totAmt * Convert.ToDouble(txtRTGSECO.Text);
                    calTAX();
                    calDiscount();
                    txtTotalSales.Text = Convert.ToString(tot);

                }
                else if (payMethCombo.SelectedIndex == 5)
                {
                    txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(txtUSDECO.Text));
                    tot = totAmt * Convert.ToDouble(txtUSDECO.Text);
                    calTAX();
                    calDiscount();
                    txtTotalSales.Text = Convert.ToString(tot);

                }
                else if (payMethCombo.SelectedIndex == 6)
                {
                    txtSubTotal.Text = Convert.ToString(totAmt * Convert.ToDouble(USDCASH));
                    tot = totAmt * Convert.ToDouble(USDCASH);
                    calTAX();
                    calDiscount();
                    txtTotalSales.Text = Convert.ToString(tot);

                }

             

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Issue key: 0x38");
            }

            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            transListView = listView1;
            paymentMethod = payMethCombo.Text;
            ItTotalCost = Convert.ToDouble(txtTotalSales.Text);
            tellerName = toolStripStatusLabel2.Text;
            qTAX = Convert.ToDouble(txtTAX.Text);
            qDiscount = Convert.ToDouble(txtDiscount.Text);
            clsAuthenticity.getPage("", this, new frmQuotation(this.salesDetails));
            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {

        

            btnViewQuot.Enabled = false;
            btnPerformSale.Enabled = false;
            txtAmtPaid.Enabled = false;
            txtDiscount.Text = "0.00";
            txtTAX.Text = "0.00";
            txtTAXAmount.Text = "0.00";
            txtDiscountA.Text = "0.00";
            txtAmtPaid.Text = "0.00";
            txtChange.Text = "0.00";
            txtTotalSales.Text = "0.00";

            try
            {
                if (txtSalesQ.Text == "")
                {
                    MessageBox.Show("Please enter item quantity!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSalesQ.Focus();
                    return;
                }
                int SaleQty = Convert.ToInt32(txtSalesQ.Text);
                if (SaleQty == 0)
                {
                    MessageBox.Show("Number of item quantity can not be zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSalesQ.Focus();
                    return;
                }

                gunaTransition3.HideSync(btnOrderCount);
             
                totalItems += Convert.ToDouble(txtSalesQ.Text);
                btnOrderCount.Text = totalItems.ToString();

                gunaTransition3.ShowSync(btnOrderCount);

                ListViewItem lst = new ListViewItem(txtICode.Text);
                lst.SubItems.Add(txtPName.Text);
                lst.SubItems.Add(txtSalesQ.Text);
                lst.SubItems.Add(txtPrice.Text);
                lst.SubItems.Add(Convert.ToString(Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtSalesQ.Text)));
                listView1.Items.Add(lst);

                Convert.ToDouble(txtSalesQ.Text = "1");



                //  double.TryParse(txtSubTotal.Text, out holder);
                //   payMethCombo.Items.Clear();
                //    getRates();
                payMethCombo.Text = payMethCombo.Items[6].ToString();
                holder = totAmt;
                totAmt = subTotal() + holder;
                txtSubTotal.Text = Convert.ToString(totAmt);
                double.TryParse(txtSubTotal.Text, out tot);
                Convert.ToInt32(txtSalesQ.Text = "1");

                animatePromotion();
              
                txtSearch.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Issue key: 0x43");
            }
          
        }

        private void tYPICALCUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void nEWCUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void guna2GradientButton1_Click_2(object sender, EventArgs e)
        {
      
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
      
        }

        private void guna2GradientButton1_Click_3(object sender, EventArgs e)
        {
            clsAuthenticity.getPage("", this, new frmPlaceOrder());
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("", this, new frmCustomerProfileEntry());
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void onscreenkeyboard_Click(object sender, EventArgs e)
        {
            clsOnScreenKeyboard.openKeyboard();
        }

        private void btnOrderCount_TextChanged(object sender, EventArgs e)
        {
        
      
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

       

        }

        private void animatePromotion()
        {
            guna2Transition1.HideSync(label25);
            guna2Transition1.ShowSync(label25);
        }

        private void dtbProductsrwsBindingSource_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void searchRst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
