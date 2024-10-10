using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuintonPOS
{
    public partial class frmSuppliersMainMenu : Form
    {
        public frmSuppliersMainMenu()
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

        private void frmSuppliersMainMenu_Load(object sender, EventArgs e)
        {
    
        }

        private void btnPE_Click(object sender, EventArgs e)
        {
         
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
    
        }

        private void btnPE_Click_1(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("", this, new frmSupplierProfileEntry());
            clsAuthenticity.form2Hide = new frmSalesMenu();
        }

        private void btnUP_Click_1(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("", this, new frmSuppliersUpdateProfile());
            clsAuthenticity.form2Hide = new frmSalesMenu();
        }

        private void btnPOasdsad_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
      
      
            clsAuthenticity.getAuth(this,new frmCreateOrder());
            clsAuthenticity.form2Hide = new frmSalesMenu();
        }

        private void btnTO_Click(object sender, EventArgs e)
        {

        }

        private void frmSuppliersMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAuthenticity.showRunningForm();
        }

        private void btnTO_Click_1(object sender, EventArgs e)
        {
            clsAuthenticity.getAuth("",this,new frmReceivedOrders());
            clsAuthenticity.form2Hide = new frmSalesMenu();
        }
    }
}
