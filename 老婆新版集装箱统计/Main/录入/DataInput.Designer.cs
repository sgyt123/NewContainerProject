namespace Main
{
    partial class DataInput
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataInput));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.cbInout = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dgvFindList = new System.Windows.Forms.DataGridView();
            this.dgvFindListID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFindListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFindListDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVoyage = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtOpenDate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbOpenInOut = new System.Windows.Forms.ComboBox();
            this.txtOpenTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOpen = new System.Windows.Forms.TextBox();
            this.btnOutPut = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvDataList = new System.Windows.Forms.DataGridView();
            this.ctms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyFirstContext = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lberror = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEdit = new EditButtonControl.EditButtons();
            this.txtCH = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataList)).BeginInit();
            this.ctms.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1047, 573);
            this.splitContainer1.SplitterDistance = 236;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvFindList);
            this.splitContainer2.Size = new System.Drawing.Size(236, 573);
            this.splitContainer2.SplitterDistance = 125;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.cbInout);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(106, 101);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 8;
            this.lblID.Visible = false;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblNumber.Location = new System.Drawing.Point(13, 105);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(0, 12);
            this.lblNumber.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "进 出 口:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "终止时间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "开始时间:";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(160, 73);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(70, 44);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "查询";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cbInout
            // 
            this.cbInout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInout.FormattingEnabled = true;
            this.cbInout.Items.AddRange(new object[] {
            "",
            "进口",
            "出口"});
            this.cbInout.Location = new System.Drawing.Point(73, 74);
            this.cbInout.Name = "cbInout";
            this.cbInout.Size = new System.Drawing.Size(81, 20);
            this.cbInout.TabIndex = 2;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(73, 47);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(147, 21);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(73, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(147, 21);
            this.dtpStart.TabIndex = 0;
            // 
            // dgvFindList
            // 
            this.dgvFindList.AllowUserToAddRows = false;
            this.dgvFindList.AllowUserToDeleteRows = false;
            this.dgvFindList.AllowUserToResizeRows = false;
            this.dgvFindList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFindList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFindList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFindList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvFindListID,
            this.dgvFindListName,
            this.dgvFindListDate});
            this.dgvFindList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFindList.Location = new System.Drawing.Point(0, 0);
            this.dgvFindList.MultiSelect = false;
            this.dgvFindList.Name = "dgvFindList";
            this.dgvFindList.ReadOnly = true;
            this.dgvFindList.RowHeadersVisible = false;
            this.dgvFindList.RowTemplate.Height = 23;
            this.dgvFindList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFindList.Size = new System.Drawing.Size(236, 444);
            this.dgvFindList.TabIndex = 0;
            this.dgvFindList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFindList_CellClick);
            // 
            // dgvFindListID
            // 
            this.dgvFindListID.HeaderText = "船舶ID";
            this.dgvFindListID.Name = "dgvFindListID";
            this.dgvFindListID.ReadOnly = true;
            this.dgvFindListID.Visible = false;
            // 
            // dgvFindListName
            // 
            this.dgvFindListName.HeaderText = "船舶名称/航次";
            this.dgvFindListName.Name = "dgvFindListName";
            this.dgvFindListName.ReadOnly = true;
            this.dgvFindListName.Width = 140;
            // 
            // dgvFindListDate
            // 
            this.dgvFindListDate.HeaderText = "进出日期";
            this.dgvFindListDate.Name = "dgvFindListDate";
            this.dgvFindListDate.ReadOnly = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(807, 573);
            this.splitContainer3.SplitterDistance = 67;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCH);
            this.groupBox2.Controls.Add(this.txtVoyage);
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Controls.Add(this.txtOpenDate);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.cbOpenInOut);
            this.groupBox2.Controls.Add(this.txtOpenTitle);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtOpen);
            this.groupBox2.Controls.Add(this.btnOutPut);
            this.groupBox2.Controls.Add(this.btnLoad);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 67);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtVoyage
            // 
            this.txtVoyage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtVoyage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVoyage.Location = new System.Drawing.Point(400, 38);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(125, 23);
            this.txtVoyage.TabIndex = 13;
            this.txtVoyage.Text = "航线";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(690, 43);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(0, 12);
            this.lblState.TabIndex = 11;
            // 
            // txtOpenDate
            // 
            this.txtOpenDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtOpenDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOpenDate.Location = new System.Drawing.Point(257, 38);
            this.txtOpenDate.Name = "txtOpenDate";
            this.txtOpenDate.ReadOnly = true;
            this.txtOpenDate.Size = new System.Drawing.Size(137, 23);
            this.txtOpenDate.TabIndex = 10;
            this.txtOpenDate.Text = "清单时间";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(733, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbOpenInOut
            // 
            this.cbOpenInOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbOpenInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOpenInOut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbOpenInOut.FormattingEnabled = true;
            this.cbOpenInOut.Items.AddRange(new object[] {
            "进口",
            "出口"});
            this.cbOpenInOut.Location = new System.Drawing.Point(440, 12);
            this.cbOpenInOut.Name = "cbOpenInOut";
            this.cbOpenInOut.Size = new System.Drawing.Size(86, 22);
            this.cbOpenInOut.TabIndex = 8;
            // 
            // txtOpenTitle
            // 
            this.txtOpenTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtOpenTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOpenTitle.Location = new System.Drawing.Point(79, 38);
            this.txtOpenTitle.Name = "txtOpenTitle";
            this.txtOpenTitle.ReadOnly = true;
            this.txtOpenTitle.Size = new System.Drawing.Size(175, 23);
            this.txtOpenTitle.TabIndex = 6;
            this.txtOpenTitle.Text = "选择文件后自动读取文件标题";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "清单标题:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Excel文件:";
            // 
            // txtOpen
            // 
            this.txtOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtOpen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOpen.Location = new System.Drawing.Point(79, 11);
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.ReadOnly = true;
            this.txtOpen.Size = new System.Drawing.Size(355, 23);
            this.txtOpen.TabIndex = 3;
            this.txtOpen.Text = "点击这里选择Excel文件";
            this.txtOpen.Click += new System.EventHandler(this.txtOpen_Click);
            // 
            // btnOutPut
            // 
            this.btnOutPut.Location = new System.Drawing.Point(733, 9);
            this.btnOutPut.Name = "btnOutPut";
            this.btnOutPut.Size = new System.Drawing.Size(68, 29);
            this.btnOutPut.TabIndex = 2;
            this.btnOutPut.Text = "导出";
            this.btnOutPut.UseVisualStyleBackColor = true;
            this.btnOutPut.Click += new System.EventHandler(this.btnOutPut_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(661, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(68, 53);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "导入手动清单";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvDataList);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer4.Size = new System.Drawing.Size(807, 502);
            this.splitContainer4.SplitterDistance = 445;
            this.splitContainer4.TabIndex = 1;
            // 
            // dgvDataList
            // 
            this.dgvDataList.AllowUserToAddRows = false;
            this.dgvDataList.AllowUserToDeleteRows = false;
            this.dgvDataList.AllowUserToResizeRows = false;
            this.dgvDataList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDataList.ContextMenuStrip = this.ctms;
            this.dgvDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataList.Location = new System.Drawing.Point(0, 0);
            this.dgvDataList.Name = "dgvDataList";
            this.dgvDataList.RowHeadersVisible = false;
            this.dgvDataList.RowTemplate.Height = 23;
            this.dgvDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDataList.Size = new System.Drawing.Size(807, 445);
            this.dgvDataList.TabIndex = 0;
            this.dgvDataList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDataList_CellBeginEdit);
            this.dgvDataList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataList_CellClick);
            this.dgvDataList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataList_CellContentDoubleClick);
            this.dgvDataList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataList_CellEndEdit);
            this.dgvDataList.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataList_CellLeave);
            this.dgvDataList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDataList_DataError);
            // 
            // ctms
            // 
            this.ctms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddBase,
            this.tsmiCopyFirstContext});
            this.ctms.Name = "ctms";
            this.ctms.Size = new System.Drawing.Size(155, 48);
            // 
            // tsmiAddBase
            // 
            this.tsmiAddBase.Name = "tsmiAddBase";
            this.tsmiAddBase.Size = new System.Drawing.Size(154, 22);
            this.tsmiAddBase.Text = "直接添加";
            this.tsmiAddBase.Click += new System.EventHandler(this.tsmiAddBase_Click);
            // 
            // tsmiCopyFirstContext
            // 
            this.tsmiCopyFirstContext.Name = "tsmiCopyFirstContext";
            this.tsmiCopyFirstContext.Size = new System.Drawing.Size(154, 22);
            this.tsmiCopyFirstContext.Text = "复制头一行内容";
            this.tsmiCopyFirstContext.Click += new System.EventHandler(this.tsmiCopyFirstContext_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lberror);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(807, 53);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // lberror
            // 
            this.lberror.BackColor = System.Drawing.SystemColors.Control;
            this.lberror.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lberror.ForeColor = System.Drawing.Color.Red;
            this.lberror.Location = new System.Drawing.Point(346, 28);
            this.lberror.Multiline = true;
            this.lberror.Name = "lberror";
            this.lberror.Size = new System.Drawing.Size(403, 21);
            this.lberror.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(351, 11);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(761, 18);
            this.lblTotal.TabIndex = 2;
            // 
            // btnEdit
            // 
            this.btnEdit.isTrue = false;
            this.btnEdit.Location = new System.Drawing.Point(11, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(336, 38);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.InsertClickHandleClick += new EditButtonControl.EditButtons.InsertClickHandle(this.btnEdit_InsertClickHandleClick);
            this.btnEdit.ChangeClickHandleClick += new EditButtonControl.EditButtons.ChangeClickHandle(this.btnEdit_ChangeClickHandleClick);
            this.btnEdit.SaveClickHandleClick += new EditButtonControl.EditButtons.SaveClickHandle(this.btnEdit_SaveClickHandleClick);
            this.btnEdit.CancelClickHandleClick += new EditButtonControl.EditButtons.CancelClickHandle(this.btnEdit_CancelClickHandleClick);
            this.btnEdit.DeleteClickHandleClick += new EditButtonControl.EditButtons.DeleteClickHandle(this.btnEdit_DeleteClickHandleClick);
            // 
            // txtCH
            // 
            this.txtCH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtCH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCH.Location = new System.Drawing.Point(531, 38);
            this.txtCH.Name = "txtCH";
            this.txtCH.Size = new System.Drawing.Size(125, 23);
            this.txtCH.TabIndex = 14;
            this.txtCH.Text = "船号";
            // 
            // DataInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 573);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "数据录入及查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataInput_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindList)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataList)).EndInit();
            this.ctms.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFindList;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvDataList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cbInout;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOutPut;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox3;
        private EditButtonControl.EditButtons btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbOpenInOut;
        private System.Windows.Forms.TextBox txtOpenTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOpen;
        private System.Windows.Forms.TextBox txtOpenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFindListID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFindListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFindListDate;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ContextMenuStrip ctms;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddBase;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyFirstContext;
        private System.Windows.Forms.TextBox txtVoyage;
        private System.Windows.Forms.TextBox lberror;
        private System.Windows.Forms.TextBox txtCH;
    }
}