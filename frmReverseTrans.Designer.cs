namespace QuintonPOS
{
    partial class frmReverseTrans
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
            Guna.UI.Animation.Animation animation3 = new Guna.UI.Animation.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReverseTrans));
            Guna.UI.Animation.Animation animation4 = new Guna.UI.Animation.Animation();
            this.btnProceed = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaTransition1 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tm = new System.Windows.Forms.Label();
            this.gunaTransition2 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProceed
            // 
            this.btnProceed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProceed.BorderColor = System.Drawing.Color.Gray;
            this.btnProceed.BorderThickness = 1;
            this.btnProceed.CheckedState.Parent = this.btnProceed;
            this.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProceed.CustomImages.Parent = this.btnProceed;
            this.gunaTransition2.SetDecoration(this.btnProceed, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.btnProceed, Guna.UI.Animation.DecorationType.None);
            this.btnProceed.FillColor = System.Drawing.Color.White;
            this.btnProceed.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.ForeColor = System.Drawing.Color.Black;
            this.btnProceed.HoverState.Parent = this.btnProceed;
            this.btnProceed.Location = new System.Drawing.Point(115, 182);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.ShadowDecoration.Parent = this.btnProceed;
            this.btnProceed.Size = new System.Drawing.Size(303, 29);
            this.btnProceed.TabIndex = 160;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.groupBox1);
            this.gunaTransition2.SetDecoration(this.groupBox2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.groupBox2, Guna.UI.Animation.DecorationType.None);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(169, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 136);
            this.groupBox2.TabIndex = 164;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Invoice No:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::QuintonPOS.Properties.Resources.bac3;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.label1);
            this.gunaTransition2.SetDecoration(this.groupBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.groupBox1, Guna.UI.Animation.DecorationType.None);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 164;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.gunaTransition1.SetDecoration(this.label1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.label1, Guna.UI.Animation.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(71, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 161;
            this.label1.Text = "label1";
            // 
            // gunaTransition1
            // 
            this.gunaTransition1.AnimationType = Guna.UI.Animation.AnimationType.Particles;
            this.gunaTransition1.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 1;
            animation3.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 2F;
            animation3.TransparencyCoeff = 0F;
            this.gunaTransition1.DefaultAnimation = animation3;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.gunaTransition2.SetDecoration(this.guna2Button1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.guna2Button1, Guna.UI.Animation.DecorationType.None);
            this.guna2Button1.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.DarkOrange;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = global::QuintonPOS.Properties.Resources.ic_action_refresh;
            this.guna2Button1.ImageOffset = new System.Drawing.Point(0, -1);
            this.guna2Button1.ImageSize = new System.Drawing.Size(18, 18);
            this.guna2Button1.Location = new System.Drawing.Point(349, 1);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedColor = System.Drawing.Color.MidnightBlue;
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(178, 30);
            this.guna2Button1.TabIndex = 191;
            this.guna2Button1.Text = "Reverse Transaction";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.gunaTransition1.SetDecoration(this.dateTimePicker1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.dateTimePicker1, Guna.UI.Animation.DecorationType.None);
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(196, 104);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(136, 20);
            this.dateTimePicker1.TabIndex = 192;
            // 
            // tm
            // 
            this.tm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tm.AutoSize = true;
            this.gunaTransition1.SetDecoration(this.tm, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.tm, Guna.UI.Animation.DecorationType.None);
            this.tm.Location = new System.Drawing.Point(306, 132);
            this.tm.Name = "tm";
            this.tm.Size = new System.Drawing.Size(35, 13);
            this.tm.TabIndex = 193;
            this.tm.Text = "label2";
            // 
            // gunaTransition2
            // 
            this.gunaTransition2.AnimationType = Guna.UI.Animation.AnimationType.Transparent;
            this.gunaTransition2.Cursor = null;
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
            this.gunaTransition2.DefaultAnimation = animation4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmReverseTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(528, 228);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tm);
            this.gunaTransition2.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReverseTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReverseTrans";
            this.Load += new System.EventHandler(this.frmReverseTrans_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnProceed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTransition gunaTransition1;
        private Guna.UI.WinForms.GunaTransition gunaTransition2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label tm;
    }
}