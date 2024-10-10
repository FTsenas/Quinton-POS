using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QuintonPOS
{
    public partial class frmUserDailyCashSalesReport : Form
    {
        public frmUserDailyCashSalesReport()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;
        
        }

        private void FrmUserDailySalesReport_Load(object sender, EventArgs e)
        {
 
        }
    }
}
