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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            this.TransparencyKey = BackColor;
        

            gunaTransition1.AddToQueue(gunaTransfarantPictureBox1, Guna.UI.Animation.AnimateMode.Show, true);

        }

        short count = 0;

        private void frmSplash_Load(object sender, EventArgs e)
        {
        
        }

        private void gunaTransition1_AllAnimationsCompleted(object sender, EventArgs e)
        {
       
        }

        private void gunaTransition1_AnimationCompleted(object sender, Guna.UI.Animation.AnimationCompletedEventArg e)
        {
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
    if(count<8)
    {
        count++;
    } else
    {
        timer1.Stop();
        count = 0;
        this.Hide();
        frmLogin frm = new frmLogin("");
        frm.Show();
    }
        }

        private void gunaTransfarantPictureBox1_Click(object sender, EventArgs e)
        {

        }



    }
}
