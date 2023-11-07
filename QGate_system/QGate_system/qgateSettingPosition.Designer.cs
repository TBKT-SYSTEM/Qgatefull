
namespace QGate_system
{
    partial class qgateSettingPosition
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
            this.cbSelectPhase = new System.Windows.Forms.ComboBox();
            this.cbSelectZone = new System.Windows.Forms.ComboBox();
            this.cbSelectStation = new System.Windows.Forms.ComboBox();
            this.lbBackToMenu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbConfirm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSelectPhase
            // 
            this.cbSelectPhase.BackColor = System.Drawing.SystemColors.Window;
            this.cbSelectPhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectPhase.DropDownWidth = 499;
            this.cbSelectPhase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectPhase.ForeColor = System.Drawing.Color.Black;
            this.cbSelectPhase.FormattingEnabled = true;
            this.cbSelectPhase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbSelectPhase.ItemHeight = 32;
            this.cbSelectPhase.Location = new System.Drawing.Point(363, 245);
            this.cbSelectPhase.Name = "cbSelectPhase";
            this.cbSelectPhase.Size = new System.Drawing.Size(376, 40);
            this.cbSelectPhase.TabIndex = 0;
            this.cbSelectPhase.SelectedIndexChanged += new System.EventHandler(this.cbPhase_SelectedIndexChanged);
            // 
            // cbSelectZone
            // 
            this.cbSelectZone.DropDownWidth = 499;
            this.cbSelectZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.cbSelectZone.FormattingEnabled = true;
            this.cbSelectZone.ItemHeight = 32;
            this.cbSelectZone.Location = new System.Drawing.Point(363, 322);
            this.cbSelectZone.Name = "cbSelectZone";
            this.cbSelectZone.Size = new System.Drawing.Size(376, 40);
            this.cbSelectZone.TabIndex = 1;
            this.cbSelectZone.SelectedIndexChanged += new System.EventHandler(this.cbZone_SelectedIndexChanged);
            // 
            // cbSelectStation
            // 
            this.cbSelectStation.DropDownWidth = 499;
            this.cbSelectStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.cbSelectStation.FormattingEnabled = true;
            this.cbSelectStation.ItemHeight = 32;
            this.cbSelectStation.Location = new System.Drawing.Point(363, 407);
            this.cbSelectStation.Name = "cbSelectStation";
            this.cbSelectStation.Size = new System.Drawing.Size(376, 40);
            this.cbSelectStation.TabIndex = 2;
            // 
            // lbBackToMenu
            // 
            this.lbBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.lbBackToMenu.Location = new System.Drawing.Point(12, 469);
            this.lbBackToMenu.Name = "lbBackToMenu";
            this.lbBackToMenu.Size = new System.Drawing.Size(168, 75);
            this.lbBackToMenu.TabIndex = 3;
            this.lbBackToMenu.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(602, 469);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 75);
            this.label2.TabIndex = 4;
            // 
            // lbConfirm
            // 
            this.lbConfirm.BackColor = System.Drawing.Color.Transparent;
            this.lbConfirm.Location = new System.Drawing.Point(612, 469);
            this.lbConfirm.Name = "lbConfirm";
            this.lbConfirm.Size = new System.Drawing.Size(168, 75);
            this.lbConfirm.TabIndex = 5;
            this.lbConfirm.Click += new System.EventHandler(this.lbConfirm_Click);
            // 
            // qgateSettingPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QGate_system.Properties.Resources.SettingStation1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lbConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbBackToMenu);
            this.Controls.Add(this.cbSelectStation);
            this.Controls.Add(this.cbSelectZone);
            this.Controls.Add(this.cbSelectPhase);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateSettingPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.setStation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cbSelectPhase;
        public System.Windows.Forms.ComboBox cbSelectZone;
        public System.Windows.Forms.ComboBox cbSelectStation;
        private System.Windows.Forms.Label lbBackToMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbConfirm;
    }
}