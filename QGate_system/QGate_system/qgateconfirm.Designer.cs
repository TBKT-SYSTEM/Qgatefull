﻿
namespace QGate_system
{
    partial class qgateconfirm
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
            this.pbConfirm = new System.Windows.Forms.PictureBox();
            this.pbCancel = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // pbConfirm
            // 
            this.pbConfirm.BackColor = System.Drawing.Color.Transparent;
            this.pbConfirm.Location = new System.Drawing.Point(117, 135);
            this.pbConfirm.Name = "pbConfirm";
            this.pbConfirm.Size = new System.Drawing.Size(100, 50);
            this.pbConfirm.TabIndex = 0;
            this.pbConfirm.TabStop = false;
            this.pbConfirm.Click += new System.EventHandler(this.pbConfirm_Click);
            // 
            // pbCancel
            // 
            this.pbCancel.BackColor = System.Drawing.Color.Transparent;
            this.pbCancel.Location = new System.Drawing.Point(253, 135);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(100, 50);
            this.pbCancel.TabIndex = 1;
            this.pbCancel.TabStop = false;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(110, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Are you sure?";
            // 
            // qgateconfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::QGate_system.Properties.Resources.Popup_NoText1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(470, 230);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.pbConfirm);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateconfirm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbConfirm;
        private System.Windows.Forms.PictureBox pbCancel;
        private System.Windows.Forms.Label label1;
    }
}