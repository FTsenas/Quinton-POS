using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuintonPOS
{
    class clsOnScreenKeyboard
    {
        public static void openKeyboard()
        {
            try
            {
                var path64 = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"), "amd64_microsoft-windows-osk_*")[0], "osk.exe");
                var path32 = @"C:\Windows\system32\osk.exe";
                var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;
                if (File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception exOSK)
            {

                System.Windows.Forms.MessageBox.Show("Something went wrong! Issue Key: 0x1OSK");
            }
           
        }
    }
}
