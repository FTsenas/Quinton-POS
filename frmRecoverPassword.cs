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
    public partial class frmRecoverPassword : Form
    {
        public frmRecoverPassword()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox3.Size = new Size(20, 20);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Size = new Size(18, 18);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            clsConfirmClose.cmdClose(this);
            clsAuthenticity.showRunningForm();

        }

        private void Guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We've just emailed you with your Username & Password.");
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmRecoverPassword_Load(object sender, EventArgs e)
        {
            txtEmail.Select();
            txtEmail.PlaceholderText = "Type your Email Address Here...";
        }
    }
}
