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
    public partial class frmCustomerUpdateProfile : Form
    {
        public frmCustomerUpdateProfile()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            guna2Transition1.AddToQueue(Label2, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(Label5, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(Label6, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(Label19, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(Label21, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(Label20, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnDelete, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnNew, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnSave, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnUndo, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(datagridview1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);

            guna2Transition2.AddToQueue(txtCustAddress, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtCustC1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtCustC2, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtCustCity, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtCustEmail, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtCustName, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtNote, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtSearch, Guna.UI2.AnimatorNS.AnimateMode.Show, true);

            guna2Transition3.AddToQueue(avatar, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
         

        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;


        private short count = 0;
        List<string> selectedDTGridIndexes = new List<string>();

  
        string avatarPlaceHolder = "";
        string previousAvatar = "";

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();


        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {



        }

        private void guna2WinProgressIndicator1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void guna2WinProgressIndicator1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void guna2WinProgressIndicator1_Leave(object sender, EventArgs e)
        {

        }

        private void guna2WinProgressIndicator1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count <= 5)
            {
                count++;

            }
            else
            {
                timer1.Stop();
                guna2WinProgressIndicator1.Visible = false;
                count = 0;

            }

        }



        private void frmCustomerUpdateProfile_Load(object sender, EventArgs e)
        {

           
            txtSearch.Focus();

            clsFilterData clsFilterDataInst = new clsFilterData();
            clsFilterDataInst.getData(datagridview1, "Select  CustomerID,CName,Address,City,Phone1,Phone2,Email,Notes From ", "dtb_regCustomers_rws order by CName asc");
            setRowDefault1();

            getCustDetails();
        }


        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();

           
                clsFilterData clsFilterDataInst = new clsFilterData();
                clsFilterDataInst.searchData(datagridview1, "SELECT CustomerID,CName,Address,City,Phone1,Phone2,Email,Notes,Avatar From dtb_regCustomers_rws where dtb_regCustomers_rws.CName like '", txtSearch.Text, "dtb_regCustomers_rws");

           
           
            try
            {
                cmd = new OleDbCommand("SELECT CustomerID,CName,Address,City,Phone1,Phone2,Email,Notes,Avatar From dtb_regCustomers_rws where dtb_regCustomers_rws.CustomerID = '" + datagridview1.SelectedRows[0].Cells[1].Value.ToString() + "'", con);

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtCustomerID.Text = rd[0].ToString();
                    txtCustName.Text = rd[1].ToString();
                    txtCustAddress.Text = rd[2].ToString();
                    txtCustCity.Text = rd[3].ToString();
                    txtCustC1.Text = rd[4].ToString();
                    txtCustC2.Text = rd[5].ToString();
                    txtCustEmail.Text = rd[6].ToString();
                    txtNote.Text = rd[7].ToString();
                    avatarPlaceHolder = rd[8].ToString();
                    previousAvatar = avatarPlaceHolder;
                }
            }
            catch (Exception ex)
            {

                return;
            }
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

           
            try
            {
                avatar.Image = Image.FromFile(clsSysFolder.cfilePath + rd[8].ToString() + ".avt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
      

            con.Close();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage("", this, new frmCustomerProfileEntry());
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage(this, new frmSalesMenu());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getPage(this, new frmLogin(""));
        }



        private void frmCustomerUpdateProfile_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            setRowDefault1();
            selectedDTGridIndexes.Clear();
            txtSearch.Focus();
        }

        private void datagridview1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void datagridview1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT CustomerID,CName,Address,City,Phone1,Phone2,Email,Notes,Avatar From dtb_regCustomers_rws where dtb_regCustomers_rws.CustomerID = '" + datagridview1.SelectedRows[0].Cells[1].Value.ToString() + "'", con);

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtCustomerID.Text = rd[0].ToString();
                    txtCustName.Text = rd[1].ToString();
                    txtCustAddress.Text = rd[2].ToString();
                    txtCustCity.Text = rd[3].ToString();
                    txtCustC1.Text = rd[4].ToString();
                    txtCustC2.Text = rd[5].ToString();
                    txtCustEmail.Text = rd[6].ToString();
                    txtNote.Text = rd[7].ToString();
                    avatarPlaceHolder = rd[8].ToString();
                    previousAvatar = avatarPlaceHolder;
                }
            }
            catch (Exception ex)
            {

                return;
            }
         
            try
            {
                avatar.Image = Image.FromFile(clsSysFolder.cfilePath + rd[8].ToString() + ".avt");
            }
            catch (Exception ex)
            {
                avatar.Image = Image.FromFile(clsSysFolder.cfilePath +  "Untitled.avt");
                return;
            }
      

            con.Close();
        }

        private void getCustDetails()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT CustomerID,CName,Address,City,Phone1,Phone2,Email,Notes,Avatar From dtb_regCustomers_rws order by CName asc", con);

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtCustomerID.Text = rd[0].ToString();
                    txtCustName.Text = rd[1].ToString();
                    txtCustAddress.Text = rd[2].ToString();
                    txtCustCity.Text = rd[3].ToString();
                    txtCustC1.Text = rd[4].ToString();
                    txtCustC2.Text = rd[5].ToString();
                    txtCustEmail.Text = rd[6].ToString();
                    txtNote.Text = rd[7].ToString();
                    avatarPlaceHolder = rd[8].ToString();
                    previousAvatar = avatarPlaceHolder;
                }

            }
            catch (Exception ex)
            {

                return;
            }
            
            try
            {
                avatar.Image = Image.FromFile(clsSysFolder.cfilePath + rd[8].ToString() + ".avt");
            }
            catch (Exception ex)
            {
                try
                {
                    avatar.Image = Image.FromFile(clsSysFolder.cfilePath + "Untitled.avt");
                }
                catch (FileNotFoundException ex2)
                {
                    avatar.Image = null;
              
                }
               
               
            }


            con.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(selectedDTGridIndexes.Count == 0)
            {
                MessageBox.Show("No selected entires have been detected!");
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
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Could not process the requested command, try again later");
                    txtSearch.Focus();
                    return;
                }

                txtSearch.Focus();
            } else
            {
                MessageBox.Show("Operation Cancelled!");
            }
          

        }

        private void setRowDefault1()
        {
            foreach (DataGridViewRow dtRow in datagridview1.Rows)
            {
                dtRow.Cells[0].Value = false;

            }
        }

        private void datagridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {

                    if (bool.Parse(datagridview1.Rows[e.RowIndex].Cells[0].Value.ToString()) == false)
                    {
                        datagridview1.Rows[e.RowIndex].Cells[0].Value = true;
                        selectedDTGridIndexes.Add(datagridview1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    }
                    else
                    {
                        datagridview1.Rows[e.RowIndex].Cells[0].Value = false;
                        selectedDTGridIndexes.Remove(datagridview1.Rows[e.RowIndex].Cells[1].Value.ToString());

                    }

                }
            }
            catch (Exception ex)
            {

                return;
            }
            
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            clsAuthenticity.getPage("", this, new frmCustomerProfileEntry());
            txtSearch.Focus();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            updateTable();
            txtSearch.Focus();
        }

        private void updateTable()
        {

            // if (avatarPlaceHolderCount == 0)
            //    {
            //       avatarPlaceHolder = "Untitled";
            //      }
            // else if (avatarPlaceHolderCount == 1)
            //     {
            //        avatarPlaceHolder = clsKeyGen.getFullCACode();
            //      }


            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                try
                {
                
                            //if (avatarPlaceHolder != "Untitled")
                            //{
                            //    previousAvatar = clsKeyGen.getFullCACode();
                            //    avatar.Image.Save(clsSysFolder.cfilePath + previousAvatar + ".avt");
                            //    clsCleanUps.addCustImageToGarbageList(avatarPlaceHolder);
                            //}
                            //else
                            //{
                            //    if(previousAvatar == avatarPlaceHolder)
                            //    {
                            //        MessageBox.Show("Item details Updated except for the Avatar since it was never reassigned!");
                            //    } else
                            //    {
                            //        previousAvatar = clsKeyGen.getFullCACode();
                            //        avatar.Image.Save(clsSysFolder.cfilePath + previousAvatar + ".avt");
                            //    }

                              
                            //}


                    if (avatarPlaceHolder != "Untitled")
                    {
                        previousAvatar = clsKeyGen.getFullCACode();
                        avatar.Image.Save(clsSysFolder.cfilePath + previousAvatar + ".avt");
                        clsCleanUps.addCustImageToGarbageList(avatarPlaceHolder);
                    }
                    else
                    {
                        previousAvatar = clsKeyGen.getFullCACode();
                        avatar.Image.Save(clsSysFolder.cfilePath + previousAvatar + ".avt");

                    }


                }  catch (Exception ex)
                {
                    MessageBox.Show("Could not process request at the moment, please try again later");
                    return;
                    
                }
                

        
                    string query = "UPDATE dtb_regCustomers_rws SET CName = @d2, Address = @d3,City = @d4,Phone1 = @d5,Phone2 = @d6,Email = @d7,Notes = @d8,Avatar = @d9 Where CustomerID ='" + txtCustomerID.Text + "'";
                    cmd = new OleDbCommand(query);
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@d2", txtCustName.Text);
                    cmd.Parameters.AddWithValue("@d3", txtCustAddress.Text);
                    cmd.Parameters.AddWithValue("@d4", txtCustCity.Text);
                    cmd.Parameters.AddWithValue("@d5", txtCustC1.Text);
                    cmd.Parameters.AddWithValue("@d6", txtCustC2.Text);
                    cmd.Parameters.AddWithValue("@d7", txtCustEmail.Text);
                    cmd.Parameters.AddWithValue("@d8", txtNote.Text);
                    cmd.Parameters.AddWithValue("@d9", previousAvatar);
                    cmd.ExecuteNonQuery();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    MessageBox.Show("Details Updated!");
                    clsSystemTray.notifier("Detailes Updated, outdated files have been added to Garbage List");
        }
         catch (Exception ex)
            {

                MessageBox.Show("Could not perform the requested operation, please try again");
                return;
            }
              
           }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            avatar.Image = Image.FromFile(openFileDialog1.FileName);
            previousAvatar = Path.GetFileNameWithoutExtension(openFileDialog1.FileName); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "Image File |*.jpg; *.jpeg; *.png";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            clsFilterData clsFilterDataInst = new clsFilterData();
            clsFilterDataInst.getData(datagridview1, "Select  CustomerID,CName,Address,City,Phone1,Phone2,Email,Notes From ", "dtb_regCustomers_rws order by CName asc");
            setRowDefault1();

            getCustDetails();
            txtSearch.Clear();
            txtSearch.Focus();
        }
    }
    
}
