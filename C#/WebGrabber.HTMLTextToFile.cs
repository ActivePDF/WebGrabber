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
            WebGrabberDK.Results.WebGrabberResult results;

            // Instantiate Object
            APWebGrabber.WebGrabber oWG = new APWebGrabber.WebGrabber();

            // Enable extra logging (logging should only be used while troubleshooting)
            // C:\ProgramData\activePDF\Logs\
            oWG.Debug = true;

            // Save the HTML text into a file before conversion
            oWG.HTMLTextToFile = true;

            // HTML to convert
            oWG.CreateFromHTMLText = "<html><body>";
            oWG.CreateFromHTMLText = "Hello World!";
            oWG.CreateFromHTMLText = "</body></html>";

            // PDF output location and filename
            oWG.NewDocumentName = "WebGrabber.HTMLTextToFile.pdf";
            oWG.OutputDirectory = strPath;

            // Perform the HTML to PDF conversion
            results = oWG.ConvertToPDF();
            if (results.WebGrabberStatus != WebGrabberDK.Results.WebGrabberStatus.Success)
            {
                ErrorHandler("ConvertToPDF", results, results.WebGrabberStatus.ToString());
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