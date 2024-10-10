using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;



namespace QuintonPOS
{
    class clsComboRestrict
    {
      public static void comboBoxMgmt(Guna2ComboBox g2combo,String firstItem)
        {
            g2combo.Visible = false;
            MessageBox.Show("Use the dropdown options only!");
        g2combo.Text = firstItem;
            g2combo.Visible = true;
        }

    }
}
