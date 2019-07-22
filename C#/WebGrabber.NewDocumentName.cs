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
            APWebGrabber.WebGrabber webgrabber = new APWebGrabber.WebGrabber();

            // Enable extra logging (logging should only be used while troubleshooting)
            // C:\ProgramData\activePDF\Logs\
            webgrabber.Debug = true;

            // If the name for the new document is not set using the below
            // line then a random name will be generated for the output PDF.
            //webgrabber.NewDocumentName = "WebGrabber.NewDocumentName.pdf";

            // PDF output location
            webgrabber.OutputDirectory = strPath;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            webgrabber.URL = "http://samples.activepdf.com/webgrabber/basic/ActivePDFExamples.html";

            // Perform the HTML to PDF conversion
            WebGrabberDK.Results.WebGrabberResult result =
                webgrabber.ConvertToPDF();

            // The generated output file name
            Console.WriteLine($"Output PDF File Name: {webgrabber.NewDocumentName}");

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