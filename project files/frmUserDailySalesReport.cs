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
    public partial class frmUserDailySalesReport : Form
    {
        public frmUserDailySalesReport()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

        }

        private void frmUserDailySalesReport_Load(object sender, EventArgs e)
        {

        }
    }
}
