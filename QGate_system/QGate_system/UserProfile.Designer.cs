
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
            this.pbImgUser.Location = new System.Drawing.Point(3, 3);
            this.pbImgUser.Name = "pbImgUser";
            this.pbImgUser.Size = new System.Drawing.Size(176, 164);
            this.pbImgUser.TabIndex = 0;
            this.pbImgUser.TabStop = false;
            // 
            // lbEmpCode
            // 
            this.lbEmpCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmpCode.Location = new System.Drawing.Point(15, 177);
            this.lbEmpCode.Name = "lbEmpCode";
            this.lbEmpCode.Size = new System.Drawing.Size(152, 31);
            this.lbEmpCode.TabIndex = 1;
            this.lbEmpCode.Text = "label1";
            this.lbEmpCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbNameUser
            // 
            this.lbNameUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameUser.Location = new System.Drawing.Point(15, 217);
            this.lbNameUser.Name = "lbNameUser";
            this.lbNameUser.Size = new System.Drawing.Size(152, 31);
            this.lbNameUser.TabIndex = 2;
            this.lbNameUser.Text = "label2";
            this.lbNameUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbNameUser);
            this.Controls.Add(this.lbEmpCode);
            this.Controls.Add(this.pbImgUser);
            this.Name = "UserProfile";
            this.Size = new System.Drawing.Size(182, 259);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImgUser;
        private System.Windows.Forms.Label lbEmpCode;
        private System.Windows.Forms.Label lbNameUser;
    }
}
