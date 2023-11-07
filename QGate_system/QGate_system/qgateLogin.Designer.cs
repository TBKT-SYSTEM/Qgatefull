
namespace QGate_system
{
    partial class qgateLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(qgateLogin));
            this.tbLoginUser = new System.Windows.Forms.TextBox();
            this.lbConfig = new System.Windows.Forms.Label();
            this.lbExitApp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbLoginUser
            // 
            this.tbLoginUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLoginUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLoginUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.tbLoginUser.Location = new System.Drawing.Point(128, 379);
            this.tbLoginUser.Name = "tbLoginUser";
            this.tbLoginUser.Size = new System.Drawing.Size(284, 48);
            this.tbLoginUser.TabIndex = 0;
            this.tbLoginUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLoginUser_KeyDown);
            // 
            // lbConfig
            // 
            this.lbConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbConfig.BackColor = System.Drawing.Color.Transparent;
            this.lbConfig.Location = new System.Drawing.Point(706, 0);
            this.lbConfig.Name = "lbConfig";
            this.lbConfig.Size = new System.Drawing.Size(92, 77);
            this.lbConfig.TabIndex = 1;
            this.lbConfig.Click += new System.EventHandler(this.pbConfig_Click);
            // 
            // lbExitApp
            // 
            this.lbExitApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbExitApp.BackColor = System.Drawing.Color.Transparent;
            this.lbExitApp.Location = new System.Drawing.Point(634, 518);
            this.lbExitApp.Name = "lbExitApp";
            this.lbExitApp.Size = new System.Drawing.Size(154, 73);
            this.lbExitApp.TabIndex = 2;
            this.lbExitApp.Text = " ";
            this.lbExitApp.Click += new System.EventHandler(this.lbexit_Click);
            // 
            // qgateLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lbExitApp);
            this.Controls.Add(this.lbConfig);
            this.Controls.Add(this.tbLoginUser);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " LoginUser";
            this.Load += new System.EventHandler(this.qgateLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLoginUser;
        private System.Windows.Forms.Label lbConfig;
        private System.Windows.Forms.Label lbExitApp;
    }
}

