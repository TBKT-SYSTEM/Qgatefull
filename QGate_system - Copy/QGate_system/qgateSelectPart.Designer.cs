
namespace QGate_system
{
    partial class qgateSelectPart
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
            this.lbZone = new System.Windows.Forms.Label();
            this.lbStation = new System.Windows.Forms.Label();
            this.lb_CancelPart = new System.Windows.Forms.Label();
            this.lb_Confirm = new System.Windows.Forms.Label();
            this.cbSelectPart = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbZone
            // 
            this.lbZone.BackColor = System.Drawing.Color.Transparent;
            this.lbZone.Font = new System.Drawing.Font("MADE Dillan", 12F);
            this.lbZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lbZone.Location = new System.Drawing.Point(461, 52);
            this.lbZone.Name = "lbZone";
            this.lbZone.Size = new System.Drawing.Size(100, 27);
            this.lbZone.TabIndex = 4;
            this.lbZone.Text = "XX";
            // 
            // lbStation
            // 
            this.lbStation.BackColor = System.Drawing.Color.Transparent;
            this.lbStation.Font = new System.Drawing.Font("MADE Dillan", 12F);
            this.lbStation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lbStation.Location = new System.Drawing.Point(746, 52);
            this.lbStation.Name = "lbStation";
            this.lbStation.Size = new System.Drawing.Size(42, 27);
            this.lbStation.TabIndex = 5;
            this.lbStation.Text = "XX";
            // 
            // lb_CancelPart
            // 
            this.lb_CancelPart.BackColor = System.Drawing.Color.Transparent;
            this.lb_CancelPart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lb_CancelPart.Location = new System.Drawing.Point(12, 509);
            this.lb_CancelPart.Name = "lb_CancelPart";
            this.lb_CancelPart.Size = new System.Drawing.Size(174, 82);
            this.lb_CancelPart.TabIndex = 6;
            this.lb_CancelPart.Click += new System.EventHandler(this.lb_CancelPart_Click);
            // 
            // lb_Confirm
            // 
            this.lb_Confirm.BackColor = System.Drawing.Color.Transparent;
            this.lb_Confirm.Location = new System.Drawing.Point(622, 509);
            this.lb_Confirm.Name = "lb_Confirm";
            this.lb_Confirm.Size = new System.Drawing.Size(166, 82);
            this.lb_Confirm.TabIndex = 7;
            this.lb_Confirm.Click += new System.EventHandler(this.lb_Confirm_Click);
            // 
            // cbSelectPart
            // 
            this.cbSelectPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbSelectPart.FormattingEnabled = true;
            this.cbSelectPart.Location = new System.Drawing.Point(87, 303);
            this.cbSelectPart.Name = "cbSelectPart";
            this.cbSelectPart.Size = new System.Drawing.Size(322, 44);
            this.cbSelectPart.TabIndex = 8;
            this.cbSelectPart.SelectedIndexChanged += new System.EventHandler(this.cbTest_SelectedIndexChanged);
            // 
            // qgateSelectPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.Select_Part;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.cbSelectPart);
            this.Controls.Add(this.lb_Confirm);
            this.Controls.Add(this.lb_CancelPart);
            this.Controls.Add(this.lbStation);
            this.Controls.Add(this.lbZone);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateSelectPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.qgateSelectPart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbZone;
        private System.Windows.Forms.Label lbStation;
        private System.Windows.Forms.Label lb_CancelPart;
        private System.Windows.Forms.Label lb_Confirm;
        private System.Windows.Forms.ComboBox cbSelectPart;
    }
}