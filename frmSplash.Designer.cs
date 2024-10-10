namespace QuintonPOS
{
    partial class frmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaTransition1 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.gunaTransfarantPictureBox1 = new Guna.UI.WinForms.GunaTransfarantPictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gunaTransfarantPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 300;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaTransition1
            // 
            this.gunaTransition1.AnimationType = Guna.UI.Animation.AnimationType.Mosaic;
            this.gunaTransition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 20;
            animation1.Padding = new System.Windows.Forms.Padding(30);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.gunaTransition1.DefaultAnimation = animation1;
            this.gunaTransition1.Interval = 5;
            this.gunaTransition1.MaxAnimationTime = 2000;
            this.gunaTransition1.TimeStep = 0.06F;
            this.gunaTransition1.AnimationCompleted += new System.EventHandler<Guna.UI.Animation.AnimationCompletedEventArg>(this.gunaTransition1_AnimationCompleted);
            this.gunaTransition1.AllAnimationsCompleted += new System.EventHandler(this.gunaTransition1_AllAnimationsCompleted);
            // 
            // gunaTransfarantPictureBox1
            // 
            this.gunaTransfarantPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransfarantPictureBox1.BaseColor = System.Drawing.Color.Black;
            this.gunaTransition1.SetDecoration(this.gunaTransfarantPictureBox1, Guna.UI.Animation.DecorationType.None);
            this.gunaTransfarantPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaTransfarantPictureBox1.Image = global::QuintonPOS.Properties.Resources.QUINTONPOSFULL;
            this.gunaTransfarantPictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("gunaTransfarantPictureBox1.InitialImage")));
            this.gunaTransfarantPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.gunaTransfarantPictureBox1.Name = "gunaTransfarantPictureBox1";
            this.gunaTransfarantPictureBox1.Size = new System.Drawing.Size(374, 361);
            this.gunaTransfarantPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaTransfarantPictureBox1.TabIndex = 0;
            this.gunaTransfarantPictureBox1.TabStop = false;
            this.gunaTransfarantPictureBox1.Visible = false;
            this.gunaTransfarantPictureBox1.Click += new System.EventHandler(this.gunaTransfarantPictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(374, 361);
            this.Controls.Add(this.gunaTransfarantPictureBox1);
            this.gunaTransition1.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.Load += new System.EventHandler(this.frmSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gunaTransfarantPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaTransition gunaTransition1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI.WinForms.GunaTransfarantPictureBox gunaTransfarantPictureBox1;
    }
}