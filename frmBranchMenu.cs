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
    public partial class frmBranchMenu : Form
    {
        public frmBranchMenu()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            #region Anime
            gunaTransition1.AddToQueue(pictureBox2, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(pictureBox3, Guna.UI.Animation.AnimateMode.Show, false);
            gunaTransition1.AddToQueue(pictureBox4, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(pictureBox5, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(pictureBox6, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(pictureBox1, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition2.AddToQueue(guna2Button3, Guna.UI.Animation.AnimateMode.Show, true);

            #endregion
            
        }

        private void frmBranchMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
    

        }

        private void frmBranchMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            clsAuthenticity.showRunningForm();
        }

        private void FrmBranchMenu_Load(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clsAuthenticity.showRunningForm();
            this.Close();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mr Mbulani" + "\n" + "Position: CEO" + "\n" + "Stock Feed Data Management", pictureBox4, 5000);
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mrs Wilson" + "\n" + "Position: Deputy Head" + "\n" + "Groceries Data Management", pictureBox5, 5000);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mr Hurry" + "\n" + "Position: Secretary" + "\n" + "Transportation Data Management", pictureBox3, 5000);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mr Mutseneki" + "\n" + "Position: Head Of Finance (HOF)" + "\n" + "Finance Data Management", pictureBox2, 5000);
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mrs Murffey" + "\n" + "Position: Secretary" + "\n"+ "Machinery Data Management", pictureBox6, 5000);
        }

        private void gunaLinkLabel1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mr Mbulani" + "\n" + "Position: CEO" + "\n" + "Stock Feed Data Management", gunaLinkLabel1, 5000);
        }

        private void gunaLinkLabel2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mrs Wilson" + "\n" + "Position: Deputy Head" + "\n" + "Groceries Data Management", gunaLinkLabel2, 5000);
        }

        private void gunaLinkLabel3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mr Hurry" + "\n" + "Position: Secretary" + "\n" + "Transportation Data Management", gunaLinkLabel3, 5000);
        }

        private void gunaLinkLabel5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mr Mutseneki" + "\n" + "Position: Head Of Finance (HOF)" + "\n" + "Finance Data Management", gunaLinkLabel5, 5000);
        }

        private void gunaLinkLabel4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Info";
            toolTip1.Show("Mrs Murffey" + "\n" + "Position: Secretary" + "\n" + "Machinery Data Management", gunaLinkLabel4, 5000);
        }

        private void frmBranchMenu_KeyDown(object sender, KeyEventArgs e)
        {
        
        }

        private void frmBranchMenu_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Tip";
            toolTip1.Show("Click to exit",pictureBox1, 5000);
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            clsAuthenticity.showRunningForm();
            this.Close();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
