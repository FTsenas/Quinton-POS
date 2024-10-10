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


namespace QuintonPOS
{
    public partial class frmRateControl : Form
    {
        public frmRateControl()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;
        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;



        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
         
            
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
       

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {


        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
       

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
       

        }

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void guna2TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void guna2TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void guna2TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void guna2TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void guna2TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputValidation.withDecimalPoints(sender, e);
        }

        private void frmRateControl_FormClosing(object sender, FormClosingEventArgs e)
        {
         

        }

        private void frmRateControl_Load(object sender, EventArgs e)
        {
            gunaLineTextBox1.Focus();

        }

        private void frmRateControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAuthenticity.showRunningForm();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (gunaLineTextBox1.Text == "")
            {
                MessageBox.Show("A blank field has been detected!");
                gunaLineTextBox1.Focus();
                return;
            }

            if (gunaLineTextBox2.Text == "")
            {
                MessageBox.Show("A blank field has been detected!");
                gunaLineTextBox2.Focus();
                return;
            }

            if (gunaLineTextBox3.Text == "")
            {
                MessageBox.Show("A blank field has been detected!");
                gunaLineTextBox3.Focus();
                return;
            }

            if (gunaLineTextBox4.Text == "")
            {
                MessageBox.Show("A blank field has been detected!");
                gunaLineTextBox4.Focus();
                return;
            }

            if (gunaLineTextBox5.Text == "")
            {
                MessageBox.Show("A blank field has been detected!");
                gunaLineTextBox5.Focus();
                return;
            }

            if (gunaLineTextBox6.Text == "")
            {
                MessageBox.Show("A blank field has been detected!");
                gunaLineTextBox6.Focus();
                return;
            }

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("update dtb_Rates_rws set Rating = " + gunaLineTextBox1.Text + " Where Currency = 'ZWL_RTGS_CASH'", con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand ("update dtb_Rates_rws set Rating = " + gunaLineTextBox2.Text + " Where Currency = 'SA_RAND_CASH'",con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("update dtb_Rates_rws set Rating = " + gunaLineTextBox3.Text + " Where Currency = 'USD_BANK_TRANSFER'", con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("update dtb_Rates_rws set Rating = " + gunaLineTextBox4.Text + " Where Currency = 'ZWL_RTGS_BANK_TRANSFER'", con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("update dtb_Rates_rws set Rating = " + gunaLineTextBox5.Text + " Where Currency = 'ZWL_RTGS_ECOCASH'", con);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("update dtb_Rates_rws set Rating = " + gunaLineTextBox6.Text + " Where Currency = 'USD_ECOCASH'", con);
            cmd.ExecuteNonQuery();

 
            con.Close();
            MessageBox.Show("Updated.");

        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.txtRTGSCSH.Text = this.gunaLineTextBox1.Text;
        }

        private void gunaLineTextBox2_TextChanged(object sender, EventArgs e)
        {
            this.txtRANDCSH.Text = this.gunaLineTextBox2.Text;
        }

        private void gunaLineTextBox3_TextChanged(object sender, EventArgs e)
        {
            this.txtUSDBNK.Text = this.gunaLineTextBox3.Text;
        }

        private void gunaLineTextBox4_TextChanged(object sender, EventArgs e)
        {
            this.txtRTGSBNK.Text = this.gunaLineTextBox4.Text;
        }

        private void gunaLineTextBox5_TextChanged(object sender, EventArgs e)
        {
            this.txtRTGSECO.Text = this.gunaLineTextBox5.Text;
        }

        private void gunaLineTextBox6_TextChanged(object sender, EventArgs e)
        {
            this.txtUSDECO.Text = this.gunaLineTextBox6.Text;
        }

        private void gunaLineTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void gunaLineTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void gunaLineTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void gunaLineTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void gunaLineTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }

        private void gunaLineTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.withDecimalPoints(sender, e);
        }
    }
}
