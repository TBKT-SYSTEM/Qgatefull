
namespace QGate_system
{
    partial class qgateDefectNg
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
            this.pbConfirm = new System.Windows.Forms.PictureBox();
            this.pbBackToOperation = new System.Windows.Forms.PictureBox();
            this.lvDefect = new System.Windows.Forms.ListView();
            this.lvDefectCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvDefectDetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbNamedefect = new System.Windows.Forms.Label();
            this.tbPartNo = new System.Windows.Forms.TextBox();
            this.CbNumProduct = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackToOperation)).BeginInit();
            this.SuspendLayout();
            // 
            // lbZone
            // 
            this.lbZone.BackColor = System.Drawing.Color.Transparent;
            this.lbZone.Font = new System.Drawing.Font("MADE Dillan", 12F);
            this.lbZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lbZone.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbZone.Location = new System.Drawing.Point(462, 50);
            this.lbZone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbZone.Name = "lbZone";
            this.lbZone.Size = new System.Drawing.Size(111, 19);
            this.lbZone.TabIndex = 56;
            this.lbZone.Text = "XX";
            // 
            // lbStation
            // 
            this.lbStation.BackColor = System.Drawing.Color.Transparent;
            this.lbStation.Font = new System.Drawing.Font("MADE Dillan", 12F);
            this.lbStation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lbStation.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbStation.Location = new System.Drawing.Point(737, 50);
            this.lbStation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStation.Name = "lbStation";
            this.lbStation.Size = new System.Drawing.Size(37, 19);
            this.lbStation.TabIndex = 57;
            this.lbStation.Text = "X";
            // 
            // pbConfirm
            // 
            this.pbConfirm.BackColor = System.Drawing.Color.Transparent;
            this.pbConfirm.Location = new System.Drawing.Point(623, 512);
            this.pbConfirm.Name = "pbConfirm";
            this.pbConfirm.Size = new System.Drawing.Size(149, 72);
            this.pbConfirm.TabIndex = 58;
            this.pbConfirm.TabStop = false;
            this.pbConfirm.Click += new System.EventHandler(this.pbConfirm_Click);
            // 
            // pbBackToOperation
            // 
            this.pbBackToOperation.BackColor = System.Drawing.Color.Transparent;
            this.pbBackToOperation.Location = new System.Drawing.Point(29, 512);
            this.pbBackToOperation.Name = "pbBackToOperation";
            this.pbBackToOperation.Size = new System.Drawing.Size(149, 72);
            this.pbBackToOperation.TabIndex = 59;
            this.pbBackToOperation.TabStop = false;
            this.pbBackToOperation.Click += new System.EventHandler(this.pbBackToOperation_Click);
            // 
            // lvDefect
            // 
            this.lvDefect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvDefectCode,
            this.lvDefectDetail});
            this.lvDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lvDefect.FullRowSelect = true;
            this.lvDefect.GridLines = true;
            this.lvDefect.HideSelection = false;
            this.lvDefect.Location = new System.Drawing.Point(29, 161);
            this.lvDefect.Name = "lvDefect";
            this.lvDefect.Size = new System.Drawing.Size(742, 335);
            this.lvDefect.TabIndex = 60;
            this.lvDefect.UseCompatibleStateImageBehavior = false;
            this.lvDefect.View = System.Windows.Forms.View.Details;
            // 
            // lvDefectCode
            // 
            this.lvDefectCode.Text = "Defect Code";
            this.lvDefectCode.Width = 161;
            // 
            // lvDefectDetail
            // 
            this.lvDefectDetail.Text = "Defect Detail";
            this.lvDefectDetail.Width = 577;
            // 
            // lbNamedefect
            // 
            this.lbNamedefect.AutoSize = true;
            this.lbNamedefect.BackColor = System.Drawing.Color.Transparent;
            this.lbNamedefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNamedefect.Location = new System.Drawing.Point(30, 108);
            this.lbNamedefect.Name = "lbNamedefect";
            this.lbNamedefect.Size = new System.Drawing.Size(19, 25);
            this.lbNamedefect.TabIndex = 61;
            this.lbNamedefect.Text = "-";
            // 
            // tbPartNo
            // 
            this.tbPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPartNo.Location = new System.Drawing.Point(159, 105);
            this.tbPartNo.Name = "tbPartNo";
            this.tbPartNo.Size = new System.Drawing.Size(334, 30);
            this.tbPartNo.TabIndex = 62;
            // 
            // CbNumProduct
            // 
            this.CbNumProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbNumProduct.FormattingEnabled = true;
            this.CbNumProduct.Location = new System.Drawing.Point(159, 105);
            this.CbNumProduct.Name = "CbNumProduct";
            this.CbNumProduct.Size = new System.Drawing.Size(184, 33);
            this.CbNumProduct.TabIndex = 63;
            // 
            // qgateDefectNg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.DefectNG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.CbNumProduct);
            this.Controls.Add(this.tbPartNo);
            this.Controls.Add(this.lbNamedefect);
            this.Controls.Add(this.lvDefect);
            this.Controls.Add(this.pbBackToOperation);
            this.Controls.Add(this.pbConfirm);
            this.Controls.Add(this.lbStation);
            this.Controls.Add(this.lbZone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "qgateDefectNg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "qgateDefectNg";
            this.Load += new System.EventHandler(this.qgateDefectNg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackToOperation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbZone;
        private System.Windows.Forms.Label lbStation;
        internal System.Windows.Forms.PictureBox pbConfirm;
        internal System.Windows.Forms.PictureBox pbBackToOperation;
        private System.Windows.Forms.ListView lvDefect;
        private System.Windows.Forms.ColumnHeader lvDefectCode;
        private System.Windows.Forms.ColumnHeader lvDefectDetail;
        internal System.Windows.Forms.Label lbNamedefect;
        internal System.Windows.Forms.TextBox tbPartNo;
        internal System.Windows.Forms.ComboBox CbNumProduct;
    }
}