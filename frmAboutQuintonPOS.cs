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
    public partial class frmAboutQuintonPOS : Form
    {
        public frmAboutQuintonPOS()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            gunaTransition1.AddToQueue(pictureBox1, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition3.AddToQueue(label2, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(label1, Guna.UI.Animation.AnimateMode.Show, true);

            gunaTransition3.AddToQueue(label5, Guna.UI.Animation.AnimateMode.Show, true);
            gunaTransition3.AddToQueue(label3, Guna.UI.Animation.AnimateMode.Show, true);
  

            this.Text = clsAppName.myName;

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmAboutQuintonPOS_Load(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string processPartialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                System.Diagnostics.Process.Start(processPartialDirectory + "\\Microsoft\\Edge\\Application\\msedge.exe", "https://ftsenas.github.io/portfolio/");
            }
            catch (Exception EXURL01)
            {

                MessageBox.Show("An error occurred loading the URL. Issue Key: EXURL01","QPOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

          
        }
    }
}
