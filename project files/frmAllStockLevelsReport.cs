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
    public partial class frmAllStockLevelsReport : Form
    {
        public frmAllStockLevelsReport()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

        }

        private void FrmAllStockLevelsReport_Load(object sender, EventArgs e)
        {

        }
    }
}
