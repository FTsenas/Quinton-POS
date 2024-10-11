using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace QuintonPOS
{
    public partial class frmLowStockReport : Form
    {
        public frmLowStockReport()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

         
        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rdr;
        DataSet ds;

     

        private void frmLowStockReport_Load(object sender, EventArgs e)
        {
           
        }
    }
}
