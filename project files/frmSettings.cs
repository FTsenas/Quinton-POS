using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Data.OleDb;


namespace QuintonPOS
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            this.Text = clsAppName.myName;
            this.Icon = clsAppName.img;

            #region GUNADESIGN
            guna2Transition1.AddToQueue(btnDDR, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnEMC, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnSLA, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition1.AddToQueue(btnDCL, Guna.UI2.AnimatorNS.AnimateMode.Show, false);

            guna2Transition2.AddToQueue(btnSID, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(btnICN, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(btnOCC, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(btnACC, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(btnOT, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition2.AddToQueue(btnSAVEWR, Guna.UI2.AnimatorNS.AnimateMode.Show, false);

            guna2Transition3.AddToQueue(btnRefresh, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition3.AddToQueue(printerComboList, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition3.AddToQueue(txtCompanyName, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition3.AddToQueue(txtOfficialC, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition3.AddToQueue(txtAlternateC, Guna.UI2.AnimatorNS.AnimateMode.Show, true);
            guna2Transition3.AddToQueue(organisationList, Guna.UI2.AnimatorNS.AnimateMode.Show, true);

            #endregion

        }

        #region filePathz

        private static string filePathDDR = Application.StartupPath + "//qpos_DDR.ini";
        private static string filePathEMC = Application.StartupPath + "//qpos_EMC.ini";
        private static string filePathSLA = Application.StartupPath + "//qpos.ini";
        private static string filePathDCL = Application.StartupPath + "//qpos_DCL.ini";

        #endregion

        #region WMI

        private static ManagementObjectSearcher objs;
        private static ManagementObject obj = new ManagementObject();
        private static ManagementObjectCollection _printerCollection;

        #endregion


        #region DatabaseComponents

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter adp;
        OleDbDataReader dr;
       

        #endregion

        List<String> OT = new List<string>();


        private void frmSettings_Load(object sender, EventArgs e)
        {

            OT.Add("ENTERPRISES");
            OT.Add("SUPERMARKET");
            OT.Add("PVT");
            OT.Add("PVT (LTD)");
            OT.Add("CLOTHING");
            OT.Add("WELDINGS");
            OT.Add("WELDERS");
            OT.Add("ENGINEERINGS");
            OT.Add("ENGINEENERS");
            OT.Add("MECHANICS");
            OT.Add("SOLUTIONS");
            OT.Add("PAINTINGS");
            OT.Add("PAINTS");
            OT.Add("ELECTRONICS");
            OT.Add("ROBOTICS");
            OT.Add("MOTORS");
            OT.Add("HARDWARE");
            OT.Add("INSTALLATIONS");
            OT.Add("PLUMBINGS");
            OT.Add("PLUMBERS");
            OT.Add("BUILDINGS");
            OT.Add("BUILDERS");
            OT.Add("CARPENTRY");
            OT.Add("CARPENTERS");
            OT.Add("MALL");
            OT.Add("FOODS");
            OT.Add("FURNITURES");
            OT.Add("TAKEAWAY");
            OT.Add("SALES");
            OT.Add("CHEMICALS");
            OT.Add("COMPLEX");

            organisationList.Items.AddRange(OT.ToArray());

            objs = new ManagementObjectSearcher("root/CIMV2","Select * From Win32_Printer");

            _printerCollection =  objs.Get();

            foreach (ManagementObject objInst in _printerCollection)
            {
                printerComboList.Items.Add(objInst["DeviceID"]);
            }

            obj.Dispose();
            objs.Dispose();

            checkDCL();
            checkDDR();
            checkEMC();
            checkSLA();
        }

        private void btnDDR_Click(object sender, EventArgs e)
        {
            if(DDR.Checked == true)
            {
                try
                {
                    File.WriteAllText(filePathDDR, "0");
                }
                catch (Exception exA1)
                {
                    MessageBox.Show("An error occurred. Issue key: 0x1A");
                    return;
                }

                clsSystemTray.notifier("Dashboard rates turned OFF!");
                DDR.Checked = false;
            }
            else if(DDR.Checked == false)
            {
                try
                {
                    File.WriteAllText(filePathDDR, "1");
                }
                catch (Exception exA2)
                {
                    MessageBox.Show("An error occurred. Issue key: 0x2A");
                    return;
                }

                clsSystemTray.notifier("Dashboard rates turned ON!");
                DDR.Checked = true;
            }
        }

        private void btnEMC_Click(object sender, EventArgs e)
        {
            if (EMC.Checked == true)
            {
                try
                {
                    File.WriteAllText(filePathEMC, "0");
                }
                catch (Exception exB1)
                {
                    MessageBox.Show("An error occurred. Issue key: 0x1B");
                    return;
                }

                clsSystemTray.notifier("Multi-Currency turned OFF!");
                EMC.Checked = false;
            }
            else if (EMC.Checked == false)
            {
                try
                {
            
                    File.WriteAllText(filePathEMC, "1");
                }
                catch (Exception exB2)
                {
                    MessageBox.Show("" + exB2);
                 //   MessageBox.Show("An error occurred. Issue key: 0x2B");
                    return;
                }

                clsSystemTray.notifier("Multi-Currency turned ON!");
               EMC.Checked = true;
            }
        }


        private void btnDCL_Click(object sender, EventArgs e)
        {

        }

        private void btnSLA_Click(object sender, EventArgs e)
        {
            if (SLA.Checked == true)
            {
                clsSystemTray.turnOFF();
                SLA.Checked = false;
            }
            else if (SLA.Checked == false)
            {
                clsSystemTray.turnON();
                SLA.Checked = true;

            }
        }

        private void DDR_CheckedChanged(object sender, EventArgs e)
        {
      
        }

        private void EMC_CheckedChanged(object sender, EventArgs e)
        {
        
        }
        

        private void DSL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DCL_CheckedChanged(object sender, EventArgs e)
        {
   
        }

        private void SLA_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkSLA()
        {
            try
            {

                string OnOff = File.ReadAllText(filePathSLA);

                if (OnOff == "1")
                {
                    SLA.Checked = true;

                }
                else if (OnOff == "0")
                {
                    SLA.Checked = false;
                }
                else
                {
                    //WHEN THE TEXT CONTENT IS NOT RECOGNISED(NOT 1 or 0)
                    MessageBox.Show("Some system files are damaged, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.WriteAllText(filePathSLA, "1");
                    Application.Restart();
                }

            }
            catch (FileNotFoundException ex1)
            {
                //WHEN THE FILE GETS DELETED OR MISSING
                MessageBox.Show("Some system files are missing, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.WriteAllText(filePathSLA, "1");
                Application.Restart();

            }
        }


        private void checkDDR()
        {
            try
            {

                string OnOff = File.ReadAllText(filePathDDR);

                if (OnOff == "1")
                {
                    DDR.Checked = true;

                }
                else if (OnOff == "0")
                {
                    DDR.Checked = false;
                }
                else
                {
                    //WHEN THE TEXT CONTENT IS NOT RECOGNISED(NOT 1 or 0)
                    MessageBox.Show("Some system files are damaged, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.WriteAllText(filePathDDR, "1");
                    Application.Restart();
                }

            }
            catch (FileNotFoundException ex1)
            {
                //WHEN THE FILE GETS DELETED OR MISSING
                MessageBox.Show("Some system files are missing, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.WriteAllText(filePathDDR, "1");
                Application.Restart();

            }
        }

        private void checkEMC()
        {
            try
            {

                string OnOff = File.ReadAllText(filePathEMC);

                if (OnOff == "1")
                {
                    EMC.Checked = true;

                }
                else if (OnOff == "0")
                {
                    EMC.Checked = false;
                }
                else
                {
                    //WHEN THE TEXT CONTENT IS NOT RECOGNISED(NOT 1 or 0)
                    MessageBox.Show("Some system files are damaged, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.WriteAllText(filePathEMC, "1");
                    Application.Restart();
                }

            }
            catch (FileNotFoundException ex1)
            {
                //WHEN THE FILE GETS DELETED OR MISSING
                MessageBox.Show("Some system files are missing, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.WriteAllText(filePathEMC, "1");
                Application.Restart();

            }
        }

        private void checkDCL()
        {
            try
            {

                string OnOff = File.ReadAllText(filePathDCL);

                if (OnOff == "1")
                {

                    DCL.Checked = true;

                }
                else if (OnOff == "0")
                {
                    DCL.Checked = false;
                }
                else
                {
                    //WHEN THE TEXT CONTENT IS NOT RECOGNISED(NOT 1 or 0)
                    MessageBox.Show("Some system files are damaged, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.WriteAllText(filePathDCL, "1");
                    Application.Restart();
                }

            }
            catch (FileNotFoundException ex1)
            {
                //WHEN THE FILE GETS DELETED OR MISSING
                MessageBox.Show("Some system files are missing, QPOS will restart & recover them now.", "QPOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.WriteAllText(filePathDCL, "1");
                Application.Restart();

            }
        }

        private void printerComboList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            printerComboList.Items.Clear();
            objs = new ManagementObjectSearcher("root/CIMV2", "Select * From Win32_Printer");

            _printerCollection = objs.Get();

            foreach (ManagementObject objInst in _printerCollection)
            {
                printerComboList.Items.Add(objInst["DeviceID"]);
            }

            objs.Dispose();
            obj.Dispose();
        }

        private void gunaGradientButton7_Click(object sender, EventArgs e)
        {

            try
            {
                
            con = new OleDbConnection(connectionString.DBConn);
            con.Open();



            if(printerComboList.Text != "")
            {

                cmd = new OleDbCommand("UPDATE dtb_Settings_rws SET [Caption] = '" + printerComboList.Text + "' WHERE [Item] = 'PrinterID'", con);
                cmd.ExecuteNonQuery();
            }

            if(txtCompanyName.Text != "")
            {
                cmd = new OleDbCommand("UPDATE dtb_Settings_rws SET  [Caption] = '" + txtCompanyName.Text.ToUpper() + "' WHERE [Item] = 'CompanyName'", con);
                cmd.ExecuteNonQuery();
            }


            if (txtOfficialC.Text != "")
            {
                cmd = new OleDbCommand("UPDATE dtb_Settings_rws SET  [Caption] = '" + txtOfficialC.Text + "' WHERE [Item] = 'OfficialCell'", con);
                cmd.ExecuteNonQuery();
            }

            if (txtAlternateC.Text != "")
            {
                cmd = new OleDbCommand("UPDATE dtb_Settings_rws SET  [Caption] = '" + txtAlternateC.Text  + "' WHERE [Item] = 'AlternateCell'", con);
                cmd.ExecuteNonQuery();
            }

            if (organisationList.Text != "")
            {
                cmd = new OleDbCommand("UPDATE dtb_Settings_rws SET  [Caption] = '" + organisationList.Text.ToUpper() + "' WHERE [Item] = 'CompanyType'", con);
                cmd.ExecuteNonQuery();
            }

            con.Close();

            MessageBox.Show("Done");

            }
            catch (Exception exSave)
            {

                MessageBox.Show("Something went wrong! Issue key: 0x1Sav");
            }

        }

        private void gunaGradientButton6_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtAlternateC_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender,e);
        }

        private void txtOfficialC_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsInputValidation.integersOnly(sender, e);
        }

        private void frmSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsAuthenticity.showRunningForm();
        }

    }
}
