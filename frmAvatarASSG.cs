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
    public partial class frmAvatarASSG : Form
    {
        public frmAvatarASSG()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            #region Anime
                  gunaTransition1.AddToQueue(panel4, Guna.UI.Animation.AnimateMode.Show, true);
                  gunaTransition1.AddToQueue(searchRst, Guna.UI.Animation.AnimateMode.Show, true);

            #endregion

            try
            {
           
                    avatar.Image = Image.FromFile(frmAvatarOPT.imageLocation);
            
            }
            catch (Exception ex1FNF)
            {

                MessageBox.Show("Something went wrong! Issue key: 0x1FNF");
             
            }
       
        }

        #region DatabaseComponents

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

        #endregion


        /// <summary>
        /// 0 = NULL
        /// 1 = PRODUCTS
        /// 2 = CUSTOMERS
        /// 3 = SUPPLIERS
        /// </summary>
        short searchID = 0;
        string avatarPlaceHolder = "";
        string avatarRep = "";

        private void frmAvatarASSG_Load(object sender, EventArgs e)
        {

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                if (frmAvatarOPT.databaseID == 1)
                {
                    searchID = 1;
                    cmd = new OleDbCommand("SELECT dtb_Products_rws.ProductCode,ProductName,ProductDescription FROM dtb_Products_rws,dtb_currentStock_rws WHERE dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode order by ProductName asc", con);
                }

                if (frmAvatarOPT.databaseID == 2)
                {
                    searchID = 2;
                    cmd = new OleDbCommand("Select  CustomerID,CName,Notes From dtb_regCustomers_rws order by CName asc", con);
                }

                if (frmAvatarOPT.databaseID == 3)
                {
                    searchID = 3;
                    cmd = new OleDbCommand("Select  SupplierID,SupplierName,Notes From dtb_regSuppliers_rws order by SupplierName asc", con);
                }

                ds = new DataSet();



                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);


                searchRst.DataSource = ds.Tables[0].DefaultView;

                con.Close();
            }
            catch (Exception exDBA)
            {

                MessageBox.Show("Something went wrong. Issue key: 0x1DBA");
            }


            getIDnAvatar();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                guna2WinProgressIndicator1.Visible = true;
                timer1.Start();

                if (searchID == 1)
                {
                    ProductSearch();
                }

                if (searchID == 2)
                {
                    CustomerSearch();
                }

                if (searchID == 3)
                {
                    SupplierSearch();
                }
            }
            catch (Exception exAll)
            {

                MessageBox.Show("Something went wrong. Issue key: 0x1All");
            }
       
         
        }

        private void CustomerSearch()
        {
            try
            {
                clsFilterData clsFilterDataInst = new clsFilterData();
                clsFilterDataInst.searchData(searchRst, "SELECT CustomerID,CName,Notes From dtb_regCustomers_rws where dtb_regCustomers_rws.CName like '", txtSearch.Text, "dtb_regCustomers_rws");
            }
            catch (Exception exCus)
            {

                MessageBox.Show("Something went wrong. Issue key: 0x1Cus");
            }
  

        }

        private void SupplierSearch()
        {
            try
            {
                clsFilterData clsFilterDataInst = new clsFilterData();
                clsFilterDataInst.searchData(searchRst, "SELECT SupplierID,SupplierName,Notes From dtb_regSuppliers_rws where dtb_regSuppliers_rws.SupplierName like '", txtSearch.Text, "dtb_regSuppliers_rws");
            }
            catch (Exception exSup)
            {

                MessageBox.Show("Something went wrong. Issue key: 0x1Sup");
            }
        

        }

        private void ProductSearch()
        {
            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,ProductDescription From dtb_Products_rws,dtb_currentStock_rws Where dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode AND ProductName Like '%" + txtSearch.Text + "%'", con);


                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);


                searchRst.DataSource = ds.Tables[0].DefaultView;

                con.Close();
            }
            catch (Exception exProd)
            {

                MessageBox.Show("Something went wrong. Issue key: 0x1Prod");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                clsProgressIndicator.timerOps(guna2WinProgressIndicator1, timer1);
            }
            catch (Exception exTOP)
            {

                MessageBox.Show("Something went wrong. Issue key: 0x1TOP");
            }
      
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchID == 1)
                {
                    try
                    {
                        con = new OleDbConnection(connectionString.DBConn);
                        con.Open();

                        if (avatarPlaceHolder != "Untitled")
                        {
                            avatarRep = clsKeyGen.getFullITACode();
                            avatar.Image.Save(clsSysFolder.ifilePath + avatarRep + ".avt");
                            clsCleanUps.addProductImageToGarbageList(avatarPlaceHolder);

                          
                        }

                       
                        cmd = new OleDbCommand("UPDATE dtb_Products_rws SET [Avatar] = @d1 WHERE [ProductCode] ='" + txtCode.Text + "'",con);
                      cmd.Parameters.AddWithValue("@d1", avatarRep);
                        cmd.ExecuteNonQuery();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                            clsSystemTray.notifier("New Product Profile Image Updated.");
                            closeApp();
                        }


                    }
                    catch (Exception exASSG1)
                    {
                      MessageBox.Show("Could not perform the requested operation. Issue key: 0x1ASSG");
                 
                        return;
                    }

                }

                if (searchID == 2)
                {
                    try
                    {
                        con = new OleDbConnection(connectionString.DBConn);
                        con.Open();

                        if (avatarPlaceHolder != "Untitled")
                        {
                            avatarRep = clsKeyGen.getFullCACode();
                            avatar.Image.Save(clsSysFolder.cfilePath + avatarRep + ".avt");
                            clsCleanUps.addCustImageToGarbageList(avatarPlaceHolder);
                           
                        }

                        cmd = new OleDbCommand("UPDATE dtb_regCustomers_rws SET [Avatar] = @d1 WHERE [CustomerID] ='" + txtCode.Text + "'", con);
                        cmd.Parameters.AddWithValue("@d1", avatarRep);
                        cmd.ExecuteNonQuery();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                            clsSystemTray.notifier("New Customer Profile Image Updated.");
                            closeApp();
                        }

                    }
                    catch (Exception exASSG2)
                    {
                        MessageBox.Show("Could not perform the requested operation. Issue key: 0x2ASSG");
                        return;
                    }
                   
                }

                if (searchID == 3)
                {

                    try
                    {

                        con = new OleDbConnection(connectionString.DBConn);
                        con.Open();

                        if (avatarPlaceHolder != "Untitled")
                        {
                            avatarRep = clsKeyGen.getFullSACode();
                            avatar.Image.Save(clsSysFolder.sfilePath + avatarRep + ".avt");
                            clsCleanUps.addSupImageToGarbageList(avatarPlaceHolder);
                            
                        }


                        cmd = new OleDbCommand("UPDATE dtb_regSuppliers_rws SET [Avatar] = @d1 WHERE [SupplierID] ='" + txtCode.Text + "'", con);
                        cmd.Parameters.AddWithValue("@d1", avatarRep);
                        cmd.ExecuteNonQuery();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                            clsSystemTray.notifier("New Supplier Profile Image Updated.");
                            closeApp();
                            
                        }

                    }
                    catch (Exception ex3ASSG)
                    {
                        MessageBox.Show("Could not perform the requested operation. Issue key: 0x3ASSG");
                      
                        return;
                    }

                   
                }
            }
            catch (Exception ex1RND)
            {

                MessageBox.Show("Something went wrong! Issue key: 0x1RND");
            }
           
        }

        private void closeApp()
        {
            this.Close();
            Application.Exit();
        }

        private void searchRst_Click(object sender, EventArgs e)
        {
            getIDnAvatar();
          
        }

        private void getIDnAvatar()
        {
            //FOR PRODUCTS
            if (searchID == 1)
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select ProductCode,Avatar From dtb_Products_rws WHERE ProductCode = @v1", con);
                cmd.Parameters.AddWithValue("v1", searchRst.SelectedCells[0].Value.ToString());

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtCode.Text = rd[0].ToString();
                    txtAvatar.Text = rd[1].ToString();
                    avatarPlaceHolder = rd[1].ToString();

                }

                con.Close();
            }


            //FOR CUSTOMERS
            if (searchID == 2)
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select CustomerID,Avatar From dtb_regCustomers_rws WHERE CustomerID = @v1", con);
                cmd.Parameters.AddWithValue("v1", searchRst.SelectedCells[0].Value.ToString());

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtCode.Text = rd[0].ToString();
                    txtAvatar.Text = rd[1].ToString();
                    avatarPlaceHolder = rd[1].ToString();

                }

                con.Close();
            }

            //FOR SUPPLIERS
            if (searchID == 3)
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select SupplierID,Avatar From dtb_regSuppliers_rws where SupplierID = @v1", con);
                cmd.Parameters.AddWithValue("v1", searchRst.SelectedCells[0].Value.ToString());

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtCode.Text = rd[0].ToString();
                    txtAvatar.Text = rd[1].ToString();
                    avatarPlaceHolder = rd[1].ToString();
                }

                con.Close();
            }
        }

        private void frmAvatarASSG_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
