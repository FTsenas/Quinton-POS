namespace QuintonPOS
{
    partial class frmShift
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
            Guna.UI.Animation.Animation animation4 = new Guna.UI.Animation.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShift));
            Guna.UI.Animation.Animation animation5 = new Guna.UI.Animation.Animation();
            Guna.UI.Animation.Animation animation6 = new Guna.UI.Animation.Animation();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gunaTransition1 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaTransition2 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.gunaTransition3 = new Guna.UI.WinForms.GunaTransition(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition1.SetDecoration(this.gunaLabel1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.gunaLabel1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this.gunaLabel1, Guna.UI.Animation.DecorationType.None);
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.Location = new System.Drawing.Point(155, 468);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(335, 30);
            this.gunaLabel1.TabIndex = 1;
            this.gunaLabel1.Text = "PRESS ANY KEY TO CONTINUE...";
            this.gunaLabel1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gunaTransition1
            // 
            this.gunaTransition1.AnimationType = Guna.UI.Animation.AnimationType.Scale;
            this.gunaTransition1.Cursor = null;
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
            animation4.TransparencyCoeff = 0F;
            this.gunaTransition1.DefaultAnimation = animation4;
            this.gunaTransition1.Interval = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.gunaTransition3.SetDecoration(this.dateTimePicker1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.dateTimePicker1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.dateTimePicker1, Guna.UI.Animation.DecorationType.None);
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(301, 408);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(12, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gunaPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gunaTransition1.SetDecoration(this.gunaPictureBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.gunaPictureBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition3.SetDecoration(this.gunaPictureBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaPictureBox1.Image = global::QuintonPOS.Properties.Resources.QUINTONPOSFULL;
            this.gunaPictureBox1.Location = new System.Drawing.Point(160, 100);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(315, 328);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 0;
            this.gunaPictureBox1.TabStop = false;
            this.gunaPictureBox1.Visible = false;
            this.gunaPictureBox1.DoubleClick += new System.EventHandler(this.gunaPictureBox1_DoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gunaTransition3.SetDecoration(this.pictureBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.pictureBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.pictureBox1, Guna.UI.Animation.DecorationType.None);
            this.pictureBox1.Image = global::QuintonPOS.Properties.Resources.side11;
            this.pictureBox1.Location = new System.Drawing.Point(-10, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 555);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaTransition3.SetDecoration(this.pictureBox2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this.pictureBox2, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this.pictureBox2, Guna.UI.Animation.DecorationType.None);
            this.pictureBox2.Image = global::QuintonPOS.Properties.Resources.side11_copy;
            this.pictureBox2.Location = new System.Drawing.Point(398, -6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(259, 555);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaTransition2
            // 
            this.gunaTransition2.AnimationType = Guna.UI.Animation.AnimationType.Rotate;
            this.gunaTransition2.Cursor = null;
            animation5.AnimateOnlyDifferences = true;
            animation5.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.BlindCoeff")));
            animation5.LeafCoeff = 0F;
            animation5.MaxTime = 1F;
            animation5.MinTime = 0F;
            animation5.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicCoeff")));
            animation5.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicShift")));
            animation5.MosaicSize = 0;
            animation5.Padding = new System.Windows.Forms.Padding(50);
            animation5.RotateCoeff = 1F;
            animation5.RotateLimit = 0F;
            animation5.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.ScaleCoeff")));
            animation5.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.SlideCoeff")));
            animation5.TimeCoeff = 0F;
            animation5.TransparencyCoeff = 1F;
            this.gunaTransition2.DefaultAnimation = animation5;
            this.gunaTransition2.Interval = 5;
            // 
            // gunaTransition3
            // 
            this.gunaTransition3.AnimationType = Guna.UI.Animation.AnimationType.Transparent;
            this.gunaTransition3.Cursor = null;
            animation6.AnimateOnlyDifferences = true;
            animation6.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.BlindCoeff")));
            animation6.LeafCoeff = 0F;
            animation6.MaxTime = 1F;
            animation6.MinTime = 0F;
            animation6.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicCoeff")));
            animation6.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicShift")));
            animation6.MosaicSize = 0;
            animation6.Padding = new System.Windows.Forms.Padding(0);
            animation6.RotateCoeff = 0F;
            animation6.RotateLimit = 0F;
            animation6.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.ScaleCoeff")));
            animation6.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.SlideCoeff")));
            animation6.TimeCoeff = 0F;
            animation6.TransparencyCoeff = 1F;
            this.gunaTransition3.DefaultAnimation = animation6;
            this.gunaTransition3.Interval = 5;
            // 
            // frmShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(649, 546);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.gunaPictureBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.gunaTransition3.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition1.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.gunaTransition2.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShift";
            this.Text = "frmShift";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShift_Load);
            this.Click += new System.EventHandler(this.frmShift_Click);
            this.DoubleClick += new System.EventHandler(this.frmShift_DoubleClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmShift_KeyPress);
            this.Validated += new System.EventHandler(this.FrmShift_Validated);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI.WinForms.GunaTransition gunaTransition1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaTransition gunaTransition2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI.WinForms.GunaTransition gunaTransition3;
 
    }
}