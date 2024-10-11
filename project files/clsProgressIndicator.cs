using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace QuintonPOS
{

    class clsProgressIndicator
    {
        private static short count = 0;

        public static void timerOps(Guna.UI2.WinForms.Guna2WinProgressIndicator progressIndicator, Timer myTimer)
        {
            if (count <= 5)
            {
                count++;

            }
            else
            {
                myTimer.Stop();
                progressIndicator.Visible = false;
                count = 0;

            }
        }

        public static void timerOps(PictureBox picBox, Timer myTimer)
        {
            if (count <= 5)
            {
                count++;

            }
            else
            {
                myTimer.Stop();
                picBox.Visible = false;
                count = 0;

            }
        }
    }
}
