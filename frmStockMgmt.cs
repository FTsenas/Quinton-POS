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
    public partial class frmStockMgmt : Form
    {
        public frmStockMgmt()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            #region GUIDESIGN
            gunaTransition1.AddToQueue(searchRstAll, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(searchRst, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(guna2GradientPanel5, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(guna2GroupBox1, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition2.AddToQueue(btnANP, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(btnUInfo, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(btnUPA, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(btnInc, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(btnDEC, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(btnSB, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition3.AddToQueue(btnPrevFIC, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(btnREGSup, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(btnUndo, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(delSelected, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(guna2GroupBox2, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(guna2GroupBox4, Guna.UI.Animation.AnimateMode.Show, true);
            #endregion

        }

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

        String avatarPlaceHolder = "";
        String avatarRep = "";


        #region ProductInfoCarriers
        public static string PCode = "";
        public static string PName = "";
        public static string PDescription = "";
        public static string PQuantity = "";
        public static string PPrice = "";
        #endregion


        List<string> selectedDTGridIndexes = new List<string>();
        List<string> supIDItems = new List<string>();
  

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void getSupImage(PictureBox pBox, String imgName) //METHOD TO GET SUPPLIER PROFILE IMAGE IF AVAILABLE.
        {

            try
            {
                pBox.Image = Image.FromFile(clsSysFolder.sfilePath + clsKeyGen.getFullSACode() + ".avt");
            }

            catch (FileNotFoundException ex3)
            {
                try
                {
                    pBox.Image = Image.FromFile(clsSysFolder.sfilePath + "Untitled.avt");
                }
                catch (FileNotFoundException ex5)
                {
                    pBox.Image = null;
                }
                
            }

        }


        private void getSupplier()  //METHOD TO GET PRODUCT SUPPLIER IF AVAILABLE.
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT  dtb_regSuppliers_rws.SupplierID,SupplierName,Address,City,dtb_regSuppliers_rws.Avatar,StockDate FROM dtb_regSuppliers_rws, dtb_Products_rws, dtb_Stock_rws WHERE dtb_Stock_rws.SupplierID=dtb_regSuppliers_rws.SupplierID AND dtb_Stock_rws.ProductCode= '" + txtCode.Text + "'", con);
                rd = cmd.ExecuteReader();


                if (rd.Read() == true)
                {
                    if (rd.HasRows)
                    {
                     
                        txtSupID.Text = rd[0].ToString();
                   

                     
                        txtSupName.Text = rd[1].ToString();
                 

              
                        txtSupAdd.Text = rd[2].ToString();
              

                 
                        txtSupCIT.Text = rd[3].ToString();
             


                        getSupImage(supAvatar, rd[4].ToString());
                    }
                    else
                    {
                        txtSupID.Clear();
                        txtSupName.Clear();
                        txtSupAdd.Clear();
                        txtSupCIT.Clear();
                    }


                }
                else
                {

                    supAvatar.Image = Image.FromFile(clsSysFolder.sfilePath + "Untitled.avt");
                    txtSupID.Clear();
                    txtSupName.Clear();
                    txtSupAdd.Clear();
                    txtSupCIT.Clear();

                }


                rd.Close();
                con.Close();
            }
            catch (Exception exSup)
            {
            //    MessageBox.Show("" + exSup);
                MessageBox.Show("An error occurred while trying to access page. Issue key: 0x1Sup");

            }



            txtSearch.Focus();


        }

        private void updateProduct()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                try
                {

                    if (avatarPlaceHolder != "Untitled")
                    {

                        avatarRep = clsKeyGen.getFullITACode();
                        avatar.Image.Save(clsSysFolder.ifilePath + avatarRep + ".avt");
                        clsCleanUps.addProductImageToGarbageList(avatarPlaceHolder);

                    } else
                    {
                        avatarRep = clsKeyGen.getFullITACode();
                        avatar.Image.Save(clsSysFolder.ifilePath + avatarRep + ".avt");
                    }


                }
                catch (Exception exITM)
                {
                    MessageBox.Show("Could not process request at the moment. Issue key: 0x1ITM");
                    return;

                }

                string query = "UPDATE dtb_Products_rws SET ProductCode = @d1,ProductName = @d2, ProductDescription = @d3,UnitPrice = @d4,Avatar = @d5 WHERE ProductCode='" + txtCode.Text + "'";
                cmd = new OleDbCommand(query);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtCode.Text);
                cmd.Parameters.AddWithValue("@d2", txtPName.Text);
                cmd.Parameters.AddWithValue("@d3", txtDesc.Text);
                cmd.Parameters.AddWithValue("@d4", txtPrice.Text);
                cmd.Parameters.AddWithValue("@d5", avatarRep);
                cmd.ExecuteNonQuery();


                string query2 = "UPDATE dtb_currentStock_rws SET Quantity = @q1 Where ProductCode = '" + txtCode.Text + "'";
                cmd = new OleDbCommand(query2);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@q1", txtQ.Text);
                cmd.Parameters.AddWithValue("@q2", txtCode.Text);
                cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                clsSystemTray.notifier("Detailes Updated, outdated files have been added to Garbage List");
            }
            catch (Exception exUPD)
            {

                MessageBox.Show("Could not perform the requested operation. Issue key: 0x1UPD");
                return;
            }

        }

        private void frmStockMgmt_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'pOSDataSet.dtb_regSuppliers_rws' table. You can move, or remove it, as needed.
        //    this.dtb_regSuppliers_rwsTableAdapter.Fill(this.pOSDataSet.dtb_regSuppliers_rws);
            // TODO: This line of code loads data into the 'pOSDataSet.dtb_Products_rws' table. You can move, or remove it, as needed.
          //  this.dtb_Products_rwsTableAdapter.Fill(this.pOSDataSet.dtb_Products_rws);

            //SQL BUILD UP TO RETRIEVE ALL PRODUCTS.
     
            txtSearch.Focus();
            DateTime dt = new DateTime();
            dt = System.DateTime.Now;

            toolStripStatusLabel4.Text = dateTimePicker1.Text;
            toolStripStatusLabel2.Text = clsAuthenticity.username;

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity FROM dtb_Products_rws,dtb_currentStock_rws WHERE dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode order by ProductName asc", con);


                //  ds = new DataSet();


                //  adp = new OleDbDataAdapter(cmd);
                //adp.Fill(ds);
                // 


                ///   searchRst.DataSource = ds.Tables[0].DefaultView;



                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtCode.Text = rd[0].ToString();
                    txtPName.Text = rd[1].ToString();
                    txtDesc.Text = rd[2].ToString();
                    txtPrice.Text = rd[3].ToString();
                    txtQ.Text = rd[5].ToString();

                    lblPName.Text = rd[1].ToString();  //FOR ADD ONS PRODUCT NAME.
                    avatarPlaceHolder = rd[4].ToString();
                    avatarRep = avatarPlaceHolder;

                    clsRetrievImage.retrieveImage(avatar, rd[4].ToString()); //CALL TO RETRIEVE PRODUCT IMAGE.


                }

                rd.Close();
                con.Close();
            }
            catch (Exception exAPRO)
            {

                MessageBox.Show("An error occurred. Issue key: 0x1APRO");
            }
      

            searchRstMeth();
            searchRstAllData();
            setRowDefault1(); //Setting the checkbox column for all rows to value: "false";
            getSupplier();
            loadSuppliers();
            autoBindSuppliers();
           
        }

        private void searchRstMeth(string filterInput)
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT ProductName From dtb_Products_rws WHERE ProductName Like '%" + filterInput + "%'", con);


            ds = new DataSet();


            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);



            searchRst.DataSource = ds.Tables[0].DefaultView;

            con.Close();

        }

        public  void refreshPage()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity FROM dtb_Products_rws,dtb_currentStock_rws WHERE dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode order by ProductName asc", con);


                //  ds = new DataSet();


                //  adp = new OleDbDataAdapter(cmd);
                //adp.Fill(ds);
                // 


                ///   searchRst.DataSource = ds.Tables[0].DefaultView;



                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtCode.Text = rd[0].ToString();
                    txtPName.Text = rd[1].ToString();
                    txtDesc.Text = rd[2].ToString();
                    txtPrice.Text = rd[3].ToString();
                    txtQ.Text = rd[5].ToString();

                    lblPName.Text = rd[1].ToString();  //FOR ADD ONS PRODUCT NAME.
                    avatarPlaceHolder = rd[4].ToString();
                    avatarRep = avatarPlaceHolder;

                    clsRetrievImage.retrieveImage(avatar, rd[4].ToString()); //CALL TO RETRIEVE PRODUCT IMAGE.


                }

                rd.Close();
                con.Close();
            }
            catch (Exception exAPRO)
            {

                MessageBox.Show("An error occurred. Issue key: 0x1APRO");
            }


            searchRstMeth();
            searchRstAllData();
            setRowDefault1(); //Setting the checkbox column for all rows to value: "false";
            getSupplier();
            loadSuppliers();
            autoBindSuppliers();
           
        }

        private void searchRstMeth()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT ProductName From dtb_Products_rws order by ProductName asc", con);


            ds = new DataSet();


            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);


       //     searchRst.Rows.Clear();
            searchRst.DataSource = ds.Tables[0].DefaultView;

            con.Close();

        }

        //*searchRstAllData* for *frmStockMgmt* onLoad method to get filtered data without Avatar Column!!! 
        private void searchRstAllData()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Quantity FROM dtb_Products_rws,dtb_currentStock_rws WHERE dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode order by ProductName asc", con);


            ds = new DataSet();


            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);


            searchRstAll.DataSource = ds.Tables[0].DefaultView;

            rd.Close();
            con.Close();
        }

        private void autoBindSuppliers()
        {
            if (txtSupID.Text != "")
            {

                for (int i = 0; i <= supList.Items.Count - 1; i++)
                {
                    if (txtSupName.Text == supList.Items[i].ToString())
                    {
                        supList.Text = supList.Items[i].ToString();
                    }
                }

            }
        }

        private void loadSuppliers()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select SupplierID,SupplierName From dtb_regSuppliers_rws", con);
            rd = cmd.ExecuteReader();


            try
            {

                while (rd.Read())
                {
                    supList.Items.Add(rd[1].ToString());
                    supIDItems.Add(rd[0].ToString()); //Collection of suppliers IDs.
                }


                rd.Close();
                con.Close();
            }
            catch (Exception exLDSup)
            {

                MessageBox.Show("An error occurred. Issue key: 0x1LDSup");
                return;
            }


        }


        //*searchRstAllData* with paremeter for *txtSearch* to get filtered data without Avatar Column (SECOND DATADRIDVIEW)!!! 
        private void searchRstAllData(String searchtxt)
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();



            cmd = new OleDbCommand("SELECT dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Quantity FROM dtb_Products_rws,dtb_currentStock_rws WHERE dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode AND ProductName Like '%" + searchtxt + "%'", con);


            ds = new DataSet();


            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);


            searchRstAll.DataSource = ds.Tables[0].DefaultView;

            rd.Close();
            con.Close();
        }





        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


        }

        private void guna2DateTimePicker1_Click(object sender, EventArgs e)
        {
            txtDesc.Clear();
        }

        private void txtSalesQ_Click(object sender, EventArgs e)
        {
            txtDesc.Clear();
        }



        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void guna2Button5_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage(this, new frmSalesMenu());


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            try
            {
                guna2WinProgressIndicator1.Visible = true;
                timer1.Start();

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity From dtb_Products_rws,dtb_currentStock_rws Where dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode AND ProductName Like '%" + txtSearch.Text + "%' order by ProductName asc", con);


                //        ds = new DataSet();


                //    adp = new OleDbDataAdapter(cmd);
                //     adp.Fill(ds);



                //   searchRst.DataSource = ds.Tables[0].DefaultView;
                //   searchRstAll.DataSource = ds.Tables[0].DefaultView;

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {


                    txtCode.Text = rd[0].ToString();
                    txtPName.Text = rd[1].ToString();
                    txtDesc.Text = rd[2].ToString();
                    txtPrice.Text = rd[3].ToString();
                    txtQ.Text = rd[5].ToString();

                    lblPName.Text = rd[1].ToString();
                    avatarPlaceHolder = rd[4].ToString();
                    avatarRep = avatarPlaceHolder; //Setting a default value for avatarReplacer

                    clsRetrievImage.retrieveImage(avatar, rd[4].ToString());

                }

                rd.Close();
                con.Close();
                searchRstMeth(txtSearch.Text);

                // searchRstAllData(txtSearch.Text);
                getSupplier();
                autoBindSuppliers();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Character not supported!");
                txtSearch.Clear();

            }
   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsProgressIndicator.timerOps(guna2WinProgressIndicator1, timer1);
        }


        private void frmStockMgmt_FormClosed(object sender, FormClosedEventArgs e)
        {

            clsAuthenticity.showRunningForm();
           
        }

        private void avatar_Click(object sender, EventArgs e)
        {
            previewAvatar previewAvatarInst = new previewAvatar(avatar.Image, txtPrice.Text);
            previewAvatarInst.ShowDialog(this);
        }

        private void searchRst_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity From dtb_Products_rws,dtb_currentStock_rws Where dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode AND ProductName =  @v1", con);
                cmd.Parameters.AddWithValue("v1", searchRst.SelectedCells[0].Value.ToString());
                rd = cmd.ExecuteReader();


                try
                {
                    if (rd.Read() == true)
                    {
                        gunaTransition4.HideSync(txtCode);
                        txtCode.Text = rd[0].ToString();
                        gunaTransition4.ShowSync(txtCode);

                        gunaTransition4.HideSync(txtPName);
                        txtPName.Text = rd[1].ToString();
                        gunaTransition4.ShowSync(txtPName);

                        gunaTransition4.HideSync(txtPName);
                        txtDesc.Text = rd[2].ToString();
                        gunaTransition4.ShowSync(txtPName);

                        gunaTransition4.HideSync(txtPrice);
                        txtPrice.Text = rd[3].ToString();
                        gunaTransition4.ShowSync(txtPrice);

                        gunaTransition4.HideSync(txtQ);
                        txtQ.Text = rd[5].ToString();
                        gunaTransition4.ShowSync(txtQ);

                        lblPName.Text = rd[1].ToString();
                        avatarPlaceHolder = rd[4].ToString();
                        avatarRep = avatarPlaceHolder; //Setting a default value for avatarReplacer

                        clsRetrievImage.retrieveImage(avatar, rd[4].ToString());

                    }

                }
                catch (InvalidOperationException exGGG)
                {
                    return;
                }
           
                rd.Close();
                con.Close();

                //  searchRstAllData(searchRst.SelectedCells[1].Value.ToString()); //NEED FINAL ALTERATION AFTER PRODUCTNAME BINDING TO GET PARAMETER VALUE FROM TEXTBOX(txtPName)!!!!!!!
                getSupplier();
                autoBindSuppliers();
            }
            catch (Exception exHHH)
            {
                MessageBox.Show("Something went wrong! Issue Key: 0x1HHH");
            }
          
        }

        private void searchRstAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchRstAll_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void searchRstAll_DoubleClick(object sender, EventArgs e)
        {
            txtSearch.Focus();
            return;
        }

        private void searchRstAll_Click(object sender, EventArgs e)
        {

        }

        private void searchRstAll_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void searchRstAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txtSupName_TextChanged(object sender, EventArgs e)
        {
            if (txtSupName.Text != "")
            {
                btnPrevFIC.Enabled = true;
                btnPrevFIC.BackColor = Color.DarkOrange;

            }
            else if (txtSupName.Text == "")
            {
                btnPrevFIC.Enabled = false;
                supList.Text = "";
                btnPrevFIC.BackColor = Color.Gray;

            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
          
        }
        /// <summary>
        /// 
        /// SETTING THE SECOND DATAGRIDVIEW'S  ROW'S FIRST COLUMN('SELECT') TO FALSE.
        /// 
        /// </summary>
        private void setRowDefault1()
        {
            foreach (DataGridViewRow dtRow in searchRstAll.Rows)
            {
                dtRow.Cells[0].Value = false;

            }
        }


        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            setRowDefault1();
            selectedDTGridIndexes.Clear();
            txtSearch.Focus();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= selectedDTGridIndexes.Count - 1; i++)
            {
                MessageBox.Show("" + selectedDTGridIndexes[i]);
            }

            //  foreach(DataGridViewRow item in searchRstAll.Rows)
            //       {
            //     if(item.Cells[0].Value.ToString() == "true")
            //       {
            //             MessageBox.Show("Selected Rows: " + item.Cells[0].RowIndex.ToString());
            //     con = new OleDbConnection (connectionString.DBConn);
            //     con.Open();

            //   cmd = new OleDbCommand("DELETE FROM dtb_Products_rws WHERE ProductCode = '" + item.Cells[1].Value.ToString() + "'");
            //   cmd.ExecuteNonQuery();
            //     con.Close();

            //  }
            //  }

            //   MessageBox.Show("Deleted!");

            //     txtSearch.Focus();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

         
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            avatar.Image = Image.FromFile(openFileDialog1.FileName);
            avatarRep = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            updateProduct();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage("", this, new frmSupplierProfileEntry());
            txtSearch.Focus();
        }

        private void searchRstAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {

                if (bool.Parse(searchRstAll.Rows[e.RowIndex].Cells[0].Value.ToString()) == false)
                {
                    searchRstAll.Rows[e.RowIndex].Cells[0].Value = true;
                    selectedDTGridIndexes.Add(searchRstAll.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
                else
                {
                    searchRstAll.Rows[e.RowIndex].Cells[0].Value = false;
                    selectedDTGridIndexes.Remove(searchRstAll.Rows[e.RowIndex].Cells[1].Value.ToString());

                }

            }
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
       
        }

        private void btnInc_Click(object sender, EventArgs e)
        {

            if (txtNUM.Text == "")
            {
                MessageBox.Show("No value has been provided!");
                txtNUM.Focus();
                return;

            }

            if (txtNUM.Text == "0")
            {
                MessageBox.Show("No value has been provided!");
                txtNUM.Focus();
                return;

            }

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("update dtb_currentStock_rws set Quantity = Quantity + " + txtNUM.Text + " Where ProductCode= '" + txtCode.Text + "'", con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("" + txtPName.Text + "'s Quantity Updated!");
            txtNUM.Text = "0";  
            refreshRst();
            txtSearch.Focus();

        }

        private void refreshRst()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity FROM dtb_Products_rws,dtb_currentStock_rws WHERE dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode order by ProductName asc", con);

            rd = cmd.ExecuteReader();

            if (rd.Read() == true)
            {
                txtCode.Text = rd[0].ToString();
                txtPName.Text = rd[1].ToString();
                txtDesc.Text = rd[2].ToString();
                txtPrice.Text = rd[3].ToString();
                txtQ.Text = rd[5].ToString();

                lblPName.Text = rd[1].ToString();  //FOR ADD ONS PRODUCT NAME.
                avatarRep = rd[4].ToString();

                clsRetrievImage.retrieveImage(avatar, rd[4].ToString()); //CALL TO RETRIEVE PRODUCT IMAGE.


            }


            getSupplier();

        }

        private void refreshRstAll()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT dtb_Products_rws.ProductCode,ProductName,ProductDescription,UnitPrice,Avatar,Quantity FROM dtb_Products_rws,dtb_currentStock_rws WHERE dtb_Products_rws.ProductCode=dtb_currentStock_rws.ProductCode", con);







        }
        private void btnDEC_Click(object sender, EventArgs e)
        {

            if (txtNUM.Text == "")
            {
                MessageBox.Show("No value has been provided!");
                txtNUM.Focus();
                return;

            }

            if (txtNUM.Text == "0")
            {
                MessageBox.Show("No value has been provided!");
                txtNUM.Focus();
                return;

            }

            if (Convert.ToInt32(txtNUM.Text) > Convert.ToInt32(txtQ.Text))
            {
                MessageBox.Show("Selected Value Exceeds the Quantity available", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("update dtb_currentStock_rws set Quantity = Quantity - " + txtNUM.Text + " Where ProductCode= '" + txtCode.Text + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("" + txtPName.Text + "'s Quantity Updated!");
                txtNUM.Text = "0";
                refreshRst();
              
            }

            txtSearch.Focus();




        }

        private void txtNUM_Click(object sender, EventArgs e)
        {
            txtNUM.Clear();

        }

        private void txtNUM_MouseClick(object sender, MouseEventArgs e)
        {
            txtNUM.Clear();

        }

        private void txtNUM_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender, e);
        }

        private void btnREGSup_Click(object sender, EventArgs e)
        {
       
        }

        private void btnPrevFIC_Click(object sender, EventArgs e)
        {
          
        }

        private void txtSupID_TextChanged(object sender, EventArgs e)
        {

            clsFilterData.supID = txtSupID.Text;
        }

        private void supList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void txtQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender, e);
        }

        private void delSelected_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2Button5_Click_2(object sender, EventArgs e)
        {
     
        }

        private void guna2RatingStar1_ValueChanged(object sender, EventArgs e)
        {
            guna2RatingStar1.Value = 2.5F;
        }

        private void guna2RatingStar1_Click(object sender, EventArgs e)
        {

        }

        private void guna2RatingStar1_MouseHover(object sender, EventArgs e)
        {

        }

        private void guna2RatingStar1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void guna2RatingStar1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmStockMgmt_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void avatar_Click_1(object sender, EventArgs e)
        {
            previewAvatar previewAvatarInst = new previewAvatar(avatar.Image, txtPrice.Text);
            previewAvatarInst.ShowDialog(this);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage("", this, new frmAddNewProduct());
            txtSearch.Focus();

        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File |*.jpg;*.png;*.jpeg";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click_2(object sender, EventArgs e)
        {
            PCode = txtCode.Text;
            PName = txtPName.Text;
            PDescription = txtDesc.Text;
            PQuantity = txtQ.Text;
            PPrice = txtPrice.Text;
            clsAuthenticity.getPage("", this, new frmStockMgmtFP());
            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click_3(object sender, EventArgs e)
        {
       
        }

        private void guna2GradientButton1_Click_4(object sender, EventArgs e)
        {
            clsAuthenticity.getPage("", this, new frmSupplierProfileEntry());
            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click_5(object sender, EventArgs e)
        {
            guna2AnimateWindow1.SetAnimateWindow(new fullDetailCard(), Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_SLIDE, 300);
            clsAuthenticity.getPage("", this, new fullDetailCard());
            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click_6(object sender, EventArgs e)
        {
            clsAuthenticity.getPage("", this, new frmCriticalStock());
        }

        private void guna2GradientButton1_Click_7(object sender, EventArgs e)
        {
            try
            {

                if (supList.Text == "")
                {
                    MessageBox.Show("Select Supplier first!");
                    return;
                }
                else
                {

                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("update dtb_Stock_rws Set SupplierID = '" + supIDItems[supList.SelectedIndex] + "' Where ProductCode = '" + txtCode.Text + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Done!");

                    refreshRst();

                }


            }
            catch (Exception ex)
            {



                MessageBox.Show("Invalid Input Detected!");
                txtSearch.Focus();
                return;


            }

            txtSearch.Focus();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedDTGridIndexes.Count == 0)
            {
                MessageBox.Show("No selected entries have been detected!");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete the selected records?", "QPOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();



                    for (int i = 0; i <= selectedDTGridIndexes.Count - 1; i++)
                    {
                        cmd = new OleDbCommand("DELETE FROM dtb_Products_rws WHERE ProductCode = '" + selectedDTGridIndexes[i] + "'", con);
                        cmd.ExecuteNonQuery();


                    }


                    MessageBox.Show("Deleted!");

                    con.Close();
                    searchRstMeth();
                    refreshRst();
                    searchRstAllData();
                    txtSearch.Focus();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Could not process command at the moment, please try again");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Operation cancelled!");
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gunaTransition5.HideSync(searchRstAll);
            setRowDefault1();
            selectedDTGridIndexes.Clear();
            gunaTransition5.ShowSync(searchRstAll);
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
       
        }

    }

    }

    

