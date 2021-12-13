namespace Blf_export_data
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbb_CANFIDList = new System.Windows.Forms.ComboBox();
            this.cbb_Signallist = new System.Windows.Forms.ComboBox();
            this.cbb_Messagelist = new System.Windows.Forms.ComboBox();
            this.btn_SaveCSV = new System.Windows.Forms.Button();
            this.tb_LoadblfPath = new System.Windows.Forms.TextBox();
            this.btn_Loadlbf = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tb_LoaddbcPath = new System.Windows.Forms.TextBox();
            this.btn_LoadDBC = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(926, 533);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.cbb_CANFIDList);
            this.tabPage1.Controls.Add(this.cbb_Signallist);
            this.tabPage1.Controls.Add(this.cbb_Messagelist);
            this.tabPage1.Controls.Add(this.btn_SaveCSV);
            this.tabPage1.Controls.Add(this.tb_LoadblfPath);
            this.tabPage1.Controls.Add(this.btn_Loadlbf);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.tbMessage);
            this.tabPage1.Controls.Add(this.tb_LoaddbcPath);
            this.tabPage1.Controls.Add(this.btn_LoadDBC);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(918, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CAN/CANFD信号数据导出";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(198, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "信号名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(198, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "报文名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(198, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "报文ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(201, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "注：BLF文件必须是绝对路径";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(658, 188);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 180);
            this.textBox1.TabIndex = 12;
            // 
            // cbb_CANFIDList
            // 
            this.cbb_CANFIDList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbb_CANFIDList.FormattingEnabled = true;
            this.cbb_CANFIDList.Location = new System.Drawing.Point(269, 210);
            this.cbb_CANFIDList.Name = "cbb_CANFIDList";
            this.cbb_CANFIDList.Size = new System.Drawing.Size(243, 24);
            this.cbb_CANFIDList.TabIndex = 11;
            // 
            // cbb_Signallist
            // 
            this.cbb_Signallist.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbb_Signallist.FormattingEnabled = true;
            this.cbb_Signallist.Location = new System.Drawing.Point(269, 335);
            this.cbb_Signallist.Name = "cbb_Signallist";
            this.cbb_Signallist.Size = new System.Drawing.Size(243, 24);
            this.cbb_Signallist.TabIndex = 10;
            // 
            // cbb_Messagelist
            // 
            this.cbb_Messagelist.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbb_Messagelist.FormattingEnabled = true;
            this.cbb_Messagelist.Location = new System.Drawing.Point(269, 272);
            this.cbb_Messagelist.Name = "cbb_Messagelist";
            this.cbb_Messagelist.Size = new System.Drawing.Size(243, 24);
            this.cbb_Messagelist.TabIndex = 9;
            // 
            // btn_SaveCSV
            // 
            this.btn_SaveCSV.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveCSV.Location = new System.Drawing.Point(515, 335);
            this.btn_SaveCSV.Name = "btn_SaveCSV";
            this.btn_SaveCSV.Size = new System.Drawing.Size(80, 33);
            this.btn_SaveCSV.TabIndex = 8;
            this.btn_SaveCSV.Text = "导出csv";
            this.btn_SaveCSV.UseVisualStyleBackColor = true;
            this.btn_SaveCSV.Click += new System.EventHandler(this.btn_SaveCSV_Click);
            // 
            // tb_LoadblfPath
            // 
            this.tb_LoadblfPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_LoadblfPath.Location = new System.Drawing.Point(201, 117);
            this.tb_LoadblfPath.Name = "tb_LoadblfPath";
            this.tb_LoadblfPath.Size = new System.Drawing.Size(243, 26);
            this.tb_LoadblfPath.TabIndex = 7;
            // 
            // btn_Loadlbf
            // 
            this.btn_Loadlbf.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Loadlbf.Location = new System.Drawing.Point(478, 117);
            this.btn_Loadlbf.Name = "btn_Loadlbf";
            this.btn_Loadlbf.Size = new System.Drawing.Size(80, 33);
            this.btn_Loadlbf.TabIndex = 6;
            this.btn_Loadlbf.Text = "加载blf";
            this.btn_Loadlbf.UseVisualStyleBackColor = true;
            this.btn_Loadlbf.Click += new System.EventHandler(this.btn_Loadlbf_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Blf_export_data.Properties.Resources.qrcode_for_gh_71b9d27fc41f_258;
            this.pictureBox2.Location = new System.Drawing.Point(785, 374);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 125);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Blf_export_data.Properties.Resources.LOGO_白;
            this.pictureBox1.Location = new System.Drawing.Point(658, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tbMessage
            // 
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMessage.Location = new System.Drawing.Point(195, 374);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(720, 130);
            this.tbMessage.TabIndex = 3;
            // 
            // tb_LoaddbcPath
            // 
            this.tb_LoaddbcPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_LoaddbcPath.Location = new System.Drawing.Point(201, 13);
            this.tb_LoaddbcPath.Name = "tb_LoaddbcPath";
            this.tb_LoaddbcPath.Size = new System.Drawing.Size(243, 26);
            this.tb_LoaddbcPath.TabIndex = 2;
            // 
            // btn_LoadDBC
            // 
            this.btn_LoadDBC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LoadDBC.Location = new System.Drawing.Point(478, 13);
            this.btn_LoadDBC.Name = "btn_LoadDBC";
            this.btn_LoadDBC.Size = new System.Drawing.Size(80, 33);
            this.btn_LoadDBC.TabIndex = 1;
            this.btn_LoadDBC.Text = "加载dbc";
            this.btn_LoadDBC.UseVisualStyleBackColor = true;
            this.btn_LoadDBC.Click += new System.EventHandler(this.btn_LoadDBC_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(192, 501);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 533);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.TextBox tb_LoaddbcPath;
        private System.Windows.Forms.Button btn_LoadDBC;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_SaveCSV;
        private System.Windows.Forms.TextBox tb_LoadblfPath;
        private System.Windows.Forms.Button btn_Loadlbf;
        private System.Windows.Forms.ComboBox cbb_Signallist;
        private System.Windows.Forms.ComboBox cbb_Messagelist;
        private System.Windows.Forms.ComboBox cbb_CANFIDList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

