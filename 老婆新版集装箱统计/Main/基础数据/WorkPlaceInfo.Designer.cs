namespace Main
{
    partial class WorkPlaceInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkPlaceInfo));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.dgvBaseList = new System.Windows.Forms.DataGridView();
            this.dgvBaseListCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBaseListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBaseListID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblError = new System.Windows.Forms.Label();
            this.btnEdit = new EditButtonControl.EditButtons();
            this.dgvShipInfo = new System.Windows.Forms.DataGridView();
            this.dgvShipListID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvShipListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvShipListDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.dgvShipInfo);
            this.splitContainer1.Size = new System.Drawing.Size(792, 573);
            this.splitContainer1.SplitterDistance = 484;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnOut);
            this.splitContainer2.Panel1.Controls.Add(this.btnIn);
            this.splitContainer2.Panel1.Controls.Add(this.btnFind);
            this.splitContainer2.Panel1.Controls.Add(this.btnCheck);
            this.splitContainer2.Panel1.Controls.Add(this.dgvBaseList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblError);
            this.splitContainer2.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer2.Size = new System.Drawing.Size(484, 573);
            this.splitContainer2.SplitterDistance = 505;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(396, 192);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 46);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "查询>>";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(397, 126);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 46);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "<<校验";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // dgvBaseList
            // 
            this.dgvBaseList.AllowUserToAddRows = false;
            this.dgvBaseList.AllowUserToDeleteRows = false;
            this.dgvBaseList.AllowUserToResizeRows = false;
            this.dgvBaseList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvBaseListCode,
            this.dgvBaseListName,
            this.dgvBaseListID});
            this.dgvBaseList.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvBaseList.Location = new System.Drawing.Point(0, 0);
            this.dgvBaseList.Name = "dgvBaseList";
            this.dgvBaseList.RowHeadersVisible = false;
            this.dgvBaseList.RowTemplate.Height = 23;
            this.dgvBaseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaseList.Size = new System.Drawing.Size(390, 505);
            this.dgvBaseList.TabIndex = 0;
            // 
            // dgvBaseListCode
            // 
            this.dgvBaseListCode.HeaderText = "编码";
            this.dgvBaseListCode.Name = "dgvBaseListCode";
            // 
            // dgvBaseListName
            // 
            this.dgvBaseListName.HeaderText = "名称";
            this.dgvBaseListName.Name = "dgvBaseListName";
            this.dgvBaseListName.Width = 150;
            // 
            // dgvBaseListID
            // 
            this.dgvBaseListID.HeaderText = "ID";
            this.dgvBaseListID.Name = "dgvBaseListID";
            this.dgvBaseListID.Visible = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(9, 46);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 12);
            this.lblError.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.isTrue = false;
            this.btnEdit.Location = new System.Drawing.Point(23, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(336, 38);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.InsertClickHandleClick += new EditButtonControl.EditButtons.InsertClickHandle(this.btnEdit_InsertClickHandleClick);
            this.btnEdit.ChangeClickHandleClick += new EditButtonControl.EditButtons.ChangeClickHandle(this.btnEdit_ChangeClickHandleClick);
            this.btnEdit.SaveClickHandleClick += new EditButtonControl.EditButtons.SaveClickHandle(this.btnEdit_SaveClickHandleClick);
            this.btnEdit.CancelClickHandleClick += new EditButtonControl.EditButtons.CancelClickHandle(this.btnEdit_CancelClickHandleClick);
            this.btnEdit.DeleteClickHandleClick += new EditButtonControl.EditButtons.DeleteClickHandle(this.btnEdit_DeleteClickHandleClick);
            // 
            // dgvShipInfo
            // 
            this.dgvShipInfo.AllowUserToAddRows = false;
            this.dgvShipInfo.AllowUserToDeleteRows = false;
            this.dgvShipInfo.AllowUserToResizeRows = false;
            this.dgvShipInfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShipInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShipInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvShipListID,
            this.dgvShipListName,
            this.dgvShipListDate});
            this.dgvShipInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvShipInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShipInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvShipInfo.Name = "dgvShipInfo";
            this.dgvShipInfo.ReadOnly = true;
            this.dgvShipInfo.RowHeadersVisible = false;
            this.dgvShipInfo.RowTemplate.Height = 23;
            this.dgvShipInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShipInfo.Size = new System.Drawing.Size(304, 573);
            this.dgvShipInfo.TabIndex = 0;
            // 
            // dgvShipListID
            // 
            this.dgvShipListID.HeaderText = "ID";
            this.dgvShipListID.Name = "dgvShipListID";
            this.dgvShipListID.ReadOnly = true;
            this.dgvShipListID.Visible = false;
            // 
            // dgvShipListName
            // 
            this.dgvShipListName.HeaderText = "船舶名称";
            this.dgvShipListName.Name = "dgvShipListName";
            this.dgvShipListName.ReadOnly = true;
            this.dgvShipListName.Width = 150;
            // 
            // dgvShipListDate
            // 
            this.dgvShipListDate.HeaderText = "出入日期";
            this.dgvShipListDate.Name = "dgvShipListDate";
            this.dgvShipListDate.ReadOnly = true;
            this.dgvShipListDate.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSearch});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // tsmiSearch
            // 
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.Size = new System.Drawing.Size(98, 22);
            this.tsmiSearch.Text = "查询";
            this.tsmiSearch.Click += new System.EventHandler(this.tsmiSearch_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(396, 428);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 46);
            this.btnOut.TabIndex = 8;
            this.btnOut.Text = "导出数据";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(396, 376);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 46);
            this.btnIn.TabIndex = 7;
            this.btnIn.Text = "导入数据";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // WorkPlaceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkPlaceInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "工作地点信息管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.this_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvBaseList;
        private EditButtonControl.EditButtons btnEdit;
        private System.Windows.Forms.DataGridView dgvShipInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvShipListID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvShipListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvShipListDate;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBaseListCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBaseListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBaseListID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnIn;
    }
}