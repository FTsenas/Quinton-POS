using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace QuintonPOS
{
    public partial class frmAccountMgmt : Form
    {
        public frmAccountMgmt()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            guna2GroupBox1.Visible = false;
            guna2Panel1.Visible = false;
            guna2CirclePictureBox1.Visible = false;
            txtSearch.Visible = false;
           btnRefresh.Visible = false;
            groupBox2.Visible = false;
            groupBox5.Visible = false;

            #region loadAnimation
            guna2Transition2.AddToQueue(guna2GradientPanel4, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(gunaGradient2Panel1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            #endregion

        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rdr;
        DataSet ds;


        private void frmAccountMgmt_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }

        private void frmAccountMgmt_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select * from dtb_Registration_rws order by Fname asc",con);

            ds = new DataSet();

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);

            guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();

            getUserDetails();
            txtSearch.Focus();
        }



        private void getUserDetails()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select * from dtb_Registration_rws Where UID = '" + guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString() + "' order by Fname asc ", con);

            rdr = cmd.ExecuteReader();

            if(rdr.Read() == true)
            {
                txtFName.Text = rdr[0].ToString();
                txtLName.Text = rdr[1].ToString();
                txtContact.Text = rdr[2].ToString();
                txtEmail.Text =  rdr[3].ToString();
                txtEDate.Text = rdr[4].ToString();
                txtNID.Text = rdr[5].ToString();
                txtUID.Text = rdr[6].ToString();
                txtNote.Text = rdr[7].ToString();
            }

            con.Close();
        }

        private void searchUsersDetails()
        {
            try
            {

                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select * from dtb_Registration_rws Where Fname Like '%" + txtSearch.Text + "%' order by Fname asc ", con);


                ds = new DataSet();

                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds);

                guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;
                con.Close();
            
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Character not supported!");
                txtSearch.Clear();
              
            }
         
        }

        private void frmAccountMgmt_FormClosed(object sender, FormClosedEventArgs e)
        {
            //clsAuthenticity.getPage(this, new frmSalesMenu());
            clsAuthenticity.showRunningForm();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("", this, new frmRegistration());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            guna2WinProgressIndicator1.Visible = true;
            timer1.Start();
            searchUsersDetails();
        }

        private void Guna2DataGridView1_Click(object sender, EventArgs e)
        {
            getUserDetails();
        }

        private void Guna2Button4_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select * from dtb_Registration_rws order by Fname asc", con);

            ds = new DataSet();

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);

            guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();

            getUserDetails();
            txtSearch.Focus();
        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Delete From dtb_Registration_rws Where UID = '" + guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString() + "'" , con);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Deleted.");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
          
        }

        private void refreshPage()
        {
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select * from dtb_Registration_rws order by Fname asc", con);

            ds = new DataSet();

            adp = new OleDbDataAdapter(cmd);
            adp.Fill(ds);

            guna2DataGridView1.DataSource = ds.Tables[0].DefaultView;
            con.Close();

            getUserDetails();
            txtSearch.Focus();
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            txtFName.Text = txtFName.Text.ToUpper();
            
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            txtLName.Text = txtLName.Text.ToUpper();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Text = txtEmail.Text.ToUpper();
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            txtNote.Text = txtNote.Text.ToUpper();
        }

        private void frmAccountMgmt_KeyDown(object sender, KeyEventArgs e)
        {
        
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            backShortcut(sender,e);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            enableORdisableControls();
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog(this); 
            txtSearch.Focus();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to delete" + txtFName.Text + "?","QPOS",MessageBoxButtons.YesNo,MessageBoxIcon.Question ) == System.Windows.Forms.DialogResult.Yes)
                {

                    con = new OleDbConnection(connectionString.DBConn);
                    con.Open();

                    cmd = new OleDbCommand("DELETE FROM dtb_Registration_rws WHERE UID = '" + txtUID.Text + "'", con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Done");

                    con.Close();

                    refreshPage();

                } else
                {
                    return;
                }

            }
            catch (Exception exMAS)
            {
                MessageBox.Show("Something went wrong! Issue key: 0x1MAS");
            }
         
            txtSearch.Focus();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("UPDATE dtb_Registration_rws SET Fname = '" + txtFName.Text + "' WHERE UID = '" + txtUID.Text + "'",con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("UPDATE dtb_Registration_rws SET Lname = '" + txtLName.Text + "' WHERE UID = '" + txtUID.Text + "'", con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("UPDATE dtb_Registration_rws SET NationalID = '" + txtNID.Text + "' WHERE UID = '" + txtUID.Text + "'", con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("UPDATE dtb_Registration_rws SET Notes = '" + txtNote.Text + "' WHERE UID = '" + txtUID.Text + "'", con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("UPDATE dtb_Registration_rws SET ContactNo = '" + txtContact.Text + "' WHERE UID = '" + txtUID.Text + "'", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Done");

            con.Close();

            txtSearch.Focus();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            processReport();

            txtSearch.Focus();
        }

        private void backShortcut(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                clsAuthenticity.showRunningForm();
            }
        }

        private void txtFName_KeyDown(object sender, KeyEventArgs e)
        {
            backShortcut(sender,e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsProgressIndicator.timerOps(guna2WinProgressIndicator1, timer1);
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
    
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select * from dtb_Login_rws Where UID = '" +  txtUID.Text.Trim() + "'", con);

            rdr = cmd.ExecuteReader();

            if(rdr.HasRows)
            {
                MessageBox.Show("This User already has a Login profile!");
            } else
            {
          
                clsAuthenticity.accUserID = txtUID.Text;
                clsAuthenticity.accUserFirstName = txtFName.Text;
                clsAuthenticity.accUserLastName = txtLName.Text;
                clsAuthenticity.getPage("",this,new frmAddLoginAccount());

                enableORdisableControls();                
                txtSearch.Focus();

            }

            con.Close();

        }
       
        private void processReport()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                rptUserDetailsReport theReport = new rptUserDetailsReport();

                //The report you created.
                con = new OleDbConnection(connectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select UID,Fname,Lname,ContactNo,Email,EnrollmentDate,NationalID from dtb_Registration_rws WHERE Fname LIKE '%" + txtSearch.Text + "%' order by Fname asc", con);
                //      cmd.ExecuteNonQuery();

                // ds = new DataSet();
                DataTable dtb = new DataTable();

                adp = new OleDbDataAdapter(cmd);

                adp.Fill(dtb);


                theReport.Database.Tables["UserDetails"].SetDataSource(dtb);
                frmUserDetailsReport frm = new frmUserDetailsReport();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {

           
        }

        private void enableORdisableControls()
        {
            if (groupBox5.Visible == false)
            {

                gunaTransition4.ShowSync(guna2Panel1);
                gunaTransition4.ShowSync(guna2CirclePictureBox1);
                gunaTransition4.ShowSync(txtSearch);
                gunaTransition4.ShowSync(guna2GroupBox1);
                gunaTransition4.ShowSync(btnRefresh);
                gunaTransition4.ShowSync(groupBox2);
                gunaTransition4.ShowSync(groupBox5);
            }
            else if (groupBox5.Visible == true)
            {
                gunaTransition4.HideSync(guna2Panel1);
                gunaTransition4.HideSync(guna2CirclePictureBox1);
                gunaTransition4.Hide(txtSearch);
                gunaTransition4.Hide(guna2GroupBox1);
                gunaTransition4.Hide(btnRefresh);
                gunaTransition4.Hide(groupBox2);
                gunaTransition4.Hide(groupBox5);
            }
        }

        private void BtnRefresh_Click_1(object sender, EventArgs e)
        {
            refreshPage();
        }

        private void Guna2Button1_Click_1(object sender, EventArgs e)
        {
            enableORdisableControls();
            refreshPage();
            txtSearch.Focus();
        }
    }
}
