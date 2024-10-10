namespace QuintonPOS
{
    partial class frmAvatarOPT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAvatarOPT));
            this.gunaTransition1 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gunaCircleButton1 = new Guna.UI.WinForms.GunaCircleButton();
            this.btnSupplier = new Guna.UI.WinForms.GunaCircleButton();
            this.btnCustomer = new Guna.UI.WinForms.GunaCircleButton();
            this.btnProduct = new Guna.UI.WinForms.GunaCircleButton();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gunaCircleButton1);
            this.groupBox1.Controls.Add(this.btnSupplier);
            this.groupBox1.Controls.Add(this.btnCustomer);
            this.groupBox1.Controls.Add(this.btnProduct);
            this.gunaTransition1.SetDecoration(this.groupBox1, Guna.UI.Animation.DecorationType.None);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Location = new System.Drawing.Point(-2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 299);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ASSIGN TO:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // gunaCircleButton1
            // 
            this.gunaCircleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaCircleButton1.AnimationHoverSpeed = 0.07F;
            this.gunaCircleButton1.AnimationSpeed = 0.03F;
            this.gunaCircleButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gunaCircleButton1.BorderColor = System.Drawing.Color.Maroon;
            this.gunaCircleButton1.BorderSize = 1;
            this.gunaCircleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaTransition1.SetDecoration(this.gunaCircleButton1, Guna.UI.Animation.DecorationType.None);
            this.gunaCircleButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaCircleButton1.ForeColor = System.Drawing.Color.White;
            this.gunaCircleButton1.Image = null;
            this.gunaCircleButton1.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaCircleButton1.Location = new System.Drawing.Point(464, 0);
            this.gunaCircleButton1.Name = "gunaCircleButton1";
            this.gunaCircleButton1.OnHoverBaseColor = System.Drawing.Color.Black;
            this.gunaCircleButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton1.OnHoverImage = null;
            this.gunaCircleButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaCircleButton1.Size = new System.Drawing.Size(23, 25);
            this.gunaCircleButton1.TabIndex = 41;
            this.gunaCircleButton1.Text = "X";
            this.gunaCircleButton1.Click += new System.EventHandler(this.gunaCircleButton1_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.AnimationHoverSpeed = 0.07F;
            this.btnSupplier.AnimationSpeed = 0.03F;
            this.btnSupplier.BaseColor = System.Drawing.Color.Purple;
            this.btnSupplier.BorderColor = System.Drawing.Color.Black;
            this.btnSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaTransition1.SetDecoration(this.btnSupplier, Guna.UI.Animation.DecorationType.None);
            this.btnSupplier.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSupplier.FocusedColor = System.Drawing.Color.Empty;
            this.btnSupplier.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.Image = null;
            this.btnSupplier.ImageSize = new System.Drawing.Size(52, 52);
            this.btnSupplier.Location = new System.Drawing.Point(350, 160);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnSupplier.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSupplier.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSupplier.OnHoverImage = null;
            this.btnSupplier.OnPressedColor = System.Drawing.Color.Black;
            this.btnSupplier.Size = new System.Drawing.Size(120, 126);
            this.btnSupplier.TabIndex = 5;
            this.btnSupplier.Text = "Supplier";
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.AnimationHoverSpeed = 0.07F;
            this.btnCustomer.AnimationSpeed = 0.03F;
            this.btnCustomer.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnCustomer.BorderColor = System.Drawing.Color.Black;
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaTransition1.SetDecoration(this.btnCustomer, Guna.UI.Animation.DecorationType.None);
            this.btnCustomer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCustomer.FocusedColor = System.Drawing.Color.Empty;
            this.btnCustomer.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Image = null;
            this.btnCustomer.ImageSize = new System.Drawing.Size(52, 52);
            this.btnCustomer.Location = new System.Drawing.Point(7, 160);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnCustomer.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCustomer.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCustomer.OnHoverImage = null;
            this.btnCustomer.OnPressedColor = System.Drawing.Color.Black;
            this.btnCustomer.Size = new System.Drawing.Size(120, 126);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.AnimationHoverSpeed = 0.07F;
            this.btnProduct.AnimationSpeed = 0.03F;
            this.btnProduct.BaseColor = System.Drawing.Color.Teal;
            this.btnProduct.BorderColor = System.Drawing.Color.Black;
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaTransition1.SetDecoration(this.btnProduct, Guna.UI.Animation.DecorationType.None);
            this.btnProduct.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProduct.FocusedColor = System.Drawing.Color.Empty;
            this.btnProduct.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = null;
            this.btnProduct.ImageSize = new System.Drawing.Size(52, 52);
            this.btnProduct.Location = new System.Drawing.Point(187, 28);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.OnHoverBaseColor = System.Drawing.Color.SteelBlue;
            this.btnProduct.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnProduct.OnHoverForeColor = System.Drawing.Color.White;
            this.btnProduct.OnHoverImage = null;
            this.btnProduct.OnPressedColor = System.Drawing.Color.Black;
            this.btnProduct.Size = new System.Drawing.Size(120, 126);
            this.btnProduct.TabIndex = 3;
            this.btnProduct.Text = "Product";
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // frmAvatarOPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 298);
            this.Controls.Add(this.groupBox1);
            this.gunaTransition1.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAvatarOPT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAvatarOPT";
            this.Load += new System.EventHandler(this.frmAvatarOPT_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaTransition gunaTransition1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI.WinForms.GunaCircleButton btnSupplier;
        private Guna.UI.WinForms.GunaCircleButton btnCustomer;
        private Guna.UI.WinForms.GunaCircleButton btnProduct;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton1;
    }
}