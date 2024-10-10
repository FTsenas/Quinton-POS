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
    public partial class frmSuppliersUpdateProfile : Form
    {
        public frmSuppliersUpdateProfile()
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

            guna2Transition2.AddToQueue(txtDelivery, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtSupAddress, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtSupC1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtSupC2, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtSupCity, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtSupEmail, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(txtSupName, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
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


        private void frmSuppliersMgmt_FormClosed(object sender, FormClosedEventArgs e)
        {
      
        }

        private void frmSuppliersMgmt_Load(object sender, EventArgs e)
        {
            this.Text = clsAppName.myName;
          

            clsFilterData clsFilterDataInst = new clsFilterData();
            clsFilterDataInst.getData(datagridview1, "Select  SupplierID,SupplierName,Address,City,Contact1,Contact2,Email,Notes,DeliveryAmount,Avatar From ", "dtb_regSuppliers_rws order by SupplierName asc");
            setRowDefault1();

            getSupDetails();
            txtSearch.Focus();
        }

        private void setRowDefault1()
        {
            foreach (DataGridViewRow dtRow in datagridview1.Rows)
            {
                dtRow.Cells[0].Value = false;

            }
        }

        private void getSupDetails()
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT SupplierID,SupplierName,Address,City,Contact1,Contact2,Email,Notes,DeliveryAmount,Avatar From dtb_regSuppliers_rws order by SupplierName asc", con);

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtSupplierID.Text = rd[0].ToString();
                    txtSupName.Text = rd[1].ToString();
                    txtSupAddress.Text = rd[2].ToString();
                    txtSupCity.Text = rd[3].ToString();
                    txtSupC1.Text = rd[4].ToString();
                    txtSupC2.Text = rd[5].ToString();
                    txtSupEmail.Text = rd[6].ToString();
                    txtNote.Text = rd[7].ToString();
                    txtDelivery.Text = rd[8].ToString();
                    avatarPlaceHolder = rd[9].ToString();
                    previousAvatar = avatarPlaceHolder;
                }
            }
            catch (Exception ex)
            {

                return;
            }
         

            try
            {
                avatar.Image = Image.FromFile(clsSysFolder.sfilePath + rd[9].ToString() + ".avt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not process Avatar at the moment, try again later!","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


            con.Close();
   
        }


        private void updateTable()
        {

if(txtSupName.Text == "")
{
    MessageBox.Show("One or more field(s) has been detected!","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
    txtSupName.Focus();
}

if (txtSupAddress.Text == "")
{
    MessageBox.Show("One or more field(s) has been detected!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
    txtSupAddress.Focus();
}

if (txtSupCity.Text == "")
{
    MessageBox.Show("One or more field(s) has been detected!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
    txtSupCity.Focus();
}

if (txtSupC1.Text == "")
{
    MessageBox.Show("One or more field(s) has been detected!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
    txtSupC1.Focus();
}

if (txtSupC2.Text == "")
{
    MessageBox.Show("One or more field(s) has been detected!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
    txtSupC2.Focus();
}

if (txtSupEmail.Text == "")
{
    MessageBox.Show("One or more field(s) has been detected!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
    txtNote.Focus();
}

if (txtDelivery.Text == "")
{
    txtDelivery.Text = "0.00";

}
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                try
                {

                    //if (avatarPlaceHolder != "Untitled")
                    //{
                    //    previousAvatar = clsKeyGen.getFullSACode();
                    //    avatar.Image.Save(clsSysFolder.sfilePath + previousAvatar + ".avt");
                    //    clsCleanUps.addSupImageToGarbageList(avatarPlaceHolder);
                    //}
                    //else
                    //{
                    //    if (previousAvatar == avatarPlaceHolder)
                    //    {
                    //        MessageBox.Show("Item details Updated except for the Avatar since it was never reassigned!");
                    //    }
                    //    else
                    //    {
                    //        previousAvatar = clsKeyGen.getFullSACode();
                    //        avatar.Image.Save(clsSysFolder.sfilePath + previousAvatar + ".avt");
                    //    }


                    //}


                    if (avatarPlaceHolder != "Untitled")
                    {
                        previousAvatar = clsKeyGen.getFullSACode();
                        avatar.Image.Save(clsSysFolder.sfilePath + previousAvatar + ".avt");
                        clsCleanUps.addSupImageToGarbageList(avatarPlaceHolder);
                    }
                    else
                    {
                        previousAvatar = clsKeyGen.getFullSACode();
                        avatar.Image.Save(clsSysFolder.sfilePath + previousAvatar + ".avt");

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not process request at the moment, please try again later");
                    return;

                }
             
                
                    string query = "UPDATE dtb_regSuppliers_rws SET SupplierName = @d2, Address = @d3,City = @d4,Contact1 = @d5,Contact2 = @d6,Email = @d7,Notes = @d8,DeliveryAmount = @d9,Avatar = @d10  Where  SupplierID ='" + txtSupplierID.Text + "'";
                    cmd = new OleDbCommand(query);
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@d2", txtSupName.Text);
                    cmd.Parameters.AddWithValue("@d3", txtSupAddress.Text);
                    cmd.Parameters.AddWithValue("@d4", txtSupCity.Text);
                    cmd.Parameters.AddWithValue("@d5", txtSupC1.Text);
                    cmd.Parameters.AddWithValue("@d6", txtSupC2.Text);
                    cmd.Parameters.AddWithValue("@d7", txtSupEmail.Text);
                    cmd.Parameters.AddWithValue("@d8", txtNote.Text);
                    cmd.Parameters.AddWithValue("@d9",txtDelivery.Text);
                    cmd.Parameters.AddWithValue("@d10", previousAvatar);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();

            clsFilterData clsFilterDataInst = new clsFilterData();
            clsFilterDataInst.searchData(datagridview1, "SELECT SupplierID,SupplierName,Address,City,Contact1,Contact2,Email,Notes,DeliveryAmount,Avatar From dtb_regSuppliers_rws where dtb_regSuppliers_rws.SupplierName like '", txtSearch.Text, "dtb_regSuppliers_rws");

            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT SupplierID,SupplierName,Address,City,Contact1,Contact2,Email,Notes,DeliveryAmount,Avatar From dtb_regSuppliers_rws where dtb_regSuppliers_rws.SupplierID = '" + datagridview1.SelectedRows[0].Cells[1].Value.ToString() + "'", con);

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtSupplierID.Text = rd[0].ToString();
                    txtSupName.Text = rd[1].ToString();
                    txtSupAddress.Text = rd[2].ToString();
                    txtSupCity.Text = rd[3].ToString();
                    txtSupC1.Text = rd[4].ToString();
                    txtSupC2.Text = rd[5].ToString();
                    txtSupEmail.Text = rd[6].ToString();
                    txtNote.Text = rd[7].ToString();
                    txtDelivery.Text = rd[8].ToString();
                    avatarPlaceHolder = rd[9].ToString();
                    previousAvatar = avatarPlaceHolder;
                }
                try
                {
                    avatar.Image = Image.FromFile(clsSysFolder.sfilePath + rd[9].ToString() + ".avt");
                }
                catch (Exception ex)
                {
                    avatar.Image = Image.FromFile(clsSysFolder.sfilePath +  "Untitled.avt");
                    return;
                    //      MessageBox.Show("Could not process Avatar at the moment, try again later!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                con.Close();

            }
            catch (Exception ex)
            {
                return;
            }
       
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
      
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
          
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            avatar.Image = Image.FromFile(openFileDialog1.FileName);
            previousAvatar = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();


            string query = "UPDATE dtb_regSuppliers_rws SET Avatar = @d1 WHERE SupplierID='" + txtSupplierID.Text + "'";
            cmd = new OleDbCommand(query);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", previousAvatar);
            cmd.ExecuteNonQuery();

            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            updateTable();
            txtSearch.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "Image File |*.jpg; *.jpeg; *.png";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void datagridview1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("SELECT SupplierID,SupplierName,Address,City,Contact1,Contact2,Email,Notes,DeliveryAmount,Avatar From dtb_regSuppliers_rws where dtb_regSuppliers_rws.SupplierID = '" + datagridview1.SelectedRows[0].Cells[1].Value.ToString() + "'", con);

                rd = cmd.ExecuteReader();

                if (rd.Read() == true)
                {
                    txtSupplierID.Text = rd[0].ToString();
                    txtSupName.Text = rd[1].ToString();
                    txtSupAddress.Text = rd[2].ToString();
                    txtSupCity.Text = rd[3].ToString();
                    txtSupC1.Text = rd[4].ToString();
                    txtSupC2.Text = rd[5].ToString();
                    txtSupEmail.Text = rd[6].ToString();
                    txtNote.Text = rd[7].ToString();
                    txtDelivery.Text = rd[8].ToString();
                    avatarPlaceHolder = rd[9].ToString();
                    previousAvatar = avatarPlaceHolder;
                }
            }
            catch (Exception ex)
            {

                return;
            }
           
            try
            {
                avatar.Image = Image.FromFile(clsSysFolder.sfilePath + rd[9].ToString() + ".avt");
            }
            catch (Exception ex)
            {
                avatar.Image = Image.FromFile(clsSysFolder.sfilePath + "Untitled.avt");
                return;
                //MessageBox.Show("Could not process Avatar at the moment, try again later!","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
      
        }

        private void txtDelivery_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsFilterData clsFilterDataInst = new clsFilterData();
            clsFilterDataInst.getData(datagridview1, "Select  SupplierID,SupplierName,Address,City,Contact1,Contact2,Email,Notes,DeliveryAmount,Avatar From ", "dtb_regSuppliers_rws order by SupplierName asc");
            setRowDefault1();

            getSupDetails();
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void btnPE_Click(object sender, EventArgs e)
        {
      
            frmSupplierProfileEntry frm = new frmSupplierProfileEntry();
            frm.ShowDialog(this);

            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            setRowDefault1();
            selectedDTGridIndexes.Clear();
            txtSearch.Focus();
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
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
                        cmd = new OleDbCommand("DELETE FROM dtb_regSuppliers_rws WHERE SupplierID = '" + selectedDTGridIndexes[i] + "'", con);
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
            }
            else
            {
                MessageBox.Show("Operation cancelled!");
            }

           
        }

        private void guna2GradientButton1_Click_2(object sender, EventArgs e)
        {
            updateTable();
            txtSearch.Focus();
        }
    }
}