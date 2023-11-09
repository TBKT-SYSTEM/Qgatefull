
namespace QGate_system
{
    partial class qgateAddUser
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
            this.tbAddUser = new System.Windows.Forms.TextBox();
            this.pbAddUser = new System.Windows.Forms.PictureBox();
            this.pbCancelAdd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAddUser
            // 
            this.tbAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.tbAddUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddUser.Location = new System.Drawing.Point(91, 62);
            this.tbAddUser.Name = "tbAddUser";
            this.tbAddUser.Size = new System.Drawing.Size(288, 38);
            this.tbAddUser.TabIndex = 0;
            this.tbAddUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbAddUser
            // 
            this.pbAddUser.BackColor = System.Drawing.Color.Transparent;
            this.pbAddUser.Location = new System.Drawing.Point(122, 135);
            this.pbAddUser.Name = "pbAddUser";
            this.pbAddUser.Size = new System.Drawing.Size(94, 53);
            this.pbAddUser.TabIndex = 1;
            this.pbAddUser.TabStop = false;
            this.pbAddUser.Click += new System.EventHandler(this.pbAddUser_Click);
            // 
            // pbCancelAdd
            // 
            this.pbCancelAdd.BackColor = System.Drawing.Color.Transparent;
            this.pbCancelAdd.Location = new System.Drawing.Point(255, 135);
            this.pbCancelAdd.Name = "pbCancelAdd";
            this.pbCancelAdd.Size = new System.Drawing.Size(94, 53);
            this.pbCancelAdd.TabIndex = 2;
            this.pbCancelAdd.TabStop = false;
            this.pbCancelAdd.Click += new System.EventHandler(this.pbCancelAdd_Click);
            // 
            // qgateAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.BackgroundImage = global::QGate_system.Properties.Resources.Popup1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(470, 230);
            this.Controls.Add(this.pbCancelAdd);
            this.Controls.Add(this.pbAddUser);
            this.Controls.Add(this.tbAddUser);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "qgateAddUser";
            ((System.ComponentModel.ISupportInitialize)(this.pbAddUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAddUser;
        private System.Windows.Forms.PictureBox pbAddUser;
        private System.Windows.Forms.PictureBox pbCancelAdd;
    }
}