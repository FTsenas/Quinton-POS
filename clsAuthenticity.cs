using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuintonPOS
{
    class clsAuthenticity
    {
        public static String userRight;
        public static String username;
        public static String userID;
        public static String password;
        public static Form form2Hide = new Form();

        public static string accUserID;
        public static string accUserFirstName;
        public static string accUserLastName;
        
        public static void getAuth(Form formToHide,Form formToOpen)
        {
            try
            {
                if (userRight != "Admin")
                {
                    MessageBox.Show("You do not have the authority to access this area!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    form2Hide = formToHide;
                    form2Hide.Hide();
                    formToOpen.Show();
                  formToOpen.Text = clsAppName.myName;
                 // formToOpen.ShowIcon = false;
                    

                }
            }
            catch (Exception ex)
            {
             
               MessageBox.Show("Oops, failed to load components...try restarting the app!");
       
            }
          

        }

        public static void getAuth(String optionalDialogName,IWin32Window dialogOwner,Form formToOpen)
        {
            try
            {
                if (userRight != "Admin")
                {
                    MessageBox.Show("You do not have the authority to access this area!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (optionalDialogName == "")
                    {
                        formToOpen.Text = clsAppName.myName;
                        formToOpen.ShowDialog(dialogOwner);

                    }
                    else
                    {
                        formToOpen.Text = optionalDialogName;
                        formToOpen.ShowDialog(dialogOwner);

                    }
                    
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops, failed to load components...try restarting the app!");

            }


        }

        public static void getPage(Form formToHide, Form formToOpen)
        {
        
                formToOpen.Text = clsAppName.myName;
            form2Hide = formToHide;
                form2Hide.Hide();
            formToOpen.Show();
       



        }

        public static void showRunningForm()
        {
          
            form2Hide.Show();
         

        }

        public static void getPage(String optionalDialogName,IWin32Window dialogOwner, Form formToOpen)
        {
            try
            {
                if (optionalDialogName == "")
                {
                    formToOpen.Text = clsAppName.myName;
                    formToOpen.ShowDialog(dialogOwner);

                }
                else
                {
                    formToOpen.Text = optionalDialogName;
                    formToOpen.ShowDialog(dialogOwner);

                }

            }
            catch (Exception ex)
            {

                return;
            }

        } 
        public static void setAuth(String passedUserRight)
        {
            userRight = passedUserRight;
        }


    }
}
