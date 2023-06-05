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
            this.pn_rpcStatus = new System.Windows.Forms.Panel();
            this.lb_rpcStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_cgiLastInfo = new System.Windows.Forms.Label();
            this.pn_cgiStatus = new System.Windows.Forms.Panel();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(28, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
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
            // SurfTimerRPC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(404, 230);
            this.Controls.Add(this.lb_cgiLastInfo);
            this.Controls.Add(this.pn_cgiStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_rpcStatus);
            this.Controls.Add(this.pn_rpcStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 269);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 269);
            this.Name = "SurfTimerRPC_Form";
            this.Text = "SurfTimer RPC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pn_rpcStatus;
        private System.Windows.Forms.Label lb_rpcStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_cgiLastInfo;
        private System.Windows.Forms.Panel pn_cgiStatus;
    }
}

