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
using System.IO;

namespace QuintonPOS
{
    public partial class frmCreateOrder : Form
    {
        public frmCreateOrder()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            guna2Transition1.AddToQueue(txtProdName, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(txtStockDT, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(txtStock, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(payMethCombo, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(cntrlDueDate, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(txtSalesQ, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(btnAddToCart, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(label7, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(label2, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(label3, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
              guna2Transition1.AddToQueue(label4, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
              guna2Transition1.AddToQueue(label6, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
              guna2Transition1.AddToQueue(label29, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
              guna2Transition1.AddToQueue(panel3, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 


        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rdr;
        DataSet ds;

        int OrderNum = 0;
        short orderCount = 0;
        int itemsCounter = 1;
        double totalItems = 0;
        int createNewOrderFlag = 2;

        List<string> OrderNumbers = new List<string>();
        List<string> supplierIDs = new List<string>();
        List<string> supplierNames = new List<string>();
        List<string> deliverDate = new List<string>();

        private void frmCreateOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSDataSet.dtb_Products_rws' table. You can move, or remove it, as needed.
    
            cntrlDueDate.Value = System.DateTime.Now;

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity FROM dtb_Products_rws,dtb_currentStock_rws WHERE dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode order by ProductName asc", con);
            ds = new DataSet();



            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);


            searchRst.DataSource = ds.Tables[0].DefaultView;

            con.Close();

            getRates();
          getSuppliers();
       

        }

       

        private void getSuppliers()         //METHOD TO GET PRODUCT SUPPLIER IF AVAILABLE.
        {
       

            guna2Transition2.HideSync(supAvatar);
      

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT  dtb_regSuppliers_rws.SupplierID,SupplierName,Address,City,Contact1,Contact2,Email,DeliveryAmount,dtb_regSuppliers_rws.Avatar,StockDate FROM dtb_regSuppliers_rws, dtb_Products_rws, dtb_Stock_rws WHERE dtb_Stock_rws.SupplierID=dtb_regSuppliers_rws.SupplierID AND dtb_Stock_rws.ProductCode= '" + txtPCode.Text + "'", con);
            rdr = cmd.ExecuteReader();


            try
            {
                if (rdr.HasRows)
                {
                   // btnAddToCart.Enabled = true;
                //    payMethCombo.Enabled = true;
                //    txtDueDate.Enabled = true;
               //     txtSalesQ.Enabled = true;
              

                    if (rdr.Read() == true)
                    {
                        txtSupID.Text = rdr[0].ToString();
                       txtSupName.Text = rdr[1].ToString();
                        txtCIT.Text = rdr[3].ToString();
                        txtOP.Text = rdr[4].ToString();
                        txtAP.Text = rdr[5].ToString();
                        txtEM.Text = rdr[6].ToString();
                        txtDelivery.Text = rdr[7].ToString();

                        

                        getSupImage(supAvatar, rdr[8].ToString());

                    }
                } 
             else
                {
              //      btnAddToCart.Enabled = false;
              //      payMethCombo.Enabled = false;
                 //   txtDueDate.Enabled = false;
                 //   txtSalesQ.Enabled = false;
          

                    clearSupplierFields();
                }
             

                rdr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred!");

            }


            guna2Transition2.ShowSync(supAvatar);
     
            //   getSupplierProducts();
            //  getProductDetails();
            //     getLastOrderDate();



            txtSearch.Focus();
        }

        private void clearSupplierFields()
        {

            supAvatar.Image = null;
            txtSupID.Clear();
            txtSupName.Clear();
            txtCIT.Clear();
            txtOP.Clear();
            txtAP.Clear();
            txtEM.Clear();
            txtDelivery.Clear();

        }


        private void getProductDetails()
        {
            try
            {
                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,Quantity From dtb_Products_rws,dtb_currentStock_rws Where dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode AND ProductName = @v1", con);
                    cmd.Parameters.AddWithValue("v1", searchRst.SelectedCells[0].Value.ToString());

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read() == true)
                    {
                        txtPCode.Text = rdr[0].ToString();
                        txtProdName.Text = rdr[1].ToString();
                        txtStock.Text = rdr[2].ToString();
                        

                        if (Convert.ToDouble(txtStock.Text) <= 0)
                        {
                            txtSalesQ.Text = "";
                            txtSalesQ.Enabled = false;
                     
                        }
                        else
                        {
                            txtSalesQ.Text = "1";
                            txtSalesQ.Enabled = true;
                  
                        }

                    }

                    rdr.Close();
                    con.Close();

                    txtSearch.Focus();
                }
                catch (ArgumentOutOfRangeException ex03)
                {
                    MessageBox.Show("The selected Supplier hasn't been registered to any Product!");
                    clearText();
              
                 

                }
              
            }
            catch (Exception ex)
            {
              MessageBox.Show("An error occurred. Issue key: 0x31");

            }
          
        }

        private void clearText()
        {
            txtPCode.Clear();
            txtStock.Clear();
            txtProdName.Clear();
            txtStockDT.Clear();
        }

        private void getSupplierProducts()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,dtb_Stock_rws.SupplierID,dtb_Stock_rws.StockDate From dtb_Products_rws,dtb_Stock_rws WHERE dtb_Products_rws.ProductCode = dtb_Stock_rws.ProductCode AND dtb_Stock_rws.SupplierID = '" + txtSupID.Text+ "'", con);
              

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(ds);

         
                searchRst.DataSource = ds.Tables[0].DefaultView;

                con.Close();
            }
            catch (OleDbException ex)
            {

                MessageBox.Show("An error occurred. Issue key: 0x93d");
            }
        }

        private void getLastOrderDate()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,Quantity,StockDate From dtb_Products_rws,dtb_Stock_rws WHERE dtb_Stock_rws.ProductCode = '" + txtPCode.Text + "'", con);
            rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {
                txtStockDT.Text = rdr[3].ToString();
            }

            rdr.Close();
            con.Close();
        }

        private void custList_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void getSupImage(PictureBox pBox, String imgName) //METHOD TO GET SUPPLIER PROFILE IMAGE IF AVAILABLE.
        {

               try
            {
                pBox.Image = Image.FromFile(clsSysFolder.sfilePath + imgName + ".avt");
            }
            catch (FileNotFoundException ex1)
            {
                try
                {
                    pBox.Image = Image.FromFile(clsSysFolder.sfilePath + "Untitled" + ".avt");
                }
                catch (FileNotFoundException ex2)
                {
                    try
                    {
                        createDir();
                        pBox.Image = Image.FromFile(clsSysFolder.sfilePath + "Untitled" + ".avt");
                    }
                    catch (Exception ex3)
                    {

                        pBox.Image = null;
                    }

                }

            }


        }

        private static void createDir()
        {
            try
            {

                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\CAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\SAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\IAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\Trash\\IAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\Trash\\CAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\Trash\\SAs\\");


            }
            catch (Exception ex4)
            {
                return;
            }

            try
            {
                File.Copy(Application.StartupPath + "/backavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\CAs\\Untitled.avt");
                File.Copy(Application.StartupPath + "/backavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\SAs\\Untitled.avt");
                File.Copy(Application.StartupPath + "/backavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\IAs\\Untitled.avt");
                File.Copy(Application.StartupPath + "/nomavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\nomore.avt");

                //SysTray
                File.Copy(Application.StartupPath + "/backexavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\exit.avt");
                File.Copy(Application.StartupPath + "/backlslavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\lsl.avt");
                File.Copy(Application.StartupPath + "/backnotavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\notify.avt");
            }
            catch (Exception exFNF)
            {

                return;
            }


        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            clsProgressIndicator.timerOps(guna2WinProgressIndicator1, timer1);
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

                try
                {
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        if (rdr.Read() == true)
                        {

                            txtPCode.Text = rdr[0].ToString();
                            txtProdName.Text = rdr[1].ToString();
                            txtStock.Text = rdr[5].ToString();

                        }

                        getLastOrderDate();

                        if (Convert.ToDouble(txtStock.Text) <= 20)
                        {
                            gunaTransition3.HideSync(txtStock);
                            txtStock.ForeColor = Color.Red;
                            gunaTransition3.ShowSync(txtStock);

                        }
                        else
                        {
                            txtStock.ForeColor = Color.Lime;
                        }

                    }
                    else
                    {
                        clearText();
                    }
           
                }
                catch (Exception ex)
                {

                    return;
                }
              
                getSuppliers();

                con.Close();

              

            }
            catch (OleDbException ex)
            {
                txtSearch.Clear();

            }

          
         
        }

     

        private void getRates()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();



            //ZWL RTGS CASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'ZWL_RTGS_CASH'", con);
            rdr = cmd.ExecuteReader();


            if (rdr.Read() == true)
            {

          
                payMethCombo.Items.Add(rdr[0].ToString());

            }

            rdr.Close();

            //SA RAND CASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'SA_RAND_CASH'", con);
            rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {

         
                payMethCombo.Items.Add(rdr[0].ToString());

            }

            rdr.Close();

            //USD BANK TRANSFER
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'USD_BANK_TRANSFER'", con);
            rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {

         
                payMethCombo.Items.Add(rdr[0].ToString());

            }

            rdr.Close();


            //ZWL RTGS BANK TRANSFER
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'ZWL_RTGS_BANK_TRANSFER'", con);
            rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {

           
                payMethCombo.Items.Add(rdr[0].ToString());

            }

            rdr.Close();


            //ZWL RTGS ECOCASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'ZWL_RTGS_ECOCASH'", con);
            rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {

            
                payMethCombo.Items.Add(rdr[0].ToString());

            }

            rdr.Close();


            //USD ECOCASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'USD_ECOCASH'", con);
            rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {

          
                payMethCombo.Items.Add(rdr[0].ToString());

            }

            //USD CASH
            cmd = new OleDbCommand("Select * From dtb_Rates_rws Where Currency = 'USD_CASH'", con);
            rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {

            
                payMethCombo.Items.Add(rdr[0].ToString());
                payMethCombo.Text = rdr[0].ToString();

            }



            rdr.Close();

            con.Close();
        }

        private void supList_SelectedIndexChanged(object sender, EventArgs e)
        {
         

       
        }

        private void frmCreateOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAuthenticity.showRunningForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {


            try
            {
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("There are no items to clear on list!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    guna2WinProgressIndicator2.Visible = true;
                    timer2.Start();

                    gunaTransition4.HideSync(groupBox1);
                    gunaTransition4.HideSync(groupBox3);
                    gunaTransition4.HideSync(groupBox5);
                    gunaTransition4.HideSync(groupBox6);
                    gunaTransition4.HideSync(listView1);

                 
                    clearEverything();


                    gunaTransition4.ShowSync(listView1);
                    gunaTransition4.ShowSync(groupBox1);
                    gunaTransition4.ShowSync(groupBox3);
                    gunaTransition4.ShowSync(groupBox6);
                    gunaTransition4.ShowSync(groupBox5);
            
                   
                }

                txtSearch.Focus();


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Issue key: 0x32");

            }
        }

        private void clearEverything()
        {
            try
            {
                listView1.Items.Clear();
                payMethCombo.Text = payMethCombo.Items[6].ToString();
                btnOrderCount.Text = "0";
                txtItemCount.Text = "0";
                OrderNum = 0;
                orderCount = 0;
                OrderNumbers.Clear();
                supplierIDs.Clear();
                supplierNames.Clear();
                deliverDate.Clear();
                txtDueDate.Clear();
                txtOrderNum.PlaceholderText = "Order #";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Restart the page.");
                return;
            } 
     
              
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            guna2WinProgressIndicator2.Visible = true;
            timer2.Start();

            if (supplierIDs.Contains(txtSupID.Text))
            {
                int getIndex = supplierIDs.IndexOf(txtSupID.Text);
                OrderNum = Convert.ToInt32(OrderNumbers[getIndex]);
                txtOrderNum.Text = OrderNum.ToString();

                string getDate = "";
                getDate = deliverDate[getIndex];
                txtDueDate.Text = getDate;

            } 
            else 
            {
                 OrderNum = clsKeyGen.createOrderCode();
                orderCount++;
                btnOrderCount.Text = orderCount.ToString();
                txtOrderNum.Text = OrderNum.ToString();
                OrderNumbers.Add(OrderNum.ToString());
                supplierIDs.Add(txtSupID.Text);
                supplierNames.Add(txtSupName.Text);
                deliverDate.Add(cntrlDueDate.Text);
                txtDueDate.Text = cntrlDueDate.Text;

            }

            //for (int i = 0; i <= supplierIDs.Count - 1; i++)
            //{
            //    if (supplierIDs[i] == txtSupID.Text)
            //    {

            //        int.TryParse(OrderNumbers[i], out OrderNum);
            //        txtOrderNum.Text = OrderNum.ToString();
            //        itemsCounter++;



            //    }

            //}

            //if (txtOrderNum.Text == "")
            //{
            //    OrderNum = clsKeyGen.createOrderCode();
            //    orderCount++;
            //  btnOrderCount.Text = orderCount.ToString();
            //    txtOrderNum.Text = OrderNum.ToString();
            //    OrderNumbers.Add(OrderNum.ToString());
            //    supplierIDs.Add(txtSupID.Text);
            //    supplierNames.Add(txtSupName.Text);
            //    deliverDate.Add(txtDueDate.Text);
            //}



            try
            {
                if (txtSalesQ.Text == "")
                {
                    MessageBox.Show("Please enter item quantity!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gunaTransition4.HideSync(txtSalesQ);
                    gunaTransition4.ShowSync(txtSalesQ);
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

                int REFFCode = clsKeyGen.RefferenceCode();

                ListViewItem lst = new ListViewItem(txtOrderNum.Text);
                lst.SubItems.Add(txtSupID.Text);
                lst.SubItems.Add(txtSupName.Text);
                lst.SubItems.Add(REFFCode.ToString()); 
                lst.SubItems.Add(txtPCode.Text);
                lst.SubItems.Add(txtProdName.Text);
                lst.SubItems.Add(txtSalesQ.Text);
                lst.SubItems.Add(txtDueDate.Text);
                lst.SubItems.Add(payMethCombo.Text);
                listView1.Items.Add(lst);

                totalItems += Convert.ToDouble(txtSalesQ.Text);
                txtItemCount.Text = totalItems.ToString();

                Convert.ToDouble(txtSalesQ.Text = "1");


                payMethCombo.Text = payMethCombo.Items[6].ToString();
             

                txtOrderNum.PlaceholderText = OrderNum.ToString();
           //     txtOrderNum.Text = "";

                txtSearch.Focus();

            }
            catch (Exception ex)
            {
            
               MessageBox.Show("An error occurred. Issue key: 0x43");
            }
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        

        }

        private void payMethCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gunaTransition3.HideSync(payMethCombo);
            gunaTransition3.ShowSync(payMethCombo);
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

    
        }

        private void searchRst_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void searchRst_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
      
        }

        private void searchRst_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
         
        }

        private void searchRst_Click(object sender, EventArgs e)
        {
            guna2WinProgressIndicator2.Visible = true;
            timer2.Start();

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity From dtb_Products_rws,dtb_currentStock_rws Where dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode AND ProductName =  @v1", con);
            cmd.Parameters.AddWithValue("v1", searchRst.SelectedCells[0].Value.ToString());
            rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {
                try
                {
                    txtPCode.Text = rdr[0].ToString();
                    txtProdName.Text = rdr[1].ToString();
                    txtStock.Text = rdr[5].ToString();

                }
                catch (InvalidOperationException exINVOPEX)
                {
                    return;
                }
             
            }


            rdr.Close();
            con.Close();

            getLastOrderDate();


            getSuppliers();

         
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtStock.Text) <= 20)
            {
           
                txtStock.ForeColor = Color.Red;
           

            }
            else
            {
                txtStock.ForeColor = Color.Lime;
            }
            gunaTransition3.HideSync(txtStock);
            gunaTransition3.ShowSync(txtStock);
        }

        private void txtProdName_TextChanged(object sender, EventArgs e)
        {
            gunaTransition3.HideSync(txtProdName);
            gunaTransition3.ShowSync(txtProdName);
        }

        private void txtSalesQ_MouseClick(object sender, MouseEventArgs e)
        {
            txtSalesQ.Clear();
        }

        private void txtSalesQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender,e);
        }

        private void txtStockDT_TextChanged(object sender, EventArgs e)
        {
            gunaTransition3.HideSync(txtStockDT);
            gunaTransition3.ShowSync(txtStockDT);
        }

        private void txtDueDate_ValueChanged(object sender, EventArgs e)
        {
            if (supplierIDs.Contains(txtSupID.Text))
            {
                MessageBox.Show("An order to the selected Supplier has already been established with a different delivery date." + "/n" + "Creating a distinct delivery date for this item requires you to start ordering afresh.");

            }
            else
            {
                gunaTransition3.HideSync(cntrlDueDate);
                gunaTransition3.ShowSync(cntrlDueDate);
            }

        
        }

        private void txtPCode_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBCode_TextChanged(object sender, EventArgs e)
        {
            gunaTransition3.HideSync(txtOrderNum);
            gunaTransition3.ShowSync(txtOrderNum);
        }

        private void supAvatar_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("There are no items to clear on list!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();


            for (int i = 0; i <= OrderNumbers.Count - 1; i++)
            {
          
                cmd = new OleDbCommand("INSERT INTO dtb_SupplyOrders_rws(OrderID,SupplierID,DateCreated,DeliverDate,OperatorID) Values(@v1,@v2,@v3,@v4,@v5)", con);
                cmd.Parameters.AddWithValue("@v1", OrderNumbers[i].ToString());
                cmd.Parameters.AddWithValue("@v2", supplierIDs[i].ToString());
                cmd.Parameters.AddWithValue("@v3",dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@v4", deliverDate[i].ToString());
                cmd.Parameters.AddWithValue("@v5", clsAuthenticity.userID);
                cmd.ExecuteNonQuery();
              
            }


            for (int i = 0; i <= listView1.Items.Count - 1 ; i++)
            {
           
                cmd = new OleDbCommand("INSERT INTO dtb_SupplyOrderProducts_rws(OrderID,RefferenceCode,ProductCode,Quantity,PaymentType) VALUES(@v1,@v2,@v3,@v4,@v5)", con);
                cmd.Parameters.AddWithValue("@v1", listView1.Items[i].SubItems[0].Text);
                cmd.Parameters.AddWithValue("@v2", listView1.Items[i].SubItems[3].Text);
                cmd.Parameters.AddWithValue("@v3", listView1.Items[i].SubItems[4].Text);
                cmd.Parameters.AddWithValue("@v4", listView1.Items[i].SubItems[6].Text);
                cmd.Parameters.AddWithValue("@v4", listView1.Items[i].SubItems[8].Text);
                cmd.ExecuteNonQuery();
       
            }

            con.Close();

            MessageBox.Show("Done");
            clsSystemTray.notifier("Order(s) Successfully Saved.");

            guna2WinProgressIndicator2.Visible = true;
            timer2.Start();

            gunaTransition4.HideSync(groupBox1);
            gunaTransition4.HideSync(groupBox3);
            gunaTransition4.HideSync(groupBox5);
            gunaTransition4.HideSync(listView1);

            clearEverything();
  
            gunaTransition4.ShowSync(listView1);
            gunaTransition4.ShowSync(groupBox1);
            gunaTransition4.ShowSync(groupBox3);
            gunaTransition4.ShowSync(groupBox5);

            txtSearch.Focus();

        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
         
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
         
            //btnAddToCart.Enabled = true;
            //payMethCombo.Enabled = true;
            //txtDueDate.Enabled = true;
            //txtSalesQ.Enabled = true;


            //int OrderNum = 0;

            //for (int i = 0; i <= supplierIDs.Count - 1; i++)
            //{
            //    if (supplierIDs[i] == txtSupID.Text)
            //    {

            //        int.TryParse(OrderNumbers[i], out OrderNum);
            //        txtOrderNum.Text = OrderNum.ToString();

            //    }

            //}

            //if (txtOrderNum.Text == "")
            //{
            //    OrderNum = clsKeyGen.createOrderCode();
            //    orderCount++;
            //    btnOrderCount.Text = orderCount.ToString();
            //    txtOrderNum.Text = OrderNum.ToString();
            //    OrderNumbers.Add(OrderNum.ToString());
            //    supplierIDs.Add(txtSupID.Text);
            //}



        }

        private void btnSelect_EnabledChanged(object sender, EventArgs e)
        {
       
        }

        private void txtSupID_TextChanged(object sender, EventArgs e)
        {
            if(txtSupID.Text == "")
            {
                btnAddToCart.Enabled = false;
                payMethCombo.Enabled = false;
                cntrlDueDate.Enabled = false;
                txtSalesQ.Enabled = false;
            } 
            else
            {
                btnAddToCart.Enabled = true;
                payMethCombo.Enabled = true;
                cntrlDueDate.Enabled = true;
                txtSalesQ.Enabled = true;


               

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOrderCount_TextChanged(object sender, EventArgs e)
        {
            gunaTransition1.HideSync(btnOrderCount);
            gunaTransition1.ShowSync(btnOrderCount);
        }

        private void btnOrderCount_MouseHover(object sender, EventArgs e)
        {
            string OrdersList = "";

            for (int i = 0; i <= OrderNumbers.Count - 1; i++)
            {
                OrdersList += supplierNames[i].ToString() + "'s Order #:   " + OrderNumbers[i].ToString() + "\n";
            }

            toolTip1.Show(OrdersList,btnOrderCount,10000);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            clsProgressIndicator.timerOps(guna2WinProgressIndicator2, timer2);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
      
            clsAuthenticity.getAuth("",this,new frmCriticalStock());
            clsAuthenticity.form2Hide = new frmSalesMenu();

            txtSearch.Focus();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("", this, new frmReceivedOrders());
            clsAuthenticity.form2Hide = new frmSalesMenu();

            txtSearch.Focus();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

            txtSearch.Focus();
        }

        private void btnOrderCount_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void searchRst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       

    }
}
