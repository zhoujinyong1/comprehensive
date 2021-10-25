namespace FTP
{
    partial class NetTCPClient
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
            this.lstConn = new System.Windows.Forms.ListBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.nmServerPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MS_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nmServerPort)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.lstConn.Location = new System.Drawing.Point(5, 65);
            this.lstConn.Margin = new System.Windows.Forms.Padding(4);
            this.lstConn.Name = "lstConn";
            this.lstConn.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstConn.Size = new System.Drawing.Size(204, 139);
            this.lstConn.TabIndex = 19;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(61, 8);
            this.txtServerIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(147, 25);
            this.txtServerIP.TabIndex = 16;
            // 
            // nmServerPort
            // 
            this.nmServerPort.Location = new System.Drawing.Point(61, 37);
            this.nmServerPort.Margin = new System.Windows.Forms.Padding(4);
            this.nmServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmServerPort.Name = "nmServerPort";
            this.nmServerPort.Size = new System.Drawing.Size(75, 25);
            this.nmServerPort.TabIndex = 20;
            this.nmServerPort.Value = new decimal(new int[] {
            2756,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "服务端";
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(144, 36);
            this.btnConn.Margin = new System.Windows.Forms.Padding(4);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(65, 29);
            this.btnConn.TabIndex = 18;
            this.btnConn.Text = "连接";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "端口";
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
            this.MS_Delete.Size = new System.Drawing.Size(210, 24);
            this.MS_Delete.Text = "断开连接";
            this.MS_Delete.Click += new System.EventHandler(this.MS_Delete_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NetTCPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstConn);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.nmServerPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.label2);
            this.Name = "NetTCPClient";
            this.Size = new System.Drawing.Size(214, 208);
            this.Load += new System.EventHandler(this.NetTCPClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmServerPort)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstConn;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.NumericUpDown nmServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MS_Delete;
        private System.Windows.Forms.Timer timer1;
    }
}
