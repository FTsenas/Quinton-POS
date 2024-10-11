using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.IO;


namespace QuintonPOS
{
    class clsAccessResources
    {

        public static Icon getIcon() 
        {
           Image img;

         Assembly asm = Assembly.GetExecutingAssembly();
          Stream stm = asm.GetManifestResourceStream("QuintonPOS.Properties.Resources.18.png");
          img = new Bitmap(stm);
            Icon ic;
            ic = Icon.ExtractAssociatedIcon("" + Image.FromFile("" + img));

            return ic;

        }
    
    }
}
