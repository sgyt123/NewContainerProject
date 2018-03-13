namespace Main
{
    partial class SearchInfomation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchInfomation));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckAllSelect = new System.Windows.Forms.CheckBox();
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
            this.dgvFindListCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvFindListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFindListDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExcelOutPut = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvSearchList = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchList)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(992, 573);
            this.splitContainer1.SplitterDistance = 262;
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
            this.splitContainer2.Size = new System.Drawing.Size(262, 573);
            this.splitContainer2.SplitterDistance = 125;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckAllSelect);
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
            this.groupBox1.Size = new System.Drawing.Size(262, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ckAllSelect
            // 
            this.ckAllSelect.AutoSize = true;
            this.ckAllSelect.Location = new System.Drawing.Point(203, 105);
            this.ckAllSelect.Name = "ckAllSelect";
            this.ckAllSelect.Size = new System.Drawing.Size(48, 16);
            this.ckAllSelect.TabIndex = 9;
            this.ckAllSelect.Text = "全选";
            this.ckAllSelect.UseVisualStyleBackColor = true;
            this.ckAllSelect.Click += new System.EventHandler(this.ckAllSelect_Click);
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
            this.btnFind.Size = new System.Drawing.Size(70, 21);
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
            this.dgvFindListCheck,
            this.dgvFindListName,
            this.dgvFindListDate});
            this.dgvFindList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFindList.Location = new System.Drawing.Point(0, 0);
            this.dgvFindList.MultiSelect = false;
            this.dgvFindList.Name = "dgvFindList";
            this.dgvFindList.RowHeadersVisible = false;
            this.dgvFindList.RowTemplate.Height = 23;
            this.dgvFindList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFindList.Size = new System.Drawing.Size(262, 444);
            this.dgvFindList.TabIndex = 0;
            // 
            // dgvFindListID
            // 
            this.dgvFindListID.HeaderText = "船舶ID";
            this.dgvFindListID.Name = "dgvFindListID";
            this.dgvFindListID.Visible = false;
            // 
            // dgvFindListCheck
            // 
            this.dgvFindListCheck.HeaderText = "";
            this.dgvFindListCheck.Name = "dgvFindListCheck";
            this.dgvFindListCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFindListCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvFindListCheck.Width = 20;
            // 
            // dgvFindListName
            // 
            this.dgvFindListName.HeaderText = "船舶名称/航次";
            this.dgvFindListName.Name = "dgvFindListName";
            this.dgvFindListName.Width = 140;
            // 
            // dgvFindListDate
            // 
            this.dgvFindListDate.HeaderText = "进出日期";
            this.dgvFindListDate.Name = "dgvFindListDate";
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
            this.splitContainer3.Panel2.Controls.Add(this.dgvSearchList);
            this.splitContainer3.Size = new System.Drawing.Size(726, 573);
            this.splitContainer3.SplitterDistance = 68;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExcelOutPut);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 68);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // ExcelOutPut
            // 
            this.ExcelOutPut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExcelOutPut.Location = new System.Drawing.Point(107, 12);
            this.ExcelOutPut.Name = "ExcelOutPut";
            this.ExcelOutPut.Size = new System.Drawing.Size(95, 50);
            this.ExcelOutPut.TabIndex = 6;
            this.ExcelOutPut.Text = "结果输出";
            this.ExcelOutPut.UseVisualStyleBackColor = true;
            this.ExcelOutPut.Click += new System.EventHandler(this.ExcelOutPut_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(6, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 50);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "开始查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnGoodsType_Click);
            // 
            // dgvSearchList
            // 
            this.dgvSearchList.AllowUserToAddRows = false;
            this.dgvSearchList.AllowUserToDeleteRows = false;
            this.dgvSearchList.BackgroundColor = System.Drawing.Color.White;
            this.dgvSearchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearchList.Location = new System.Drawing.Point(0, 0);
            this.dgvSearchList.Name = "dgvSearchList";
            this.dgvSearchList.ReadOnly = true;
            this.dgvSearchList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvSearchList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSearchList.RowTemplate.Height = 23;
            this.dgvSearchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSearchList.Size = new System.Drawing.Size(726, 501);
            this.dgvSearchList.TabIndex = 0;
            this.dgvSearchList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountList_CellContentClick);
            // 
            // SearchInfomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 573);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchInfomation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.this_FormClosed);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cbInout;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DataGridView dgvFindList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFindListID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvFindListCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFindListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFindListDate;
        private System.Windows.Forms.CheckBox ckAllSelect;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSearchList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button ExcelOutPut;
    }
}