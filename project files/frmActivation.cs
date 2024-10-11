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
    public partial class frmActivation : Form
    {
        public frmActivation()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            #region loadAnimation

                 gunaTransition4.AddToQueue(label18, Guna.UI.Animation.AnimateMode.Show, true);
                 gunaTransition4.AddToQueue(txtProductKey, Guna.UI.Animation.AnimateMode.Show, true);
                 gunaTransition4.AddToQueue(btnActivateNow, Guna.UI.Animation.AnimateMode.Show, false);

            #endregion

        }

        private void frmActivation_Load(object sender, EventArgs e)
        {
            txtProductKey.PlaceholderText = "x x x x - x x x x - x x x x - x x x x - x x x x - x x x x ";
            txtProductKey.Select();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
