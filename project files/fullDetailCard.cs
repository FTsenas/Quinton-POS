using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace QuintonPOS
{
    public partial class fullDetailCard : Form
    {
        public fullDetailCard()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;


            #region Anime
                   gunaTransition1.AddToQueue(supAvatar, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(gunaLabel1, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(gunaLabel2, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(gunaLabel3, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(gunaLabel4, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(gunaLabel5, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(gunaLabel6, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(gunaLabel7, Guna.UI.Animation.AnimateMode.Show, true);
                   gunaTransition1.AddToQueue(gunaLabel8, Guna.UI.Animation.AnimateMode.Show, true);
            #endregion



            txtSupID.Text = clsFilterData.supID;



        }

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader rd;
        DataSet ds;

        string avatarPlaceHolder = "";

        private void fullDetailCard_Load(object sender, EventArgs e)
        {
            this.Owner.Visible = false;
            //this.Opacity = 10;

            con = new OleDbConnection(connectionString.DBConn);
            con.Open();

            cmd = new OleDbCommand("Select SupplierID,SupplierName,Address,City,Contact1,Contact2,Email,Notes,DeliveryAmount,Avatar From dtb_regSuppliers_rws Where SupplierID = '" + txtSupID.Text + "'", con);
                   
            rd = cmd.ExecuteReader();

            try
            {

                   if (rd.Read() == true)
                   {
                       txtName.Text = rd[1].ToString();
                       txtAdd.Text = rd[2].ToString();
                       txtCIT.Text = rd[3].ToString();
                       txtCel1.Text = rd[4].ToString();
                       txtCel2.Text = rd[5].ToString();
                       txtEM.Text = rd[6].ToString();
                       txtNotes.Text = rd[7].ToString();
                       txtDel.Text = "$" + rd[8].ToString();
                       avatarPlaceHolder = rd[9].ToString();
                      
                

                   }
       
          
            }
            catch (Exception ex)
            {
               rd.Close();
               con.Close();
                this.Close();
          //      MessageBox.Show("An error occurred!");

                MessageBox.Show("" + ex);
            }

            try
            {
                supAvatar.Image = Image.FromFile(clsSysFolder.sfilePath + rd[9].ToString() + ".avt");
            }
            catch (Exception ex)
            {
                try
                {
                    supAvatar.Image = Image.FromFile(clsSysFolder.sfilePath + "Untitled.avt");
                    return;
                }
                catch (Exception ex12)
                {

                    return;
                }
             
            }

            rd.Close();
            con.Close();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
       
            this.Owner.Visible = true;

            this.Close();
          
        }

        private void GunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
