namespace Main
{
    partial class SystemMenu
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslError = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblError = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnToInput = new System.Windows.Forms.Button();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.btnOpenSystemMenu = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslError,
            this.lblError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(966, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslError
            // 
            this.tsslError.ForeColor = System.Drawing.Color.Red;
            this.tsslError.Name = "tsslError";
            this.tsslError.Size = new System.Drawing.Size(0, 17);
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvList);
            this.splitContainer1.Size = new System.Drawing.Size(966, 495);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.btnToInput);
            this.groupBox1.Controls.Add(this.btnToExcel);
            this.groupBox1.Controls.Add(this.btnOpenSystemMenu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 495);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(13, 92);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(124, 36);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "校验内容";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnToInput
            // 
            this.btnToInput.Location = new System.Drawing.Point(13, 214);
            this.btnToInput.Name = "btnToInput";
            this.btnToInput.Size = new System.Drawing.Size(124, 36);
            this.btnToInput.TabIndex = 2;
            this.btnToInput.Text = "导出清单到录入";
            this.btnToInput.UseVisualStyleBackColor = true;
            // 
            // btnToExcel
            // 
            this.btnToExcel.Location = new System.Drawing.Point(13, 172);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(124, 36);
            this.btnToExcel.TabIndex = 1;
            this.btnToExcel.Text = "导出清单到Excel";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnOpenSystemMenu
            // 
            this.btnOpenSystemMenu.Location = new System.Drawing.Point(13, 20);
            this.btnOpenSystemMenu.Name = "btnOpenSystemMenu";
            this.btnOpenSystemMenu.Size = new System.Drawing.Size(124, 36);
            this.btnOpenSystemMenu.TabIndex = 0;
            this.btnOpenSystemMenu.Text = "导入清单";
            this.btnOpenSystemMenu.UseVisualStyleBackColor = true;
            this.btnOpenSystemMenu.Click += new System.EventHandler(this.btnOpenSystemMenu_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(812, 495);
            this.dgvList.TabIndex = 0;
            // 
            // SystemMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 517);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "SystemMenu";
            this.Text = "系统清单管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SystemMenu_FormClosed);
            this.Load += new System.EventHandler(this.SystemMenu_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslError;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnToInput;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.Button btnOpenSystemMenu;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ToolStripStatusLabel lblError;
        private System.Windows.Forms.Button btnCheck;
    }
}