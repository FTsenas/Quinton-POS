using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace QuintonPOS
{
    class clsConfirmClose
    {
        public static void cmdClose(Form frm)
        {
            try
            {
                if (MessageBox.Show("Make sure you saved changes, Continue to close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    frm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops...something went wrong, contact the manufaturer [Error Code: 0x02]");
            }

        }
    }
}
