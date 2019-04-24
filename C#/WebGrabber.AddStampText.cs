// Copyright (c) 2019 ActivePDF, Inc.
// ActivePDF WebGrabber 2016
// Example generated 04/16/19 

using System;

// Make sure to add the ActivePDF product .NET DLL(s) to your application.
// .NET DLL(s) are typically found in the products 'bin' folder.

namespace WebGrabberExamples
{
    class Program
    {
        public static void Main()
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/");

            // Instantiate Object
            APWebGrabber.WebGrabber oWG = new APWebGrabber.WebGrabber();

            // Enable extra logging (logging should only be used while troubleshooting)
            // C:\ProgramData\activePDF\Logs\
            oWG.Debug = true;

            // PDF output location and filename
            oWG.NewDocumentName = "WebGrabber.AddTextStamp.pdf";
            oWG.OutputDirectory = strPath;

            // Stamp Images and Text onto the output PDF
            oWG.AddStampCollection("TXTinternal");
            oWG.StampFont = "Helvetica";
            oWG.StampFontSize = 108;
            oWG.StampFontTransparency = 0.1f;
            oWG.StampRotation = 45.0f;
            oWG.StampFillMode = ADK.PDF.FontFillMode.FillThenStroke;
            oWG.StampColorNET = new ADK.PDF.Color() { Red = 255, Green = 0, Blue = 0, Gray = 0 };
            oWG.StampStrokeColorNET = new ADK.PDF.Color() { Red = 100, Green = 0, Blue = 0, Gray = 0 };
            oWG.AddStampText(116.0f, 156.0f, "Internal Only");

            // Set whether the stamp collection(s) appears in the background or foreground
            oWG.StampBackground = 0;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            oWG.URL = $"file:///{strPath}ActivePDFExamples.html";

            // Perform the HTML to PDF conversion
            WebGrabberDK.Results.WebGrabberResult result = oWG.ConvertToPDF();
            if (result.WebGrabberStatus != WebGrabberDK.Results.WebGrabberStatus.Success)
            {
                ErrorHandler(result);
            }

            // Release Object
            oWG = null;

            // Process Complete
            Console.WriteLine("Done!");
        }

        // Error Handling
        public static void ErrorHandler(WebGrabberDK.Results.WebGrabberResult Result)
        {
            Console.WriteLine($"Error with {Result.Origin.Class}.{Result.Origin.Function}");
            Console.WriteLine($"Error Status: {Result.WebGrabberStatus}");
            Console.WriteLine($"Error Details: {Result.Details}");
            if (Result.ResultException != null)
            {
                Console.WriteLine("Exception caught during conversion.");
                Console.WriteLine($"Excpetion Details: {Result.ResultException.Message}");
                Console.WriteLine($"Exception Stack Trace: {Result.ResultException.StackTrace}");
            }
        }
    }
}