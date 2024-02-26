using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace QGate_system
{
    public partial class PrintTag : Form
    {
        operationData operationData = operationData.Instance;

        public PrintTag()
        {
            InitializeComponent();
        }

        private int MillimetersToInches(float millimeters)
        {
            const float inchesPerMillimeter = 0.0393701f;
            return (int)(millimeters * inchesPerMillimeter * 100);
        }

        public void printTagQgate(string Sendto, string custPartNo, string boxNo, string tagqgate, string id_product, string location)
        {
            //QRCodeGenerator generator = new QRCodeGenerator();
            PrintDocument printDoc = new PrintDocument();
            qgateScanTag qgateScanTag = new qgateScanTag();
            PaperSize customPaperSize = new PaperSize("Custom", MillimetersToInches(79.0f), MillimetersToInches(181.0f));
            printDoc.DefaultPageSettings.PaperSize = customPaperSize;

            int partNameSize = "COMPRESSOR HOUSING".Length > 25 ? 12 : 18;
            int partNameY = "COMPRESSOR HOUSING".Length > 25 ? 75 : 80;
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.PrintPage += (sender, e) =>
            {

                QRCodeGenerator generator = new QRCodeGenerator();
                generator.DrawQRCode(e.Graphics, tagqgate , 582, 11, 85, 85); // TOP
                generator.DrawQRCode(e.Graphics, tagqgate , 5, 205, 80, 80); // button left
                generator.DrawQRCode(e.Graphics, id_product, 585, 201, 80, 80); // button right


                Pen aPen = new Pen(Color.Black);
                aPen.Width = 2.5F;

                e.Graphics.DrawLine(aPen, 90, 4, 90, 291);
                e.Graphics.DrawLine(aPen, 570, 5, 570, 290);
                e.Graphics.DrawLine(aPen, 270, 139, 270, 240);
                e.Graphics.DrawLine(aPen, 410, 189, 410, 240);
                e.Graphics.DrawLine(aPen, 230, 240, 230, 290);
                e.Graphics.DrawLine(aPen, 350, 240, 350, 290);
                e.Graphics.DrawLine(aPen, 490, 240, 490, 290);
                e.Graphics.DrawLine(aPen, 680, 5, 680, 290);
                e.Graphics.DrawLine(aPen, 90, 5, 681, 5);
                e.Graphics.DrawLine(aPen, 90, 40, 570, 40);
                e.Graphics.DrawLine(aPen, 90, 100, 680, 100);
                e.Graphics.DrawLine(aPen, 90, 140, 680, 140);
                e.Graphics.DrawLine(aPen, 90, 190, 680, 190);
                e.Graphics.DrawLine(aPen, 90, 240, 570, 240);
                e.Graphics.DrawLine(aPen, 90, 290, 681, 290);


                e.Graphics.DrawString("TBKK", label5.Font, Brushes.Black, 10, 10);
                e.Graphics.DrawString("(Thailand) Co.,Ltd.", label6.Font, Brushes.Black, 10, 40);
                e.Graphics.DrawString("To", label13.Font, Brushes.Black, 100, 10);
                e.Graphics.DrawString(Sendto, label1.Font, Brushes.Black, 140, 16);
                e.Graphics.DrawString("PART NO", label13.Font, Brushes.Black, 100, 50);
                e.Graphics.DrawString(operationData.partnotagfa, label10.Font, Brushes.Black, 140, 65);
                e.Graphics.DrawString("PART NAME", label13.Font, Brushes.Black, 100, 100);
                e.Graphics.DrawString(operationData.partNoName, label1.Font, Brushes.Black, 140, 116);
                e.Graphics.DrawString("PROCESS", label13.Font, Brushes.Black, 575, 100);
                e.Graphics.DrawString("Q-GATE", label1.Font, Brushes.Black, 585, 116);
                e.Graphics.DrawString("MODEL", label13.Font, Brushes.Black, 100, 145);
                e.Graphics.DrawString(operationData.model, label1.Font, Brushes.Black, 140, 165);
                e.Graphics.DrawString("CUSTOMER PART NO.", label13.Font, Brushes.Black, 275, 145);
                e.Graphics.DrawString(custPartNo, label1.Font, Brushes.Black, 295, 165);
                e.Graphics.DrawString("LOCATION", label13.Font, Brushes.Black, 575, 145);
                e.Graphics.DrawString(location, label1.Font, Brushes.Black, 585, 165);
                e.Graphics.DrawString("QTY", label8.Font, Brushes.Black, 100, 190);

                //if (flgprint == "normalprint" || flgprint == "reprint")
                //{
                e.Graphics.DrawString(operationData.partsnp, label12.Font, Brushes.Black, 160, 186);
                //}

                e.Graphics.DrawString("BOX NO.", label13.Font, Brushes.Black, 275, 193);
                e.Graphics.DrawString(int.Parse(boxNo).ToString() , label10.Font, Brushes.Black, 320, 209);
                e.Graphics.DrawString("CHECK DATE | LOT NO.", title.Font, Brushes.Black, 415, 193);
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy") + " | " + qgateScanTag.genLot(DateTime.Now) , values.Font, Brushes.Black, 415, 213);
                e.Graphics.DrawString("PROD. LOT NO.", label13.Font, Brushes.Black, 100, 245);
                e.Graphics.DrawString(operationData.partlotno, label10.Font, Brushes.Black, 140, 255);
                e.Graphics.DrawString("SHIFT", label13.Font, Brushes.Black, 235, 245);
                e.Graphics.DrawString(operationData.partworkshift, label10.Font, Brushes.Black, 278, 255);
                e.Graphics.DrawString("LINE", label13.Font, Brushes.Black, 360, 245);
                e.Graphics.DrawString(operationData.partline, label1.Font, Brushes.Black, 380, 262);
                e.Graphics.DrawString("PHASE", label13.Font, Brushes.Black, 492, 245);
                e.Graphics.DrawString("10", label1.Font, Brushes.Black, 516, 262);


            };

            printPreviewDialog1.Document = printDoc;
            printPreviewDialog1.ShowDialog();

            /*printDoc.Print();

            qgateScanTag scanTag = new qgateScanTag();
            scanTag.Show();
            this.Hide();*/

        }









    }
}
