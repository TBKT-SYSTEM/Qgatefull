using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using System.Drawing;

namespace QGate_system
{
    class QRCodeGenerator
    {
        public void DrawQRCode(Graphics graphics, string data, int x, int y, int width, int height, bool isRotate = false)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = width,
                    Height = height,
                    Margin = 0,
                    NoPadding = true,
                    PureBarcode = false,
                }
            };

            Bitmap qrCodeBitmap = writer.Write(data);
            graphics.DrawImage(qrCodeBitmap, x, y, width, height);

        }

       
    }
}
