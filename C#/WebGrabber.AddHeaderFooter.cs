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
            string strPath =
               System.AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/");

            // Instantiate Object
            APWebGrabber.WebGrabber webgrabber = new APWebGrabber.WebGrabber();

            // Enable extra logging (logging should only be used while
            // troubleshooting) C:\ProgramData\activePDF\Logs\
            webgrabber.Debug = true;

            // Add a header and footer to the PDF output
            // Must use full paths to additional files
            // Using %cp% of %tp% in the HTML equals current and total page numbers
            webgrabber.FooterHeight = 0.5f;
            webgrabber.FooterHTML = "<html><body>";
            webgrabber.FooterHTML =
                "<div style='text-align: center;'>%cp% of %tp%</div>";
            webgrabber.FooterHTML = "</body></html>";

            DateTime now = DateTime.Now;
            webgrabber.HeaderHeight = 0.5f;
            webgrabber.HeaderHTML = "<html><body>";
            webgrabber.HeaderHTML
                = "<div style='float: left;'>ActivePDF.com</div>";
            webgrabber.HeaderHTML = $"<div style='float: right;'>{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}</div>";
            webgrabber.HeaderHTML = "</body></html>";

            // PDF output location and filename
            webgrabber.NewDocumentName = "WebGrabber.AddHeaderFooter.pdf";
            webgrabber.OutputDirectory = strPath;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            webgrabber.URL = "http://samples.activepdf.com/webgrabber/basic/ActivePDFExamples.html";

            // Perform the HTML to PDF conversion
            WebGrabberDK.Results.WebGrabberResult result =
                webgrabber.ConvertToPDF();

            // Output result
            WriteResult(result);

            // Process Complete
            Console.WriteLine("Done!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static void WriteResult(WebGrabberDK.Results.WebGrabberResult Result)
        {
            Console.WriteLine($"WebGrabber Status: {Result.WebGrabberStatus}");
            if (Result.WebGrabberStatus != WebGrabberDK.Results.WebGrabberStatus.Success)
            {
                Console.WriteLine($"Result Origin: {Result.Origin.Class}.{Result.Origin.Function}");
                if (!String.IsNullOrEmpty(Result.Details))
                {
                    Console.WriteLine($"Result Details: {Result.Details}");
                }
                if (Result.ResultException != null)
                {
                    Console.WriteLine("Exception caught during conversion.");
                    Console.WriteLine($"Excpetion Details: {Result.ResultException.Message}");
                    Console.WriteLine($"Exception Stack Trace: {Result.ResultException.StackTrace}");
                }
            }
        }
    }
}