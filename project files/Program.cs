using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuintonPOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string[] theArgs = Environment.GetCommandLineArgs();

            if(theArgs.Length >= 2)
            {
                try
                {
                    if (theArgs[1] == "--rc")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmLogin("--rc"));


                    }

                    if (theArgs[1] == "--lsl")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmLogin("--lsl"));


                    }

                    if (theArgs[1] == "--avtOPT")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmLogin("--avtOPT"));


                    }

                 
                }
                catch (IndexOutOfRangeException ex)
                {

                    MessageBox.Show("An error occurred. Issue key: 0x40");
                    Application.Exit();

                }
            } else
            {
                try
                {

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    clsCleanUps.emptyTrash();
                    Application.Run(new frmSplash());
                  

                    ;
                }
                catch (Exception ex)
                {
                 // MessageBox.Show("" + ex);
               MessageBox.Show("An error occurred. Issue key: 0x41");
          
                }
         
            }

        }
    }
}
