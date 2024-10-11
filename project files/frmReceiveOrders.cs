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
    public partial class frmReceiveOrders : Form
    {
        public frmReceiveOrders()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

        }

        #region databaseObjects

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rdr;
        DataSet ds;


        #endregion

        int selector = 0;
        int status = 0;
        int newORexist = 0;
        double result = 0;

        private void frmReceiveOrders_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime();
                dt = System.DateTime.Now;

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID as [Order Number] FROM dtb_SupplyOrders_rws", con);

                adp = new OleDbDataAdapter(cmd);

                ds = new DataSet();

                adp.Fill(ds);

                searchRst.DataSource = ds.Tables[0].DefaultView;
                con.Close();

                getOrderGeneralDetail();
                getOrderDetails();
                getSupplierName();
                getLastRecorded();

            }
            catch (Exception exAKL)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1AKL");
            }
           
            txtSearch.Focus();
        }

        private void loadSearchRst(string orderIDp)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID as [Order Number] FROM dtb_SupplyOrders_rws WHERE OrderID LIKE '%" + orderIDp + "%'", con);

                adp = new OleDbDataAdapter(cmd);

                ds = new DataSet();

                adp.Fill(ds);

                searchRst.DataSource = ds.Tables[0].DefaultView;
                con.Close();

                getOrderGeneralDetail();
                getOrderDetails();
                getSupplierName();

            }
            catch (Exception exVBS)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1VBS");
            }
         
        }

        private void getOrderDetails()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID as [Order Number],RefferenceCode as [Refference Code],dtb_SupplyOrderProducts_rws.ProductCode,ProductName as [Product Name],Quantity as [Expected Quantity],PaymentType as [Payment Method] FROM dtb_SupplyOrderProducts_rws,dtb_Products_rws WHERE dtb_SupplyOrderProducts_rws.ProductCode = dtb_Products_rws.ProductCode", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(ds);

                ProductsRst.DataSource = ds.Tables[0].DefaultView;

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtREFFCode.Text = rdr[1].ToString();
                    txtQ.Text = rdr[4].ToString();
                    txtProductName.Text = rdr[3].ToString();
                }

                con.Close();

            }
            catch (Exception exXSD)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1XSD");
            }
       
        }

        private void getOrderGeneralDetail()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID,SupplierID,DateCreated,DeliverDate FROM dtb_SupplyOrders_rws", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtSupID.Text = rdr[1].ToString();
                    txtOrderDate.Text = rdr[2].ToString();
                    txtOrderDelivery.Text = rdr[3].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exCSJ)
            {
                MessageBox.Show("Something  went wrong! Issue Key: 0x1CSJ");
            }
       

            txtSearch.Focus();
        }

        private void getOrderGeneralDetail(string orderIDparam)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID,SupplierID,DateCreated,DeliverDate FROM dtb_SupplyOrders_rws WHERE OrderID = '" + orderIDparam + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtSupID.Text = rdr[1].ToString();
                    txtOrderDate.Text = rdr[2].ToString();
                    txtOrderDelivery.Text = rdr[3].ToString();
                }

                rdr.Close();
                con.Close();

            }
            catch (Exception exHAS)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1HAS");
            }
          
            txtSearch.Focus();
        }

        private void searchOrderGeneralDetail(string orderIDparam)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID,SupplierID,DateCreated,DeliverDate FROM dtb_SupplyOrders_rws WHERE OrderID LIKE '%" + orderIDparam + "%'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtSupID.Text = rdr[1].ToString();
                    txtOrderDate.Text = rdr[2].ToString();
                    txtOrderDelivery.Text = rdr[3].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exFGE)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1FGE");
            }
           

            txtSearch.Focus();
        }

        private void searchSupplyOrderProducts(string providedParameter)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID as [Order Number],RefferenceCode,dtb_SupplyOrderProducts_rws.ProductCode,ProductName,Quantity,PaymentType FROM dtb_SupplyOrderProducts_rws,dtb_Products_rws WHERE dtb_SupplyOrderProducts_rws.ProductCode = dtb_Products_rws.ProductCode AND OrderID LIKE '%" + providedParameter + "%'", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(ds);

                ProductsRst.DataSource = ds.Tables[0].DefaultView;

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtREFFCode.Text = rdr[1].ToString();
                    txtQ.Text = rdr[4].ToString();
                    txtProductName.Text = rdr[3].ToString();

                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exVBS)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1VBS");  
              
            }
         

            txtSearch.Focus();
        }

        private void getSupplyOrderProducts(string providedParameter)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID as [Order Number],RefferenceCode,dtb_SupplyOrderProducts_rws.ProductCode,ProductName,Quantity,PaymentType FROM dtb_SupplyOrderProducts_rws,dtb_Products_rws WHERE dtb_SupplyOrderProducts_rws.ProductCode = dtb_Products_rws.ProductCode AND OrderID ='" + providedParameter + "'", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(ds);

                ProductsRst.DataSource = ds.Tables[0].DefaultView;

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtREFFCode.Text = rdr[1].ToString();
                    txtQ.Text = rdr[4].ToString();
                    txtProductName.Text = rdr[3].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exSAL)
            {

                MessageBox.Show("Something went wrong! Issue Key: 0x1SAL");
            }
           

            txtSearch.Focus();
        }

        private void disableFields()
        {
            txtTotalCost.Enabled = false;
            txtAmtPaid.Enabled = false;
            txtTAX.Enabled = false;
            txtDiscount.Enabled = false;
            txtTAXAmount.Enabled = false;
            txtDiscountA.Enabled = false;
            txtUnitP.Enabled = false;
            txtDeliveryA.Enabled = false;

        }

        private void enableFields()
        {
            txtTotalCost.Enabled = true;
            txtAmtPaid.Enabled = true;
            txtTAX.Enabled = true;
            txtDiscount.Enabled = true;
            txtTAXAmount.Enabled = true;
            txtDiscountA.Enabled = true;
            txtUnitP.Enabled = true;
            txtDeliveryA.Enabled = true;

        }

        private void getSupplierName()
        {
            try
            {

            }
            catch (Exception exBNS)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1BNS");
            }
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT SupplierID,SupplierName FROM dtb_regSuppliers_rws WHERE SupplierID = '" + txtSupID.Text + "'",con);

            rdr = cmd.ExecuteReader();

            if(rdr.Read() == true)
            {
            txtSupplierName.Text = rdr[1].ToString();
            }

            rdr.Close();
            con.Close();

        }

        private void searchSupplierName(string supplierIDParam)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT SupplierID,SupplierName FROM dtb_regSuppliers_rws WHERE SupplierID LIKE '%" + txtSupID.Text + "%'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtSupplierName.Text = rdr[1].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exUTN)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1UTN");
            }
         

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadSearchRst(txtSearch.Text);
            searchSupplyOrderProducts(txtSearch.Text);
            searchOrderGeneralDetail(txtSearch.Text);
            searchSupplierName(txtSearch.Text);
            getLastRecorded();
            statusDetector();
        }

        private void searchRst_Click(object sender, EventArgs e)
        {
            getSupplyOrderProducts(searchRst.SelectedRows[0].Cells[0].Value.ToString());
            getOrderGeneralDetail(searchRst.SelectedRows[0].Cells[0].Value.ToString());
            getSupplierName();
            getLastRecorded();
            statusDetector();

        }

        private void searchRst_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void searchRst_SelectionChanged(object sender, EventArgs e)
        {
        
        }

        private void searchRst_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void refresh()
        {
            try
            {
                cmd = new OleDbCommand("SELECT OrderID as [Order Number] FROM dtb_SupplyOrders_rws", con);

                adp = new OleDbDataAdapter(cmd);

                ds = new DataSet();

                adp.Fill(ds);

                searchRst.DataSource = ds.Tables[0].DefaultView;
                con.Close();

                getOrderGeneralDetail();
                getOrderDetails();
                getSupplierName();
                getLastRecorded();

            }
            catch (Exception exREF)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1REF");
            
            }
        
            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

                if (MessageBox.Show("Are you sure you want to delete Order #: " + searchRst.SelectedRows[0].Cells[0].Value.ToString() + " and all it's records?", "QPOS", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        con = new OleDbConnection(connectionString.DBConn);
                        con.Open();

                        cmd = new OleDbCommand("DELETE  FROM dtb_SupplyOrders_rws WHERE OrderID = '" + searchRst.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
                        cmd.ExecuteNonQuery();

                        cmd = new OleDbCommand("DELETE  FROM dtb_SupplyOrderProducts_rws WHERE OrderID = '" + searchRst.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
                        cmd.ExecuteNonQuery();


                        MessageBox.Show("Successfully deleted!");
                        con.Close();

                        refresh();
                    }
                    catch (Exception exDSE)
                    {
                        MessageBox.Show("Something went wrong! Issue Key: 0x1DSE");
                    
                    }
                 
                    
                } 
                else
                {
                    return;
                }
            
        }

        private void txtSalesQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender,e);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender, e);
        }

        private void txtSalesQ_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtSalesQ_MouseLeave(object sender, EventArgs e)
        {
          //  txtSalesQ.Text = "0";
        }

        private void txtSalesQ_Click(object sender, EventArgs e)
        {
            txtSalesQ.Clear();
        }

        private void getIndividualProductDetails()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID as [Order Number],RefferenceCode,dtb_SupplyOrderProducts_rws.ProductCode,ProductName,Quantity,PaymentType FROM dtb_SupplyOrderProducts_rws,dtb_Products_rws WHERE dtb_SupplyOrderProducts_rws.ProductCode = dtb_Products_rws.ProductCode AND RefferenceCode ='" + ProductsRst.SelectedRows[0].Cells[1].Value.ToString() + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtQ.Text = rdr[4].ToString();
                    txtREFFCode.Text = rdr[1].ToString();
                    txtProductName.Text = rdr[3].ToString();
                }

                rdr.Close();
                con.Close();

      
            }
            catch (Exception exIOP)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1IOP");
            }

            txtSearch.Focus();
        }

        private void ProductsRst_Click(object sender, EventArgs e)
        {
            getIndividualProductDetails();
            getLastRecorded();
            statusDetector();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
        
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtQ.Text) < Convert.ToDouble(txtSalesQ.Text))
            {
                MessageBox.Show("The figure provided is above the Quantity ordered!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalesQ.Text = "0";
                txtSalesQ.Focus();

                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
       
            saveChanges();
            resetText();
            refresh();
        }

        private void statusDetector()
        {
            if(txtLastRec.Text != "")
            {
                if (Convert.ToDouble(txtLastRec.Text) < Convert.ToDouble(ProductsRst.SelectedRows[0].Cells[4].Value))
                {
                    selector = 0;
                }

                if (Convert.ToDouble(txtLastRec.Text) == Convert.ToDouble(ProductsRst.SelectedRows[0].Cells[4].Value))
                {
                    selector = 1;
                }

         

            }
          
        }

        private void saveChanges()
        {
            if(txtSalesQ.Text == "")
            {
                txtSalesQ.Text = "0";
            }

            if (txtDeliveryA.Text == "")
            {
               txtDeliveryA.Text = "0.00";
            }

            if (txtUnitP.Text == "")
            {
               txtUnitP.Text = "0.00";
            }

            if (txtTotalCost.Text == "")
            {
               txtTotalCost.Text = "0.00";
            }

            if (txtAmtPaid.Text == "")
            {
               txtAmtPaid.Text = "0.00";
            }


            if (txtTAX.Text == "")
            {
               txtTAX.Text = "0";
            }


            if (txtDiscount.Text == "")
            {
               txtDiscount.Text = "0";
            }


            if (txtTAXAmount.Text == "")
            {
                txtTAXAmount.Text = "0.00";
            }


            if (txtDiscountA.Text == "")
            {
              txtDiscountA.Text = "0.00";
            }

            if(Convert.ToDouble(txtSalesQ.Text) <= 0)
            {
                MessageBox.Show("Quantity cannot be less than or equal to 0");
                return;
            }

            statusDetector();

            if(selector == 1)
            {
                MessageBox.Show("This product is fully delivered.");
                selector = 0; //TESTER
                return;
            }

            if(selector == 0)
            {
            

                if (txtLastRec.Text == "")
                {
                    txtLastRec.Text = "0";
                    newORexist = 0;
                } 
                else
                {
                    newORexist = 1;
                }

                result = Convert.ToDouble(txtLastRec.Text) + Convert.ToDouble(txtSalesQ.Text);

                if (result > Convert.ToDouble(ProductsRst.SelectedRows[0].Cells[4].Value))
                {
                    MessageBox.Show("The amount provided now exceeds the amount of ordered items!");
                    txtSalesQ.Focus();
                    return;
                }

                if (result == Convert.ToDouble(ProductsRst.SelectedRows[0].Cells[4].Value))
                {
                    status = 1; //Product has been fully delivered
                }

                if (result < Convert.ToDouble(ProductsRst.SelectedRows[0].Cells[4].Value))
                {
                    status = 3; //Product Delivery is still pending
                }
            }

            string receiveID = clsKeyGen.getFullRECCode();

            if(newORexist == 0)
            {
                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("INSERT INTO dtb_ReceivedOrderProducts_rws(ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,AmountPaid,Pushed) VALUES(@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@v11,@v12,@v13,@v14,@v15,@v16,@v17,@v18)", con);
                    cmd.Parameters.AddWithValue("@d1", receiveID);
                    cmd.Parameters.AddWithValue("@d2", ProductsRst.SelectedRows[0].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@d3", txtSupID.Text);
                    cmd.Parameters.AddWithValue("@d4", ProductsRst.SelectedRows[0].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@d5", ProductsRst.SelectedRows[0].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@d6", txtSalesQ.Text);
                    cmd.Parameters.AddWithValue("@d7", txtDiscount.Text);
                    cmd.Parameters.AddWithValue("@d8", txtDiscountA.Text);
                    cmd.Parameters.AddWithValue("@d9", txtTAX.Text);
                    cmd.Parameters.AddWithValue("@d10", txtTAXAmount.Text);
                    cmd.Parameters.AddWithValue("@d11", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@d12", txtUnitP.Text);
                    cmd.Parameters.AddWithValue("@d13", txtTotalCost.Text);
                    cmd.Parameters.AddWithValue("@d14", ProductsRst.SelectedRows[0].Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("@d15", txtDeliveryA.Text);
                    cmd.Parameters.AddWithValue("@d16", status);
                    cmd.Parameters.AddWithValue("@d17", txtAmtPaid.Text);
                    cmd.Parameters.AddWithValue("@d18", "0");
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Done");
                }
                catch (Exception exUK)
                {
                    MessageBox.Show("Something went wrong! Issue Key: ex1UK");
                }
           
            }

            if (newORexist == 1)
            {
                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("UPDATE dtb_ReceivedOrderProducts_rws SET Status = " + status + " WHERE RefferenceCode = '" + ProductsRst.SelectedRows[0].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();

                    cmd = new OleDbCommand("UPDATE dtb_ReceivedOrderProducts_rws SET Quantity = " + result + " WHERE RefferenceCode = '" + ProductsRst.SelectedRows[0].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Done");
                }
                catch (Exception exUK)
                {
                    MessageBox.Show("Something went wrong! Issue Key: ex1UK");
                }

            } 

        }

      private void resetText()
        {
            txtLastRec.Clear();
            txtSalesQ.Text = "0";
            txtDeliveryA.Text = "0.00";
            txtTotalCost.Text = "0.00";
            txtUnitP.Text = "0.00";
            txtAmtPaid.Text = "0.00";
            txtTAX.Text = "0";
            txtDiscount.Text = "0";
            txtTAXAmount.Text = "0.00";
            txtDiscountA.Text = "0.00";
        }

        private void getLastRecorded()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT Quantity FROM dtb_ReceivedOrderProducts_rws WHERE RefferenceCode = '" + ProductsRst.SelectedRows[0].Cells[1].Value.ToString() + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
             
                        txtLastRec.Text = rdr[0].ToString();

                }
                else
                {
                    txtLastRec.Clear();
                    txtLastRec.PlaceholderText = "n/a";
                }
            }
            catch (OleDbException exOLE)
            {
                txtLastRec.Clear();
                txtLastRec.PlaceholderText = "n/a";
            }
           
        }

        private void txtUnitP_KeyUp(object sender, KeyEventArgs e)
        {
        
        }

        private void txtUnitP_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender,e);
        }

        private void txtDeliveryA_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void txtTotalCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void txtSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void txtTAXAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void txtDiscountA_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void txtTAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            processReport();
        }

        private void processReport()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                rptCreatedOrdersReport theReport = new rptCreatedOrdersReport();

                //The report you created.
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT OrderID,RefferenceCode,dtb_SupplyOrderProducts_rws.ProductCode,ProductName,Quantity,PaymentType FROM dtb_SupplyOrderProducts_rws,dtb_Products_rws WHERE dtb_SupplyOrderProducts_rws.ProductCode = dtb_Products_rws.ProductCode AND dtb_SupplyOrderProducts_rws.OrderID LIKE '%" + txtSearch.Text + "%'", con);
                //      cmd.ExecuteNonQuery();

                // ds = new DataSet();
                DataTable dtb = new DataTable();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(dtb);


                theReport.Database.Tables["createdOrders"].SetDataSource(dtb);
                frmCreatedOrdersReport frm = new frmCreatedOrdersReport();
                frm.crystalReportViewer1.ReportSource = null;
                frm.crystalReportViewer1.ReportSource = theReport;
                frm.Visible = true;
                con.Close();
                con.Dispose();
            }
            catch (Exception exRPT)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1RPT");
            }
          
        }

        private void txtLastRec_TextChanged(object sender, EventArgs e)
        {
            if(txtLastRec.Text == "")
            {
                enableFields();

            } 
            else
            {
                disableFields();
            }

        }

        private void txtDeliveryA_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtDeliveryA_MouseLeave(object sender, EventArgs e)
        {

        }

        private void txtDeliveryA_Leave(object sender, EventArgs e)
        {
            if (txtDeliveryA.Text == "")
            {
                txtDeliveryA.Text = "0.00";
            }
        }

        private void txtTotalCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalCost_Leave(object sender, EventArgs e)
        {
            if (txtTotalCost.Text == "")
            {
             txtTotalCost.Text = "0.00";
            }
        }

        private void txtSubTotal_Leave(object sender, EventArgs e)
        {
            if (txtAmtPaid.Text == "")
            {
              txtAmtPaid.Text = "0.00";
            }
        }

        private void txtTAX_Leave(object sender, EventArgs e)
        {
            if (txtTAX.Text == "")
            {
                txtTAX.Text  = "0";
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";
            }
        }

        private void txtTAXAmount_Leave(object sender, EventArgs e)
        {
            if (txtTAXAmount.Text == "")
            {
                txtTAXAmount.Text = "0.00";
            }
        }

        private void txtUnitP_Leave(object sender, EventArgs e)
        {
            if (txtUnitP.Text == "")
            {
                txtUnitP.Text = "0.00";
            }
        }

        private void txtDiscountA_Leave(object sender, EventArgs e)
        {
            if (txtDiscountA.Text == "")
            {
                txtDiscountA.Text = "0.00";
            }
        }

        private void txtSalesQ_Leave(object sender, EventArgs e)
        {
            if (txtSalesQ.Text == "")
            {
                txtSalesQ.Text = "0";
            }
        }

        private void txtSalesQ_MouseClick(object sender, MouseEventArgs e)
        {
            txtSalesQ.Clear();
        }

        private void txtUnitP_MouseClick(object sender, MouseEventArgs e)
        {
            txtUnitP.Clear();
        }

        private void txtTotalCost_MouseClick(object sender, MouseEventArgs e)
        {
            txtTotalCost.Clear();
        }

        private void txtSubTotal_MouseClick(object sender, MouseEventArgs e)
        {
            txtAmtPaid.Clear();
        }

        private void txtTAX_MouseClick(object sender, MouseEventArgs e)
        {
            txtTAX.Clear();

        }

        private void txtDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            txtDiscount.Clear();
        }

        private void txtTAXAmount_MouseClick(object sender, MouseEventArgs e)
        {
            txtTAXAmount.Clear();
        }

        private void txtDiscountA_MouseClick(object sender, MouseEventArgs e)
        {
            txtDiscountA.Clear();

        }

    }
}
