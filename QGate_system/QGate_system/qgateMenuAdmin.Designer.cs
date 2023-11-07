
namespace QGate_system
{
    partial class qgateMenuAdmin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpAdminMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbLogout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(138, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 2;
            // 
            // flpAdminMenu
            // 
            this.flpAdminMenu.AutoScroll = true;
            this.flpAdminMenu.BackColor = System.Drawing.Color.Transparent;
            this.flpAdminMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.flpAdminMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAdminMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flpAdminMenu.Location = new System.Drawing.Point(44, 224);
            this.flpAdminMenu.Name = "flpAdminMenu";
            this.flpAdminMenu.Size = new System.Drawing.Size(456, 273);
            this.flpAdminMenu.TabIndex = 0;
            this.flpAdminMenu.WrapContents = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::QGate_system.Properties.Resources.Btn_MenuAdmin;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(401, 255);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 0);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lbLogout
            // 
            this.lbLogout.BackColor = System.Drawing.Color.Transparent;
            this.lbLogout.ForeColor = System.Drawing.Color.Transparent;
            this.lbLogout.Location = new System.Drawing.Point(23, 510);
            this.lbLogout.Name = "lbLogout";
            this.lbLogout.Size = new System.Drawing.Size(162, 81);
            this.lbLogout.TabIndex = 4;
            this.lbLogout.Click += new System.EventHandler(this.lbLogout_Click);
            // 
            // qgateMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.MenuAdmin2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lbLogout);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flpAdminMenu);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateMenuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "qgateMenuAdmin";
            this.Load += new System.EventHandler(this.qgateMenuAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpAdminMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbLogout;
    }
}