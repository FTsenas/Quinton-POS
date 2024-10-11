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
    public partial class frmReceivedOrders : Form
    {
        public frmReceivedOrders()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            txtReceivingDT.Value = DateTime.Today;

            #region Animations

            guna2Transition1.AddToQueue(guna2GradientPanel1, Guna.UI2.AnimatorNS.AnimateMode.Show, false);
           guna2Transition2.AddToQueue(groupBox4, Guna.UI2.AnimatorNS.AnimateMode.Show, false);
            guna2Transition2.AddToQueue(groupBox5, Guna.UI2.AnimatorNS.AnimateMode.Show, false);
            guna2Transition2.AddToQueue(groupBox9, Guna.UI2.AnimatorNS.AnimateMode.Show, false); 
            guna2Transition2.AddToQueue(guna2GradientPanel2, Guna.UI2.AnimatorNS.AnimateMode.Show, false);
            guna2Transition1.AddToQueue(groupBox10, Guna.UI2.AnimatorNS.AnimateMode.Show, false);
        
            #endregion

        }

        #region DatabaseObjects

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rdr;
        DataSet ds;

        #endregion

        private void frmReceivedOrders_Load(object sender, EventArgs e)
        {
        

            getTableData();
            markColumns();
            getItemInfo();
            getItemInfo2();
            getItemInfo3();
            getOrderATTCreator();
            getOrderATTCreator2();
            getOrderATTCreator3();
            getSupplierName();
            getSupplierName2();
            getSupplierName3();
            getOrderATTReceiver();
            getOrderATTReceiver2();
            getOrderATTReceiver3();
            getOrderDate();
            getOrderDate2();
            getOrderDate3();
            getExpiryDate();
            getExpiryDate2();
            getExpiryDate3();

            txtSearchReff.Select();
            txtSearchReff.Focus();
        
        }

        private void getItemInfo()
        {
            
          
             try
             {
                 con = new OleDbConnection(connectionString.DBConn);
                 con.Open();


                 cmd = new OleDbCommand("SELECT  ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,Pushed,AmountPaid,OperatorID FROM dtb_ReceivedOrderProducts_rws WHERE RefferenceCode = '" + guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'", con);

                 rdr = cmd.ExecuteReader();

                 if (rdr.Read() == true)
                 {
                     string yesORno = "";

                     if (rdr[16].ToString() == "1")
                     {
                         yesORno = "YES";
                     }

                     if (rdr[16].ToString() == "0")
                     {
                         yesORno = "NO";
                     }

                   
                     txtRID.Text = rdr[0].ToString();
                     txtSupplierID.Text = rdr[2].ToString();

           
                     lblStock.Text = yesORno;
              

    
                     lblStatus.Text = rdr[15].ToString();
                 


                     txtOID.Text = rdr[1].ToString();
                     txtREFFCode.Text = rdr[3].ToString();
                     txtPCode.Text = rdr[4].ToString();

                     txtDeliverDT.Text = rdr[10].ToString();
                     txtQ.Text = rdr[5].ToString();
                     txtOPID.Text = rdr[18].ToString();

                   
                     txtTAX.Text = rdr[8].ToString();
                


                     txtTAXAmount.Text = rdr[9].ToString();
                

               
                     txtTotP.Text = rdr[12].ToString();
        

   
                     txtPT.Text = rdr[13].ToString();
              

             
                     txtDiscPerc.Text = rdr[6].ToString();
        

             
                     txtDiscountA.Text = rdr[7].ToString();
          

         
                     txtAP.Text = rdr[17].ToString();
             


                     txtUP.Text = rdr[11].ToString();
             
                 }

                 rdr.Close();
                 con.Close();
             }
             catch (Exception exDAFS)
             {

                 MessageBox.Show("Something went wrong! Issue key: 0x1DAFS");
             }
       

        }

        private void searchItemInfo()
        {

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT  ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,Pushed,AmountPaid,OperatorID FROM dtb_ReceivedOrderProducts_rws WHERE RefferenceCode LIKE '%" + txtSearchReff.Text + "%'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    string yesORno = "";

                    if (rdr[16].ToString() == "1")
                    {
                        yesORno = "YES";
                    }

                    if (rdr[16].ToString() == "0")
                    {
                        yesORno = "NO";
                    }


                    txtRID.Text = rdr[0].ToString();
                    txtSupplierID.Text = rdr[2].ToString();
                    lblStock.Text = yesORno;
                    lblStatus.Text = rdr[15].ToString();
                    txtOID.Text = rdr[1].ToString();
                    txtREFFCode.Text = rdr[3].ToString();
                    txtPCode.Text = rdr[4].ToString();
                    txtDeliverDT.Text = rdr[10].ToString();
                    txtQ.Text = rdr[5].ToString();
                    txtOPID.Text = rdr[18].ToString();
                    txtTAX.Text = rdr[8].ToString();
                    txtTAXAmount.Text = rdr[9].ToString();
                    txtTotP.Text = rdr[12].ToString();
                    txtPT.Text = rdr[13].ToString();
                    txtDiscPerc.Text = rdr[6].ToString();
                    txtDiscountA.Text = rdr[7].ToString();
                    txtAP.Text = rdr[17].ToString();
                    //     txtDUEDT.Text = rdr[].ToString();
                    txtUP.Text = rdr[11].ToString();
                }

                rdr.Close();
                con.Close();



            }
            catch (Exception exRTA)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1RTA");
            }
          
        }

        private void searchItemInfo2()
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

         
                cmd = new OleDbCommand("SELECT  ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,Pushed,AmountPaid,OperatorID FROM dtb_ReceivedOrderProducts_rws WHERE OrderID LIKE '%" + txtSearchOrder.Text + "%'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    string yesORno = "";

                    if (rdr[16].ToString() == "1")
                    {
                        yesORno = "YES";
                    }

                    if (rdr[16].ToString() == "0")
                    {
                        yesORno = "NO";
                    }


                    txtRID2.Text = rdr[0].ToString();
                    txtSupplierID2.Text = rdr[2].ToString();
                    lblStock2.Text = yesORno;
                    lblStatus2.Text = rdr[15].ToString();
                    txtOID2.Text = rdr[1].ToString();
                    txtREFFCode2.Text = rdr[3].ToString();
                    txtPCode2.Text = rdr[4].ToString();
                    txtDeliverDT2.Text = rdr[10].ToString();
                    txtQ2.Text = rdr[5].ToString();
                    txtOPID2.Text = rdr[18].ToString();
                    txtTAX2.Text = rdr[8].ToString();
                    txtTAXAmount2.Text = rdr[9].ToString();
                    txtTotP2.Text = rdr[12].ToString();
                    txtPT2.Text = rdr[13].ToString();
                    txtDiscPerc2.Text = rdr[6].ToString();
                    txtDiscountA2.Text = rdr[7].ToString();
                    txtAP2.Text = rdr[17].ToString();
                    //     txtDUEDT.Text = rdr[].ToString();
                    txtUP2.Text = rdr[11].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exYUI)
            {
                MessageBox.Show("Something went wrong! Issue key: 0xYUI");
            }

         

        }

        private void searchItemInfo3()
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                //  cmd = new OleDbCommand ("SELECT  ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,Pushed,AmountPaid,OperatorID FROM dtb_ReceivedOrderProducts_rws",con);
                cmd = new OleDbCommand("SELECT  ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,Pushed,AmountPaid,OperatorID FROM dtb_ReceivedOrderProducts_rws WHERE DateDelivered = '" + txtReceivingDT.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    string yesORno = "";

                    if (rdr[16].ToString() == "1")
                    {
                        yesORno = "YES";
                    }

                    if (rdr[16].ToString() == "0")
                    {
                        yesORno = "NO";
                    }


                    txtRID3.Text = rdr[0].ToString();
                    txtSupplierID3.Text = rdr[2].ToString();
                    lblStock3.Text = yesORno;
                    lblStatus3.Text = rdr[15].ToString();
                    txtOID3.Text = rdr[1].ToString();
                    txtREFFCode3.Text = rdr[3].ToString();
                    txtPCode3.Text = rdr[4].ToString();
                    txtDeliverDT3.Text = rdr[10].ToString();
                    txtQ3.Text = rdr[5].ToString();
                    txtOPID3.Text = rdr[18].ToString();
                    txtTAX3.Text = rdr[8].ToString();
                    txtTAXAmount3.Text = rdr[9].ToString();
                    txtTotP3.Text = rdr[12].ToString();
                    txtPT3.Text = rdr[13].ToString();
                    txtDiscPerc3.Text = rdr[6].ToString();
                    txtDiscountA3.Text = rdr[7].ToString();
                    txtAP3.Text = rdr[17].ToString();
                    //     txtDUEDT.Text = rdr[].ToString();
                    txtUP3.Text = rdr[11].ToString();
                }

                rdr.Close();
                con.Close();

            }
            catch (Exception exTAYS)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1TAYS");
            }
           
        }

        private void getItemInfo2()
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                //  cmd = new OleDbCommand ("SELECT  ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,Pushed,AmountPaid,OperatorID FROM dtb_ReceivedOrderProducts_rws",con);
                cmd = new OleDbCommand("SELECT  ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,Pushed,AmountPaid,OperatorID FROM dtb_ReceivedOrderProducts_rws WHERE RefferenceCode = '" + guna2DataGridView2.SelectedRows[0].Cells[1].Value.ToString() + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    string yesORno = "";

                    if (rdr[16].ToString() == "1")
                    {
                        yesORno = "YES";
                    }

                    if (rdr[16].ToString() == "0")
                    {
                        yesORno = "NO";
                    }


                    txtRID2.Text = rdr[0].ToString();
                    txtSupplierID2.Text = rdr[2].ToString();
                    lblStock2.Text = yesORno;
                    lblStatus2.Text = rdr[15].ToString();
                    txtOID2.Text = rdr[1].ToString();
                    txtREFFCode2.Text = rdr[3].ToString();
                    txtPCode2.Text = rdr[4].ToString();
                    txtDeliverDT2.Text = rdr[10].ToString();
                    txtQ2.Text = rdr[5].ToString();
                    txtOPID2.Text = rdr[18].ToString();
                    txtTAX2.Text = rdr[8].ToString();
                    txtTAXAmount2.Text = rdr[9].ToString();
                    txtTotP2.Text = rdr[12].ToString();
                    txtPT2.Text = rdr[13].ToString();
                    txtDiscPerc2.Text = rdr[6].ToString();
                    txtDiscountA2.Text = rdr[7].ToString();
                    txtAP2.Text = rdr[17].ToString();
                    //     txtDUEDT.Text = rdr[].ToString();
                    txtUP2.Text = rdr[11].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exJSH)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1JSH");
            }

          

        }

        private void getItemInfo3()
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                //  cmd = new OleDbCommand ("SELECT  ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,Pushed,AmountPaid,OperatorID FROM dtb_ReceivedOrderProducts_rws",con);
                cmd = new OleDbCommand("SELECT  ReceivedID,OrderID,SupplierID,RefferenceCode,ProductCode,Quantity,DiscountPer,DiscountAmount,TAX,TAXAmount,DateDelivered,UnitPrice,TotalCost,PaymentType,DeliveryAmount,Status,Pushed,AmountPaid,OperatorID FROM dtb_ReceivedOrderProducts_rws WHERE RefferenceCode = '" + guna2DataGridView3.SelectedRows[0].Cells[1].Value.ToString() + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    string yesORno = "";

                    if (rdr[16].ToString() == "1")
                    {
                        yesORno = "YES";
                    }

                    if (rdr[16].ToString() == "0")
                    {
                        yesORno = "NO";
                    }


                    txtRID3.Text = rdr[0].ToString();
                    txtSupplierID3.Text = rdr[2].ToString();
                    lblStock3.Text = yesORno;
                    lblStatus3.Text = rdr[15].ToString();
                    txtOID3.Text = rdr[1].ToString();
                    txtREFFCode3.Text = rdr[3].ToString();
                    txtPCode3.Text = rdr[4].ToString();
                    txtDeliverDT3.Text = rdr[10].ToString();
                    txtQ3.Text = rdr[5].ToString();
                    txtOPID3.Text = rdr[18].ToString();
                    txtTAX3.Text = rdr[8].ToString();
                    txtTAXAmount3.Text = rdr[9].ToString();
                    txtTotP3.Text = rdr[12].ToString();
                    txtPT3.Text = rdr[13].ToString();
                    txtDiscPerc3.Text = rdr[6].ToString();
                    txtDiscountA3.Text = rdr[7].ToString();
                    txtAP3.Text = rdr[17].ToString();
                    //     txtDUEDT.Text = rdr[].ToString();
                    txtUP3.Text = rdr[11].ToString();
                }

                rdr.Close();
                con.Close();

            }
            catch (Exception exISJ)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1ISJ");
            }

           
        }

        private void getOrderATTCreator()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT UID,Username FROM dtb_Login_rws,dtb_SupplyOrders_rws WHERE dtb_Login_rws.UID = dtb_SupplyOrders_rws.OperatorID AND dtb_SupplyOrders_rws.OrderID = '" + txtOID.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
      
                    txtOATT.Text = rdr[1].ToString();
 

                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exOSLS)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1OSLS");
            }

        

        }

        private void getOrderATTCreator2()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT UID,Username FROM dtb_Login_rws,dtb_SupplyOrders_rws WHERE dtb_Login_rws.UID = dtb_SupplyOrders_rws.OperatorID AND dtb_SupplyOrders_rws.OrderID = '" + txtOID2.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtOATT2.Text = rdr[1].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exBNS)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1BNS");
            }

           

        }

        private void getOrderATTCreator3()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT UID,Username FROM dtb_Login_rws,dtb_SupplyOrders_rws WHERE dtb_Login_rws.UID = dtb_SupplyOrders_rws.OperatorID AND dtb_SupplyOrders_rws.OrderID = '" + txtOID3.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtOATT3.Text = rdr[1].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exXLS)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1XLS");
            }

        

        }

        private void getOrderATTReceiver()
        {
            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT UID,Username FROM dtb_Login_rws,dtb_ReceivedOrderProducts_rws WHERE dtb_Login_rws.UID = dtb_ReceivedOrderProducts_rws.OperatorID AND dtb_ReceivedOrderProducts_rws.RefferenceCode = '" + txtREFFCode.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
          
                    txtRATT.Text = rdr[1].ToString();
        
                }

                rdr.Close();
                con.Close();

            }
            catch (Exception exALO)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1ALO");
            }

        }

        private void getOrderATTReceiver2()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT UID,Username FROM dtb_Login_rws,dtb_ReceivedOrderProducts_rws WHERE dtb_Login_rws.UID = dtb_ReceivedOrderProducts_rws.OperatorID AND dtb_ReceivedOrderProducts_rws.RefferenceCode = '" + txtREFFCode2.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtRATT2.Text = rdr[1].ToString();
                }

                rdr.Close();
                con.Close();

            }
            catch (Exception exPAS)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1PAS");
            }

         
        }

        private void getOrderATTReceiver3()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT UID,Username FROM dtb_Login_rws,dtb_ReceivedOrderProducts_rws WHERE dtb_Login_rws.UID = dtb_ReceivedOrderProducts_rws.OperatorID AND dtb_ReceivedOrderProducts_rws.RefferenceCode = '" + txtREFFCode3.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtRATT3.Text = rdr[1].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exHJS)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1HJS");
            }

         

        }


        private void getSupplierName()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_regSuppliers_rws.SupplierID,SupplierName FROM dtb_regSuppliers_rws,dtb_ReceivedOrderProducts_rws WHERE dtb_regSuppliers_rws.SupplierID = '" + txtSupplierID.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                   
                    txtSName.Text = rdr[1].ToString();
                 
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exLOI)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1LOI");
            }

        

        }

        private void getSupplierName2()
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_regSuppliers_rws.SupplierID,SupplierName FROM dtb_regSuppliers_rws,dtb_ReceivedOrderProducts_rws WHERE dtb_regSuppliers_rws.SupplierID = '" + txtSupplierID2.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtSName2.Text = rdr[1].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exUER)
            {
                MessageBox.Show("Somehting went wrong! Issue key: 0x1UER");
            }

         

        }

        private void getSupplierName3()
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_regSuppliers_rws.SupplierID,SupplierName FROM dtb_regSuppliers_rws,dtb_ReceivedOrderProducts_rws WHERE dtb_regSuppliers_rws.SupplierID = '" + txtSupplierID3.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtSName3.Text = rdr[1].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exGET)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1GET");
            }

         

        }

        private void getTableData()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_ReceivedOrderProducts_rws.OrderID As [Order Number],dtb_ReceivedOrderProducts_rws.RefferenceCode As [Refference Code],ProductName As [Product Name],dtb_ReceivedOrderProducts_rws.Quantity As [Quantity Obtained],dtb_SupplyOrderProducts_rws.Quantity as [Expected Quantity], DateDelivered As [Delivered On],DeliveryAmount As [Delivery Fee] FROM dtb_ReceivedOrderProducts_rws,dtb_Products_rws,dtb_SupplyOrderProducts_rws WHERE dtb_ReceivedOrderProducts_rws.ProductCode=dtb_Products_rws.ProductCode AND dtb_ReceivedOrderProducts_rws.RefferenceCode = dtb_SupplyOrderProducts_rws.RefferenceCode", con);
                cmd.ExecuteNonQuery();

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);

                guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;
                guna2DataGridView2.DataSource = ds.Tables[0].DefaultView;
                guna2DataGridView3.DataSource = ds.Tables[0].DefaultView;

                con.Close();
            }
            catch (Exception exDGH)
            {
         
                MessageBox.Show("Something went wrong! Issue Key: 0x1DGH");
            }
          
        }

   

        private void getOrderDate()
        {
            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT DateCreated FROM dtb_SupplyOrders_rws WHERE OrderID ='" + txtOID.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
         
                    txtODT.Text = rdr[0].ToString();
         
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exDOP)
            {
                MessageBox.Show("something went wrong! Issue key: 0x1DOP");
            }


        }

        private void getOrderDate2()
        {
            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT DateCreated FROM dtb_SupplyOrders_rws WHERE OrderID ='" + txtOID2.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtODT2.Text = rdr[0].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exHDY)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1HDY");
            }


        }

        private void getOrderDate3()
        {

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT DateCreated FROM dtb_SupplyOrders_rws WHERE OrderID ='" + txtOID3.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtODT3.Text = rdr[0].ToString();
                }

                rdr.Close();
                con.Close();

            }
            catch (Exception exAOP)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1AOP");
            }

        }


        private void getExpiryDate()
        {

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT DeliverDate FROM dtb_SupplyOrders_rws WHERE OrderID ='" + txtOID.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
            
                    txtDUEDT.Text = rdr[0].ToString();
                   
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exEMF)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1EMF");
            }


        }

        private void getExpiryDate2()
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT DeliverDate FROM dtb_SupplyOrders_rws WHERE OrderID ='" + txtOID2.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtDUEDT2.Text = rdr[0].ToString();
                }

                rdr.Close();
                con.Close();
            }
            catch (Exception exCVB)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1CVB");
            }

      

        }

        private void getExpiryDate3()
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT DeliverDate FROM dtb_SupplyOrders_rws WHERE OrderID ='" + txtOID3.Text + "'", con);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    txtDueDT3.Text = rdr[0].ToString();
                }

                rdr.Close();
                con.Close();

            }
            catch (Exception exXMC)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1XMC");
            }

        
        }


        private void btnVReport_Click(object sender, EventArgs e)
        {
            processReport();

            txtSearchReff.Focus();
        }

        private void guna2DataGridView1_Click(object sender, EventArgs e)
        {
            getItemInfo();
            getOrderATTCreator();
            getSupplierName();
            getOrderATTReceiver();
            getOrderDate();
            getExpiryDate();

            txtSearchReff.Focus();
        }

        private void guna2DataGridView2_Click(object sender, EventArgs e)
        {
            getItemInfo2();
            getOrderATTCreator2();
            getSupplierName2();
            getOrderATTReceiver2();
            getOrderDate2();
            getExpiryDate2();
        }

        private void guna2DataGridView3_Click(object sender, EventArgs e)
        {
            getItemInfo3();
            getOrderATTCreator3();
            getSupplierName3();
            getOrderATTReceiver3();
            getOrderDate3();
            getExpiryDate3();
        }

      
        private void searchRefferenceCode()
        {

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_ReceivedOrderProducts_rws.OrderID As [Order Number], dtb_ReceivedOrderProducts_rws.RefferenceCode As [Refference Code],ProductName As [Product Name],dtb_ReceivedOrderProducts_rws.Quantity As [Quantity Obtained],dtb_SupplyOrderProducts_rws.Quantity as [Expected Quantity], DateDelivered As [Delivered On],DeliveryAmount As [Delivery Fee] FROM dtb_ReceivedOrderProducts_rws,dtb_Products_rws,dtb_SupplyOrderProducts_rws WHERE dtb_ReceivedOrderProducts_rws.ProductCode=dtb_Products_rws.ProductCode AND dtb_ReceivedOrderProducts_rws.RefferenceCode = dtb_SupplyOrderProducts_rws.RefferenceCode AND dtb_ReceivedOrderProducts_rws.RefferenceCode LIKE '%" + txtSearchReff.Text + "%'", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(ds);

                guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;

                con.Close();

            }
            catch (Exception exLEW)
            {
                MessageBox.Show("Somethig went wrong! Issue key: 0x1LEW");
            }

        }

        private void searchReceivingDate()
        {

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_ReceivedOrderProducts_rws.OrderID As [Order Number], dtb_ReceivedOrderProducts_rws.RefferenceCode As [Refference Code],ProductName As [Product Name],dtb_ReceivedOrderProducts_rws.Quantity As [Quantity Obtained],dtb_SupplyOrderProducts_rws.Quantity as [Expected Quantity], DateDelivered As [Delivered On],DeliveryAmount As [Delivery Fee] FROM dtb_ReceivedOrderProducts_rws,dtb_Products_rws,dtb_SupplyOrderProducts_rws WHERE dtb_ReceivedOrderProducts_rws.ProductCode=dtb_Products_rws.ProductCode AND dtb_ReceivedOrderProducts_rws.RefferenceCode = dtb_SupplyOrderProducts_rws.RefferenceCode AND dtb_ReceivedOrderProducts_rws.DateDelivered = '" + txtReceivingDT.Text + "'", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(ds);

                guna2DataGridView3.DataSource = ds.Tables[0].DefaultView;

                con.Close();
            }
            catch (Exception exKLO)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1KLO");
            }


        }

        private void searchOrderNumber()
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_ReceivedOrderProducts_rws.OrderID As [Order Number], dtb_ReceivedOrderProducts_rws.RefferenceCode As [Refference Code],ProductName As [Product Name],dtb_ReceivedOrderProducts_rws.Quantity As [Quantity Obtained],dtb_SupplyOrderProducts_rws.Quantity as [Expected Quantity], DateDelivered As [Delivered On],DeliveryAmount As [Delivery Fee] FROM dtb_ReceivedOrderProducts_rws,dtb_Products_rws,dtb_SupplyOrderProducts_rws WHERE dtb_ReceivedOrderProducts_rws.ProductCode=dtb_Products_rws.ProductCode AND dtb_ReceivedOrderProducts_rws.RefferenceCode = dtb_SupplyOrderProducts_rws.RefferenceCode AND dtb_SupplyOrderProducts_rws.OrderID LIKE '%" + txtSearchOrder.Text + "%'", con);

                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(ds);

                guna2DataGridView2.DataSource = ds.Tables[0].DefaultView;

                con.Close();

            }
            catch (Exception exOAS)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1OAS");
            }

       
        }

        private void markColumns()
        {

            try
            {

                //Datagridview1 Style
                guna2DataGridView1.Columns[3].HeaderCell.Style.BackColor = Color.Black;
                guna2DataGridView1.Columns[4].HeaderCell.Style.BackColor = Color.Black;

                //Datagridview2 Style
                guna2DataGridView2.Columns[3].HeaderCell.Style.BackColor = Color.Black;
                guna2DataGridView2.Columns[4].HeaderCell.Style.BackColor = Color.Black;

                //Datagridview3 Style
                guna2DataGridView3.Columns[3].HeaderCell.Style.BackColor = Color.Black;
                guna2DataGridView3.Columns[4].HeaderCell.Style.BackColor = Color.Black;
            }
            catch (Exception exGDT)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1GDT");
            }


        }

        private void txtSearchReff_TextChanged(object sender, EventArgs e)
        {
            searchItemInfo();
            searchRefferenceCode();
            getOrderATTCreator();
            getSupplierName();
            getOrderATTReceiver();
            getOrderDate();
            getExpiryDate();
        
        }

        private void txtSearchOrder_TextChanged(object sender, EventArgs e)
        {
            searchItemInfo2();
            searchOrderNumber();
            getOrderATTCreator2();
            getSupplierName2();
            getOrderATTReceiver2();
            getOrderDate2();
            getExpiryDate2();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            searchItemInfo3();
            searchReceivingDate();
            getOrderATTCreator3();
            getSupplierName3();
            getOrderATTReceiver3();
            getOrderDate3();
            getExpiryDate3();
        }

        private void performSave()
        {
            if (Convert.ToDouble(guna2DataGridView1.SelectedRows[0].Cells[3].Value) != Convert.ToDouble(guna2DataGridView1.SelectedRows[0].Cells[4].Value))
            {
                MessageBox.Show("Cannot merge Products until they are fully delivered.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblStock.Text == "YES")
            {
                MessageBox.Show("Stock has already been merged with the existing one.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();


                cmd = new OleDbCommand("UPDATE dtb_Stock_rws SET StockDate = " + Convert.ToDouble(guna2DataGridView1.SelectedRows[0].Cells[5].Value) + " WHERE ProductCode = '" + txtPCode.Text + "'", con);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("UPDATE dtb_Stock_rws SET Quantity = Quantity + " + Convert.ToDouble(guna2DataGridView1.SelectedRows[0].Cells[3].Value) + " WHERE ProductCode = '" + txtPCode.Text + "'", con);
                cmd.ExecuteNonQuery();


                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("UPDATE dtb_currentStock_rws SET Quantity = Quantity + " + Convert.ToDouble(guna2DataGridView1.SelectedRows[0].Cells[3].Value) + " WHERE ProductCode = '" + txtPCode.Text + "'", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Done");

                clsSystemTray.notifier("New Products Successfully Added To Stock");

                con.Close();
            }
            catch (Exception exLDB)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1LDB");
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            performSave();

        }

        private void performSave2()
        {
            if (Convert.ToDouble(guna2DataGridView2.SelectedRows[0].Cells[3].Value) != Convert.ToDouble(guna2DataGridView2.SelectedRows[0].Cells[4].Value))
            {
                MessageBox.Show("Cannot merge Products until they are fully delivered.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblStock2.Text == "YES")
            {
                MessageBox.Show("Stock has already been merged with the existing one.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("UPDATE dtb_Stock_rws SET StockDate =" + Convert.ToDouble(guna2DataGridView2.SelectedRows[0].Cells[5].Value) + " WHERE ProductCode = '" + txtPCode2.Text + "'", con);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("UPDATE dtb_Stock_rws SET Quantity = Quantity + " + Convert.ToDouble(guna2DataGridView2.SelectedRows[0].Cells[3].Value) + " WHERE ProductCode = '" + txtPCode2.Text + "'", con);
                cmd.ExecuteNonQuery();


                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("UPDATE dtb_currentStock_rws SET Quantity = Quantity + " + Convert.ToDouble(guna2DataGridView2.SelectedRows[0].Cells[3].Value) + " WHERE ProductCode = '" + txtPCode2.Text + "'", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Done");

                clsSystemTray.notifier("New Products Successfully Added To Stock");

                con.Close();
            }
            catch (Exception exNJS)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1NJS");
            }

            txtSearchReff.Focus();
        }


        private void performSave3()
        {
            if (Convert.ToDouble(guna2DataGridView3.SelectedRows[0].Cells[3].Value) != Convert.ToDouble(guna2DataGridView3.SelectedRows[0].Cells[4].Value))
            {
                MessageBox.Show("Cannot merge Products until they are fully delivered.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblStock3.Text == "YES")
            {
                MessageBox.Show("Stock has already been merged with the existing one.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("UPDATE dtb_Stock_rws SET StockDate =" + Convert.ToDouble(guna2DataGridView3.SelectedRows[0].Cells[5].Value) + " WHERE ProductCode = '" + txtPCode3.Text + "'", con);
                cmd.ExecuteNonQuery();


                cmd = new OleDbCommand("UPDATE dtb_Stock_rws SET Quantity = Quantity + " + Convert.ToDouble(guna2DataGridView3.SelectedRows[0].Cells[3].Value) + " WHERE ProductCode = '" + txtPCode3.Text + "'", con);
                cmd.ExecuteNonQuery();


                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("UPDATE dtb_currentStock_rws SET Quantity = Quantity + " + Convert.ToDouble(guna2DataGridView3.SelectedRows[0].Cells[3].Value) + " WHERE ProductCode = '" + txtPCode3.Text + "'", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Done");

                clsSystemTray.notifier("New Products Successfully Added To Stock");

                con.Close();

            }
            catch (Exception exBAH)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1BAH");
            }

            
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            performSave2();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            performSave3();
        }

        private void btnReverseTrans_Click(object sender, EventArgs e)
        {
            if(lblStatus.Text != "YES")
            {
                MessageBox.Show("You cannot erase this Product's record until it's merged to the existing Stock!","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("DELETE FROM dtb_ReceivedOrderProducts_rws WHERE RefferenceCode = '" + guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted.");

                con.Close();

            }
            catch (Exception exKAE)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1KAE");
            }

            txtSearchReff.Focus();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
             if(lblStatus2.Text != "YES")
            {
                MessageBox.Show("You cannot erase this Product's record until it's merged to the existing Stock!","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("DELETE FROM dtb_ReceivedOrderProducts_rws WHERE RefferenceCode = '" + guna2DataGridView2.SelectedRows[0].Cells[1].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted.");

                con.Close();

            }
            catch (Exception exKAE)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1KAE");
            }

           txtSearchOrder.Focus();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
             if(lblStatus3.Text != "YES")
            {
                MessageBox.Show("You cannot erase this Product's record until it's merged to the existing Stock!","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("DELETE FROM dtb_ReceivedOrderProducts_rws WHERE RefferenceCode = '" + guna2DataGridView3.SelectedRows[0].Cells[1].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record deleted.");

                con.Close();

            }
            catch (Exception exKAE)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1KAE");
            }

        }

        private void lblStock_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void txtOATT_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void processReport()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                rptReceivedOrderProductsReport theReport = new rptReceivedOrderProductsReport();

                //The report you created.
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_ReceivedOrderProducts_rws.OrderID As [Order Number],dtb_ReceivedOrderProducts_rws.RefferenceCode As [Refference Code],ProductName As [Product Name],dtb_ReceivedOrderProducts_rws.Quantity As [Quantity Obtained],dtb_SupplyOrderProducts_rws.Quantity as [Expected Quantity], DateDelivered As [Delivery Date],DeliveryAmount As [Delivery Fee] FROM dtb_ReceivedOrderProducts_rws,dtb_Products_rws,dtb_SupplyOrderProducts_rws WHERE dtb_ReceivedOrderProducts_rws.ProductCode=dtb_Products_rws.ProductCode AND dtb_ReceivedOrderProducts_rws.RefferenceCode = dtb_SupplyOrderProducts_rws.RefferenceCode AND dtb_ReceivedOrderProducts_rws.RefferenceCode LIKE '%" + txtSearchReff.Text + "%'", con);
                //      cmd.ExecuteNonQuery();

                // ds = new DataSet();
                DataTable dtb = new DataTable();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(dtb);


                theReport.Database.Tables["ReceivedOrderProducts"].SetDataSource(dtb);
                frmReceivedOrderProductsReport frm = new frmReceivedOrderProductsReport();
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

        private void processReport2()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                rptReceivedOrderProductsReport theReport = new rptReceivedOrderProductsReport();

                //The report you created.
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_ReceivedOrderProducts_rws.OrderID As [Order Number],dtb_ReceivedOrderProducts_rws.RefferenceCode As [Refference Code],ProductName As [Product Name],dtb_ReceivedOrderProducts_rws.Quantity As [Quantity Obtained],dtb_SupplyOrderProducts_rws.Quantity as [Expected Quantity], DateDelivered As [Delivery Date],DeliveryAmount As [Delivery Fee] FROM dtb_ReceivedOrderProducts_rws,dtb_Products_rws,dtb_SupplyOrderProducts_rws WHERE dtb_ReceivedOrderProducts_rws.ProductCode=dtb_Products_rws.ProductCode AND dtb_ReceivedOrderProducts_rws.RefferenceCode = dtb_SupplyOrderProducts_rws.RefferenceCode AND dtb_ReceivedOrderProducts_rws.OrderID LIKE '%" + txtSearchOrder.Text + "%'", con);
                //      cmd.ExecuteNonQuery();

                // ds = new DataSet();
                DataTable dtb = new DataTable();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(dtb);


                theReport.Database.Tables["ReceivedOrderProducts"].SetDataSource(dtb);
                frmReceivedOrderProductsReport frm = new frmReceivedOrderProductsReport();
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

        private void processReport3()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                rptReceivedOrderProductsReport theReport = new rptReceivedOrderProductsReport();

                //The report you created.
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_ReceivedOrderProducts_rws.OrderID As [Order Number],dtb_ReceivedOrderProducts_rws.RefferenceCode As [Refference Code],ProductName As [Product Name],dtb_ReceivedOrderProducts_rws.Quantity As [Quantity Obtained],dtb_SupplyOrderProducts_rws.Quantity as [Expected Quantity], DateDelivered As [Delivery Date],DeliveryAmount As [Delivery Fee] FROM dtb_ReceivedOrderProducts_rws,dtb_Products_rws,dtb_SupplyOrderProducts_rws WHERE dtb_ReceivedOrderProducts_rws.ProductCode=dtb_Products_rws.ProductCode AND dtb_ReceivedOrderProducts_rws.RefferenceCode = dtb_SupplyOrderProducts_rws.RefferenceCode AND dtb_ReceivedOrderProducts_rws.DateDelivered = '" + txtReceivingDT.Text + "'", con);
                //      cmd.ExecuteNonQuery();

                // ds = new DataSet();
                DataTable dtb = new DataTable();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(dtb);


                theReport.Database.Tables["ReceivedOrderProducts"].SetDataSource(dtb);
                frmReceivedOrderProductsReport frm = new frmReceivedOrderProductsReport();
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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            processReport2();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            processReport3();
        }

    }
}
