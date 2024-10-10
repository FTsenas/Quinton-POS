namespace QuintonPOS
{
    partial class frmCustomerProfileEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtID = new System.Windows.Forms.TextBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtContactNo1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtContactNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCty = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2GradientPanel4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.guna2GradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(651, 77);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(144, 20);
            this.txtID.TabIndex = 115;
            this.txtID.Visible = false;
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_ACTIVATE;
            this.guna2AnimateWindow1.Interval = 500;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Controls.Add(this.button1);
            this.guna2GradientPanel2.Controls.Add(this.label10);
            this.guna2GradientPanel2.Controls.Add(this.groupBox2);
            this.guna2GradientPanel2.Controls.Add(this.guna2GradientPanel3);
            this.guna2GradientPanel2.Controls.Add(this.avatar);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.Silver;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.Silver;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(142, 103);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.ShadowDecoration.Parent = this.guna2GradientPanel2;
            this.guna2GradientPanel2.Size = new System.Drawing.Size(684, 292);
            this.guna2GradientPanel2.TabIndex = 134;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(573, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 31);
            this.button1.TabIndex = 169;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Silver;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(575, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 18);
            this.label10.TabIndex = 168;
            this.label10.Text = "Avatar:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtNotes);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(428, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 138);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notes *";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(6, 21);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(230, 106);
            this.txtNotes.TabIndex = 125;
            this.txtNotes.Text = "";
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.Controls.Add(this.txtEmail);
            this.guna2GradientPanel3.Controls.Add(this.txtContactNo1);
            this.guna2GradientPanel3.Controls.Add(this.txtContactNo);
            this.guna2GradientPanel3.Controls.Add(this.txtCty);
            this.guna2GradientPanel3.Controls.Add(this.txtAddress);
            this.guna2GradientPanel3.Controls.Add(this.txtCustomerName);
            this.guna2GradientPanel3.Controls.Add(this.Label21);
            this.guna2GradientPanel3.Controls.Add(this.Label20);
            this.guna2GradientPanel3.Controls.Add(this.Label19);
            this.guna2GradientPanel3.Controls.Add(this.Label6);
            this.guna2GradientPanel3.Controls.Add(this.Label5);
            this.guna2GradientPanel3.Controls.Add(this.Label2);
            this.guna2GradientPanel3.FillColor = System.Drawing.Color.Silver;
            this.guna2GradientPanel3.FillColor2 = System.Drawing.Color.Silver;
            this.guna2GradientPanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel3.Location = new System.Drawing.Point(4, 3);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.ShadowDecoration.Parent = this.guna2GradientPanel3;
            this.guna2GradientPanel3.Size = new System.Drawing.Size(377, 286);
            this.guna2GradientPanel3.TabIndex = 133;
            // 
            // txtEmail
            // 
            this.txtEmail.Animated = true;
            this.txtEmail.BorderColor = System.Drawing.Color.Gray;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.Parent = this.txtEmail;
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.Maroon;
            this.txtEmail.FocusedState.Parent = this.txtEmail;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.Parent = this.txtEmail;
            this.txtEmail.Location = new System.Drawing.Point(164, 229);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.Parent = this.txtEmail;
            this.txtEmail.Size = new System.Drawing.Size(187, 22);
            this.txtEmail.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtEmail.TabIndex = 159;
            // 
            // txtContactNo1
            // 
            this.txtContactNo1.Animated = true;
            this.txtContactNo1.BorderColor = System.Drawing.Color.Gray;
            this.txtContactNo1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContactNo1.DefaultText = "";
            this.txtContactNo1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContactNo1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContactNo1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactNo1.DisabledState.Parent = this.txtContactNo1;
            this.txtContactNo1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactNo1.FocusedState.BorderColor = System.Drawing.Color.Maroon;
            this.txtContactNo1.FocusedState.Parent = this.txtContactNo1;
            this.txtContactNo1.HoverState.BorderColor = System.Drawing.Color.Black;
            this.txtContactNo1.HoverState.Parent = this.txtContactNo1;
            this.txtContactNo1.Location = new System.Drawing.Point(164, 189);
            this.txtContactNo1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContactNo1.Name = "txtContactNo1";
            this.txtContactNo1.PasswordChar = '\0';
            this.txtContactNo1.PlaceholderText = "";
            this.txtContactNo1.SelectedText = "";
            this.txtContactNo1.ShadowDecoration.Parent = this.txtContactNo1;
            this.txtContactNo1.Size = new System.Drawing.Size(187, 21);
            this.txtContactNo1.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtContactNo1.TabIndex = 158;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Animated = true;
            this.txtContactNo.BorderColor = System.Drawing.Color.Gray;
            this.txtContactNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContactNo.DefaultText = "";
            this.txtContactNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContactNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContactNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactNo.DisabledState.Parent = this.txtContactNo;
            this.txtContactNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactNo.FocusedState.BorderColor = System.Drawing.Color.Maroon;
            this.txtContactNo.FocusedState.Parent = this.txtContactNo;
            this.txtContactNo.HoverState.BorderColor = System.Drawing.Color.Black;
            this.txtContactNo.HoverState.Parent = this.txtContactNo;
            this.txtContactNo.Location = new System.Drawing.Point(164, 151);
            this.txtContactNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.PasswordChar = '\0';
            this.txtContactNo.PlaceholderText = "";
            this.txtContactNo.SelectedText = "";
            this.txtContactNo.ShadowDecoration.Parent = this.txtContactNo;
            this.txtContactNo.Size = new System.Drawing.Size(187, 22);
            this.txtContactNo.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtContactNo.TabIndex = 157;
            // 
            // txtCty
            // 
            this.txtCty.Animated = true;
            this.txtCty.BorderColor = System.Drawing.Color.Gray;
            this.txtCty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCty.DefaultText = "";
            this.txtCty.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCty.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCty.DisabledState.Parent = this.txtCty;
            this.txtCty.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCty.FocusedState.BorderColor = System.Drawing.Color.Maroon;
            this.txtCty.FocusedState.Parent = this.txtCty;
            this.txtCty.HoverState.BorderColor = System.Drawing.Color.Black;
            this.txtCty.HoverState.Parent = this.txtCty;
            this.txtCty.Location = new System.Drawing.Point(164, 110);
            this.txtCty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCty.Name = "txtCty";
            this.txtCty.PasswordChar = '\0';
            this.txtCty.PlaceholderText = "";
            this.txtCty.SelectedText = "";
            this.txtCty.ShadowDecoration.Parent = this.txtCty;
            this.txtCty.Size = new System.Drawing.Size(187, 21);
            this.txtCty.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtCty.TabIndex = 156;
            // 
            // txtAddress
            // 
            this.txtAddress.Animated = true;
            this.txtAddress.BorderColor = System.Drawing.Color.Gray;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.Parent = this.txtAddress;
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.Maroon;
            this.txtAddress.FocusedState.Parent = this.txtAddress;
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.Black;
            this.txtAddress.HoverState.Parent = this.txtAddress;
            this.txtAddress.Location = new System.Drawing.Point(164, 64);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.ShadowDecoration.Parent = this.txtAddress;
            this.txtAddress.Size = new System.Drawing.Size(187, 23);
            this.txtAddress.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtAddress.TabIndex = 155;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Animated = true;
            this.txtCustomerName.BorderColor = System.Drawing.Color.Gray;
            this.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerName.DefaultText = "";
            this.txtCustomerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.DisabledState.Parent = this.txtCustomerName;
            this.txtCustomerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.FocusedState.BorderColor = System.Drawing.Color.Maroon;
            this.txtCustomerName.FocusedState.Parent = this.txtCustomerName;
            this.txtCustomerName.HoverState.BorderColor = System.Drawing.Color.Black;
            this.txtCustomerName.HoverState.Parent = this.txtCustomerName;
            this.txtCustomerName.Location = new System.Drawing.Point(164, 19);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.PlaceholderText = "";
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.ShadowDecoration.Parent = this.txtCustomerName;
            this.txtCustomerName.Size = new System.Drawing.Size(187, 25);
            this.txtCustomerName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtCustomerName.TabIndex = 154;
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.BackColor = System.Drawing.Color.Silver;
            this.Label21.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.Black;
            this.Label21.Location = new System.Drawing.Point(9, 191);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(136, 20);
            this.Label21.TabIndex = 153;
            this.Label21.Text = "Alt. Contact No. *";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.BackColor = System.Drawing.Color.Silver;
            this.Label20.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label20.ForeColor = System.Drawing.Color.Black;
            this.Label20.Location = new System.Drawing.Point(82, 231);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(58, 20);
            this.Label20.TabIndex = 152;
            this.Label20.Text = "Email *";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.BackColor = System.Drawing.Color.Silver;
            this.Label19.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.ForeColor = System.Drawing.Color.Black;
            this.Label19.Location = new System.Drawing.Point(38, 153);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(107, 20);
            this.Label19.TabIndex = 151;
            this.Label19.Text = "Contact No. *";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Silver;
            this.Label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(97, 111);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 20);
            this.Label6.TabIndex = 150;
            this.Label6.Text = "City *";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Silver;
            this.Label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(65, 67);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(80, 20);
            this.Label5.TabIndex = 149;
            this.Label5.Text = "Address *";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Silver;
            this.Label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(82, 24);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 20);
            this.Label2.TabIndex = 148;
            this.Label2.Text = "Name *";
            // 
            // avatar
            // 
            this.avatar.BackColor = System.Drawing.Color.Transparent;
            this.avatar.Image = global::QuintonPOS.Properties.Resources.QUINTONPOSFULL;
            this.avatar.Location = new System.Drawing.Point(434, 13);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(131, 131);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar.TabIndex = 132;
            this.avatar.TabStop = false;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.pictureBox2);
            this.guna2GradientPanel1.Controls.Add(this.label9);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.SteelBlue;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(832, 69);
            this.guna2GradientPanel1.TabIndex = 135;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::QuintonPOS.Properties.Resources.png_transparent_new_text_new_york_city_sticker_information_new_sticker_angle_text_label_thumbnail;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 183;
            this.pictureBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(290, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(367, 29);
            this.label9.TabIndex = 32;
            this.label9.Text = "QUINTON POINT OF SALE.SYS";
            // 
            // guna2GradientPanel4
            // 
            this.guna2GradientPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2GradientPanel4.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2GradientPanel4.FillColor2 = System.Drawing.Color.SteelBlue;
            this.guna2GradientPanel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel4.Location = new System.Drawing.Point(0, 434);
            this.guna2GradientPanel4.Name = "guna2GradientPanel4";
            this.guna2GradientPanel4.ShadowDecoration.Parent = this.guna2GradientPanel4;
            this.guna2GradientPanel4.Size = new System.Drawing.Size(832, 40);
            this.guna2GradientPanel4.TabIndex = 150;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QuintonPOS.Properties.Resources.side11;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 383);
            this.panel1.TabIndex = 133;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.Animated = true;
            this.guna2Button1.BorderColor = System.Drawing.Color.Gray;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = global::QuintonPOS.Properties.Resources.save1;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Location = new System.Drawing.Point(661, 401);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(144, 27);
            this.guna2Button1.TabIndex = 117;
            this.guna2Button1.Text = "Save";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // guna2Button3
            // 
            this.guna2Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 10;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.Black;
            this.guna2Button3.HoverState.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2Button3.HoverState.ForeColor = System.Drawing.Color.DarkOrange;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Image = global::QuintonPOS.Properties.Resources.update1___Copy;
            this.guna2Button3.ImageOffset = new System.Drawing.Point(0, -1);
            this.guna2Button3.ImageSize = new System.Drawing.Size(18, 18);
            this.guna2Button3.Location = new System.Drawing.Point(576, 67);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.PressedColor = System.Drawing.Color.MidnightBlue;
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(219, 30);
            this.guna2Button3.TabIndex = 189;
            this.guna2Button3.Text = "Customer Registration";
            // 
            // frmCustomerProfileEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(832, 474);
            this.Controls.Add(this.guna2GradientPanel4);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.txtID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerProfileEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustomerProfileEntry";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frmCustomerProfileEntry_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomerProfileEntry_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomerProfileEntry_FormClosed);
            this.Load += new System.EventHandler(this.frmCustomerProfileEntry_Load);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.guna2GradientPanel3.ResumeLayout(false);
            this.guna2GradientPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        internal System.Windows.Forms.TextBox txtID;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtContactNo1;
        private Guna.UI2.WinForms.Guna2TextBox txtContactNo;
        private Guna.UI2.WinForms.Guna2TextBox txtCty;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerName;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.PictureBox avatar;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}