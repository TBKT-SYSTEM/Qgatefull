
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(qgateSettingPosition));
            this.cbSelectPhase = new System.Windows.Forms.ComboBox();
            this.cbSelectZone = new System.Windows.Forms.ComboBox();
            this.cbSelectStation = new System.Windows.Forms.ComboBox();
            this.lbBackToMenu = new System.Windows.Forms.Label();
            this.lbConfirm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSelectPhase
            // 
            this.cbSelectPhase.BackColor = System.Drawing.SystemColors.Window;
            this.cbSelectPhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectPhase.DropDownWidth = 499;
            this.cbSelectPhase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectPhase.ForeColor = System.Drawing.Color.Black;
            this.cbSelectPhase.FormattingEnabled = true;
            this.cbSelectPhase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbSelectPhase.ItemHeight = 33;
            this.cbSelectPhase.Location = new System.Drawing.Point(362, 243);
            this.cbSelectPhase.Margin = new System.Windows.Forms.Padding(2);
            this.cbSelectPhase.Name = "cbSelectPhase";
            this.cbSelectPhase.Size = new System.Drawing.Size(376, 41);
            this.cbSelectPhase.TabIndex = 0;
            this.cbSelectPhase.SelectedIndexChanged += new System.EventHandler(this.cbPhase_SelectedIndexChanged);
            // 
            // cbSelectZone
            // 
            this.cbSelectZone.DropDownWidth = 499;
            this.cbSelectZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectZone.FormattingEnabled = true;
            this.cbSelectZone.ItemHeight = 33;
            this.cbSelectZone.Location = new System.Drawing.Point(362, 323);
            this.cbSelectZone.Margin = new System.Windows.Forms.Padding(2);
            this.cbSelectZone.Name = "cbSelectZone";
            this.cbSelectZone.Size = new System.Drawing.Size(376, 41);
            this.cbSelectZone.TabIndex = 1;
            this.cbSelectZone.SelectedIndexChanged += new System.EventHandler(this.cbZone_SelectedIndexChanged);
            // 
            // cbSelectStation
            // 
            this.cbSelectStation.DropDownWidth = 499;
            this.cbSelectStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectStation.FormattingEnabled = true;
            this.cbSelectStation.ItemHeight = 33;
            this.cbSelectStation.Location = new System.Drawing.Point(362, 406);
            this.cbSelectStation.Margin = new System.Windows.Forms.Padding(2);
            this.cbSelectStation.Name = "cbSelectStation";
            this.cbSelectStation.Size = new System.Drawing.Size(376, 41);
            this.cbSelectStation.TabIndex = 2;
            // 
            // lbBackToMenu
            // 
            this.lbBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.lbBackToMenu.Location = new System.Drawing.Point(11, 509);
            this.lbBackToMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBackToMenu.Name = "lbBackToMenu";
            this.lbBackToMenu.Size = new System.Drawing.Size(176, 82);
            this.lbBackToMenu.TabIndex = 3;
            this.lbBackToMenu.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbConfirm
            // 
            this.lbConfirm.BackColor = System.Drawing.Color.Transparent;
            this.lbConfirm.Location = new System.Drawing.Point(622, 509);
            this.lbConfirm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbConfirm.Name = "lbConfirm";
            this.lbConfirm.Size = new System.Drawing.Size(167, 82);
            this.lbConfirm.TabIndex = 5;
            this.lbConfirm.Click += new System.EventHandler(this.lbConfirm_Click);
            // 
            // qgateSettingPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QGate_system.Properties.Resources.SettingStation1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lbConfirm);
            this.Controls.Add(this.lbBackToMenu);
            this.Controls.Add(this.cbSelectStation);
            this.Controls.Add(this.cbSelectZone);
            this.Controls.Add(this.cbSelectPhase);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label lbConfirm;
    }
}