using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace QuintonPOS
{
    class clsMsgConfirmations : Form
    {
        public void msg(string textMsg, string frmHeader)
        {

            try
            {
                if (MessageBox.Show(textMsg, frmHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();

                }

                else
                {


                    MessageBox.Show("Request cancelled!", "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Oops, something went wrong...Error Code: 0x0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void msgConfirmations_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void msgConfirmations_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // clsMsgConfirmations
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "clsMsgConfirmations";
            this.Load += new System.EventHandler(this.clsMsgConfirmations_Load);
            this.ResumeLayout(false);

        }

        private void clsMsgConfirmations_Load(object sender, EventArgs e)
        {
            
        }


    }
}
