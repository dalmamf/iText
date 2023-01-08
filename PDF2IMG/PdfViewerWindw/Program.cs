using Syncfusion.Windows.Forms.PdfViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf.Parsing;
using System.Drawing;
using System.Drawing.Imaging;

namespace PdfViewerWindw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Convert();
        }

        public static void Convert()
        {
            //Initialize the PdfViewer Control
            PdfViewerControl pdfViewer = new PdfViewerControl();

            //Load the input PDF file
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("Resources\\generic-invoice.pdf");

            pdfViewer.Load(loadedDocument);

            //Export the particular PDF page as image at the page index of 0
            Bitmap image = pdfViewer.ExportAsImage(0);

            // Save the image.
            image.Save("Sample.jpg", ImageFormat.Jpeg);
        }
    }
}
