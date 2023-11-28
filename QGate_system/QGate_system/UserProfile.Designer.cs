
namespace QGate_system
{
    partial class UserProfile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImgUser = new System.Windows.Forms.PictureBox();
            this.lbEmpCode = new System.Windows.Forms.Label();
            this.lbNameUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgUser)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImgUser
            // 
            this.pbImgUser.BackColor = System.Drawing.Color.Transparent;
            this.pbImgUser.Location = new System.Drawing.Point(13, 2);
            this.pbImgUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbImgUser.Name = "pbImgUser";
            this.pbImgUser.Size = new System.Drawing.Size(71, 66);
            this.pbImgUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImgUser.TabIndex = 0;
            this.pbImgUser.TabStop = false;
            // 
            // lbEmpCode
            // 
            this.lbEmpCode.BackColor = System.Drawing.Color.Transparent;
            this.lbEmpCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmpCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbEmpCode.Location = new System.Drawing.Point(97, 12);
            this.lbEmpCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbEmpCode.Name = "lbEmpCode";
            this.lbEmpCode.Size = new System.Drawing.Size(71, 20);
            this.lbEmpCode.TabIndex = 1;
            this.lbEmpCode.Text = "label1";
            this.lbEmpCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbNameUser
            // 
            this.lbNameUser.BackColor = System.Drawing.Color.Transparent;
            this.lbNameUser.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbNameUser.Location = new System.Drawing.Point(97, 37);
            this.lbNameUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNameUser.Name = "lbNameUser";
            this.lbNameUser.Size = new System.Drawing.Size(71, 20);
            this.lbNameUser.TabIndex = 2;
            this.lbNameUser.Text = "label2";
            this.lbNameUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.lbNameUser);
            this.Controls.Add(this.lbEmpCode);
            this.Controls.Add(this.pbImgUser);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserProfile";
            this.Size = new System.Drawing.Size(180, 70);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImgUser;
        private System.Windows.Forms.Label lbEmpCode;
        private System.Windows.Forms.Label lbNameUser;
    }
}
