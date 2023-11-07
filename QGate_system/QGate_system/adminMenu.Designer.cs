
namespace QGate_system
{
    partial class adminMenu
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
            this.pbMenuAdmin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMenuAdmin
            // 
            this.pbMenuAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbMenuAdmin.Location = new System.Drawing.Point(8, 10);
            this.pbMenuAdmin.Name = "pbMenuAdmin";
            this.pbMenuAdmin.Size = new System.Drawing.Size(351, 115);
            this.pbMenuAdmin.TabIndex = 0;
            this.pbMenuAdmin.TabStop = false;
            // 
            // adminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbMenuAdmin);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "adminMenu";
            this.Size = new System.Drawing.Size(351, 115);
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuAdmin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMenuAdmin;
    }
}
