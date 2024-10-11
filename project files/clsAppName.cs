using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using QuintonPOS.Properties;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace QuintonPOS
{
    class clsAppName
    {
        public static String myName = "QUINTONPOS - [Version 1.0.0]";
        public static Icon img = Icon.ExtractAssociatedIcon(Application.StartupPath + "/QuintonPOS.exe");

    }
}
