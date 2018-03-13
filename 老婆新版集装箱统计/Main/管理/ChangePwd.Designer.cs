namespace Main
{
    partial class ChangePwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePwd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pass3 = new myTextBoxControl.myTextBox();
            this.pass2 = new myTextBoxControl.myTextBox();
            this.pass1 = new myTextBoxControl.myTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.pass3);
            this.groupBox1.Controls.Add(this.pass2);
            this.groupBox1.Controls.Add(this.pass1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 201);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(13, 177);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 12);
            this.lblError.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(112, 119);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(26, 119);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 35);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧密码：";
            // 
            // pass3
            // 
            this.pass3.Demo = "请确认新密码";
            this.pass3.Font_My = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pass3.IsDigt = false;
            this.pass3.IsIp = false;
            this.pass3.IsLetter = false;
            this.pass3.IsSpeace = false;
            this.pass3.IsTrue = false;
            this.pass3.Location = new System.Drawing.Point(78, 78);
            this.pass3.MaxLenght = 20;
            this.pass3.Name = "pass3";
            this.pass3.PassWord = '*';
            this.pass3.Size = new System.Drawing.Size(118, 26);
            this.pass3.TabIndex = 5;
            this.pass3.Text_My = "";
            // 
            // pass2
            // 
            this.pass2.Demo = "请输入新密码";
            this.pass2.Font_My = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pass2.IsDigt = false;
            this.pass2.IsIp = false;
            this.pass2.IsLetter = false;
            this.pass2.IsSpeace = false;
            this.pass2.IsTrue = false;
            this.pass2.Location = new System.Drawing.Point(78, 46);
            this.pass2.MaxLenght = 20;
            this.pass2.Name = "pass2";
            this.pass2.PassWord = '*';
            this.pass2.Size = new System.Drawing.Size(118, 26);
            this.pass2.TabIndex = 4;
            this.pass2.Text_My = "";
            // 
            // pass1
            // 
            this.pass1.Demo = "请输入旧密码";
            this.pass1.Font_My = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pass1.IsDigt = false;
            this.pass1.IsIp = false;
            this.pass1.IsLetter = false;
            this.pass1.IsSpeace = false;
            this.pass1.IsTrue = false;
            this.pass1.Location = new System.Drawing.Point(78, 15);
            this.pass1.MaxLenght = 20;
            this.pass1.Name = "pass1";
            this.pass1.PassWord = '*';
            this.pass1.Size = new System.Drawing.Size(118, 26);
            this.pass1.TabIndex = 3;
            this.pass1.Text_My = "";
            // 
            // ChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(205, 201);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "修改密码";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.this_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private myTextBoxControl.myTextBox pass3;
        private myTextBoxControl.myTextBox pass2;
        private myTextBoxControl.myTextBox pass1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}