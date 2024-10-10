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
    public partial class frmCreateQuotation : Form
    {
        public frmCreateQuotation()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

        }

        private void frmCreateQuotation_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void frmCreateQuotation_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAuthenticity.getPage(this, new frmSalesMenu());
        }

        private void FrmCreateQuotation_Load(object sender, EventArgs e)
        {

        }
    }
}
