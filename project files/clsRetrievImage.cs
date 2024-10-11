using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace QuintonPOS
{
    class clsRetrievImage
    {
        public static void    retrieveImage(PictureBox pBox, String imgName)
        {
            try
            {
             pBox.Image = Image.FromFile(clsSysFolder.ifilePath + imgName + ".avt");
            }
            catch (FileNotFoundException ex1)
            {
                try
                {
                    pBox.Image = Image.FromFile(clsSysFolder.ifilePath + "Untitled" + ".avt");
                }
                catch (FileNotFoundException ex2)
                {
                    try
                    {
                        createDir();
                        pBox.Image = Image.FromFile(clsSysFolder.ifilePath + "Untitled" + ".avt");
                    }
                    catch (Exception ex3)
                    {

                        pBox.Image = null;
                    }
                  
                }
   
            }

                }

        private static void  createDir()
        {
            try
            {

                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\CAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\SAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\IAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\Trash\\IAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\Trash\\CAs\\");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\Trash\\SAs\\");

         
            }
            catch (Exception ex4)
            {
                return;
            }

            try
            {
                File.Copy(Application.StartupPath + "/backavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\CAs\\Untitled.avt");
                File.Copy(Application.StartupPath + "/backavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\SAs\\Untitled.avt");
                File.Copy(Application.StartupPath + "/backavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\IAs\\Untitled.avt");
                File.Copy(Application.StartupPath + "/nomavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\nomore.avt");
              
                //SysTray
                File.Copy(Application.StartupPath + "/backexavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\exit.avt");
                File.Copy(Application.StartupPath + "/backlslavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\lsl.avt");
                File.Copy(Application.StartupPath + "/backnotavt.bac", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\{XKY4K-2NRWR-8F6P2-448RF-CRYQH-TSENAS-44521}\\ICs\\notify.avt");
            }
            catch (Exception exFNF)
            {

                return;
            }
      
        
        }

            }
        }

    