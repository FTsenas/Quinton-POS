using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuintonPOS
{
    public partial class frmAvatarOPT : Form
    {
        public frmAvatarOPT()
        {
            InitializeComponent();
            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            #region GUIDESIGN
            gunaTransition1.AddToQueue(btnProduct, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(btnCustomer, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition1.AddToQueue(btnSupplier, Guna.UI.Animation.AnimateMode.Show, true);
            #endregion
         
        }

        #region CONTEXTMENU-NOTES

        //HKEY_CLASSES_ROOT\Directory\Background\shell
        //[RIGHT-CLICK] shell then [New] then [Key]
        //Give the new key a name thats going to show up on the contextmenu
        //Computer\HKEY_CLASSES_ROOT\SystemFileAssociations\.jpg\Shell\QUINTONPOS\Command
        //ApplicationInstallPath + "\QuintonPOS.exe" "--avtOPT" "%1"
//ASSIGN ITEM Icon by creating a String Value by the name 'Icon' then set the value as the ApplicationInstallPath

        #endregion

        /// <summary>
        /// 0 = NULL
        /// 1 = PRODUCTS
        /// 2 = CUSTOMERS
        /// 3 = SUPPLIERS
        /// </summary>
       public static short databaseID = 0;
       string[] theArgs = Environment.GetCommandLineArgs();
       public static string imageLocation = "";


        private void frmAvatarOPT_Load(object sender, EventArgs e)
        {
            try
            {
                 imageLocation = theArgs[2].ToString();
              
              
            }
            catch (Exception exAr)
            {

                MessageBox.Show("Something went wrong! Issue key: 0x1Ar");
            }
    

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            databaseID = 1;
            clsAuthenticity.getPage( this, new frmAvatarASSG());
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            databaseID = 2;
            clsAuthenticity.getPage( this, new frmAvatarASSG());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            databaseID = 3;
            clsAuthenticity.getPage( this, new frmAvatarASSG());
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
