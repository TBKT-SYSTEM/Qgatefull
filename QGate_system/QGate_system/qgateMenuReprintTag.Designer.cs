
namespace QGate_system
{
    partial class qgateMenuReprintTag
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
            this.lbBackToMenu = new System.Windows.Forms.Label();
            this.lbQgate = new System.Windows.Forms.Label();
            this.lbDefect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbBackToMenu
            // 
            this.lbBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.lbBackToMenu.Location = new System.Drawing.Point(27, 513);
            this.lbBackToMenu.Name = "lbBackToMenu";
            this.lbBackToMenu.Size = new System.Drawing.Size(153, 70);
            this.lbBackToMenu.TabIndex = 1;
            this.lbBackToMenu.Click += new System.EventHandler(this.lbBackToMenu_Click);
            // 
            // lbQgate
            // 
            this.lbQgate.BackColor = System.Drawing.Color.Transparent;
            this.lbQgate.Location = new System.Drawing.Point(441, 281);
            this.lbQgate.Name = "lbQgate";
            this.lbQgate.Size = new System.Drawing.Size(252, 86);
            this.lbQgate.TabIndex = 2;
            this.lbQgate.Click += new System.EventHandler(this.lbQgate_Click);
            // 
            // lbDefect
            // 
            this.lbDefect.BackColor = System.Drawing.Color.Transparent;
            this.lbDefect.Location = new System.Drawing.Point(441, 384);
            this.lbDefect.Name = "lbDefect";
            this.lbDefect.Size = new System.Drawing.Size(252, 86);
            this.lbDefect.TabIndex = 3;
            this.lbDefect.Click += new System.EventHandler(this.lbDefect_Click);
            // 
            // qgatePrintTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.Reprint;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lbDefect);
            this.Controls.Add(this.lbQgate);
            this.Controls.Add(this.lbBackToMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "qgatePrintTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbBackToMenu;
        private System.Windows.Forms.Label lbQgate;
        private System.Windows.Forms.Label lbDefect;
    }
}