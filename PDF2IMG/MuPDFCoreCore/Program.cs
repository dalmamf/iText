using MuPDFCore;
using System;

namespace MuPDFCoreCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialise the MuPDF context. This is needed to open or create documents.
            using MuPDFContext ctx = new MuPDFContext();

            //Open a PDF document
            using MuPDFDocument document = new MuPDFDocument(ctx, "Resources\\generic-invoice.pdf");

            //Page index (page 0 is the first page of the document)
            int pageIndex = 0;

            //Zoom level, converting document units into pixels. For a PDF document, a 1x zoom level corresponds to a
            //72dpi resolution.
            double zoomLevel = 1;

            //Save the first page as a PNG image with transparency, at a 1x zoom level (1pt = 1px).
            document.SaveImage(pageIndex, zoomLevel, PixelFormats.RGB, "Resources\\sample.png", RasterOutputFileTypes.PNG);
        }
    }
}
