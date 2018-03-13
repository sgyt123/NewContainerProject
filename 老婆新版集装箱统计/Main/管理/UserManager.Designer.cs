namespace Main
{
    partial class UserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManager));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.lblError = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new EditButtonControl.EditButtons();
            this.txtLoginPwd = new myTextBoxControl.myTextBox();
            this.txtLoginUser = new myTextBoxControl.myTextBox();
            this.txtUser = new myTextBoxControl.myTextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.dgvUserListID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUserListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUserListLoginUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUserListLoginPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUserListPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblID);
            this.splitContainer1.Panel2.Controls.Add(this.lblError);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.txtLoginPwd);
            this.splitContainer1.Panel2.Controls.Add(this.txtLoginUser);
            this.splitContainer1.Panel2.Controls.Add(this.txtUser);
            this.splitContainer1.Size = new System.Drawing.Size(436, 390);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUserList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgvUserList
            // 
            this.dgvUserList.AllowUserToAddRows = false;
            this.dgvUserList.AllowUserToDeleteRows = false;
            this.dgvUserList.AllowUserToResizeRows = false;
            this.dgvUserList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvUserListID,
            this.dgvUserListName,
            this.dgvUserListLoginUser,
            this.dgvUserListLoginPwd,
            this.dgvUserListPass});
            this.dgvUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserList.Location = new System.Drawing.Point(3, 17);
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.ReadOnly = true;
            this.dgvUserList.RowHeadersVisible = false;
            this.dgvUserList.RowTemplate.Height = 23;
            this.dgvUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserList.Size = new System.Drawing.Size(430, 232);
            this.dgvUserList.TabIndex = 0;
            this.dgvUserList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserList_CellClick);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(13, 112);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 12);
            this.lblError.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "初始密码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "登录名称:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "用户姓名:";
            // 
            // btnEdit
            // 
            this.btnEdit.isTrue = false;
            this.btnEdit.Location = new System.Drawing.Point(49, 67);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(336, 38);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.InsertClickHandleClick += new EditButtonControl.EditButtons.InsertClickHandle(this.btnEdit_InsertClickHandleClick);
            this.btnEdit.ChangeClickHandleClick += new EditButtonControl.EditButtons.ChangeClickHandle(this.btnEdit_ChangeClickHandleClick);
            this.btnEdit.SaveClickHandleClick += new EditButtonControl.EditButtons.SaveClickHandle(this.btnEdit_SaveClickHandleClick);
            this.btnEdit.CancelClickHandleClick += new EditButtonControl.EditButtons.CancelClickHandle(this.btnEdit_CancelClickHandleClick);
            this.btnEdit.DeleteClickHandleClick += new EditButtonControl.EditButtons.DeleteClickHandle(this.btnEdit_DeleteClickHandleClick);
            // 
            // txtLoginPwd
            // 
            this.txtLoginPwd.Demo = "请输入密码";
            this.txtLoginPwd.Font_My = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginPwd.IsDigt = false;
            this.txtLoginPwd.IsIp = false;
            this.txtLoginPwd.IsLetter = false;
            this.txtLoginPwd.IsSpeace = false;
            this.txtLoginPwd.IsTrue = false;
            this.txtLoginPwd.Location = new System.Drawing.Point(77, 38);
            this.txtLoginPwd.MaxLenght = 20;
            this.txtLoginPwd.Name = "txtLoginPwd";
            this.txtLoginPwd.PassWord = '*';
            this.txtLoginPwd.Size = new System.Drawing.Size(139, 23);
            this.txtLoginPwd.TabIndex = 2;
            this.txtLoginPwd.Text_My = "";
            // 
            // txtLoginUser
            // 
            this.txtLoginUser.Demo = "请输入登录名";
            this.txtLoginUser.Font_My = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginUser.IsDigt = false;
            this.txtLoginUser.IsIp = false;
            this.txtLoginUser.IsLetter = false;
            this.txtLoginUser.IsSpeace = false;
            this.txtLoginUser.IsTrue = false;
            this.txtLoginUser.Location = new System.Drawing.Point(285, 14);
            this.txtLoginUser.MaxLenght = 20;
            this.txtLoginUser.Name = "txtLoginUser";
            this.txtLoginUser.PassWord = '\0';
            this.txtLoginUser.Size = new System.Drawing.Size(139, 23);
            this.txtLoginUser.TabIndex = 1;
            this.txtLoginUser.Text_My = "";
            // 
            // txtUser
            // 
            this.txtUser.Demo = "请输入用户姓名";
            this.txtUser.Font_My = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUser.IsDigt = false;
            this.txtUser.IsIp = false;
            this.txtUser.IsLetter = false;
            this.txtUser.IsSpeace = false;
            this.txtUser.IsTrue = false;
            this.txtUser.Location = new System.Drawing.Point(77, 14);
            this.txtUser.MaxLenght = 20;
            this.txtUser.Name = "txtUser";
            this.txtUser.PassWord = '\0';
            this.txtUser.Size = new System.Drawing.Size(139, 23);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text_My = "";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(345, 43);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 12);
            this.lblID.TabIndex = 8;
            this.lblID.Visible = false;
            // 
            // dgvUserListID
            // 
            this.dgvUserListID.HeaderText = "用户ID";
            this.dgvUserListID.Name = "dgvUserListID";
            this.dgvUserListID.ReadOnly = true;
            this.dgvUserListID.Visible = false;
            this.dgvUserListID.Width = 10;
            // 
            // dgvUserListName
            // 
            this.dgvUserListName.HeaderText = "用户姓名";
            this.dgvUserListName.Name = "dgvUserListName";
            this.dgvUserListName.ReadOnly = true;
            this.dgvUserListName.Width = 130;
            // 
            // dgvUserListLoginUser
            // 
            this.dgvUserListLoginUser.HeaderText = "登录用户名";
            this.dgvUserListLoginUser.Name = "dgvUserListLoginUser";
            this.dgvUserListLoginUser.ReadOnly = true;
            this.dgvUserListLoginUser.Width = 140;
            // 
            // dgvUserListLoginPwd
            // 
            this.dgvUserListLoginPwd.HeaderText = "登录密码";
            this.dgvUserListLoginPwd.Name = "dgvUserListLoginPwd";
            this.dgvUserListLoginPwd.ReadOnly = true;
            this.dgvUserListLoginPwd.Visible = false;
            // 
            // dgvUserListPass
            // 
            this.dgvUserListPass.HeaderText = "登录密码";
            this.dgvUserListPass.Name = "dgvUserListPass";
            this.dgvUserListPass.ReadOnly = true;
            // 
            // UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 390);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "用户管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.this_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUserList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private EditButtonControl.EditButtons btnEdit;
        private myTextBoxControl.myTextBox txtLoginPwd;
        private myTextBoxControl.myTextBox txtLoginUser;
        private myTextBoxControl.myTextBox txtUser;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUserListID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUserListName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUserListLoginUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUserListLoginPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUserListPass;
    }
}