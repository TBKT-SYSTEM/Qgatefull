
namespace QGate_system
{
    partial class qgateLoginAdmin
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
            this.lbBackToLogin = new System.Windows.Forms.Label();
            this.tbLoginAdmin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbBackToLogin
            // 
            this.lbBackToLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbBackToLogin.BackColor = System.Drawing.Color.Transparent;
            this.lbBackToLogin.ForeColor = System.Drawing.Color.Transparent;
            this.lbBackToLogin.Location = new System.Drawing.Point(24, 517);
            this.lbBackToLogin.Name = "lbBackToLogin";
            this.lbBackToLogin.Size = new System.Drawing.Size(151, 74);
            this.lbBackToLogin.TabIndex = 1;
            this.lbBackToLogin.Click += new System.EventHandler(this.pbBackToLogin_Click);
            // 
            // tbLoginAdmin
            // 
            this.tbLoginAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLoginAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.2F);
            this.tbLoginAdmin.Location = new System.Drawing.Point(458, 321);
            this.tbLoginAdmin.Multiline = true;
            this.tbLoginAdmin.Name = "tbLoginAdmin";
            this.tbLoginAdmin.Size = new System.Drawing.Size(285, 46);
            this.tbLoginAdmin.TabIndex = 2;
            this.tbLoginAdmin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLoginAdmin_KeyDown);
            // 
            // qgateLoginAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.Login_Admin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tbLoginAdmin);
            this.Controls.Add(this.lbBackToLogin);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateLoginAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        } 

        #endregion
        private System.Windows.Forms.Label lbBackToLogin;
        private System.Windows.Forms.TextBox tbLoginAdmin;
    }
}