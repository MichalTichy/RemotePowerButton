﻿namespace RemotePowerButton.APP
{
    partial class RemotePowerButton
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
            this.butShort = new System.Windows.Forms.Button();
            this.butLong = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbOnlineStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butShort
            // 
            this.butShort.Location = new System.Drawing.Point(12, 12);
            this.butShort.Name = "butShort";
            this.butShort.Size = new System.Drawing.Size(248, 23);
            this.butShort.TabIndex = 0;
            this.butShort.Text = "Short";
            this.butShort.UseVisualStyleBackColor = true;
            this.butShort.Click += new System.EventHandler(this.ButShort_Click);
            // 
            // butLong
            // 
            this.butLong.Location = new System.Drawing.Point(266, 12);
            this.butLong.Name = "butLong";
            this.butLong.Size = new System.Drawing.Size(248, 23);
            this.butLong.TabIndex = 1;
            this.butLong.Text = "Long";
            this.butLong.UseVisualStyleBackColor = true;
            this.butLong.Click += new System.EventHandler(this.ButLong_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOnlineStatus,
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 39);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(521, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(465, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = " ";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOnlineStatus
            // 
            this.tbOnlineStatus.Name = "tbOnlineStatus";
            this.tbOnlineStatus.Size = new System.Drawing.Size(10, 17);
            this.tbOnlineStatus.Text = " ";
            // 
            // RemotePowerButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 61);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.butLong);
            this.Controls.Add(this.butShort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemotePowerButton";
            this.Text = "RemotePowerButton";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butShort;
        private System.Windows.Forms.Button butLong;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tbOnlineStatus;
    }
}

