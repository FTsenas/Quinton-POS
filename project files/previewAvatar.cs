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
    public partial class previewAvatar : Form
    {
        public previewAvatar(Image imgAvatar, string priceVal)
        {
            InitializeComponent();

           

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            pictureBox1.Image = imgAvatar;
            lblPrice.Text = "$" + priceVal;
        }

    private void previewAvatar_Load(object sender, EventArgs e)
        {
            this.Owner.Visible = false;
        }

    private void button1_Click(object sender, EventArgs e)
    {
            this.Owner.Visible = true;
            this.Close();

    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }


    }
}
