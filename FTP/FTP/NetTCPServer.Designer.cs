
namespace FTP
{
    partial class NetTCPServer
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbxServerIP = new System.Windows.Forms.ComboBox();
            this.lstConn = new System.Windows.Forms.ListBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nmServerPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MS_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nmServerPort)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxServerIP
            // 
            this.cbxServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerIP.FormattingEnabled = true;
            this.cbxServerIP.Items.AddRange(new object[] {
            "Any"});
            this.cbxServerIP.Location = new System.Drawing.Point(48, 6);
            this.cbxServerIP.Margin = new System.Windows.Forms.Padding(4);
            this.cbxServerIP.Name = "cbxServerIP";
            this.cbxServerIP.Size = new System.Drawing.Size(157, 23);
            this.cbxServerIP.TabIndex = 15;
            // 
            // lstConn
            // 
            this.lstConn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstConn.ContextMenuStrip = this.contextMenuStrip1;
            this.lstConn.DisplayMember = "Name";
            this.lstConn.FormattingEnabled = true;
            this.lstConn.ItemHeight = 15;
            this.lstConn.Location = new System.Drawing.Point(0, 75);
            this.lstConn.Margin = new System.Windows.Forms.Padding(4);
            this.lstConn.Name = "lstConn";
            this.lstConn.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstConn.Size = new System.Drawing.Size(206, 214);
            this.lstConn.TabIndex = 17;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(133, 37);
            this.btnListen.Margin = new System.Windows.Forms.Padding(4);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(73, 29);
            this.btnListen.TabIndex = 16;
            this.btnListen.Text = "监听";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "本地";
            // 
            // nmServerPort
            // 
            this.nmServerPort.Location = new System.Drawing.Point(48, 39);
            this.nmServerPort.Margin = new System.Windows.Forms.Padding(4);
            this.nmServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmServerPort.Name = "nmServerPort";
            this.nmServerPort.Size = new System.Drawing.Size(75, 25);
            this.nmServerPort.TabIndex = 13;
            this.nmServerPort.Value = new decimal(new int[] {
            2756,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "端口";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MS_Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 28);
            // 
            // MS_Delete
            // 
            this.MS_Delete.Name = "MS_Delete";
            this.MS_Delete.Size = new System.Drawing.Size(138, 24);
            this.MS_Delete.Text = "断开连接";
            this.MS_Delete.Click += new System.EventHandler(this.MS_Delete_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NetTCPServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxServerIP);
            this.Controls.Add(this.lstConn);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmServerPort);
            this.Controls.Add(this.label1);
            this.Name = "NetTCPServer";
            this.Size = new System.Drawing.Size(213, 298);
            this.Load += new System.EventHandler(this.NetTCPServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmServerPort)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxServerIP;
        private System.Windows.Forms.ListBox lstConn;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MS_Delete;
        private System.Windows.Forms.Timer timer1;
    }
}
