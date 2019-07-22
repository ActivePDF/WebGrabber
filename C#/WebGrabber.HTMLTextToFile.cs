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
            // Instantiate Object
            APWebGrabber.WebGrabber webgrabber = new APWebGrabber.WebGrabber();

            // Enable extra logging (logging should only be used while troubleshooting)
            // C:\ProgramData\activePDF\Logs\
            webgrabber.Debug = true;

            // Save the HTML text into a file before conversion
            webgrabber.HTMLTextToFile = true;

            // HTML to convert
            webgrabber.CreateFromHTMLText = "<html><body>";
            webgrabber.CreateFromHTMLText = "Hello World!";
            webgrabber.CreateFromHTMLText = "</body></html>";

            // PDF output location and filename
            webgrabber.NewDocumentName = "WebGrabber.HTMLTextToFile.pdf";
            webgrabber.OutputDirectory = strPath;

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