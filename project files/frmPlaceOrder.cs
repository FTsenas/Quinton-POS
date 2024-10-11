using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipt_val_fl;
using System.Data.OleDb;
using System.IO;



namespace QuintonPOS
{
    public partial class frmPlaceOrder : Form
    {
        public frmPlaceOrder()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;


            gunaTransition1.AddToQueue(avatar, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtRTGSCSH, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtRANDCSH, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtUSDBNK, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtRTGSBNK, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtRTGSECO, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtUSDECO, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(groupBox1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(btnAddToCart, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(btnPlaceOrder, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(btnViewQuot, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(groupBox6, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(txtDueDate, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(label16, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(groupBox7, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition2.AddToQueue(listView1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(searchRst, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(guna2GradientPanel2, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(txtSearch, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label3, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label9, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label14, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label4, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(label15, Guna.UI.Animation.AnimateMode.Show, true);



        }


        #region FilePathz

        private static string filePathDDR = Application.StartupPath + "//qpos_DDR.ini";
        private static string filePathEMC = Application.StartupPath + "//qpos_EMC.ini";

        #endregion


        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

        #region Quotation

        public static ListView transListView = new ListView();
        public static string paymentMethod = "";
        public static double ItTotalCost = 0.00;
        public static string tellerName = "";
        public static double qTAX = 0.00;
        public static double qDiscount = 0.00;
        public static string customerName = "";


        #endregion

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
        double totalItems = 0;

        string USDCASH = "";

        String status = "";
        double payDue = 0.00;



          List<string> custIDs = new List<string>();
          List<string> salesDetails = new List<string>();

        private void frmPlaceOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSDataSet.dtb_Products_rws' table. You can move, or remove it, as needed.
        

            DateTime dt = new DateTime();
            dt = System.DateTime.Now;
            
            txtDueDate.Value = dt.Date; 

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
                    soldOut.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\nomore.avt");
                    soldOut.Visible = true;
                }
                else
                {
                    txtSalesQ.Text = "1";
                    txtSalesQ.Enabled = true;
                    soldOut.Visible = false;
                }

            }

            getCustomers();
            con.Close();

            DDR();
            EMC();
     

        }

    

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            clsProgressIndicator.timerOps(guna2WinProgressIndicator1,timer1);
        }

        private void payMethCombo_KeyUp(object sender, KeyEventArgs e)
        {
            clsComboRestrict.comboBoxMgmt(payMethCombo, Convert.ToString(payMethCombo.Items[0]));

        }


        private void getRates()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();



            //ZWL RTGS CASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'ZWL_RTGS_CASH'", con);
            rd = cmd.ExecuteReader();


            if (rd.Read() == true)
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


        private void guna2Button5_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage(this, new frmLogin(""));
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage(this, new frmSalesMenu());
        }

        private void txtSalesQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.integersOnly(sender, e);
        }

        private void txtTAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void txtAmtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();


            try
            {
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
                        soldOut.Image = Image.FromFile("C:\\Users\\QUINTON\\Desktop\\items\\nomore.png");
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



        private void frmPlaceOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
          

        }

        private void avatar_Click(object sender, EventArgs e)
        {
            previewAvatar previewAvatarInst = new previewAvatar(avatar.Image,txtPrice.Text);
            previewAvatarInst.ShowDialog(this);
        }

        private void searchRst_Click(object sender, EventArgs e)
        {

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();
           
              //  cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity From dtb_Products_rws,dtb_currentStock_rws Where dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode AND ProductName = '" + searchRst.SelectedCells[0].Value.ToString() + "'", con);

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
                    soldOut.Image = Image.FromFile("C:\\Users\\QUINTON\\Desktop\\items\\nomore.png");
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


        private void guna2Button3_Click(object sender, EventArgs e)
        {

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

        private void txtSalesQ_MouseLeave(object sender, EventArgs e)
        {
            if (txtSalesQ.Text == "")
            {
                Convert.ToInt32(txtSalesQ.Text == "0");
            }
        }

        private void txtSalesQ_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtSalesQ.Clear();
        }

        private void txtSalesQ_MouseClick(object sender, MouseEventArgs e)
        {
            txtSalesQ.Clear();
        }

        private void txtSalesQ_Leave(object sender, EventArgs e)
        {
            if (txtSalesQ.Text == "")
            {
                Convert.ToInt32(txtSalesQ.Text == "0");
            }
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtSubTotal.Text) > 0)
            {
                gunaTransition3.HideSync(txtSubTotal);

                txtTAX.Enabled = true;
                txtDiscount.Enabled = true;
                payMethCombo.Enabled = true;
                txtDueDate.Enabled = true;
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
                btnPlaceOrder.Enabled = false;
                payMethCombo.Enabled = false;
                txtDueDate.Enabled = false;
                btnCal.Enabled = false;

            }
        }

        private void txtTAX_TextChanged(object sender, EventArgs e)
        {
            txtTotalSales.Text = "0.00";
            txtTAXAmount.Text = "0.00";
            txtAmtPaid.Text = "0.00";
            txtAmtPaid.Enabled = false;
            btnPlaceOrder.Enabled = false;
            btnViewQuot.Enabled = false;
        }

        private void calTAX()
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

        private void calDiscount()
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

        private void txtTAX_MouseLeave(object sender, EventArgs e)
        {
            if (txtTAX.Text == "")
            {
                txtTAX.Text = "0.00";

            }
        }

        private void txtTAX_MouseClick(object sender, MouseEventArgs e)
        {
            txtTAX.Clear();
        }

        private void txtTAX_DoubleClick(object sender, EventArgs e)
        {
            txtTAX.Clear();
        }

        private void txtTAX_Click(object sender, EventArgs e)
        {
            txtTAX.Clear();
        }

        private void txtTAX_Leave(object sender, EventArgs e)
        {
            if (txtTAX.Text == "")
            {
                txtTAX.Text = "0.00";

            }
        }

        private void getCustomers()         //METHOD TO GET PRODUCT SUPPLIER IF AVAILABLE.
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT CustomerID,CName,Address,City,Phone1,Phone2,Email,Avatar  FROM dtb_regCustomers_rws", con);
                rd = cmd.ExecuteReader();



                while (rd.Read())
                {
                    custList.Items.Add(rd[1].ToString());
                    custIDs.Add(rd[0].ToString()); //Collection of customer IDs.
                }


                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred!");
             
            }
          
        }
          


            
        
    


        private void getCustImage(PictureBox pBox, String imgName) //METHOD TO GET SUPPLIER PROFILE IMAGE IF AVAILABLE.
        {
            try
            {
                pBox.Image = Image.FromFile(clsSysFolder.cfilePath + imgName + ".avt");
            }
 catch (FileNotFoundException ex3)
            {
                pBox.Image = Image.FromFile(clsSysFolder.cfilePath + "Untitled" + ".avt");
           }

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            txtTotalSales.Text = "0.00";
            txtDiscountA.Text = "0.00";
            txtAmtPaid.Text = "0.00";
            txtAmtPaid.Enabled = false;
            btnPlaceOrder.Enabled = false;
            btnViewQuot.Enabled = false;
        }

        private void txtDiscount_MouseLeave(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0.00";

            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0.00";

            }
        }

        private void txtDiscount_Click(object sender, EventArgs e)
        {
            txtDiscount.Clear();

        }

        private void txtDiscount_DoubleClick(object sender, EventArgs e)
        {
            txtDiscount.Clear();
        }

        private void txtDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            txtDiscount.Clear();
        }

        private void txtAmtPaid_MouseClick(object sender, MouseEventArgs e)
        {
            txtAmtPaid.Clear();

        }

        private void txtAmtPaid_DoubleClick(object sender, EventArgs e)
        {
            txtAmtPaid.Clear();

        }

        private void txtAmtPaid_Click(object sender, EventArgs e)
        {
            txtAmtPaid.Clear();

        }

        private void txtAmtPaid_MouseLeave(object sender, EventArgs e)
        {
            if (txtAmtPaid.Text == "")
            {
                txtAmtPaid.Text = "0.00";

            }
        }

        private void txtAmtPaid_Leave(object sender, EventArgs e)
        {
            if (txtAmtPaid.Text == "")
            {
                txtAmtPaid.Text = "0.00";

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
        
        }

        private void clearCustomerDetails()
    {
        custList.Items.Clear();
        getCustomers();

        custAvatar.Image = null;
        txtCName.Clear();
        txtCIT.Clear();
        txtAP.Clear();
        txtADD.Clear();
        txtEM.Clear();
        txtOP.Clear();
        txtCustID.Clear();

    }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {

            if (txtAmtPaid.Text == "")
            {
                MessageBox.Show("Invalid input!");
                gunaTransition4.HideSync(txtAmtPaid);
                gunaTransition4.ShowSync(txtAmtPaid);
                txtAmtPaid.Focus();
                return;
            }


            if (custList.Text == "")
            {
       
                MessageBox.Show("Select Customer first!");
                gunaTransition4.HideSync(custList);
                gunaTransition4.ShowSync(custList);
                return;
            }

            if (Convert.ToDouble(txtAmtPaid.Text) < Convert.ToDouble(txtTotalSales.Text))
            {
                String[] statusItems = {"Balanced","Pending"};
                status = statusItems[1];
                 payDue = Convert.ToDouble(txtTotalSales.Text) - Convert.ToDouble(txtAmtPaid.Text);
            }
            else
            {
                String[] statusItems = { "Balanced", "Pending" };
                status = statusItems[0];
                payDue = 0.00;
                remainda = Convert.ToDouble(txtAmtPaid.Text) - Convert.ToDouble(txtTotalSales.Text);
                txtChange.Text = remainda.ToString();
            }

                int invoiceNum = clsKeyGen.InvoiceGen();
                double placeholder = 0;



                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                string query = "insert Into dtb_InvoiceInfo_rws(InvoiceNo,InvoiceDate,CustomerID,SubTotal,VATPer,VATAmount,DiscountPer,DiscountAmount,Status,AmountPaid,TotalPayment,PaymentType,PaymentDue,DueDate,OperatorName,OperatorID,TransTime) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@15,@16,@17)";
                cmd = new OleDbCommand(query);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", invoiceNum);
                cmd.Parameters.AddWithValue("@d2", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@d3", txtCustID.Text);
                cmd.Parameters.AddWithValue("@d4", Convert.ToDouble(txtSubTotal.Text));
                cmd.Parameters.AddWithValue("@d5", Convert.ToDouble(txtTAX.Text));
                cmd.Parameters.AddWithValue("@d6", Convert.ToDouble(txtTAXAmount.Text));
                cmd.Parameters.AddWithValue("@d7", Convert.ToDouble(txtDiscount.Text));
                cmd.Parameters.AddWithValue("@d8", Convert.ToDouble(txtDiscountA.Text));
                cmd.Parameters.AddWithValue("@d9", status);
                cmd.Parameters.AddWithValue("@d10", Convert.ToDouble(txtAmtPaid.Text));
                cmd.Parameters.AddWithValue("@d11", Convert.ToDouble(txtTotalSales.Text));
                cmd.Parameters.AddWithValue("@d12", payMethCombo.Text);
                cmd.Parameters.AddWithValue("@d13", payDue);
                cmd.Parameters.AddWithValue("@d14", txtDueDate.Text);
                cmd.Parameters.AddWithValue("@d15", toolStripStatusLabel2.Text);
            cmd.Parameters.AddWithValue("@d16", clsAuthenticity.userID);
            cmd.Parameters.AddWithValue("@d17", System.DateTime.Now.ToShortTimeString());
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();


                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    con = new OleDbConnection(connectionString.DBConn);

                    string query2 = "insert Into dtb_ProductsSold_rws(InvoiceNo,CustomerID,ProductCode,ProductName,Price,Quantity,TotalAmount) VALUES (@d1,@d3,@d4,@d5,@d6,@d7,@d8)";
                    cmd = new OleDbCommand(query2);
                    cmd.Connection = con;
                  
                    cmd.Parameters.AddWithValue("@d1", invoiceNum);
                    cmd.Parameters.AddWithValue("@d3", custIDs[custList.SelectedIndex]);
                    cmd.Parameters.AddWithValue("@d4", listView1.Items[i].SubItems[0].Text);
                    cmd.Parameters.AddWithValue("@d5", listView1.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("@d6", listView1.Items[i].SubItems[3].Text);
                    cmd.Parameters.AddWithValue("@d7", listView1.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("@d8", listView1.Items[i].SubItems[4].Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }



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


                //    GetData();
          
                MessageBox.Show("Transaction Complete", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
        }

        private void txtTAXAmount_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtTAXAmount.Text) > 0)
            {
                txtTAXAmount.Text = "0";

            }
        }

        private void txtDiscountA_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtSubTotal.Text) > 0)
            {
                txtDiscountA.Text = "0.00";

            }
            txtSearch.Focus();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (txtDueDate.Value < System.DateTime.Today.Date)
            {
                MessageBox.Show("Due date cannot be a past date!");
                txtDueDate.Value = System.DateTime.Today.Date;
       
            } 
          
            txtSearch.Focus();
        }

        private void payMethCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtAmtPaid.Enabled = false;
            btnPlaceOrder.Enabled = false;
            btnViewQuot.Enabled = false;
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


            txtSearch.Focus();
        }

        private void payMethCombo_TextChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();

        }

        private void payMethCombo_VisibleChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void btnViewQuot_Click(object sender, EventArgs e)
        {

         
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        
          
        }

        private void txtAmtPaid_TextChanged(object sender, EventArgs e)
        {
            if(txtAmtPaid.Text == ".")
            {
                txtAmtPaid.Text = "";
            }
            if(txtAmtPaid.Text != "")
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
                        payDue = Convert.ToDouble(txtTotalSales.Text) - Convert.ToDouble(txtAmtPaid.Text);
                        txtChange.Text = "0.00";
                    }
                }
            }



  

            }

        private void btnCal_Click(object sender, EventArgs e)
        {
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                    label20.Visible = true;
                    payMethCombo.Visible = true;

                }
                else if (OnOff == "0")
                {
                    label20.Visible = false;
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

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            txtDueDate.Value = DateTime.Now.Date;
            dateTimePicker1.Value = DateTime.Now.Date;
            toolStripStatusLabel4.Text = dateTimePicker1.Text;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
        
            txtAmtPaid.Enabled = false;
            btnPlaceOrder.Enabled = false;
            btnViewQuot.Enabled = false;
            txtDiscount.Text = "0.00";
            txtTAX.Text = "0.00";
            txtTAXAmount.Text = "0.00";
            txtDiscountA.Text = "0.00";
            txtAmtPaid.Text = "0.00";
            txtChange.Text = "0.00";
            txtTotalSales.Text = "0.00";

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



            ListViewItem lst = new ListViewItem(txtICode.Text);
            lst.SubItems.Add(txtPName.Text);
            lst.SubItems.Add(txtSalesQ.Text);
            lst.SubItems.Add(txtPrice.Text);
            lst.SubItems.Add(Convert.ToString(Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtSalesQ.Text)));
            listView1.Items.Add(lst);

            gunaTransition3.HideSync(btnOrderCount);
            totalItems += Convert.ToDouble(txtSalesQ.Text);
            btnOrderCount.Text = totalItems.ToString();
            gunaTransition3.ShowSync(btnOrderCount);

            Convert.ToDouble(txtSalesQ.Text = "1");

            payMethCombo.Text = payMethCombo.Items[6].ToString();
            holder = totAmt;
            totAmt = subTotal() + holder;
            txtSubTotal.Text = Convert.ToString(totAmt);
            double.TryParse(txtSubTotal.Text, out tot);
            Convert.ToInt32(txtSalesQ.Text = "1");

           

        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
    
            txtAmtPaid.Enabled = true;
            btnPlaceOrder.Enabled = true;
            btnViewQuot.Enabled = true;
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


            txtSearch.Focus();

        }

        private void guna2GradientButton1_Click_2(object sender, EventArgs e)
        {
            if (custList.Text == "")
            {
                MessageBox.Show("Select Customer first!");
                toolTip1.Show("Click the Dropdown field to select Customer.", custList, 5000);
                return;
            }

            transListView = listView1;
            paymentMethod = payMethCombo.Text;
            ItTotalCost = Convert.ToDouble(txtTotalSales.Text);
            tellerName = toolStripStatusLabel2.Text;
            qTAX = Convert.ToDouble(txtTAX.Text);
            qDiscount = Convert.ToDouble(txtDiscount.Text);
            customerName = custList.Text;
            clsAuthenticity.getPage("", this, new frmQuotation2(this.salesDetails));
            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click_3(object sender, EventArgs e)
        {
            try
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


                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("There are no selected items to delete!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    double holder = 0;
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

                MessageBox.Show("Could not complete requested task! Issue Key: ex001", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtSearch.Focus();
        

        }

        private void guna2GradientButton1_Click_4(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("There are no items to clear on list!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gunaTransition4.HideSync(groupBox1);
                gunaTransition4.HideSync(listView1);

                listView1.Items.Clear();
                payMethCombo.Text = payMethCombo.Items[6].ToString();
                txtSubTotal.Text = "0.00";
                totAmt = 0;
                tot = 0;
                btnOrderCount.Text = "0";
                clearCustomerDetails();

        
                gunaTransition4.ShowSync(listView1);
                gunaTransition4.ShowSync(groupBox1);
            }
            txtSearch.Focus();
        }

        private void custList_SelectedIndexChanged(object sender, EventArgs e)
        {

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT CustomerID,CName,Address,City,Phone1,Phone2,Email,Avatar  FROM dtb_regCustomers_rws Where CustomerID = '" + custIDs[custList.SelectedIndex] + "'", con);
            rd = cmd.ExecuteReader();


            try
            {

                if (rd.Read() == true)
                {
                    txtCustID.Text = rd[0].ToString();
                    txtCName.Text = rd[1].ToString();
                    txtADD.Text = rd[2].ToString();
                    txtCIT.Text = rd[3].ToString();
                    txtOP.Text = rd[4].ToString();
                    txtAP.Text = rd[5].ToString();
                    txtEM.Text = rd[6].ToString();

                    getCustImage(custAvatar, rd[7].ToString());

                }

                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred!");

            }
                
            
        }

        private void txtTotalSales_TextChanged(object sender, EventArgs e)
        {
            gunaTransition3.HideSync(txtTotalSales);
            gunaTransition3.ShowSync(txtTotalSales);
        }

        private void TxtRANDCSH_TextChanged(object sender, EventArgs e)
        {

        }
    }



 
    }

