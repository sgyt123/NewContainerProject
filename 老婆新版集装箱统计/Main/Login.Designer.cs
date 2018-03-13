namespace Main
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.llblConfig = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtuser
            // 
            this.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtuser.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtuser.Location = new System.Drawing.Point(210, 286);
            this.txtuser.MaxLength = 10;
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(117, 22);
            this.txtuser.TabIndex = 0;
            this.txtuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuser_KeyPress);
            // 
            // txtpwd
            // 
            this.txtpwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpwd.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpwd.Location = new System.Drawing.Point(210, 318);
            this.txtpwd.MaxLength = 20;
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '●';
            this.txtpwd.Size = new System.Drawing.Size(117, 22);
            this.txtpwd.TabIndex = 1;
            this.txtpwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpwd_KeyPress);
            // 
            // btnJoin
            // 
            this.btnJoin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnJoin.BackgroundImage")));
            this.btnJoin.Location = new System.Drawing.Point(358, 281);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(62, 27);
            this.btnJoin.TabIndex = 2;
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(358, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(5, 371);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(164, 19);
            this.lblError.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(380, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Version 2.2";
            // 
            // llblConfig
            // 
            this.llblConfig.AutoSize = true;
            this.llblConfig.BackColor = System.Drawing.Color.Transparent;
            this.llblConfig.DisabledLinkColor = System.Drawing.Color.Black;
            this.llblConfig.LinkColor = System.Drawing.Color.Yellow;
            this.llblConfig.Location = new System.Drawing.Point(447, 371);
            this.llblConfig.Name = "llblConfig";
            this.llblConfig.Size = new System.Drawing.Size(29, 12);
            this.llblConfig.TabIndex = 6;
            this.llblConfig.TabStop = true;
            this.llblConfig.Text = "配置";
            this.llblConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblConfig_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(501, 395);
            this.Controls.Add(this.llblConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtuser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录窗体";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llblConfig;
    }
}