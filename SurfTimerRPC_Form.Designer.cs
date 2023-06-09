namespace surftimer_rpc_gui
{
    partial class SurfTimerRPC_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurfTimerRPC_Form));
            this.pn_rpcStatus = new System.Windows.Forms.Panel();
            this.lb_rpcStatus = new System.Windows.Forms.Label();
            this.lb_cgiLastInfo = new System.Windows.Forms.Label();
            this.pn_cgiStatus = new System.Windows.Forms.Panel();
            this.lbx_modules0 = new System.Windows.Forms.ListBox();
            this.lbx_modules1 = new System.Windows.Forms.ListBox();
            this.lbx_modules2 = new System.Windows.Forms.ListBox();
            this.lbx_modules3 = new System.Windows.Forms.ListBox();
            this.lb_cgiConfig = new System.Windows.Forms.Label();
            this.pn_cgiConfigStatus = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pn_rpcStatus
            // 
            this.pn_rpcStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.pn_rpcStatus.Location = new System.Drawing.Point(12, 12);
            this.pn_rpcStatus.Name = "pn_rpcStatus";
            this.pn_rpcStatus.Size = new System.Drawing.Size(10, 10);
            this.pn_rpcStatus.TabIndex = 0;
            // 
            // lb_rpcStatus
            // 
            this.lb_rpcStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_rpcStatus.AutoSize = true;
            this.lb_rpcStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.lb_rpcStatus.Location = new System.Drawing.Point(28, 11);
            this.lb_rpcStatus.Name = "lb_rpcStatus";
            this.lb_rpcStatus.Size = new System.Drawing.Size(62, 13);
            this.lb_rpcStatus.TabIndex = 1;
            this.lb_rpcStatus.Text = "RPC Status";
            // 
            // lb_cgiLastInfo
            // 
            this.lb_cgiLastInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_cgiLastInfo.AutoSize = true;
            this.lb_cgiLastInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.lb_cgiLastInfo.Location = new System.Drawing.Point(115, 11);
            this.lb_cgiLastInfo.Name = "lb_cgiLastInfo";
            this.lb_cgiLastInfo.Size = new System.Drawing.Size(75, 13);
            this.lb_cgiLastInfo.TabIndex = 4;
            this.lb_cgiLastInfo.Text = "CGI Last Info: ";
            // 
            // pn_cgiStatus
            // 
            this.pn_cgiStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.pn_cgiStatus.Location = new System.Drawing.Point(99, 12);
            this.pn_cgiStatus.Name = "pn_cgiStatus";
            this.pn_cgiStatus.Size = new System.Drawing.Size(10, 10);
            this.pn_cgiStatus.TabIndex = 3;
            // 
            // lbx_modules0
            // 
            this.lbx_modules0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.lbx_modules0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbx_modules0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.lbx_modules0.FormattingEnabled = true;
            this.lbx_modules0.Location = new System.Drawing.Point(12, 28);
            this.lbx_modules0.Name = "lbx_modules0";
            this.lbx_modules0.Size = new System.Drawing.Size(120, 93);
            this.lbx_modules0.TabIndex = 5;
            this.lbx_modules0.SelectedIndexChanged += new System.EventHandler(this.lbx_modulesChangeIndex);
            // 
            // lbx_modules1
            // 
            this.lbx_modules1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.lbx_modules1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbx_modules1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.lbx_modules1.FormattingEnabled = true;
            this.lbx_modules1.Location = new System.Drawing.Point(138, 28);
            this.lbx_modules1.Name = "lbx_modules1";
            this.lbx_modules1.Size = new System.Drawing.Size(120, 93);
            this.lbx_modules1.TabIndex = 6;
            this.lbx_modules1.SelectedIndexChanged += new System.EventHandler(this.lbx_modulesChangeIndex);
            // 
            // lbx_modules2
            // 
            this.lbx_modules2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.lbx_modules2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbx_modules2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.lbx_modules2.FormattingEnabled = true;
            this.lbx_modules2.Location = new System.Drawing.Point(12, 129);
            this.lbx_modules2.Name = "lbx_modules2";
            this.lbx_modules2.Size = new System.Drawing.Size(120, 93);
            this.lbx_modules2.TabIndex = 7;
            this.lbx_modules2.SelectedIndexChanged += new System.EventHandler(this.lbx_modulesChangeIndex);
            // 
            // lbx_modules3
            // 
            this.lbx_modules3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(86)))), ((int)(((byte)(106)))));
            this.lbx_modules3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbx_modules3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.lbx_modules3.FormattingEnabled = true;
            this.lbx_modules3.Location = new System.Drawing.Point(138, 129);
            this.lbx_modules3.Name = "lbx_modules3";
            this.lbx_modules3.Size = new System.Drawing.Size(120, 93);
            this.lbx_modules3.TabIndex = 8;
            this.lbx_modules3.SelectedIndexChanged += new System.EventHandler(this.lbx_modulesChangeIndex);
            // 
            // lb_cgiConfig
            // 
            this.lb_cgiConfig.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_cgiConfig.AutoSize = true;
            this.lb_cgiConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.lb_cgiConfig.Location = new System.Drawing.Point(237, 11);
            this.lb_cgiConfig.Name = "lb_cgiConfig";
            this.lb_cgiConfig.Size = new System.Drawing.Size(58, 13);
            this.lb_cgiConfig.TabIndex = 10;
            this.lb_cgiConfig.Text = "CGI Config";
            // 
            // pn_cgiConfigStatus
            // 
            this.pn_cgiConfigStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.pn_cgiConfigStatus.Location = new System.Drawing.Point(221, 12);
            this.pn_cgiConfigStatus.Name = "pn_cgiConfigStatus";
            this.pn_cgiConfigStatus.Size = new System.Drawing.Size(10, 10);
            this.pn_cgiConfigStatus.TabIndex = 9;
            // 
            // SurfTimerRPC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(404, 230);
            this.Controls.Add(this.lb_cgiConfig);
            this.Controls.Add(this.pn_cgiConfigStatus);
            this.Controls.Add(this.lbx_modules3);
            this.Controls.Add(this.lbx_modules2);
            this.Controls.Add(this.lbx_modules1);
            this.Controls.Add(this.lbx_modules0);
            this.Controls.Add(this.lb_cgiLastInfo);
            this.Controls.Add(this.pn_cgiStatus);
            this.Controls.Add(this.lb_rpcStatus);
            this.Controls.Add(this.pn_rpcStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 269);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 269);
            this.Name = "SurfTimerRPC_Form";
            this.Text = "SurfTimer RPC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SurfTimerRPC_Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pn_rpcStatus;
        private System.Windows.Forms.Label lb_rpcStatus;
        private System.Windows.Forms.Label lb_cgiLastInfo;
        private System.Windows.Forms.Panel pn_cgiStatus;
        private System.Windows.Forms.ListBox lbx_modules0;
        private System.Windows.Forms.ListBox lbx_modules1;
        private System.Windows.Forms.ListBox lbx_modules2;
        private System.Windows.Forms.ListBox lbx_modules3;
        private System.Windows.Forms.Label lb_cgiConfig;
        private System.Windows.Forms.Panel pn_cgiConfigStatus;
    }
}

