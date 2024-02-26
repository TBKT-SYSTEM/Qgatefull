using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using System.Drawing.Printing;


namespace QGate_system
{
    public partial class PrintTagDefect : Form
    {
        private string part_no = "NO_DATA";
        private string PART_NAME = "NO_DATA";
        private string Model = "NO_DATA";
        private string LOT_NO = "NO_DATA";
        private string LOT_PRODUCTION = "No_DATA";
        private int BOX_NO = 0;
        private string SHIFT = "NO_DATA";
        private string QTY = "NO_DATA";
        private string LINE = "NO_DATA";
        private string CHECK_DATE = "NO_DATA";
        private string M_BOX = "NO_DATA";
        private string NEW_QR = "NO_DATA";
        private string box_seq = "NO_DATA";
        private string new_gen_qr = "NO_DATA";
        private string QR_PRODUCT = "NO_DATA";
        private string WASHING_DATE = "NO DATA";
        private string CUST_ITEM_CD = "NO DATA";
        private string location = "NO DATA";
        private string date_check_q_gate = "dd/MM/yyyy";
        private string qrtagdefect = "NO DATA";
        private string defectcode = "NO DATA";
        private string typeproduct = "NO DATA";

        PrintDocument printDoc = new PrintDocument();
        operationData operationData = operationData.Instance;

        public PrintTagDefect()
        {
            InitializeComponent();
        }

        private int MillimetersToInches(float millimeters)
        {
            const float inchesPerMillimeter = 0.0393701f;
            return (int)(millimeters * inchesPerMillimeter * 100);
        }

        public void printTagQgate(string tagqgateDefect, string tagDefectDetil, string typeDefect,string boxNo,string location)
        {
            typeproduct = typeDefect;
            //typeproduct = "NC";
            MessageBox.Show("type Defect : " + typeproduct);

            QRCodeGenerator generator = new QRCodeGenerator();
            qgateScanTag qgateScanTag = new qgateScanTag();

            PaperSize customPaperSize = new PaperSize("Custom", MillimetersToInches(79.0f), MillimetersToInches(181.0f));
            printDoc.DefaultPageSettings.PaperSize = customPaperSize;

            int partNameSize = "COMPRESSOR HOUSING".Length > 25 ? 12 : 18;
            int partNameY = "COMPRESSOR HOUSING".Length > 25 ? 75 : 80;
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.PrintPage += (sender, e) =>
            {
                
                generator.DrawQRCode(e.Graphics, tagqgateDefect, 595, 198, 75, 75);
                generator.DrawQRCode(e.Graphics, tagqgateDefect, 25, 15, 75, 75);
                generator.DrawQRCode(e.Graphics, tagDefectDetil, 25, 128, 75, 75);

                Pen aPen = new Pen(Color.Black);

                Pen blackPen = new Pen(Color.Black, 2);
                e.Graphics.DrawLine(Pens.Azure, 10, 10, 20, 20);
                aPen.Width = 3.0F; // border 


                e.Graphics.DrawLine(aPen, 9, 5, 9, 280); // แก้ตำแหน่งที่ 1 , 3 เส้นเปิด NC/NG
                e.Graphics.DrawLine(aPen, 120, 5, 120, 230); // แก้ตำแหน่งที่ 1 , 3 เส้นเปิด NC/NG
                e.Graphics.DrawLine(aPen, 680, 5, 680, 250); // แก้ตำแหน่งที่ 1 , 3 เส้นปิด NC/NG
                e.Graphics.DrawLine(aPen, 560, 5, 560, 192); // แก้ตำแหน่งที่ 1 , 3 เส้นปิด NC/NG
                e.Graphics.DrawLine(aPen, 425, 100, 425, 192); // แก้ตำแหน่งที่ 1 , 3 เส้นปิด NC/NG
                e.Graphics.DrawLine(aPen, 320, 190, 320, 230); // แก้ตำแหน่งที่ 1 , 3 เส้นปิด NC/NG
                e.Graphics.DrawLine(aPen, 460, 190, 460, 230); // แก้ตำแหน่งที่ 1 , 3 เส้นปิด NC/NG
                e.Graphics.DrawLine(aPen, 585, 190, 585, 280); // แก้ตำแหน่งที่ 1 , 3 เส้นปิด NC/NG
                e.Graphics.DrawLine(aPen, 680, 5, 680, 280); // แก้ตำแหน่งที่ 1 , 3 เส้นปิด NC/NG
                e.Graphics.DrawLine(aPen, 8, 5, 681, 5); // แก้ตำแหน่งที่ 2 , 4
                e.Graphics.DrawLine(aPen, 120, 55, 560, 55); // แก้ตำแหน่งที่ 2 , 4 part no
                e.Graphics.DrawLine(aPen, 120, 100, 681, 100); // แก้ตำแหน่งที่ 2 , 4 part name
                e.Graphics.DrawLine(aPen, 120, 145, 681, 145); // แก้ตำแหน่งที่ 2 , 4 model
                e.Graphics.DrawLine(aPen, 120, 190, 681, 190); // แก้ตำแหน่งที่ 2 , 4 Actual Date
                e.Graphics.FillRectangle(Brushes.Black, 10, 100, 110, 20); // background back
                e.Graphics.DrawString("INFO.", IN_FO.Font, Brushes.White, 46, 101);
                e.Graphics.FillRectangle(Brushes.Black, 10, 210, 110, 20); // background back
                e.Graphics.DrawString("DEFECT QR.", IN_FO.Font, Brushes.White, 16, 214);
                e.Graphics.DrawLine(aPen, 8, 230, 587, 230); // แก้ตำแหน่งที่ 2 , 4


                //e.Graphics.FillRectangle(Brushes.Black, 560, 5, 122, 97); // NG/NC BACKGROUD Black
                //e.Graphics.DrawString(typeproduct, Label1.Font, Brushes.White, 560, 20); // left top


                // MsgBox(sDefect)
                // e.Graphics.DrawString(typeproduct, Label1.Font, Brushes.Black, 560, 20)

                /**/
                if (typeproduct == "NG")
                {
                    e.Graphics.FillRectangle(Brushes.Black, 560, 5, 122, 97); // NG/NC BACKGROUD Black
                    e.Graphics.DrawString("NG", Label1.Font, Brushes.White, 547, 1); // left top
                }
                else if (typeproduct == "NC")
                {
                    //e.Graphics.FillRectangle(Brushes.Black, 560, 5, 122, 97); // NG/NC BACKGROUD Black
                    //e.Graphics.FillRectangle(Brushes.White, 10, 100, 110, 20); // background back
                    e.Graphics.DrawString("NC", Label1.Font, Brushes.Black, 547, 1); // left top
                }

                e.Graphics.DrawLine(aPen, 8, 280, 681, 280); // แก้ตำแหน่งที่ 2 , 4 // Details
                e.Graphics.DrawString("PART NO:", title.Font, Brushes.Black, 130, 10);
                e.Graphics.DrawString(operationData.partnotagfa, values.Font, Brushes.Black, 150, 31);
                e.Graphics.DrawString("PART NAME:", title.Font, Brushes.Black, 130, 60);
                e.Graphics.DrawString(operationData.partNoName, values.Font, Brushes.Black, 150, 78);
                e.Graphics.DrawString("MODEL:", title.Font, Brushes.Black, 130, 105);
                e.Graphics.DrawString(operationData.model, values.Font, Brushes.Black, 150, 122);
                e.Graphics.DrawString("LINE:", title.Font, Brushes.Black, 430, 105);
                e.Graphics.DrawString(operationData.partline, values.Font, Brushes.Black, 460, 122);
                e.Graphics.DrawString("LOT NO:", title.Font, Brushes.Black, 570, 105);
                e.Graphics.DrawString(qgateScanTag.genLot(DateTime.Now), values.Font, Brushes.Black, 610, 122);
                e.Graphics.DrawString("ACTUAL DATE : ", title.Font, Brushes.Black, 130, 150);
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), values.Font, Brushes.Black, 150, 167);
                e.Graphics.DrawString("LOCATION :", title.Font, Brushes.Black, 430, 150);
                e.Graphics.DrawString(location, values.Font, Brushes.Black, 445, 167);
                e.Graphics.DrawString("SHIFT : ", title.Font, Brushes.Black, 130, 197);
                e.Graphics.DrawString(operationData.partworkshift, values.Font, Brushes.Black, 191, 210);
                e.Graphics.DrawString("PHASE :", title.Font, Brushes.Black, 325, 197);
                e.Graphics.DrawString("10", values.Font, Brushes.Black, 390, 210);
                e.Graphics.DrawString("BOX NO :", title.Font, Brushes.Black, 470, 197);
                e.Graphics.DrawString(boxNo, values.Font, Brushes.Black, 510, 210);
                e.Graphics.DrawString("DEFECT CODE :", detail_code.Font, Brushes.Black, 15, 236);
                e.Graphics.DrawString(tagDefectDetil, values.Font, Brushes.Black, 130, 236);

                int i = 1;
                int cNumber = 1;
                string dataDefect = " "; 
                string dataQrdefectcodedetails = "";
                int mgtop = 250;
                int mgleft = 15;

                e.Graphics.DrawString(dataDefect, detail_code.Font, Brushes.Black, mgleft, mgtop);
                e.Graphics.DrawString("QTY :", title.Font, Brushes.Black, 570, 150);
                e.Graphics.DrawString(QTY, values.Font, Brushes.Black, 610, 167);
                //MessagingToolkit.QRCode.Codec.QRCodeEncoder qrcode = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
                /*qrcode.QRCodeScale = 10;
                Bitmap bitmap_qr_box = qrcode.Encode(qrtagdefect);
                Bitmap bitmap_qr_product = qrcode.Encode(QR_PRODUCT);
                e.Graphics.DrawImage(bitmap_qr_box, 595, 198, 75, 75); // button right
                e.Graphics.DrawImage(bitmap_qr_box, 25, 15, 75, 75); // top left
                e.Graphics.DrawImage(bitmap_qr_product, 25, 128, 75, 75); // button right*/
            };

            printPreviewDialog1.Document = printDoc;
            printPreviewDialog1.ShowDialog();

            //printPreviewDialog1.Document = printDoc;
            //printPreviewDialog1.ShowDialog();

            //printDocument1.Print();

        }

    }
}
