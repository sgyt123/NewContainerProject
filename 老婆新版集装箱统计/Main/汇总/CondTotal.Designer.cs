namespace Main
{
    partial class CondTotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CondTotal));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LlblDelete = new System.Windows.Forms.LinkLabel();
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
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lbFilter2 = new System.Windows.Forms.ListBox();
            this.lbFilter1 = new System.Windows.Forms.ListBox();
            this.btnFilterDelete = new System.Windows.Forms.PictureBox();
            this.btnFilterInsert = new System.Windows.Forms.PictureBox();
            this.lblFilterError = new System.Windows.Forms.Label();
            this.btnCountOutPut = new System.Windows.Forms.Button();
            this.btnCountLook = new System.Windows.Forms.Button();
            this.dgvCountList = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.btnFilterDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFilterInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountList)).BeginInit();
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
            this.groupBox1.Controls.Add(this.LlblDelete);
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
            // LlblDelete
            // 
            this.LlblDelete.AutoSize = true;
            this.LlblDelete.LinkColor = System.Drawing.Color.Red;
            this.LlblDelete.Location = new System.Drawing.Point(213, 107);
            this.LlblDelete.Name = "LlblDelete";
            this.LlblDelete.Size = new System.Drawing.Size(29, 12);
            this.LlblDelete.TabIndex = 10;
            this.LlblDelete.TabStop = true;
            this.LlblDelete.Text = "删除";
            this.LlblDelete.Click += new System.EventHandler(this.LlblDelete_Click);
            // 
            // ckAllSelect
            // 
            this.ckAllSelect.AutoSize = true;
            this.ckAllSelect.Location = new System.Drawing.Point(155, 105);
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
            this.splitContainer3.Panel2.Controls.Add(this.dgvCountList);
            this.splitContainer3.Size = new System.Drawing.Size(726, 573);
            this.splitContainer3.SplitterDistance = 146;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 146);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(3, 17);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.lbFilter2);
            this.splitContainer4.Panel1.Controls.Add(this.lbFilter1);
            this.splitContainer4.Panel1.Controls.Add(this.btnFilterDelete);
            this.splitContainer4.Panel1.Controls.Add(this.btnFilterInsert);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.lblFilterError);
            this.splitContainer4.Panel2.Controls.Add(this.btnCountOutPut);
            this.splitContainer4.Panel2.Controls.Add(this.btnCountLook);
            this.splitContainer4.Size = new System.Drawing.Size(720, 126);
            this.splitContainer4.SplitterDistance = 368;
            this.splitContainer4.TabIndex = 0;
            // 
            // lbFilter2
            // 
            this.lbFilter2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFilter2.FormattingEnabled = true;
            this.lbFilter2.ItemHeight = 16;
            this.lbFilter2.Location = new System.Drawing.Point(212, 3);
            this.lbFilter2.Name = "lbFilter2";
            this.lbFilter2.Size = new System.Drawing.Size(143, 116);
            this.lbFilter2.TabIndex = 19;
            this.lbFilter2.DoubleClick += new System.EventHandler(this.lbFilter2_DoubleClick);
            // 
            // lbFilter1
            // 
            this.lbFilter1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFilter1.FormattingEnabled = true;
            this.lbFilter1.ItemHeight = 16;
            this.lbFilter1.Location = new System.Drawing.Point(2, 3);
            this.lbFilter1.Name = "lbFilter1";
            this.lbFilter1.Size = new System.Drawing.Size(143, 116);
            this.lbFilter1.TabIndex = 18;
            this.lbFilter1.DoubleClick += new System.EventHandler(this.lbFilter1_DoubleClick);
            // 
            // btnFilterDelete
            // 
            this.btnFilterDelete.Image = global::Main.Properties.Resources.backward;
            this.btnFilterDelete.Location = new System.Drawing.Point(151, 66);
            this.btnFilterDelete.Name = "btnFilterDelete";
            this.btnFilterDelete.Size = new System.Drawing.Size(50, 50);
            this.btnFilterDelete.TabIndex = 17;
            this.btnFilterDelete.TabStop = false;
            this.btnFilterDelete.Click += new System.EventHandler(this.lbFilter2_DoubleClick);
            // 
            // btnFilterInsert
            // 
            this.btnFilterInsert.Image = global::Main.Properties.Resources.forward;
            this.btnFilterInsert.Location = new System.Drawing.Point(151, 10);
            this.btnFilterInsert.Name = "btnFilterInsert";
            this.btnFilterInsert.Size = new System.Drawing.Size(50, 50);
            this.btnFilterInsert.TabIndex = 16;
            this.btnFilterInsert.TabStop = false;
            this.btnFilterInsert.Click += new System.EventHandler(this.lbFilter1_DoubleClick);
            this.btnFilterInsert.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnFilterInsert_MouseDown);
            this.btnFilterInsert.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFilterInsert_MouseUp);
            // 
            // lblFilterError
            // 
            this.lblFilterError.AutoSize = true;
            this.lblFilterError.Location = new System.Drawing.Point(13, 103);
            this.lblFilterError.Name = "lblFilterError";
            this.lblFilterError.Size = new System.Drawing.Size(0, 12);
            this.lblFilterError.TabIndex = 2;
            // 
            // btnCountOutPut
            // 
            this.btnCountOutPut.Location = new System.Drawing.Point(107, 30);
            this.btnCountOutPut.Name = "btnCountOutPut";
            this.btnCountOutPut.Size = new System.Drawing.Size(88, 42);
            this.btnCountOutPut.TabIndex = 1;
            this.btnCountOutPut.Text = "导出到Excel";
            this.btnCountOutPut.UseVisualStyleBackColor = true;
            this.btnCountOutPut.Click += new System.EventHandler(this.btnCountOutPut_Click);
            // 
            // btnCountLook
            // 
            this.btnCountLook.Location = new System.Drawing.Point(13, 30);
            this.btnCountLook.Name = "btnCountLook";
            this.btnCountLook.Size = new System.Drawing.Size(88, 42);
            this.btnCountLook.TabIndex = 0;
            this.btnCountLook.Text = "汇总查询";
            this.btnCountLook.UseVisualStyleBackColor = true;
            this.btnCountLook.Click += new System.EventHandler(this.btnCountLook_Click);
            // 
            // dgvCountList
            // 
            this.dgvCountList.AllowUserToAddRows = false;
            this.dgvCountList.AllowUserToDeleteRows = false;
            this.dgvCountList.BackgroundColor = System.Drawing.Color.White;
            this.dgvCountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCountList.Location = new System.Drawing.Point(0, 0);
            this.dgvCountList.Name = "dgvCountList";
            this.dgvCountList.ReadOnly = true;
            this.dgvCountList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvCountList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCountList.RowTemplate.Height = 23;
            this.dgvCountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCountList.Size = new System.Drawing.Size(726, 423);
            this.dgvCountList.TabIndex = 0;
            this.dgvCountList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountList_CellContentClick);
            // 
            // CondTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 573);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CondTotal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "条件汇总";
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
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnFilterDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFilterInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountList)).EndInit();
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
        private System.Windows.Forms.LinkLabel LlblDelete;
        private System.Windows.Forms.CheckBox ckAllSelect;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCountList;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListBox lbFilter2;
        private System.Windows.Forms.ListBox lbFilter1;
        private System.Windows.Forms.PictureBox btnFilterDelete;
        private System.Windows.Forms.PictureBox btnFilterInsert;
        private System.Windows.Forms.Button btnCountOutPut;
        private System.Windows.Forms.Button btnCountLook;
        private System.Windows.Forms.Label lblFilterError;
    }
}