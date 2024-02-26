
namespace QGate_system
{
    partial class qgateOperationManual
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
            this.components = new System.ComponentModel.Container();
            this.lbZone = new System.Windows.Forms.Label();
            this.lbStation = new System.Windows.Forms.Label();
            this.lbPartNo = new System.Windows.Forms.Label();
            this.tbCounter = new System.Windows.Forms.TextBox();
            this.lbPartNoName = new System.Windows.Forms.Label();
            this.lbProductDate = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.lbLotNo = new System.Windows.Forms.Label();
            this.lbSnp = new System.Windows.Forms.Label();
            this.lbBoxNo = new System.Windows.Forms.Label();
            this.pbNg = new System.Windows.Forms.Panel();
            this.pbNc = new System.Windows.Forms.Panel();
            this.tbCounterNc = new System.Windows.Forms.TextBox();
            this.tbCounterNg = new System.Windows.Forms.TextBox();
            this.lbBoxNoNg = new System.Windows.Forms.Label();
            this.lbBoxNoNc = new System.Windows.Forms.Label();
            this.pbBackToScan = new System.Windows.Forms.PictureBox();
            this.pbEnd = new System.Windows.Forms.PictureBox();
            this.pbFinish = new System.Windows.Forms.PictureBox();
            this.lbIncrease = new System.Windows.Forms.Label();
            this.lbReduce = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackToScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinish)).BeginInit();
            this.SuspendLayout();
            // 
            // lbZone
            // 
            this.lbZone.BackColor = System.Drawing.Color.Transparent;
            this.lbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbZone.Location = new System.Drawing.Point(460, 47);
            this.lbZone.Name = "lbZone";
            this.lbZone.Size = new System.Drawing.Size(142, 23);
            this.lbZone.TabIndex = 0;
            this.lbZone.Text = "XX";
            this.lbZone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStation
            // 
            this.lbStation.BackColor = System.Drawing.Color.Transparent;
            this.lbStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStation.Location = new System.Drawing.Point(734, 47);
            this.lbStation.Name = "lbStation";
            this.lbStation.Size = new System.Drawing.Size(40, 23);
            this.lbStation.TabIndex = 0;
            this.lbStation.Text = "XX";
            this.lbStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPartNo
            // 
            this.lbPartNo.BackColor = System.Drawing.Color.Transparent;
            this.lbPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPartNo.ForeColor = System.Drawing.Color.White;
            this.lbPartNo.Location = new System.Drawing.Point(100, 145);
            this.lbPartNo.Name = "lbPartNo";
            this.lbPartNo.Size = new System.Drawing.Size(201, 21);
            this.lbPartNo.TabIndex = 1;
            this.lbPartNo.Text = "-";
            this.lbPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCounter
            // 
            this.tbCounter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCounter.Location = new System.Drawing.Point(132, 379);
            this.tbCounter.Name = "tbCounter";
            this.tbCounter.Size = new System.Drawing.Size(83, 31);
            this.tbCounter.TabIndex = 9;
            this.tbCounter.Text = "0";
            this.tbCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCounter.TextChanged += new System.EventHandler(this.tbCounter_TextChanged);
            // 
            // lbPartNoName
            // 
            this.lbPartNoName.BackColor = System.Drawing.Color.Transparent;
            this.lbPartNoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPartNoName.ForeColor = System.Drawing.Color.White;
            this.lbPartNoName.Location = new System.Drawing.Point(127, 186);
            this.lbPartNoName.Name = "lbPartNoName";
            this.lbPartNoName.Size = new System.Drawing.Size(176, 21);
            this.lbPartNoName.TabIndex = 11;
            this.lbPartNoName.Text = "-";
            this.lbPartNoName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbProductDate
            // 
            this.lbProductDate.BackColor = System.Drawing.Color.Transparent;
            this.lbProductDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbProductDate.ForeColor = System.Drawing.Color.White;
            this.lbProductDate.Location = new System.Drawing.Point(147, 221);
            this.lbProductDate.Name = "lbProductDate";
            this.lbProductDate.Size = new System.Drawing.Size(156, 21);
            this.lbProductDate.TabIndex = 12;
            this.lbProductDate.Text = "-";
            this.lbProductDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbModel
            // 
            this.lbModel.BackColor = System.Drawing.Color.Transparent;
            this.lbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbModel.ForeColor = System.Drawing.Color.White;
            this.lbModel.Location = new System.Drawing.Point(90, 257);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(156, 21);
            this.lbModel.TabIndex = 13;
            this.lbModel.Text = "-";
            this.lbModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLotNo
            // 
            this.lbLotNo.BackColor = System.Drawing.Color.Transparent;
            this.lbLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbLotNo.ForeColor = System.Drawing.Color.White;
            this.lbLotNo.Location = new System.Drawing.Point(95, 295);
            this.lbLotNo.Name = "lbLotNo";
            this.lbLotNo.Size = new System.Drawing.Size(156, 21);
            this.lbLotNo.TabIndex = 14;
            this.lbLotNo.Text = "-";
            this.lbLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSnp
            // 
            this.lbSnp.BackColor = System.Drawing.Color.Transparent;
            this.lbSnp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbSnp.ForeColor = System.Drawing.Color.White;
            this.lbSnp.Location = new System.Drawing.Point(75, 332);
            this.lbSnp.Name = "lbSnp";
            this.lbSnp.Size = new System.Drawing.Size(156, 21);
            this.lbSnp.TabIndex = 15;
            this.lbSnp.Text = "-";
            this.lbSnp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBoxNo
            // 
            this.lbBoxNo.BackColor = System.Drawing.Color.Transparent;
            this.lbBoxNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbBoxNo.ForeColor = System.Drawing.Color.White;
            this.lbBoxNo.Location = new System.Drawing.Point(98, 432);
            this.lbBoxNo.Name = "lbBoxNo";
            this.lbBoxNo.Size = new System.Drawing.Size(156, 21);
            this.lbBoxNo.TabIndex = 16;
            this.lbBoxNo.Text = "-";
            this.lbBoxNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbNg
            // 
            this.pbNg.BackColor = System.Drawing.Color.Transparent;
            this.pbNg.Location = new System.Drawing.Point(356, 113);
            this.pbNg.Name = "pbNg";
            this.pbNg.Size = new System.Drawing.Size(163, 109);
            this.pbNg.TabIndex = 17;
            this.pbNg.Click += new System.EventHandler(this.pbNg_Click);
            // 
            // pbNc
            // 
            this.pbNc.BackColor = System.Drawing.Color.Transparent;
            this.pbNc.Location = new System.Drawing.Point(356, 243);
            this.pbNc.Name = "pbNc";
            this.pbNc.Size = new System.Drawing.Size(163, 105);
            this.pbNc.TabIndex = 18;
            this.pbNc.Click += new System.EventHandler(this.pbNc_Click);
            // 
            // tbCounterNc
            // 
            this.tbCounterNc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCounterNc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCounterNc.Location = new System.Drawing.Point(671, 262);
            this.tbCounterNc.Name = "tbCounterNc";
            this.tbCounterNc.Size = new System.Drawing.Size(83, 31);
            this.tbCounterNc.TabIndex = 20;
            this.tbCounterNc.Text = "0";
            this.tbCounterNc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCounterNg
            // 
            this.tbCounterNg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCounterNg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCounterNg.Location = new System.Drawing.Point(671, 132);
            this.tbCounterNg.Name = "tbCounterNg";
            this.tbCounterNg.Size = new System.Drawing.Size(83, 31);
            this.tbCounterNg.TabIndex = 21;
            this.tbCounterNg.Text = "0";
            this.tbCounterNg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbBoxNoNg
            // 
            this.lbBoxNoNg.BackColor = System.Drawing.Color.Transparent;
            this.lbBoxNoNg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBoxNoNg.ForeColor = System.Drawing.Color.Black;
            this.lbBoxNoNg.Location = new System.Drawing.Point(597, 183);
            this.lbBoxNoNg.Name = "lbBoxNoNg";
            this.lbBoxNoNg.Size = new System.Drawing.Size(88, 21);
            this.lbBoxNoNg.TabIndex = 22;
            this.lbBoxNoNg.Text = "0";
            this.lbBoxNoNg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBoxNoNc
            // 
            this.lbBoxNoNc.BackColor = System.Drawing.Color.Transparent;
            this.lbBoxNoNc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBoxNoNc.ForeColor = System.Drawing.Color.Black;
            this.lbBoxNoNc.Location = new System.Drawing.Point(597, 309);
            this.lbBoxNoNc.Name = "lbBoxNoNc";
            this.lbBoxNoNc.Size = new System.Drawing.Size(88, 21);
            this.lbBoxNoNc.TabIndex = 23;
            this.lbBoxNoNc.Text = "0";
            this.lbBoxNoNc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbBackToScan
            // 
            this.pbBackToScan.BackColor = System.Drawing.Color.Transparent;
            this.pbBackToScan.Location = new System.Drawing.Point(24, 509);
            this.pbBackToScan.Name = "pbBackToScan";
            this.pbBackToScan.Size = new System.Drawing.Size(160, 76);
            this.pbBackToScan.TabIndex = 24;
            this.pbBackToScan.TabStop = false;
            this.pbBackToScan.Click += new System.EventHandler(this.pbBackToScan_Click);
            // 
            // pbEnd
            // 
            this.pbEnd.BackColor = System.Drawing.Color.Transparent;
            this.pbEnd.BackgroundImage = global::QGate_system.Properties.Resources.End;
            this.pbEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbEnd.Location = new System.Drawing.Point(628, 512);
            this.pbEnd.Name = "pbEnd";
            this.pbEnd.Size = new System.Drawing.Size(160, 76);
            this.pbEnd.TabIndex = 25;
            this.pbEnd.TabStop = false;
            this.pbEnd.Click += new System.EventHandler(this.pbEnd_Click);
            // 
            // pbFinish
            // 
            this.pbFinish.BackColor = System.Drawing.Color.Transparent;
            this.pbFinish.BackgroundImage = global::QGate_system.Properties.Resources.Finish;
            this.pbFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbFinish.Location = new System.Drawing.Point(442, 512);
            this.pbFinish.Name = "pbFinish";
            this.pbFinish.Size = new System.Drawing.Size(160, 76);
            this.pbFinish.TabIndex = 26;
            this.pbFinish.TabStop = false;
            this.pbFinish.Click += new System.EventHandler(this.pbFinish_Click);
            // 
            // lbIncrease
            // 
            this.lbIncrease.BackColor = System.Drawing.Color.Transparent;
            this.lbIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbIncrease.Location = new System.Drawing.Point(413, 376);
            this.lbIncrease.Name = "lbIncrease";
            this.lbIncrease.Size = new System.Drawing.Size(147, 117);
            this.lbIncrease.TabIndex = 27;
            this.lbIncrease.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbIncrease.Click += new System.EventHandler(this.lb_plus_Click);
            // 
            // lbReduce
            // 
            this.lbReduce.BackColor = System.Drawing.Color.Transparent;
            this.lbReduce.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbReduce.Location = new System.Drawing.Point(580, 376);
            this.lbReduce.Name = "lbReduce";
            this.lbReduce.Size = new System.Drawing.Size(147, 117);
            this.lbReduce.TabIndex = 28;
            this.lbReduce.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbReduce.Click += new System.EventHandler(this.lb_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 29;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(225, 298);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 31;
            // 
            // qgateOperationManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QGate_system.Properties.Resources.operationNotDMC11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbReduce);
            this.Controls.Add(this.lbIncrease);
            this.Controls.Add(this.pbFinish);
            this.Controls.Add(this.pbEnd);
            this.Controls.Add(this.pbBackToScan);
            this.Controls.Add(this.lbBoxNoNc);
            this.Controls.Add(this.lbBoxNoNg);
            this.Controls.Add(this.tbCounterNg);
            this.Controls.Add(this.tbCounterNc);
            this.Controls.Add(this.pbNc);
            this.Controls.Add(this.pbNg);
            this.Controls.Add(this.lbBoxNo);
            this.Controls.Add(this.lbSnp);
            this.Controls.Add(this.lbLotNo);
            this.Controls.Add(this.lbModel);
            this.Controls.Add(this.lbProductDate);
            this.Controls.Add(this.lbPartNoName);
            this.Controls.Add(this.tbCounter);
            this.Controls.Add(this.lbPartNo);
            this.Controls.Add(this.lbStation);
            this.Controls.Add(this.lbZone);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "qgateOperationManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "test";
            this.Load += new System.EventHandler(this.qgateOperationManual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackToScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinish)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbZone;
        private System.Windows.Forms.Label lbStation;
        private System.Windows.Forms.Label lbPartNo;
        private System.Windows.Forms.TextBox tbCounter;
        private System.Windows.Forms.Label lbPartNoName;
        private System.Windows.Forms.Label lbProductDate;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label lbLotNo;
        private System.Windows.Forms.Label lbSnp;
        private System.Windows.Forms.Label lbBoxNo;
        private System.Windows.Forms.Panel pbNg;
        private System.Windows.Forms.Panel pbNc;
        private System.Windows.Forms.TextBox tbCounterNc;
        private System.Windows.Forms.TextBox tbCounterNg;
        private System.Windows.Forms.Label lbBoxNoNg;
        private System.Windows.Forms.Label lbBoxNoNc;
        private System.Windows.Forms.PictureBox pbBackToScan;
        private System.Windows.Forms.PictureBox pbEnd;
        private System.Windows.Forms.PictureBox pbFinish;
        private System.Windows.Forms.Label lbIncrease;
        private System.Windows.Forms.Label lbReduce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}