using Aspose.Pdf;
using Aspose.Pdf.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose
{
    internal class Program
    {
        private static readonly string _dataDir = @"Resources\";

        static void Main(string[] args)
        {
            Document document = new Document(_dataDir + "generic-invoice.pdf");
            Resolution resolution = new Resolution(300);
            JpegDevice jpegDevice = new JpegDevice(resolution);
            ConvertPDFtoImage(jpegDevice, "jpeg", document);
        }

        public static void ConvertPDFtoImage(ImageDevice imageDevice,
        string ext, Document pdfDocument)
        {
            for (int pageCount = 1; pageCount <= pdfDocument.Pages.Count; pageCount++)
            {
                using (FileStream imageStream =
                new FileStream($"{_dataDir}image{pageCount}_out.{ext}",
                FileMode.Create))
                {
                    // Convert a particular page and save the image to stream
                    imageDevice.Process(pdfDocument.Pages[pageCount], imageStream);

                    // Close stream
                    imageStream.Close();
                }
            }
        }
    }
}
