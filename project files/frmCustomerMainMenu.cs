using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuintonPOS
{
    public partial class frmCustomerMainMenu : Form
    {
        public frmCustomerMainMenu()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            guna2Transition1.AddToQueue(btnPE, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnPO, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnTO, Guna.UI2.AnimatorNS.AnimateMode.Show, true); 
            guna2Transition1.AddToQueue(btnUP, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(guna2Button4, Guna.UI2.AnimatorNS.AnimateMode.Show, true);

            guna2Transition2.AddToQueue(panel1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition3.AddToQueue(guna2CirclePictureBox1, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
        }

        private void frmCustomerMainMenu_Load(object sender, EventArgs e)
        {
           

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerProfileEntry frmInst= new frmCustomerProfileEntry();
                frmInst.ShowDialog(this);
                frmInst.Focus();


            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
         

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
        
   
        }

        private void frmCustomerMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void frmCustomerMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            clsAuthenticity.showRunningForm();

        }

        private void btnTO_Click(object sender, EventArgs e)
        {
        
        }

        private void btnPE_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("", this, new frmCustomerProfileEntry());
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("", this, new frmCustomerUpdateProfile());
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("", this, new frmPlaceOrder());
        }

        private void btnTO_Click_1(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth(this, new frmCustomerOrders());
        }
    }
}
