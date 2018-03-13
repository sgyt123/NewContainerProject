namespace Main
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stateLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbarDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tTime = new System.Windows.Forms.Timer(this.components);
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tmiBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGoodsType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGoodsType1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGoodsType2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShip = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSource = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWorkPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiInput = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCale = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCondFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCondTotal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiQuickTotal = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPassWord = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.系统清单管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSystemChixiang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSystemGang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSystemChuan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSystemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.tsbInput = new System.Windows.Forms.ToolStripButton();
            this.tsbCount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbQuick = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.menu.SuspendLayout();
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stateLbl,
            this.tsbarDate,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 719);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1192, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stateLbl
            // 
            this.stateLbl.Name = "stateLbl";
            this.stateLbl.Size = new System.Drawing.Size(909, 17);
            this.stateLbl.Spring = true;
            this.stateLbl.Text = "状态";
            this.stateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsbarDate
            // 
            this.tsbarDate.Name = "tsbarDate";
            this.tsbarDate.Size = new System.Drawing.Size(89, 17);
            this.tsbarDate.Text = "    当前时间：";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(179, 17);
            this.toolStripStatusLabel1.Text = "    CopyRight By 关启明 @2013";
            // 
            // tTime
            // 
            this.tTime.Enabled = true;
            this.tTime.Interval = 1000;
            this.tTime.Tick += new System.EventHandler(this.tTime_Tick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiBase,
            this.tmiInput,
            this.tmiCale,
            this.tmiSet,
            this.系统清单管理ToolStripMenuItem,
            this.tmiExit});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1192, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // tmiBase
            // 
            this.tmiBase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBase,
            this.tsmiCompany,
            this.tsmiGoodsType,
            this.tsmiProxy,
            this.tsmiShip,
            this.tsmiSource,
            this.tsmiWorkPlace});
            this.tmiBase.Name = "tmiBase";
            this.tmiBase.Size = new System.Drawing.Size(89, 20);
            this.tmiBase.Text = "【基础信息】";
            // 
            // tsmiBase
            // 
            this.tsmiBase.Name = "tsmiBase";
            this.tsmiBase.Size = new System.Drawing.Size(244, 22);
            this.tsmiBase.Text = "箱型信息";
            this.tsmiBase.Click += new System.EventHandler(this.tsmiBase_Click);
            // 
            // tsmiCompany
            // 
            this.tsmiCompany.Name = "tsmiCompany";
            this.tsmiCompany.Size = new System.Drawing.Size(244, 22);
            this.tsmiCompany.Text = "船公司信息";
            this.tsmiCompany.Click += new System.EventHandler(this.tsmiCompany_Click);
            // 
            // tsmiGoodsType
            // 
            this.tsmiGoodsType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGoodsType1,
            this.tsmiGoodsType2});
            this.tsmiGoodsType.Name = "tsmiGoodsType";
            this.tsmiGoodsType.Size = new System.Drawing.Size(244, 22);
            this.tsmiGoodsType.Text = "货种信息";
            // 
            // tsmiGoodsType1
            // 
            this.tsmiGoodsType1.Name = "tsmiGoodsType1";
            this.tsmiGoodsType1.Size = new System.Drawing.Size(118, 22);
            this.tsmiGoodsType1.Text = "一级货种";
            this.tsmiGoodsType1.Click += new System.EventHandler(this.tsmiGoodsType1_Click);
            // 
            // tsmiGoodsType2
            // 
            this.tsmiGoodsType2.Name = "tsmiGoodsType2";
            this.tsmiGoodsType2.Size = new System.Drawing.Size(118, 22);
            this.tsmiGoodsType2.Text = "二级货种";
            this.tsmiGoodsType2.Click += new System.EventHandler(this.tsmiGoodsType2_Click);
            // 
            // tsmiProxy
            // 
            this.tsmiProxy.Name = "tsmiProxy";
            this.tsmiProxy.Size = new System.Drawing.Size(244, 22);
            this.tsmiProxy.Text = "代理信息";
            this.tsmiProxy.Click += new System.EventHandler(this.tsmiProxy_Click);
            // 
            // tsmiShip
            // 
            this.tsmiShip.Name = "tsmiShip";
            this.tsmiShip.Size = new System.Drawing.Size(244, 22);
            this.tsmiShip.Text = "船舶信息";
            this.tsmiShip.Click += new System.EventHandler(this.tsmiShip_Click);
            // 
            // tsmiSource
            // 
            this.tsmiSource.Name = "tsmiSource";
            this.tsmiSource.Size = new System.Drawing.Size(244, 22);
            this.tsmiSource.Text = "目的港\\来源地\\流向\\发往地信息";
            this.tsmiSource.Click += new System.EventHandler(this.tsmiSource_Click);
            // 
            // tsmiWorkPlace
            // 
            this.tsmiWorkPlace.Name = "tsmiWorkPlace";
            this.tsmiWorkPlace.Size = new System.Drawing.Size(244, 22);
            this.tsmiWorkPlace.Text = "工作地点信息";
            this.tsmiWorkPlace.Click += new System.EventHandler(this.tsmiWorkPlace_Click);
            // 
            // tmiInput
            // 
            this.tmiInput.Name = "tmiInput";
            this.tmiInput.Size = new System.Drawing.Size(89, 20);
            this.tmiInput.Text = "【数据录入】";
            this.tmiInput.Click += new System.EventHandler(this.tmiInput_Click);
            // 
            // tmiCale
            // 
            this.tmiCale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCondFind,
            this.tsmiCondTotal,
            this.toolStripSeparator1,
            this.tsmiQuickTotal});
            this.tmiCale.Name = "tmiCale";
            this.tmiCale.Size = new System.Drawing.Size(89, 20);
            this.tmiCale.Text = "【数据统计】";
            // 
            // tsmiCondFind
            // 
            this.tsmiCondFind.Name = "tsmiCondFind";
            this.tsmiCondFind.Size = new System.Drawing.Size(118, 22);
            this.tsmiCondFind.Text = "条件查询";
            this.tsmiCondFind.Click += new System.EventHandler(this.tsmiCondFind_Click);
            // 
            // tsmiCondTotal
            // 
            this.tsmiCondTotal.Name = "tsmiCondTotal";
            this.tsmiCondTotal.Size = new System.Drawing.Size(118, 22);
            this.tsmiCondTotal.Text = "条件汇总";
            this.tsmiCondTotal.Click += new System.EventHandler(this.tsmiCondTotal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            // 
            // tsmiQuickTotal
            // 
            this.tsmiQuickTotal.Name = "tsmiQuickTotal";
            this.tsmiQuickTotal.Size = new System.Drawing.Size(118, 22);
            this.tsmiQuickTotal.Text = "快速汇总";
            this.tsmiQuickTotal.Click += new System.EventHandler(this.tsmiQuickTotal_Click);
            // 
            // tmiSet
            // 
            this.tmiSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPassWord,
            this.tsmiUser,
            this.tsmiAdmin,
            this.toolStripSeparator2,
            this.tsmiBackup});
            this.tmiSet.Name = "tmiSet";
            this.tmiSet.Size = new System.Drawing.Size(77, 20);
            this.tmiSet.Text = "【管  理】";
            // 
            // tsmiPassWord
            // 
            this.tsmiPassWord.Name = "tsmiPassWord";
            this.tsmiPassWord.Size = new System.Drawing.Size(118, 22);
            this.tsmiPassWord.Text = "密码修改";
            this.tsmiPassWord.Click += new System.EventHandler(this.tsmiPassWord_Click);
            // 
            // tsmiUser
            // 
            this.tsmiUser.Name = "tsmiUser";
            this.tsmiUser.Size = new System.Drawing.Size(118, 22);
            this.tsmiUser.Text = "用户管理";
            this.tsmiUser.Click += new System.EventHandler(this.tsmiUser_Click);
            // 
            // tsmiAdmin
            // 
            this.tsmiAdmin.Name = "tsmiAdmin";
            this.tsmiAdmin.Size = new System.Drawing.Size(118, 22);
            this.tsmiAdmin.Text = "权限设置";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // tsmiBackup
            // 
            this.tsmiBackup.Name = "tsmiBackup";
            this.tsmiBackup.Size = new System.Drawing.Size(118, 22);
            this.tsmiBackup.Text = "备份数据";
            // 
            // 系统清单管理ToolStripMenuItem
            // 
            this.系统清单管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSystemChixiang,
            this.tsmiSystemGang,
            this.tsmiSystemChuan,
            this.toolStripSeparator4,
            this.tsmiSystemMenu});
            this.系统清单管理ToolStripMenuItem.Name = "系统清单管理ToolStripMenuItem";
            this.系统清单管理ToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.系统清单管理ToolStripMenuItem.Text = "【系统清单管理】";
            // 
            // tsmiSystemChixiang
            // 
            this.tsmiSystemChixiang.Name = "tsmiSystemChixiang";
            this.tsmiSystemChixiang.Size = new System.Drawing.Size(130, 22);
            this.tsmiSystemChixiang.Text = "持箱人信息";
            this.tsmiSystemChixiang.Click += new System.EventHandler(this.tsmiSystemChixiang_Click);
            // 
            // tsmiSystemGang
            // 
            this.tsmiSystemGang.Name = "tsmiSystemGang";
            this.tsmiSystemGang.Size = new System.Drawing.Size(130, 22);
            this.tsmiSystemGang.Text = "港口信息";
            this.tsmiSystemGang.Click += new System.EventHandler(this.tsmiSystemGang_Click);
            // 
            // tsmiSystemChuan
            // 
            this.tsmiSystemChuan.Name = "tsmiSystemChuan";
            this.tsmiSystemChuan.Size = new System.Drawing.Size(130, 22);
            this.tsmiSystemChuan.Text = "船名信息";
            this.tsmiSystemChuan.Click += new System.EventHandler(this.tsmiSystemChuan_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(127, 6);
            // 
            // tsmiSystemMenu
            // 
            this.tsmiSystemMenu.Name = "tsmiSystemMenu";
            this.tsmiSystemMenu.Size = new System.Drawing.Size(130, 22);
            this.tsmiSystemMenu.Text = "清单信息";
            this.tsmiSystemMenu.Click += new System.EventHandler(this.tsmiSystemMenu_Click);
            // 
            // tmiExit
            // 
            this.tmiExit.Name = "tmiExit";
            this.tmiExit.Size = new System.Drawing.Size(77, 20);
            this.tmiExit.Text = "【退  出】";
            this.tmiExit.Click += new System.EventHandler(this.tmiExit_Click);
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbInput,
            this.tsbCount,
            this.toolStripSeparator3,
            this.tsbQuick});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1192, 25);
            this.tools.TabIndex = 3;
            this.tools.Text = "toolStrip1";
            // 
            // tsbInput
            // 
            this.tsbInput.Image = ((System.Drawing.Image)(resources.GetObject("tsbInput.Image")));
            this.tsbInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInput.Name = "tsbInput";
            this.tsbInput.Size = new System.Drawing.Size(73, 22);
            this.tsbInput.Text = "清单录入";
            this.tsbInput.Click += new System.EventHandler(this.tsbInput_Click);
            // 
            // tsbCount
            // 
            this.tsbCount.Image = ((System.Drawing.Image)(resources.GetObject("tsbCount.Image")));
            this.tsbCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCount.Name = "tsbCount";
            this.tsbCount.Size = new System.Drawing.Size(73, 22);
            this.tsbCount.Text = "条件汇总";
            this.tsbCount.Click += new System.EventHandler(this.tsbCount_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbQuick
            // 
            this.tsbQuick.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuick.Image")));
            this.tsbQuick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuick.Name = "tsbQuick";
            this.tsbQuick.Size = new System.Drawing.Size(73, 22);
            this.tsbQuick.Text = "快速汇总";
            this.tsbQuick.Click += new System.EventHandler(this.tsbQuick_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 741);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盘锦港集装箱统计管理";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stateLbl;
        private System.Windows.Forms.Timer tTime;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripMenuItem tmiBase;
        private System.Windows.Forms.ToolStripMenuItem tsmiBase;
        private System.Windows.Forms.ToolStripMenuItem tmiInput;
        private System.Windows.Forms.ToolStripMenuItem tmiCale;
        private System.Windows.Forms.ToolStripMenuItem tmiSet;
        private System.Windows.Forms.ToolStripMenuItem tmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiCompany;
        private System.Windows.Forms.ToolStripMenuItem tsmiGoodsType;
        private System.Windows.Forms.ToolStripMenuItem tsmiProxy;
        private System.Windows.Forms.ToolStripMenuItem tsmiShip;
        private System.Windows.Forms.ToolStripMenuItem tsmiSource;
        private System.Windows.Forms.ToolStripMenuItem tsmiWorkPlace;
        private System.Windows.Forms.ToolStripMenuItem tsmiGoodsType1;
        private System.Windows.Forms.ToolStripMenuItem tsmiGoodsType2;
        private System.Windows.Forms.ToolStripMenuItem tsmiCondFind;
        private System.Windows.Forms.ToolStripMenuItem tsmiCondTotal;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuickTotal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsbarDate;
        private System.Windows.Forms.ToolStripMenuItem tsmiPassWord;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdmin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbInput;
        private System.Windows.Forms.ToolStripButton tsbCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackup;
        private System.Windows.Forms.ToolStripButton tsbQuick;
        private System.Windows.Forms.ToolStripMenuItem 系统清单管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSystemChixiang;
        private System.Windows.Forms.ToolStripMenuItem tsmiSystemGang;
        private System.Windows.Forms.ToolStripMenuItem tsmiSystemChuan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiSystemMenu;
    }
}