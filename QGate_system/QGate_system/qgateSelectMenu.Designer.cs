
namespace QGate_system
{
    partial class qgateSelectMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pbAddUser = new System.Windows.Forms.PictureBox();
            this.pbMinusUser = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinusUser)).BeginInit();
            this.SuspendLayout();
            // 
            // lbZone
            // 
            this.lbZone.BackColor = System.Drawing.Color.Transparent;
            this.lbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbZone.Location = new System.Drawing.Point(461, 48);
            this.lbZone.Name = "lbZone";
            this.lbZone.Size = new System.Drawing.Size(151, 23);
            this.lbZone.TabIndex = 0;
            // 
            // lbStation
            // 
            this.lbStation.BackColor = System.Drawing.Color.Transparent;
            this.lbStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStation.Location = new System.Drawing.Point(733, 48);
            this.lbStation.Name = "lbStation";
            this.lbStation.Size = new System.Drawing.Size(55, 23);
            this.lbStation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(27, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 70);
            this.label1.TabIndex = 5;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // flpMenu
            // 
            this.flpMenu.BackColor = System.Drawing.Color.Transparent;
            this.flpMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpMenu.Location = new System.Drawing.Point(453, 115);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(332, 459);
            this.flpMenu.TabIndex = 6;
            // 
            // pbAddUser
            // 
            this.pbAddUser.BackColor = System.Drawing.Color.Transparent;
            this.pbAddUser.Location = new System.Drawing.Point(30, 91);
            this.pbAddUser.Name = "pbAddUser";
            this.pbAddUser.Size = new System.Drawing.Size(182, 68);
            this.pbAddUser.TabIndex = 7;
            this.pbAddUser.TabStop = false;
            this.pbAddUser.Click += new System.EventHandler(this.pbAddUser_Click);
            // 
            // pbMinusUser
            // 
            this.pbMinusUser.BackColor = System.Drawing.Color.Transparent;
            this.pbMinusUser.Location = new System.Drawing.Point(30, 433);
            this.pbMinusUser.Name = "pbMinusUser";
            this.pbMinusUser.Size = new System.Drawing.Size(182, 69);
            this.pbMinusUser.TabIndex = 8;
            this.pbMinusUser.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(30, 160);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(182, 272);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // qgateSelectMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pbMinusUser);
            this.Controls.Add(this.pbAddUser);
            this.Controls.Add(this.flpMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbStation);
            this.Controls.Add(this.lbZone);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateSelectMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "qgateSelectMenu";
            this.Load += new System.EventHandler(this.qgateSelectMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinusUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbZone;
        private System.Windows.Forms.Label lbStation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.PictureBox pbAddUser;
        private System.Windows.Forms.PictureBox pbMinusUser;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}