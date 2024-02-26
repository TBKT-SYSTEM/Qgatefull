
namespace QGate_system
{
    partial class qgateMenuStart
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbDMC = new System.Windows.Forms.Label();
            this.lbNonDMC = new System.Windows.Forms.Label();
            this.lbBackToMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // lbDMC
            // 
            this.lbDMC.BackColor = System.Drawing.Color.Transparent;
            this.lbDMC.Location = new System.Drawing.Point(272, 271);
            this.lbDMC.Name = "lbDMC";
            this.lbDMC.Size = new System.Drawing.Size(259, 93);
            this.lbDMC.TabIndex = 1;
            this.lbDMC.Click += new System.EventHandler(this.lbDMC_Click);
            // 
            // lbNonDMC
            // 
            this.lbNonDMC.BackColor = System.Drawing.Color.Transparent;
            this.lbNonDMC.Location = new System.Drawing.Point(272, 383);
            this.lbNonDMC.Name = "lbNonDMC";
            this.lbNonDMC.Size = new System.Drawing.Size(259, 93);
            this.lbNonDMC.TabIndex = 2;
            this.lbNonDMC.Click += new System.EventHandler(this.lbNonDMC_Click);
            // 
            // lbBackToMenu
            // 
            this.lbBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.lbBackToMenu.Location = new System.Drawing.Point(24, 507);
            this.lbBackToMenu.Name = "lbBackToMenu";
            this.lbBackToMenu.Size = new System.Drawing.Size(163, 84);
            this.lbBackToMenu.TabIndex = 3;
            this.lbBackToMenu.Click += new System.EventHandler(this.lbBackToMenu_Click);
            // 
            // qgateMenuStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.MenuStart;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lbBackToMenu);
            this.Controls.Add(this.lbNonDMC);
            this.Controls.Add(this.lbDMC);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateMenuStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "qgateMenuStart";
            this.Load += new System.EventHandler(this.qgateMenuStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDMC;
        private System.Windows.Forms.Label lbNonDMC;
        private System.Windows.Forms.Label lbBackToMenu;
    }
}