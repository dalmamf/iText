using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using QRCoder;

namespace AddQRToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            AddQR();
        }

        public static void AddQR()
        {
            string oldFile = @"Resource\generic-invoice.pdf";
            string newFile = @"Resource\newFile.pdf";

            // open the reader
            PdfReader reader = new PdfReader(oldFile);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            Image image = GetQR();
            image.ScalePercent(10);
            image.SetAbsolutePosition(130, 670);

            for (var i = 1; i <= reader.NumberOfPages; i++)
            {
                document.NewPage();

                var importedPage = writer.GetImportedPage(reader, i);
                var contentByte = writer.DirectContent;
                contentByte.AddImage(image);
                contentByte.AddTemplate(importedPage, 0, 0);
            }


            // close the streams
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();

            Process.Start(@"C:\Users\NewHotel\source\repos\AddQRToPdf\AddQRToPdf\bin\Debug\Resource\newfile.pdf");
        }

        public static Image GetQR()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(@"https://itextpdf.com/", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20);

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();

            Image image = Image.GetInstance((byte[])converter.ConvertTo(qrCodeImage, typeof(byte[])));
            return image;
        }
    }
}
