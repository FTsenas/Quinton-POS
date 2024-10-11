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
    public partial class frmLogin : Form
    {

        public static string usernameContainer;
        public static string passwordContainer;
        public static bool trueorfalse;
        public static string frmHolder;

 
        
        public frmLogin(string frm)
        {

        

            InitializeComponent();



            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            gunaTransition1.AddToQueue(CLPic, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(pictureBox5, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(guna2Button5, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(txtFirst, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(txtSecond, Guna.UI.Animation.AnimateMode.Show, true);   
            gunaTransition4.AddToQueue(pictureBox3, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition4.AddToQueue(label7, Guna.UI.Animation.AnimateMode.Show, false);
            gunaTransition4.AddToQueue(label1, Guna.UI.Animation.AnimateMode.Show, false);
            gunaTransition3.AddToQueue(U1, Guna.UI.Animation.AnimateMode.Show, false);
            gunaTransition3.AddToQueue(P1, Guna.UI.Animation.AnimateMode.Show, false);
        

            frmHolder = frm;

        

        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
      


        private void frmLogin_Load(object sender, EventArgs e)
        {

            txtFirst.PlaceholderText = "USERNAME";
            txtSecond.PlaceholderText = "PASSWORD";

            txtFirst.Select();
           txtFirst.Focus();
           
           
        }

      

        private void performLoginOp()
        {

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("SELECT * FROM dtb_Login_rws WHERE Username = @v1 AND [Password] = @v2 ", con);
            cmd.Parameters.AddWithValue("v1", txtFirst.Text);
            cmd.Parameters.AddWithValue("v2", txtSecond.Text);
            dr = cmd.ExecuteReader();

            if(dr.Read()){
                if(frmHolder == ""){
                    String userLevel = dr["UType"].ToString();
                    String userID = dr["UID"].ToString();

                    clsAuthenticity.setAuth(userLevel);
                    clsAuthenticity.userID = userID;
                    clsAuthenticity.username = txtFirst.Text;
                    clsAuthenticity.password = txtSecond.Text;
                 
                    txtFirst.Clear();
                    txtSecond.Clear();
                    con.Close();
                    clsAuthenticity.getPage(this, new frmShift());
                }

                if(frmHolder == "--lsl")
                {
                    String userLevel = dr["UType"].ToString();
                    String userID = dr["UID"].ToString();

                    if (userLevel != "Admin")
                    {
                        MessageBox.Show("You are not authorised to access this Page!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtFirst.Clear();
                        txtSecond.Clear();
                        return;
                    }
                    else
                    {
                        clsAuthenticity.setAuth(userLevel);
                        clsAuthenticity.userID = userID;
                        clsAuthenticity.username = txtFirst.Text;
                        clsAuthenticity.password = txtSecond.Text;
                        txtFirst.Clear();
                        txtSecond.Clear();
                        con.Close();
                        clsAuthenticity.getPage(this, new frmCriticalStockShort());
                    }
           
                }

                if (frmHolder == "--avtOPT")
                {
                    String userLevel = dr["UType"].ToString();
                    String userID = dr["UID"].ToString();

                    if (userLevel != "Admin")
                    {
                        MessageBox.Show("You are not authorised to access this Page!", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtFirst.Clear();
                        txtSecond.Clear();
                        return;
                    }
                    else
                    {
                        clsAuthenticity.setAuth(userLevel);
                        clsAuthenticity.userID = userID;
                        clsAuthenticity.username = txtFirst.Text;
                        clsAuthenticity.password = txtSecond.Text;
                        txtFirst.Clear();
                        txtSecond.Clear();
                        con.Close();
                        clsAuthenticity.getPage(this, new frmAvatarOPT());
                    }

                }
         
                if(frmHolder == "--rc")
                {
                    String userLevel = dr["UType"].ToString();
                    String userID = dr["UID"].ToString();

                    if (userLevel != "Admin")
                    {
                        MessageBox.Show("You are not authorised to access this Page!","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        txtFirst.Clear();
                        txtSecond.Clear();
                        return;
                    }
                    else
                    {
                        clsAuthenticity.setAuth(userLevel);
                        clsAuthenticity.userID = userID;
                        clsAuthenticity.username = txtFirst.Text;
                        clsAuthenticity.password = txtSecond.Text;
                        txtFirst.Clear();
                        txtSecond.Clear();
                        con.Close();
                        clsAuthenticity.getPage(this, new frmRateControlShort());
                    }

                }

            } 
            else
            {
                if(txtFirst.Text == "")
                {
                    MessageBox.Show("Username cannot be blank!");
                    txtFirst.Focus();
                    return;
                }

                if (txtSecond.Text == "")
                {
                    MessageBox.Show("Password cannot be blank!");
                    txtSecond.Focus();
                    return;
                }

                MessageBox.Show("User Credentials not found, please try again!");
                txtFirst.Clear();
                txtSecond.Clear();
                txtFirst.Focus();
            }

        }




        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }


        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clsProgressIndicator.timerOps(pictureBox1, timer1);
           
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
          
            clsProgressIndicator.timerOps(pictureBox2, timer2);
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
       


        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
       
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
        


        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaElipsePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return)
            //{
            //    performLoginOp();
            //}
        }

        private void txtSecond_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtFirst_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void guna2Button5_KeyDown(object sender, KeyEventArgs e)
        {
    
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            
        }

        private void frmLogin_Validated(object sender, EventArgs e)
        {

        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {

        }

        private void txtFirst_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        private void txtSecond_TextChanged_1(object sender, EventArgs e)
        {
         
           
        }

        private void txtFirst_KeyDown_1(object sender, KeyEventArgs e)
        {
         
        }

        private void txtSecond_KeyDown_1(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return)
            //{
            //    performLoginOp();
            //}
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtFirst_TextChanged_2(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Start();
           
        }

        private void txtSecond_TextChanged_2(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            timer2.Start();
        }

        private void txtFirst_KeyDown_2(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return)
            //{
            //    performLoginOp();
            //}
        }

        private void txtSecond_KeyDown_2(object sender, KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.Enter)
            {
                activateApp();
                performLoginOp();
            }
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            activateApp();
            performLoginOp();
        }

        private void activateApp()
        {
            try
            {

            
                con = new OleDbConnection(ActconnectionString.DBConn);
                con.Open();

                cmd = new OleDbCommand("Select KeyValue From dtb_Activation_rws", con);

                dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {

                    string theValue = dr[0].ToString();

                    if (Convert.ToInt32(theValue) > Convert.ToInt32("0"))
                    {
                        cmd = new OleDbCommand("UPDATE dtb_Activation_rws SET KeyValue = KeyValue - 1", con);
                        cmd.ExecuteNonQuery();


                    }
                    else if (Convert.ToInt32(theValue) <= Convert.ToInt32("0"))
                    {
                        this.Hide();
                        frmActivation frm = new frmActivation();
                        frm.ShowDialog(this);
                        return;
                    }
                }

                dr.Close();
                con.Close();

            }
            catch (Exception exACT)
            {
               
                MessageBox.Show("The program can't find some of the dependences needed for it to run smoothly, please make sure that you have installed all the requirements.","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsAuthenticity.getPage( this, new frmRecoverPassword());
            txtFirst.Select();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_MouseHover(object sender, EventArgs e)
        {
        
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void P2_Click(object sender, EventArgs e)
        {
            P2.Visible = false;
            P1.Visible = true;
            txtSecond.PasswordChar = 'x';
        }

        private void P1_Click(object sender, EventArgs e)
        {
            P1.Visible = false;
            P2.Visible = true;
            txtSecond.PasswordChar = '\0' ;
        }

        private void U1_Click(object sender, EventArgs e)
        {
            U1.Visible = false;
            U2.Visible = true;
            txtFirst.PasswordChar = '\0';
        }

        private void U2_Click(object sender, EventArgs e)
        {
            U2.Visible = false;
            U1.Visible = true;
            txtFirst.PasswordChar = 'x';
        }

     


        }
    }

