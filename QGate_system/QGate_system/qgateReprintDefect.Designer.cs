
namespace QGate_system
{
    partial class qgateReprintDefect
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvDetail = new System.Windows.Forms.ListView();
            this.lvid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPartNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLotNO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvBoxNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbDate = new System.Windows.Forms.ComboBox();
            this.cbPartNo = new System.Windows.Forms.ComboBox();
            this.cbLotNo = new System.Windows.Forms.ComboBox();
            this.cbTypeDefect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbZone = new System.Windows.Forms.Label();
            this.lbStation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(97, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reprint Tag Defect";
            // 
            // lvDetail
            // 
            this.lvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvid,
            this.lvPartNo,
            this.lvLotNO,
            this.lvBoxNo});
            this.lvDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lvDetail.HideSelection = false;
            this.lvDetail.Location = new System.Drawing.Point(30, 231);
            this.lvDetail.Name = "lvDetail";
            this.lvDetail.Size = new System.Drawing.Size(740, 270);
            this.lvDetail.TabIndex = 1;
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
            this.lvPartNo.Width = 330;
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
            // cbDate
            // 
            this.cbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbDate.FormattingEnabled = true;
            this.cbDate.Location = new System.Drawing.Point(132, 118);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(194, 32);
            this.cbDate.TabIndex = 9;
            // 
            // cbPartNo
            // 
            this.cbPartNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbPartNo.FormattingEnabled = true;
            this.cbPartNo.Location = new System.Drawing.Point(132, 181);
            this.cbPartNo.Name = "cbPartNo";
            this.cbPartNo.Size = new System.Drawing.Size(194, 32);
            this.cbPartNo.TabIndex = 10;
            // 
            // cbLotNo
            // 
            this.cbLotNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLotNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbLotNo.FormattingEnabled = true;
            this.cbLotNo.Location = new System.Drawing.Point(450, 181);
            this.cbLotNo.Name = "cbLotNo";
            this.cbLotNo.Size = new System.Drawing.Size(140, 32);
            this.cbLotNo.TabIndex = 11;
            // 
            // cbTypeDefect
            // 
            this.cbTypeDefect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeDefect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTypeDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbTypeDefect.FormattingEnabled = true;
            this.cbTypeDefect.Location = new System.Drawing.Point(700, 181);
            this.cbTypeDefect.Name = "cbTypeDefect";
            this.cbTypeDefect.Size = new System.Drawing.Size(65, 32);
            this.cbTypeDefect.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(454, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 69);
            this.label2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(615, 513);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 69);
            this.label3.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(27, 513);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 69);
            this.label4.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(452, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 69);
            this.label5.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(618, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 69);
            this.label6.TabIndex = 17;
            // 
            // lbZone
            // 
            this.lbZone.BackColor = System.Drawing.Color.Transparent;
            this.lbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbZone.Location = new System.Drawing.Point(463, 49);
            this.lbZone.Name = "lbZone";
            this.lbZone.Size = new System.Drawing.Size(83, 23);
            this.lbZone.TabIndex = 18;
            this.lbZone.Text = "XX";
            // 
            // lbStation
            // 
            this.lbStation.BackColor = System.Drawing.Color.Transparent;
            this.lbStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbStation.Location = new System.Drawing.Point(740, 49);
            this.lbStation.Name = "lbStation";
            this.lbStation.Size = new System.Drawing.Size(54, 23);
            this.lbStation.TabIndex = 19;
            this.lbStation.Text = "XX";
            // 
            // qgateReprintDefect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.ReprintDefectDate11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lbStation);
            this.Controls.Add(this.lbZone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTypeDefect);
            this.Controls.Add(this.cbLotNo);
            this.Controls.Add(this.cbPartNo);
            this.Controls.Add(this.cbDate);
            this.Controls.Add(this.lvDetail);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "qgateReprintDefect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.qgateReprintDefect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvDetail;
        private System.Windows.Forms.ColumnHeader lvid;
        private System.Windows.Forms.ColumnHeader lvPartNo;
        private System.Windows.Forms.ColumnHeader lvLotNO;
        private System.Windows.Forms.ColumnHeader lvBoxNo;
        private System.Windows.Forms.ComboBox cbDate;
        private System.Windows.Forms.ComboBox cbPartNo;
        private System.Windows.Forms.ComboBox cbLotNo;
        private System.Windows.Forms.ComboBox cbTypeDefect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbZone;
        private System.Windows.Forms.Label lbStation;
    }
}