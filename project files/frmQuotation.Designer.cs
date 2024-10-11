namespace QuintonPOS
{
    partial class frmQuotation
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
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.gunaShadowPanel1 = new Guna.UI.WinForms.GunaShadowPanel();
            this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
            this.gunaCircleButton1 = new Guna.UI.WinForms.GunaCircleButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.gunaGroupBox1.SuspendLayout();
            this.gunaShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.gunaShadowPanel1);
            this.gunaGroupBox1.Controls.Add(this.gunaCircleButton1);
            this.gunaGroupBox1.Controls.Add(this.richTextBox1);
            this.gunaGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGroupBox1.LineColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(315, 625);
            this.gunaGroupBox1.TabIndex = 1;
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            this.gunaGroupBox1.Click += new System.EventHandler(this.GunaGroupBox1_Click);
            // 
            // gunaShadowPanel1
            // 
            this.gunaShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaShadowPanel1.BaseColor = System.Drawing.Color.Gainsboro;
            this.gunaShadowPanel1.Controls.Add(this.guna2Button8);
            this.gunaShadowPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gunaShadowPanel1.Location = new System.Drawing.Point(0, 588);
            this.gunaShadowPanel1.Name = "gunaShadowPanel1";
            this.gunaShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.gunaShadowPanel1.Size = new System.Drawing.Size(315, 37);
            this.gunaShadowPanel1.TabIndex = 159;
            // 
            // guna2Button8
            // 
            this.guna2Button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button8.BorderRadius = 5;
            this.guna2Button8.CheckedState.Parent = this.guna2Button8;
            this.guna2Button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button8.CustomImages.Parent = this.guna2Button8;
            this.guna2Button8.FillColor = System.Drawing.Color.Tomato;
            this.guna2Button8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button8.ForeColor = System.Drawing.Color.White;
            this.guna2Button8.HoverState.Parent = this.guna2Button8;
            this.guna2Button8.Location = new System.Drawing.Point(244, 6);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.ShadowDecoration.Parent = this.guna2Button8;
            this.guna2Button8.Size = new System.Drawing.Size(66, 25);
            this.guna2Button8.TabIndex = 158;
            this.guna2Button8.Text = "Print";
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
            this.gunaCircleButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaCircleButton1.ForeColor = System.Drawing.Color.White;
            this.gunaCircleButton1.Image = null;
            this.gunaCircleButton1.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaCircleButton1.Location = new System.Drawing.Point(288, 1);
            this.gunaCircleButton1.Name = "gunaCircleButton1";
            this.gunaCircleButton1.OnHoverBaseColor = System.Drawing.Color.Black;
            this.gunaCircleButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton1.OnHoverImage = null;
            this.gunaCircleButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaCircleButton1.Size = new System.Drawing.Size(23, 25);
            this.gunaCircleButton1.TabIndex = 40;
            this.gunaCircleButton1.Text = "X";
            this.gunaCircleButton1.Click += new System.EventHandler(this.gunaCircleButton1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(315, 570);
            this.richTextBox1.TabIndex = 41;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // frmQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 625);
            this.Controls.Add(this.gunaGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuotation";
            this.Load += new System.EventHandler(this.frmQuotation_Load);
            this.gunaGroupBox1.ResumeLayout(false);
            this.gunaShadowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button8;
    }
}