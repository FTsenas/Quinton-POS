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
    public partial class frmMoreTransInfo : Form
    {
        public frmMoreTransInfo(short parameta)
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;



            #region retrievInfo

            if(parameta == 1)
            {
            txtDT.Text = frmReversedTransactions.theReversalDate;
            txtRB.Text = frmReversedTransactions.theReversalApprover;
            txtRT.Text = frmReversedTransactions.theReversalTime;
            }
         
            
            if(parameta == 2)
            {
            txtDT.Text = frmReversedTransactions.theReversalDate2;
            txtRB.Text = frmReversedTransactions.theReversalApprover2;
            txtRT.Text = frmReversedTransactions.theReversalTime2;
            }

            
            if(parameta == 3)
            {
            txtDT.Text = frmReversedTransactions.theReversalDate3;
            txtRB.Text = frmReversedTransactions.theReversalApprover3;
            txtRT.Text = frmReversedTransactions.theReversalTime3;
            }

            #endregion

        }

        private void frmMoreTransInfo_Load(object sender, EventArgs e)
        {
            btnExit.Select();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
