namespace QuintonPOS
{
    partial class frmLogin
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
            Guna.UI.Animation.Animation animation1 = new Guna.UI.Animation.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            Guna.UI.Animation.Animation animation3 = new Guna.UI.Animation.Animation();
            Guna.UI.Animation.Animation animation2 = new Guna.UI.Animation.Animation();
            Guna.UI.Animation.Animation animation4 = new Guna.UI.Animation.Animation();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gunaTransition1 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.P2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.P1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.U2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.U1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSecond = new Guna.UI2.WinForms.Guna2TextBox();
            this.CLPic = new Guna.UI.WinForms.GunaTransfarantPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFirst = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.gunaTransition2 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.gunaTransition3 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaTransition4 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.U2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.U1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // gunaTransition1
            // 
            this.gunaTransition1.AnimationType = Guna.UI.Animation.AnimationType.Rotate;
            this.gunaTransition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(50);
            animation1.RotateCoeff = 1F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.gunaTransition1.DefaultAnimation = animation1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.P2);
            this.panel1.Controls.Add(this.P1);
            this.panel1.Controls.Add(this.U2);
            this.panel1.Controls.Add(this.U1);
            this.panel1.Controls.Add(this.guna2CircleButton1);
            this.panel1.Controls.Add(this.guna2Button5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSecond);
            this.panel1.Controls.Add(this.CLPic);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtFirst);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox3);
            this.gunaTransition4.SetDecoration(this.panel1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.panel1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.panel1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this.panel1, Guna.UI.Animation.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 414);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition3.SetDecoration(this.label1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.label1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.label1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.label1, Guna.UI.Animation.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "All Rights Reserved.\r\n";
            this.label1.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition3.SetDecoration(this.label7, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.label7, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.label7, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.label7, Guna.UI.Animation.DecorationType.None);
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(234, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Copyright © 2024 Fortune Mutseneki.\r\n";
            this.label7.Visible = false;
            // 
            // P2
            // 
            this.P2.BackColor = System.Drawing.Color.White;
            this.P2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaTransition4.SetDecoration(this.P2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.P2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.P2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this.P2, Guna.UI.Animation.DecorationType.None);
            this.P2.Image = global::QuintonPOS.Properties.Resources.hidePassword;
            this.P2.Location = new System.Drawing.Point(452, 241);
            this.P2.Name = "P2";
            this.P2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.P2.ShadowDecoration.Parent = this.P2;
            this.P2.Size = new System.Drawing.Size(19, 19);
            this.P2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P2.TabIndex = 189;
            this.P2.TabStop = false;
            this.P2.Visible = false;
            this.P2.Click += new System.EventHandler(this.P2_Click);
            // 
            // P1
            // 
            this.P1.BackColor = System.Drawing.Color.White;
            this.P1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaTransition4.SetDecoration(this.P1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.P1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.P1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this.P1, Guna.UI.Animation.DecorationType.None);
            this.P1.Image = global::QuintonPOS.Properties.Resources.showPassword;
            this.P1.Location = new System.Drawing.Point(452, 241);
            this.P1.Name = "P1";
            this.P1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.P1.ShadowDecoration.Parent = this.P1;
            this.P1.Size = new System.Drawing.Size(19, 19);
            this.P1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P1.TabIndex = 188;
            this.P1.TabStop = false;
            this.P1.Visible = false;
            this.P1.Click += new System.EventHandler(this.P1_Click);
            // 
            // U2
            // 
            this.U2.BackColor = System.Drawing.Color.White;
            this.U2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaTransition4.SetDecoration(this.U2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.U2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.U2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this.U2, Guna.UI.Animation.DecorationType.None);
            this.U2.Image = global::QuintonPOS.Properties.Resources.hidePassword;
            this.U2.Location = new System.Drawing.Point(452, 176);
            this.U2.Name = "U2";
            this.U2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.U2.ShadowDecoration.Parent = this.U2;
            this.U2.Size = new System.Drawing.Size(19, 19);
            this.U2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.U2.TabIndex = 187;
            this.U2.TabStop = false;
            this.U2.Visible = false;
            this.U2.Click += new System.EventHandler(this.U2_Click);
            // 
            // U1
            // 
            this.U1.BackColor = System.Drawing.Color.White;
            this.U1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaTransition4.SetDecoration(this.U1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.U1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.U1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this.U1, Guna.UI.Animation.DecorationType.None);
            this.U1.Image = global::QuintonPOS.Properties.Resources.showPassword;
            this.U1.Location = new System.Drawing.Point(452, 176);
            this.U1.Name = "U1";
            this.U1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.U1.ShadowDecoration.Parent = this.U1;
            this.U1.Size = new System.Drawing.Size(19, 19);
            this.U1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.U1.TabIndex = 186;
            this.U1.TabStop = false;
            this.U1.Visible = false;
            this.U1.Click += new System.EventHandler(this.U1_Click);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CircleButton1.BorderColor = System.Drawing.Color.Silver;
            this.guna2CircleButton1.BorderThickness = 1;
            this.guna2CircleButton1.CheckedState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CircleButton1.CustomImages.Parent = this.guna2CircleButton1;
            this.gunaTransition2.SetDecoration(this.guna2CircleButton1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.guna2CircleButton1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.guna2CircleButton1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this.guna2CircleButton1, Guna.UI.Animation.DecorationType.None);
            this.guna2CircleButton1.FillColor = System.Drawing.SystemColors.Control;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2CircleButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2CircleButton1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.HoverState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Location = new System.Drawing.Point(579, 8);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.PressedColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.ShadowDecoration.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Size = new System.Drawing.Size(23, 23);
            this.guna2CircleButton1.TabIndex = 4;
            this.guna2CircleButton1.Text = "X";
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button5.Animated = true;
            this.guna2Button5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2Button5.BorderColor = System.Drawing.Color.Gray;
            this.guna2Button5.BorderRadius = 10;
            this.guna2Button5.BorderThickness = 1;
            this.guna2Button5.CheckedState.Parent = this.guna2Button5;
            this.guna2Button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button5.CustomImages.Parent = this.guna2Button5;
            this.gunaTransition2.SetDecoration(this.guna2Button5, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.guna2Button5, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.guna2Button5, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this.guna2Button5, Guna.UI.Animation.DecorationType.None);
            this.guna2Button5.FillColor = System.Drawing.Color.White;
            this.guna2Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button5.ForeColor = System.Drawing.Color.Black;
            this.guna2Button5.HoverState.Parent = this.guna2Button5;
            this.guna2Button5.Image = global::QuintonPOS.Properties.Resources.key13;
            this.guna2Button5.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button5.Location = new System.Drawing.Point(248, 282);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.ShadowDecoration.Parent = this.guna2Button5;
            this.guna2Button5.Size = new System.Drawing.Size(178, 28);
            this.guna2Button5.TabIndex = 3;
            this.guna2Button5.Text = "K";
            this.guna2Button5.TextOffset = new System.Drawing.Point(-4, 0);
            this.guna2Button5.Visible = false;
            this.guna2Button5.Click += new System.EventHandler(this.guna2Button5_Click_1);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition3.SetDecoration(this.label3, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.label3, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.label3, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.label3, Guna.UI.Animation.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(263, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Please";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition3.SetDecoration(this.pictureBox2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.pictureBox2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.pictureBox2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.pictureBox2, Guna.UI.Animation.DecorationType.None);
            this.pictureBox2.Image = global::QuintonPOS.Properties.Resources.progress;
            this.pictureBox2.Location = new System.Drawing.Point(484, 241);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 165;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition3.SetDecoration(this.label4, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.label4, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.label4, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.label4, Guna.UI.Animation.DecorationType.None);
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(332, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Login";
            // 
            // txtSecond
            // 
            this.txtSecond.Animated = true;
            this.txtSecond.BorderColor = System.Drawing.Color.Gray;
            this.txtSecond.BorderRadius = 10;
            this.txtSecond.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTransition3.SetDecoration(this.txtSecond, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.txtSecond, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.txtSecond, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.txtSecond, Guna.UI.Animation.DecorationType.None);
            this.txtSecond.DefaultText = "";
            this.txtSecond.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSecond.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSecond.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSecond.DisabledState.Parent = this.txtSecond;
            this.txtSecond.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSecond.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSecond.FocusedState.Parent = this.txtSecond;
            this.txtSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecond.ForeColor = System.Drawing.Color.Black;
            this.txtSecond.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSecond.HoverState.Parent = this.txtSecond;
            this.txtSecond.Location = new System.Drawing.Point(200, 232);
            this.txtSecond.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.PasswordChar = 'x';
            this.txtSecond.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtSecond.PlaceholderText = "PASSWORD";
            this.txtSecond.SelectedText = "";
            this.txtSecond.ShadowDecoration.Parent = this.txtSecond;
            this.txtSecond.Size = new System.Drawing.Size(277, 37);
            this.txtSecond.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtSecond.TabIndex = 2;
            this.txtSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSecond.Visible = false;
            this.txtSecond.TextChanged += new System.EventHandler(this.txtSecond_TextChanged_2);
            this.txtSecond.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecond_KeyDown_2);
            // 
            // CLPic
            // 
            this.CLPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CLPic.BackColor = System.Drawing.Color.Transparent;
            this.CLPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CLPic.BaseColor = System.Drawing.Color.Black;
            this.gunaTransition3.SetDecoration(this.CLPic, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.CLPic, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.CLPic, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.CLPic, Guna.UI.Animation.DecorationType.None);
            this.CLPic.Image = global::QuintonPOS.Properties.Resources.QUINTONPOSFULL;
            this.CLPic.Location = new System.Drawing.Point(494, 35);
            this.CLPic.Name = "CLPic";
            this.CLPic.Size = new System.Drawing.Size(81, 85);
            this.CLPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CLPic.TabIndex = 172;
            this.CLPic.TabStop = false;
            this.CLPic.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition3.SetDecoration(this.pictureBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.pictureBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.pictureBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.pictureBox1, Guna.UI.Animation.DecorationType.None);
            this.pictureBox1.Image = global::QuintonPOS.Properties.Resources.progress;
            this.pictureBox1.Location = new System.Drawing.Point(484, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // txtFirst
            // 
            this.txtFirst.Animated = true;
            this.txtFirst.BackColor = System.Drawing.Color.Transparent;
            this.txtFirst.BorderColor = System.Drawing.Color.Gray;
            this.txtFirst.BorderRadius = 10;
            this.txtFirst.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTransition3.SetDecoration(this.txtFirst, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.txtFirst, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.txtFirst, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.txtFirst, Guna.UI.Animation.DecorationType.None);
            this.txtFirst.DefaultText = "";
            this.txtFirst.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFirst.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFirst.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFirst.DisabledState.Parent = this.txtFirst;
            this.txtFirst.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFirst.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFirst.FocusedState.Parent = this.txtFirst;
            this.txtFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirst.ForeColor = System.Drawing.Color.Black;
            this.txtFirst.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFirst.HoverState.Parent = this.txtFirst;
            this.txtFirst.Location = new System.Drawing.Point(200, 168);
            this.txtFirst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.PasswordChar = 'x';
            this.txtFirst.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtFirst.PlaceholderText = "USERNAME";
            this.txtFirst.SelectedText = "";
            this.txtFirst.ShadowDecoration.Parent = this.txtFirst;
            this.txtFirst.Size = new System.Drawing.Size(278, 37);
            this.txtFirst.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtFirst.TabIndex = 1;
            this.txtFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFirst.Visible = false;
            this.txtFirst.TextChanged += new System.EventHandler(this.txtFirst_TextChanged_2);
            this.txtFirst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFirst_KeyDown_2);
            // 
            // pictureBox5
            // 
            this.gunaTransition3.SetDecoration(this.pictureBox5, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.pictureBox5, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.pictureBox5, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.pictureBox5, Guna.UI.Animation.DecorationType.None);
            this.pictureBox5.Image = global::QuintonPOS.Properties.Resources.side11;
            this.pictureBox5.Location = new System.Drawing.Point(3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(140, 426);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 173;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition3.SetDecoration(this.pictureBox3, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this.pictureBox3, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.pictureBox3, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.pictureBox3, Guna.UI.Animation.DecorationType.None);
            this.pictureBox3.Image = global::QuintonPOS.Properties.Resources.bac11;
            this.pictureBox3.Location = new System.Drawing.Point(365, 325);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(248, 112);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 190;
            this.pictureBox3.TabStop = false;
            // 
            // gunaTransition2
            // 
            this.gunaTransition2.AnimationType = Guna.UI.Animation.AnimationType.VertSlide;
            this.gunaTransition2.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.gunaTransition2.DefaultAnimation = animation3;
            // 
            // gunaTransition3
            // 
            this.gunaTransition3.AnimationType = Guna.UI.Animation.AnimationType.HorizSlide;
            this.gunaTransition3.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.gunaTransition3.DefaultAnimation = animation2;
            this.gunaTransition3.TimeStep = 0.01F;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 20;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaTransition4
            // 
            this.gunaTransition4.AnimationType = Guna.UI.Animation.AnimationType.Transparent;
            this.gunaTransition4.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(0);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 1F;
            this.gunaTransition4.DefaultAnimation = animation4;
            this.gunaTransition4.TimeStep = 0.01F;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::QuintonPOS.Properties.Resources.bacCopy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(606, 407);
            this.Controls.Add(this.panel1);
            this.gunaTransition2.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition4.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.MouseHover += new System.EventHandler(this.frmLogin_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseMove);
            this.Validated += new System.EventHandler(this.frmLogin_Validated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.U2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.U1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI.WinForms.GunaTransition gunaTransition1;
        private Guna.UI.WinForms.GunaTransition gunaTransition2;
        private Guna.UI.WinForms.GunaTransition gunaTransition3;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtSecond;
        private Guna.UI.WinForms.GunaTransfarantPictureBox CLPic;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtFirst;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox U1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox U2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox P2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox P1;
        private Guna.UI.WinForms.GunaTransition gunaTransition4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;

    }

        

}