namespace MuzCatalogr
{
    partial class HOLO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOLO));
            this.fbrDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.nUD_tracks = new System.Windows.Forms.NumericUpDown();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nUD_MaxMean = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nUD_MaxMax = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nUD_MaxThr = new System.Windows.Forms.NumericUpDown();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dGV_pls = new System.Windows.Forms.DataGridView();
            this.dGV_tgt = new System.Windows.Forms.DataGridView();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.dg_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbl_sec_tot = new System.Windows.Forms.Label();
            this.lbl_sec_snap = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nUD4 = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PB1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.nUD3 = new System.Windows.Forms.NumericUpDown();
            this.nUD2 = new System.Windows.Forms.NumericUpDown();
            this.nUD = new System.Windows.Forms.NumericUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.clbFeatures = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFilterTracks = new System.Windows.Forms.TextBox();
            this.cbEnableFilter = new System.Windows.Forms.CheckBox();
            this.button8 = new System.Windows.Forms.Button();
            this.cbOrderBy = new System.Windows.Forms.CheckBox();
            this.button9 = new System.Windows.Forms.Button();
            this.clbStatnames = new System.Windows.Forms.CheckedListBox();
            this.cbOverStats = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_tracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxMean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxThr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_pls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_tgt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fbrDlg
            // 
            this.fbrDlg.Description = "Locate root folder to gather snaps DB";
            this.fbrDlg.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbrDlg.ShowNewFolderButton = false;
            this.fbrDlg.HelpRequest += new System.EventHandler(this.fbrDlg_HelpRequest);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1187, 430);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.cbOverStats);
            this.tabPage2.Controls.Add(this.clbStatnames);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.cbOrderBy);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.cbEnableFilter);
            this.tabPage2.Controls.Add(this.tbFilterTracks);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.nUD_tracks);
            this.tabPage2.Controls.Add(this.lblMsg);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.nUD_MaxMean);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.nUD_MaxMax);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.nUD_MaxThr);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.dGV_pls);
            this.tabPage2.Controls.Add(this.dGV_tgt);
            this.tabPage2.Controls.Add(this.dGV);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1179, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create playlist";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1004, 357);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Limit playlist to:";
            // 
            // nUD_tracks
            // 
            this.nUD_tracks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nUD_tracks.Location = new System.Drawing.Point(1087, 355);
            this.nUD_tracks.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_tracks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_tracks.Name = "nUD_tracks";
            this.nUD_tracks.Size = new System.Drawing.Size(86, 20);
            this.nUD_tracks.TabIndex = 15;
            this.nUD_tracks.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.LightSalmon;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMsg.Location = new System.Drawing.Point(270, 170);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(680, 51);
            this.lblMsg.TabIndex = 14;
            this.lblMsg.Text = "Please wait for request processing";
            this.lblMsg.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(965, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Max mean distance, %:";
            // 
            // nUD_MaxMean
            // 
            this.nUD_MaxMean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nUD_MaxMean.Location = new System.Drawing.Point(1087, 329);
            this.nUD_MaxMean.Name = "nUD_MaxMean";
            this.nUD_MaxMean.Size = new System.Drawing.Size(86, 20);
            this.nUD_MaxMean.TabIndex = 12;
            this.nUD_MaxMean.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(972, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Max max distance, %:";
            // 
            // nUD_MaxMax
            // 
            this.nUD_MaxMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nUD_MaxMax.Location = new System.Drawing.Point(1087, 303);
            this.nUD_MaxMax.Name = "nUD_MaxMax";
            this.nUD_MaxMax.Size = new System.Drawing.Size(86, 20);
            this.nUD_MaxMax.TabIndex = 10;
            this.nUD_MaxMax.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(915, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Filter by threshold (at your risk), %:";
            // 
            // nUD_MaxThr
            // 
            this.nUD_MaxThr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nUD_MaxThr.Location = new System.Drawing.Point(1087, 274);
            this.nUD_MaxThr.Name = "nUD_MaxThr";
            this.nUD_MaxThr.Size = new System.Drawing.Size(86, 20);
            this.nUD_MaxThr.TabIndex = 8;
            this.nUD_MaxThr.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.Location = new System.Drawing.Point(593, 144);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(116, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Clear target tracks";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "Open whole database";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.Chocolate;
            this.button4.Location = new System.Drawing.Point(838, 222);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Save and open playlist";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.ForestGreen;
            this.button2.Location = new System.Drawing.Point(715, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Calculate playlist";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dGV_pls
            // 
            this.dGV_pls.AllowUserToAddRows = false;
            this.dGV_pls.AllowUserToDeleteRows = false;
            this.dGV_pls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV_pls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_pls.Location = new System.Drawing.Point(715, 6);
            this.dGV_pls.Name = "dGV_pls";
            this.dGV_pls.ReadOnly = true;
            this.dGV_pls.Size = new System.Drawing.Size(458, 210);
            this.dGV_pls.TabIndex = 3;
            this.dGV_pls.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_pls_CellContentDoubleClick);
            // 
            // dGV_tgt
            // 
            this.dGV_tgt.AllowUserToAddRows = false;
            this.dGV_tgt.AllowUserToDeleteRows = false;
            this.dGV_tgt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dGV_tgt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_tgt.Location = new System.Drawing.Point(6, 173);
            this.dGV_tgt.Name = "dGV_tgt";
            this.dGV_tgt.ReadOnly = true;
            this.dGV_tgt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_tgt.Size = new System.Drawing.Size(703, 225);
            this.dGV_tgt.TabIndex = 2;
            this.dGV_tgt.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_tgt_CellContentDoubleClick);
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dg_id,
            this.dg_Name,
            this.dg_Path});
            this.dGV.Location = new System.Drawing.Point(6, 33);
            this.dGV.Name = "dGV";
            this.dGV.ReadOnly = true;
            this.dGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV.Size = new System.Drawing.Size(703, 105);
            this.dGV.TabIndex = 1;
            this.dGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentDoubleClick);
            // 
            // dg_id
            // 
            this.dg_id.HeaderText = "id";
            this.dg_id.Name = "dg_id";
            this.dg_id.ReadOnly = true;
            // 
            // dg_Name
            // 
            this.dg_Name.HeaderText = "Name";
            this.dg_Name.Name = "dg_Name";
            this.dg_Name.ReadOnly = true;
            // 
            // dg_Path
            // 
            this.dg_Path.HeaderText = "Path";
            this.dg_Path.Name = "dg_Path";
            this.dg_Path.ReadOnly = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.button12);
            this.tabPage1.Controls.Add(this.lbl_sec_tot);
            this.tabPage1.Controls.Add(this.lbl_sec_snap);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nUD4);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.PB1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.nUD3);
            this.tabPage1.Controls.Add(this.nUD2);
            this.tabPage1.Controls.Add(this.nUD);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1179, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create database";
            // 
            // lbl_sec_tot
            // 
            this.lbl_sec_tot.AutoSize = true;
            this.lbl_sec_tot.Location = new System.Drawing.Point(82, 231);
            this.lbl_sec_tot.Name = "lbl_sec_tot";
            this.lbl_sec_tot.Size = new System.Drawing.Size(13, 13);
            this.lbl_sec_tot.TabIndex = 47;
            this.lbl_sec_tot.Text = "0";
            // 
            // lbl_sec_snap
            // 
            this.lbl_sec_snap.AutoSize = true;
            this.lbl_sec_snap.Location = new System.Drawing.Point(82, 218);
            this.lbl_sec_snap.Name = "lbl_sec_snap";
            this.lbl_sec_snap.Size = new System.Drawing.Size(13, 13);
            this.lbl_sec_snap.TabIndex = 46;
            this.lbl_sec_snap.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Total seconds:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Snap dowscale factor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Snap time, s:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Smoothing size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Snap size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Count of snaps";
            // 
            // nUD4
            // 
            this.nUD4.Location = new System.Drawing.Point(11, 156);
            this.nUD4.Maximum = new decimal(new int[] {
            6553600,
            0,
            0,
            0});
            this.nUD4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD4.Name = "nUD4";
            this.nUD4.Size = new System.Drawing.Size(107, 20);
            this.nUD4.TabIndex = 38;
            this.nUD4.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(600, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 23);
            this.button5.TabIndex = 33;
            this.button5.Text = "Locate dir";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(470, 20);
            this.textBox1.TabIndex = 32;
            this.textBox1.Text = "E:\\music\\";
            // 
            // PB1
            // 
            this.PB1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB1.Location = new System.Drawing.Point(124, 248);
            this.PB1.Name = "PB1";
            this.PB1.Size = new System.Drawing.Size(1049, 23);
            this.PB1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PB1.TabIndex = 30;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 47);
            this.button3.TabIndex = 29;
            this.button3.Text = "Gather stats";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // nUD3
            // 
            this.nUD3.Location = new System.Drawing.Point(11, 195);
            this.nUD3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD3.Name = "nUD3";
            this.nUD3.Size = new System.Drawing.Size(107, 20);
            this.nUD3.TabIndex = 27;
            this.nUD3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nUD2
            // 
            this.nUD2.Location = new System.Drawing.Point(11, 110);
            this.nUD2.Maximum = new decimal(new int[] {
            6553600,
            0,
            0,
            0});
            this.nUD2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUD2.Name = "nUD2";
            this.nUD2.Size = new System.Drawing.Size(107, 20);
            this.nUD2.TabIndex = 26;
            this.nUD2.Value = new decimal(new int[] {
            96000,
            0,
            0,
            0});
            this.nUD2.ValueChanged += new System.EventHandler(this.nUD2_ValueChanged);
            // 
            // nUD
            // 
            this.nUD.Location = new System.Drawing.Point(11, 71);
            this.nUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD.Name = "nUD";
            this.nUD.Size = new System.Drawing.Size(107, 20);
            this.nUD.TabIndex = 25;
            this.nUD.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nUD.ValueChanged += new System.EventHandler(this.nUD_ValueChanged);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(124, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(1049, 212);
            this.listBox1.TabIndex = 24;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.clbFeatures);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.tbDBName);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1179, 404);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // clbFeatures
            // 
            this.clbFeatures.FormattingEnabled = true;
            this.clbFeatures.Location = new System.Drawing.Point(9, 45);
            this.clbFeatures.Name = "clbFeatures";
            this.clbFeatures.Size = new System.Drawing.Size(546, 244);
            this.clbFeatures.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbDBName
            // 
            this.tbDBName.Location = new System.Drawing.Point(99, 19);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(348, 20);
            this.tbDBName.TabIndex = 1;
            this.tbDBName.Text = "test.db";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Active database:";
            // 
            // tbFilterTracks
            // 
            this.tbFilterTracks.Location = new System.Drawing.Point(258, 6);
            this.tbFilterTracks.Name = "tbFilterTracks";
            this.tbFilterTracks.Size = new System.Drawing.Size(353, 20);
            this.tbFilterTracks.TabIndex = 18;
            // 
            // cbEnableFilter
            // 
            this.cbEnableFilter.AutoSize = true;
            this.cbEnableFilter.Location = new System.Drawing.Point(143, 10);
            this.cbEnableFilter.Name = "cbEnableFilter";
            this.cbEnableFilter.Size = new System.Drawing.Size(109, 17);
            this.cbEnableFilter.TabIndex = 19;
            this.cbEnableFilter.Text = "Apply search filter";
            this.cbEnableFilter.UseVisualStyleBackColor = true;
            this.cbEnableFilter.CheckedChanged += new System.EventHandler(this.cbEnableFilter_CheckedChanged);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(617, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(92, 23);
            this.button8.TabIndex = 20;
            this.button8.Text = "Update search";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // cbOrderBy
            // 
            this.cbOrderBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOrderBy.AutoSize = true;
            this.cbOrderBy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbOrderBy.Checked = true;
            this.cbOrderBy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOrderBy.Location = new System.Drawing.Point(1030, 381);
            this.cbOrderBy.Name = "cbOrderBy";
            this.cbOrderBy.Size = new System.Drawing.Size(143, 17);
            this.cbOrderBy.TabIndex = 21;
            this.cbOrderBy.Text = "Use ordering by distance";
            this.cbOrderBy.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.Location = new System.Drawing.Point(1039, 222);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(134, 23);
            this.button9.TabIndex = 22;
            this.button9.Text = "Open last saved playlist";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // clbStatnames
            // 
            this.clbStatnames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clbStatnames.CheckOnClick = true;
            this.clbStatnames.Enabled = false;
            this.clbStatnames.FormattingEnabled = true;
            this.clbStatnames.Items.AddRange(new object[] {
            "Mean",
            "Median",
            "St.dev.",
            "Skewness",
            "Kurtosis"});
            this.clbStatnames.Location = new System.Drawing.Point(715, 319);
            this.clbStatnames.Name = "clbStatnames";
            this.clbStatnames.Size = new System.Drawing.Size(116, 79);
            this.clbStatnames.TabIndex = 23;
            // 
            // cbOverStats
            // 
            this.cbOverStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbOverStats.AutoSize = true;
            this.cbOverStats.Location = new System.Drawing.Point(716, 296);
            this.cbOverStats.Name = "cbOverStats";
            this.cbOverStats.Size = new System.Drawing.Size(144, 17);
            this.cbOverStats.TabIndex = 24;
            this.cbOverStats.Text = "Override default statistics";
            this.cbOverStats.UseVisualStyleBackColor = true;
            this.cbOverStats.CheckedChanged += new System.EventHandler(this.cbOverStats_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.button11);
            this.tabPage4.Controls.Add(this.button10);
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1179, 404);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Startup";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::HOLO.Properties.Resources.holo_logo;
            this.pictureBox1.Location = new System.Drawing.Point(661, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 107);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(136, 23);
            this.button10.TabIndex = 1;
            this.button10.Text = "Go to create playlist";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 136);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(136, 23);
            this.button11.TabIndex = 2;
            this.button11.Text = "Go to create database";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(6, 248);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(112, 23);
            this.button12.TabIndex = 48;
            this.button12.Text = "Postprocess DB";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // HOLO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 454);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HOLO";
            this.Text = "HOLO - The Music Amalgamation System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_tracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxMean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MaxThr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_pls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_tgt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbrDlg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown nUD4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar PB1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown nUD3;
        private System.Windows.Forms.NumericUpDown nUD2;
        private System.Windows.Forms.NumericUpDown nUD;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbl_sec_tot;
        private System.Windows.Forms.Label lbl_sec_snap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_Path;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbDBName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dGV_tgt;
        private System.Windows.Forms.DataGridView dGV_pls;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckedListBox clbFeatures;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nUD_MaxThr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nUD_MaxMean;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nUD_MaxMax;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nUD_tracks;
        private System.Windows.Forms.CheckBox cbEnableFilter;
        private System.Windows.Forms.TextBox tbFilterTracks;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox cbOrderBy;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.CheckBox cbOverStats;
        private System.Windows.Forms.CheckedListBox clbStatnames;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button12;
    }
}

