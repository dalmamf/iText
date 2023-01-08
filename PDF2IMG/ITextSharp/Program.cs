using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //public static IEnumerable<System.Drawing.Image> ExtractImagesFromPDF(string sourcePdf)
        //{
        //    // NOTE:  This will only get the first image it finds per page.
        //    var pdf = new PdfReader(sourcePdf);
        //    var raf = new RandomAccessFileOrArray(sourcePdf);

        //    try
        //    {
        //        for (int pageNum = 1; pageNum <= pdf.NumberOfPages; pageNum++)
        //        {
        //            PdfDictionary pg = pdf.GetPageN(pageNum);

        //            // recursively search pages, forms and groups for images.
        //            PdfObject obj = ExtractImagesFromPDF_FindImageInPDFDictionary(pg);
        //            if (obj != null)
        //            {
        //                int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(CultureInfo.InvariantCulture));
        //                PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
        //                PdfStream pdfStrem = (PdfStream)pdfObj;
        //                PdfImageObject pdfImage = new PdfImageObject((PRStream)pdfStrem);
        //                System.Drawing.Image img = pdfImage.GetDrawingImage();
        //                yield return img;
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        pdf.Close();
        //        raf.Close();
        //    }
        //}
    }
}
