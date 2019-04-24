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
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory.Replace('\\', '/');

            // Instantiate Object
            APWebGrabber.WebGrabber oWG = new APWebGrabber.WebGrabber();

            // Rendering engine used for the HTML
            // 0 = Native, 1 = IE
            oWG.EngineToUse = APWebGrabberInterface.ConversionEngine.Native;

            // Send HTTP post data to the URL
            oWG.AddHTTPPostData("input_name_first=John");
            oWG.AddHTTPPostData("input_name_last=Johnson");
            oWG.AddHTTPPostData("input_email=john.johnson@fakedomain.com");
            oWG.AddHTTPPostData("radio_gender=male");

            // Enable extra logging (logging should only be used while troubleshooting)
            // C:\ProgramData\activePDF\Logs\
            oWG.Debug = true;

            // PDF output location and filename
            oWG.NewDocumentName = "WebGrabber.AddHTTPPostData.pdf";
            oWG.OutputDirectory = strPath;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            oWG.URL = "http://localhost/AddHTTPPostData.asp";

            // Perform the HTML to PDF conversion - You need IIS installed to test
            // post data and the URL below expects the ASP page to be located in
            // the default website. "C:\inetpub\wwwroot"
            WebGrabberDK.Results.WebGrabberResult results = oWG.ConvertToPDF();
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