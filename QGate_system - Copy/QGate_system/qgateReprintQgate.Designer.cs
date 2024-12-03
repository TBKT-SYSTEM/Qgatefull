
namespace QGate_system
{
    partial class qgateReprintQgate
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
            this.cbDate = new System.Windows.Forms.ComboBox();
            this.cbPartNo = new System.Windows.Forms.ComboBox();
            this.cbLotNo = new System.Windows.Forms.ComboBox();
            this.lvDetail = new System.Windows.Forms.ListView();
            this.lvid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPartNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLotNO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvBoxNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbZone = new System.Windows.Forms.Label();
            this.lbStation = new System.Windows.Forms.Label();
            this.pbBackReprintToMenu = new System.Windows.Forms.PictureBox();
            this.pbClear = new System.Windows.Forms.PictureBox();
            this.pbPrint = new System.Windows.Forms.PictureBox();
            this.pbListPrint = new System.Windows.Forms.PictureBox();
            this.pbScanPrint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackReprintToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbListPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScanPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDate
            // 
            this.cbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.cbDate.FormattingEnabled = true;
            this.cbDate.Location = new System.Drawing.Point(132, 118);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(194, 32);
            this.cbDate.TabIndex = 9;
            this.cbDate.SelectedIndexChanged += new System.EventHandler(this.cbDate_SelectedIndexChanged);
            // 
            // cbPartNo
            // 
            this.cbPartNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.cbPartNo.FormattingEnabled = true;
            this.cbPartNo.Location = new System.Drawing.Point(132, 181);
            this.cbPartNo.Name = "cbPartNo";
            this.cbPartNo.Size = new System.Drawing.Size(194, 32);
            this.cbPartNo.TabIndex = 10;
            this.cbPartNo.SelectedIndexChanged += new System.EventHandler(this.cbPartNo_SelectedIndexChanged);
            // 
            // cbLotNo
            // 
            this.cbLotNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.cbLotNo.FormattingEnabled = true;
            this.cbLotNo.Location = new System.Drawing.Point(450, 181);
            this.cbLotNo.Name = "cbLotNo";
            this.cbLotNo.Size = new System.Drawing.Size(140, 32);
            this.cbLotNo.TabIndex = 11;
            this.cbLotNo.SelectedIndexChanged += new System.EventHandler(this.cbLotNo_SelectedIndexChanged);
            // 
            // lvDetail
            // 
            this.lvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvid,
            this.lvPartNo,
            this.lvLotNO,
            this.lvBoxNo});
            this.lvDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lvDetail.FullRowSelect = true;
            this.lvDetail.GridLines = true;
            this.lvDetail.HideSelection = false;
            this.lvDetail.Location = new System.Drawing.Point(30, 231);
            this.lvDetail.Name = "lvDetail";
            this.lvDetail.Size = new System.Drawing.Size(747, 270);
            this.lvDetail.TabIndex = 12;
            this.lvDetail.UseCompatibleStateImageBehavior = false;
            this.lvDetail.View = System.Windows.Forms.View.Details;
            // 
            // lvid
            // 
            this.lvid.Text = "ID";
            this.lvid.Width = 58;
            // 
            // lvPartNo
            // 
            this.lvPartNo.Text = "PART NO";
            this.lvPartNo.Width = 469;
            // 
            // lvLotNO
            // 
            this.lvLotNO.Text = "LOT NO";
            this.lvLotNO.Width = 106;
            // 
            // lvBoxNo
            // 
            this.lvBoxNo.Text = "BOX NO";
            this.lvBoxNo.Width = 92;
            // 
            // lbZone
            // 
            this.lbZone.BackColor = System.Drawing.Color.Transparent;
            this.lbZone.Font = new System.Drawing.Font("MADE Dillan", 12F);
            this.lbZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lbZone.Location = new System.Drawing.Point(463, 51);
            this.lbZone.Name = "lbZone";
            this.lbZone.Size = new System.Drawing.Size(83, 23);
            this.lbZone.TabIndex = 13;
            this.lbZone.Text = "XX";
            // 
            // lbStation
            // 
            this.lbStation.BackColor = System.Drawing.Color.Transparent;
            this.lbStation.Font = new System.Drawing.Font("MADE Dillan", 12F);
            this.lbStation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lbStation.Location = new System.Drawing.Point(740, 51);
            this.lbStation.Name = "lbStation";
            this.lbStation.Size = new System.Drawing.Size(54, 23);
            this.lbStation.TabIndex = 14;
            this.lbStation.Text = "XX";
            // 
            // pbBackReprintToMenu
            // 
            this.pbBackReprintToMenu.BackColor = System.Drawing.Color.Transparent;
            this.pbBackReprintToMenu.Location = new System.Drawing.Point(24, 512);
            this.pbBackReprintToMenu.Name = "pbBackReprintToMenu";
            this.pbBackReprintToMenu.Size = new System.Drawing.Size(158, 72);
            this.pbBackReprintToMenu.TabIndex = 15;
            this.pbBackReprintToMenu.TabStop = false;
            this.pbBackReprintToMenu.Click += new System.EventHandler(this.pbBackReprintToMenu_Click);
            // 
            // pbClear
            // 
            this.pbClear.BackColor = System.Drawing.Color.Transparent;
            this.pbClear.Location = new System.Drawing.Point(452, 512);
            this.pbClear.Name = "pbClear";
            this.pbClear.Size = new System.Drawing.Size(158, 72);
            this.pbClear.TabIndex = 16;
            this.pbClear.TabStop = false;
            this.pbClear.Click += new System.EventHandler(this.pbClear_Click);
            // 
            // pbPrint
            // 
            this.pbPrint.BackColor = System.Drawing.Color.Transparent;
            this.pbPrint.Location = new System.Drawing.Point(619, 512);
            this.pbPrint.Name = "pbPrint";
            this.pbPrint.Size = new System.Drawing.Size(158, 72);
            this.pbPrint.TabIndex = 17;
            this.pbPrint.TabStop = false;
            this.pbPrint.Click += new System.EventHandler(this.pbPrint_Click);
            // 
            // pbListPrint
            // 
            this.pbListPrint.BackColor = System.Drawing.Color.Transparent;
            this.pbListPrint.Location = new System.Drawing.Point(450, 94);
            this.pbListPrint.Name = "pbListPrint";
            this.pbListPrint.Size = new System.Drawing.Size(162, 76);
            this.pbListPrint.TabIndex = 18;
            this.pbListPrint.TabStop = false;
            // 
            // pbScanPrint
            // 
            this.pbScanPrint.BackColor = System.Drawing.Color.Transparent;
            this.pbScanPrint.Location = new System.Drawing.Point(617, 94);
            this.pbScanPrint.Name = "pbScanPrint";
            this.pbScanPrint.Size = new System.Drawing.Size(162, 76);
            this.pbScanPrint.TabIndex = 19;
            this.pbScanPrint.TabStop = false;
            this.pbScanPrint.Click += new System.EventHandler(this.pbScanPrint_Click);
            // 
            // qgateReprintQgate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.ReprintQgateDate2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pbScanPrint);
            this.Controls.Add(this.pbListPrint);
            this.Controls.Add(this.pbPrint);
            this.Controls.Add(this.pbClear);
            this.Controls.Add(this.pbBackReprintToMenu);
            this.Controls.Add(this.lbStation);
            this.Controls.Add(this.lbZone);
            this.Controls.Add(this.lvDetail);
            this.Controls.Add(this.cbLotNo);
            this.Controls.Add(this.cbPartNo);
            this.Controls.Add(this.cbDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateReprintQgate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.qgateReprintQgate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackReprintToMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbListPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScanPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDate;
        private System.Windows.Forms.ComboBox cbPartNo;
        private System.Windows.Forms.ComboBox cbLotNo;
        private System.Windows.Forms.ListView lvDetail;
        private System.Windows.Forms.ColumnHeader lvid;
        private System.Windows.Forms.ColumnHeader lvPartNo;
        private System.Windows.Forms.ColumnHeader lvLotNO;
        private System.Windows.Forms.ColumnHeader lvBoxNo;
        private System.Windows.Forms.Label lbZone;
        private System.Windows.Forms.Label lbStation;
        private System.Windows.Forms.PictureBox pbBackReprintToMenu;
        private System.Windows.Forms.PictureBox pbClear;
        private System.Windows.Forms.PictureBox pbPrint;
        private System.Windows.Forms.PictureBox pbListPrint;
        private System.Windows.Forms.PictureBox pbScanPrint;
    }
}