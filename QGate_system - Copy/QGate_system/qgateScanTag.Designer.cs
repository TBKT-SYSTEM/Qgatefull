
namespace QGate_system
{
    partial class qgateScanTag
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
            this.pbSelectModel = new System.Windows.Forms.PictureBox();
            this.lb_pbBackToMenuStart = new System.Windows.Forms.Label();
            this.tbScanTag = new System.Windows.Forms.TextBox();
            this.lbZone = new System.Windows.Forms.Label();
            this.lbStation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectModel)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSelectModel
            // 
            this.pbSelectModel.BackColor = System.Drawing.Color.Transparent;
            this.pbSelectModel.BackgroundImage = global::QGate_system.Properties.Resources.setting1;
            this.pbSelectModel.Location = new System.Drawing.Point(710, 91);
            this.pbSelectModel.Name = "pbSelectModel";
            this.pbSelectModel.Size = new System.Drawing.Size(90, 80);
            this.pbSelectModel.TabIndex = 0;
            this.pbSelectModel.TabStop = false;
            this.pbSelectModel.Click += new System.EventHandler(this.pbSelectModel_Click);
            // 
            // lb_pbBackToMenuStart
            // 
            this.lb_pbBackToMenuStart.BackColor = System.Drawing.Color.Transparent;
            this.lb_pbBackToMenuStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_pbBackToMenuStart.Location = new System.Drawing.Point(12, 504);
            this.lb_pbBackToMenuStart.Name = "lb_pbBackToMenuStart";
            this.lb_pbBackToMenuStart.Size = new System.Drawing.Size(184, 87);
            this.lb_pbBackToMenuStart.TabIndex = 1;
            this.lb_pbBackToMenuStart.Click += new System.EventHandler(this.lb_pbBackToMenuStart_Click);
            // 
            // tbScanTag
            // 
            this.tbScanTag.BackColor = System.Drawing.SystemColors.Window;
            this.tbScanTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbScanTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tbScanTag.ForeColor = System.Drawing.Color.Black;
            this.tbScanTag.Location = new System.Drawing.Point(123, 306);
            this.tbScanTag.Name = "tbScanTag";
            this.tbScanTag.Size = new System.Drawing.Size(257, 40);
            this.tbScanTag.TabIndex = 2;
            this.tbScanTag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbScanTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbScanTag_KeyDown);
            // 
            // lbZone
            // 
            this.lbZone.BackColor = System.Drawing.Color.Transparent;
            this.lbZone.Font = new System.Drawing.Font("MADE Dillan", 12F);
            this.lbZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lbZone.Location = new System.Drawing.Point(462, 51);
            this.lbZone.Name = "lbZone";
            this.lbZone.Size = new System.Drawing.Size(100, 27);
            this.lbZone.TabIndex = 3;
            this.lbZone.Text = "XX";
            // 
            // lbStation
            // 
            this.lbStation.BackColor = System.Drawing.Color.Transparent;
            this.lbStation.Font = new System.Drawing.Font("MADE Dillan", 12F);
            this.lbStation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lbStation.Location = new System.Drawing.Point(746, 51);
            this.lbStation.Name = "lbStation";
            this.lbStation.Size = new System.Drawing.Size(42, 27);
            this.lbStation.TabIndex = 4;
            this.lbStation.Text = "XX";
            // 
            // qgateScanTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.ScanTagFA_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lbStation);
            this.Controls.Add(this.lbZone);
            this.Controls.Add(this.tbScanTag);
            this.Controls.Add(this.lb_pbBackToMenuStart);
            this.Controls.Add(this.pbSelectModel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "qgateScanTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.qgateScanTag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSelectModel;
        private System.Windows.Forms.Label lb_pbBackToMenuStart;
        private System.Windows.Forms.TextBox tbScanTag;
        private System.Windows.Forms.Label lbZone;
        private System.Windows.Forms.Label lbStation;
    }
}