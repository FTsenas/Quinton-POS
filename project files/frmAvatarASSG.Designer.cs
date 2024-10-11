namespace QuintonPOS
{
    partial class frmAvatarASSG
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            Guna.UI.Animation.Animation animation3 = new Guna.UI.Animation.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAvatarASSG));
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.guna2WinProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.searchRst = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAssignToAV = new Guna.UI2.WinForms.Guna2GradientButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtAvatar = new System.Windows.Forms.TextBox();
            this.gunaTransition1 = new Guna.UI.WinForms.GunaTransition(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchRst)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.guna2Button3);
            this.panel2.Controls.Add(this.avatar);
            this.panel2.Controls.Add(this.guna2WinProgressIndicator1);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.panel4);
            this.gunaTransition1.SetDecoration(this.panel2, Guna.UI.Animation.DecorationType.None);
            this.panel2.Location = new System.Drawing.Point(-3, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(847, 313);
            this.panel2.TabIndex = 12;
            // 
            // guna2Button3
            // 
            this.guna2Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 10;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.gunaTransition1.SetDecoration(this.guna2Button3, Guna.UI.Animation.DecorationType.None);
            this.guna2Button3.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.Black;
            this.guna2Button3.HoverState.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2Button3.HoverState.ForeColor = System.Drawing.Color.DarkOrange;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.ImageOffset = new System.Drawing.Point(0, -1);
            this.guna2Button3.ImageSize = new System.Drawing.Size(18, 15);
            this.guna2Button3.Location = new System.Drawing.Point(640, 9);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.PressedColor = System.Drawing.Color.MidnightBlue;
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(148, 27);
            this.guna2Button3.TabIndex = 184;
            this.guna2Button3.Text = "Assign Avatar";
            // 
            // avatar
            // 
            this.gunaTransition1.SetDecoration(this.avatar, Guna.UI.Animation.DecorationType.None);
            this.avatar.Location = new System.Drawing.Point(794, 17);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(45, 50);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar.TabIndex = 101;
            this.avatar.TabStop = false;
            this.avatar.Visible = false;
            // 
            // guna2WinProgressIndicator1
            // 
            this.guna2WinProgressIndicator1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2WinProgressIndicator1.AutoStart = true;
            this.guna2WinProgressIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2WinProgressIndicator1.CircleSize = 0.1F;
            this.gunaTransition1.SetDecoration(this.guna2WinProgressIndicator1, Guna.UI.Animation.DecorationType.None);
            this.guna2WinProgressIndicator1.Location = new System.Drawing.Point(607, 29);
            this.guna2WinProgressIndicator1.Name = "guna2WinProgressIndicator1";
            this.guna2WinProgressIndicator1.NumberOfCircles = 6;
            this.guna2WinProgressIndicator1.ProgressColor = System.Drawing.Color.Green;
            this.guna2WinProgressIndicator1.Size = new System.Drawing.Size(30, 30);
            this.guna2WinProgressIndicator1.TabIndex = 100;
            this.guna2WinProgressIndicator1.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearch.BorderColor = System.Drawing.Color.Gray;
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaTransition1.SetDecoration(this.txtSearch, Guna.UI.Animation.DecorationType.None);
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconLeft = global::QuintonPOS.Properties.Resources.search2;
            this.txtSearch.IconLeftSize = new System.Drawing.Size(15, 15);
            this.txtSearch.Location = new System.Drawing.Point(257, 31);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtSearch.PlaceholderText = "Search for items here!";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(344, 24);
            this.txtSearch.TabIndex = 95;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.searchRst);
            this.gunaTransition1.SetDecoration(this.panel4, Guna.UI.Animation.DecorationType.None);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(844, 233);
            this.panel4.TabIndex = 96;
            // 
            // searchRst
            // 
            this.searchRst.AllowUserToAddRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.searchRst.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.searchRst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchRst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchRst.BackgroundColor = System.Drawing.Color.White;
            this.searchRst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchRst.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.searchRst.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchRst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.searchRst.ColumnHeadersHeight = 25;
            this.searchRst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.searchRst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaTransition1.SetDecoration(this.searchRst, Guna.UI.Animation.DecorationType.None);
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.searchRst.DefaultCellStyle = dataGridViewCellStyle13;
            this.searchRst.EnableHeadersVisualStyles = false;
            this.searchRst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.searchRst.Location = new System.Drawing.Point(-3, 0);
            this.searchRst.MultiSelect = false;
            this.searchRst.Name = "searchRst";
            this.searchRst.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchRst.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.searchRst.RowHeadersVisible = false;
            this.searchRst.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchRst.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.searchRst.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchRst.RowTemplate.Height = 30;
            this.searchRst.RowTemplate.ReadOnly = true;
            this.searchRst.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.searchRst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchRst.ShowEditingIcon = false;
            this.searchRst.Size = new System.Drawing.Size(847, 240);
            this.searchRst.TabIndex = 99;
            this.searchRst.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WetAsphalt;
            this.searchRst.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.searchRst.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchRst.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.searchRst.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.searchRst.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.searchRst.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.searchRst.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.searchRst.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.searchRst.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.searchRst.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchRst.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.searchRst.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.searchRst.ThemeStyle.HeaderStyle.Height = 25;
            this.searchRst.ThemeStyle.ReadOnly = true;
            this.searchRst.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.searchRst.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.searchRst.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchRst.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.searchRst.ThemeStyle.RowsStyle.Height = 30;
            this.searchRst.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.MediumPurple;
            this.searchRst.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.searchRst.Click += new System.EventHandler(this.searchRst_Click);
            // 
            // btnAssignToAV
            // 
            this.btnAssignToAV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAssignToAV.Animated = true;
            this.btnAssignToAV.BorderColor = System.Drawing.Color.Gray;
            this.btnAssignToAV.BorderRadius = 15;
            this.btnAssignToAV.BorderThickness = 1;
            this.btnAssignToAV.CheckedState.Parent = this.btnAssignToAV;
            this.btnAssignToAV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignToAV.CustomImages.Parent = this.btnAssignToAV;
            this.gunaTransition1.SetDecoration(this.btnAssignToAV, Guna.UI.Animation.DecorationType.None);
            this.btnAssignToAV.FillColor = System.Drawing.Color.White;
            this.btnAssignToAV.FillColor2 = System.Drawing.Color.White;
            this.btnAssignToAV.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignToAV.ForeColor = System.Drawing.Color.Black;
            this.btnAssignToAV.HoverState.Parent = this.btnAssignToAV;
            this.btnAssignToAV.Image = global::QuintonPOS.Properties.Resources.save;
            this.btnAssignToAV.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAssignToAV.ImageOffset = new System.Drawing.Point(30, 0);
            this.btnAssignToAV.Location = new System.Drawing.Point(299, 392);
            this.btnAssignToAV.Name = "btnAssignToAV";
            this.btnAssignToAV.ShadowDecoration.Parent = this.btnAssignToAV;
            this.btnAssignToAV.Size = new System.Drawing.Size(250, 32);
            this.btnAssignToAV.TabIndex = 111;
            this.btnAssignToAV.Text = "ASSIGN & SAVE";
            this.btnAssignToAV.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaTransition1.SetDecoration(this.panel1, Guna.UI.Animation.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(-66, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 63);
            this.panel1.TabIndex = 172;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.Controls.Add(this.pictureBox2);
            this.guna2GradientPanel2.Controls.Add(this.label1);
            this.gunaTransition1.SetDecoration(this.guna2GradientPanel2, Guna.UI.Animation.DecorationType.None);
            this.guna2GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.SteelBlue;
            this.guna2GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.ShadowDecoration.Parent = this.guna2GradientPanel2;
            this.guna2GradientPanel2.Size = new System.Drawing.Size(839, 69);
            this.guna2GradientPanel2.TabIndex = 173;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition1.SetDecoration(this.pictureBox2, Guna.UI.Animation.DecorationType.None);
            this.pictureBox2.Image = global::QuintonPOS.Properties.Resources.png_transparent_paper_sticker_sales_label_graphics_miscellaneous_text_service_thumbnail;
            this.pictureBox2.Location = new System.Drawing.Point(-15, -4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(92, 102);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 183;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransition1.SetDecoration(this.label1, Guna.UI.Animation.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(231, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 31);
            this.label1.TabIndex = 31;
            this.label1.Text = "QUINTON POINT OF SALE.SYS";
            // 
            // txtCode
            // 
            this.gunaTransition1.SetDecoration(this.txtCode, Guna.UI.Animation.DecorationType.None);
            this.txtCode.Location = new System.Drawing.Point(79, 377);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 184;
            this.txtCode.Visible = false;
            // 
            // txtAvatar
            // 
            this.gunaTransition1.SetDecoration(this.txtAvatar, Guna.UI.Animation.DecorationType.None);
            this.txtAvatar.Location = new System.Drawing.Point(79, 403);
            this.txtAvatar.Name = "txtAvatar";
            this.txtAvatar.Size = new System.Drawing.Size(100, 20);
            this.txtAvatar.TabIndex = 185;
            this.txtAvatar.Visible = false;
            // 
            // gunaTransition1
            // 
            this.gunaTransition1.AnimationType = Guna.UI.Animation.AnimationType.HorizSlide;
            this.gunaTransition1.Cursor = null;
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
            this.gunaTransition1.DefaultAnimation = animation3;
            // 
            // frmAvatarASSG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 479);
            this.Controls.Add(this.txtAvatar);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.btnAssignToAV);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.gunaTransition1.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAvatarASSG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAvatarASSG";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAvatarASSG_FormClosed);
            this.Load += new System.EventHandler(this.frmAvatarASSG_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchRst)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator guna2WinProgressIndicator1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2DataGridView searchRst;
        private Guna.UI2.WinForms.Guna2GradientButton btnAssignToAV;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtAvatar;
        private Guna.UI.WinForms.GunaTransition gunaTransition1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}