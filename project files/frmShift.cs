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
    public partial class frmShift : Form
    {
        public frmShift()
        {
      
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

           // gunaTransition2.AddToQueue(dateTimePicker1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(pictureBox1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(pictureBox2, Guna.UI.Animation.AnimateMode.Show, true);
           
    

            gunaTransition2.AddToQueue(gunaPictureBox1, Guna.UI.Animation.AnimateMode.Show, false);
            gunaTransition1.AddToQueue(gunaLabel1, Guna.UI.Animation.AnimateMode.Show, false);

           

        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

       String theTime = System.DateTime.Now.ToShortTimeString();
        String time1 = "8:00 PM";
        TimeSpan dt1 = DateTime.Now.TimeOfDay;
        TimeSpan dt2 = TimeSpan.Parse("17:00:00");





        int hrs = System.DateTime.Now.TimeOfDay.Hours;
        int mins = System.DateTime.Now.TimeOfDay.Minutes;
        string timeSeparator = ":";


        private void frmShift_Load(object sender, EventArgs e)
        {

            this.Text = clsAppName.myName;
            
        }

        private void frmShift_Click(object sender, EventArgs e)
        {
         
        }

        private void frmShift_DoubleClick(object sender, EventArgs e)
        {
        
        }

        private void gunaPictureBox1_DoubleClick(object sender, EventArgs e)
        {
            clsOnScreenKeyboard.openKeyboard();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(gunaLabel1.Visible == true)
            {
                gunaLabel1.Visible = false;
            
            }    
            else if(gunaLabel1.Visible == false)
            {
                    gunaLabel1.Visible = true;
               
            }
        
    
        }

        private void frmShift_KeyPress(object sender, KeyPressEventArgs e)
        {
            String ShiftND = "";


            if (dt1 < dt2)
            {
                ShiftND = "Day";
            }
            else if (dt1 >= dt2)
            {
                ShiftND = "Night";
            }


            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Insert Into dtb_Shifts_rws (sDate,OperatorName,Shift,StartTime,EndTime,OperatorID) Values (@v1,@v2,v3,v4,v5,v6)",con);
            cmd.Parameters.AddWithValue("v1", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("v2", clsAuthenticity.username);
            cmd.Parameters.AddWithValue("v3", ShiftND);
            cmd.Parameters.AddWithValue("v4", System.DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("v5", "");
            cmd.Parameters.AddWithValue("v6", clsAuthenticity.userID);
            cmd.ExecuteNonQuery();

            timer1.Stop();
            clsAuthenticity.getPage(this, new frmSalesMenu());
        }

        private void FrmShift_Validated(object sender, EventArgs e)
        {
            
        }
    }
}
