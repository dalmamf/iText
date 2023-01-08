﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuPDFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialise the MuPDF context. This is needed to open or create documents.
            MuPDFContext ctx = new MuPDFContext();

            //Open a PDF document
            MuPDFDocument doc1 = new MuPDFDocument(ctx, "Document1.pdf");

            //Save the page as a PNG image with transparency, at a 1x zoom level (1pt = 1px).
            doc1.SaveImage(0, 1, PixelFormats.RGBA, "Raster1.png", RasterOutputFileTypes.PNG);

            //Open an Open XPS document
            MuPDFDocument doc2 = new MuPDFDocument(ctx, "Document2.oxps");

            //Save only part of the page as a PNG image with transparency, at a 2x zoom level (1pt = 2px).
            doc2.SaveImage(0, new Rectangle(87, 360, 517, 790), 2, PixelFormats.RGBA, "Raster2.png", RasterOutputFileTypes.PNG);

            //Merge the two documents into a single document.
            MuPDFDocument.CreateDocument(ctx, "Merged.pdf", DocumentOutputFileTypes.PDF, true,

                //We take the full page from the first document
                (doc1.Pages[0], doc1.Pages[0].Bounds, 1),

                //We only take a region of the page from the second document
                (doc2.Pages[0], new Rectangle(87, 360, 517, 790), 1)
            );

            //Open the rasterised page so that we can try using the OCR.
            MuPDFDocument doc3 = new MuPDFDocument(ctx, "Raster1.png");

            //Get a structured text representation of the page using OCR.
            MuPDFStructuredTextPage page = doc3.GetStructuredTextPage(0, new TesseractLanguage(TesseractLanguage.Fast.Eng));

            //Print all the text lines.
            foreach (MuPDFStructuredTextBlock blk in page)
            {
                foreach (MuPDFStructuredTextLine line in blk)
                {
                    System.Console.WriteLine(line.Text);
                }
            }
        }
    }
}
