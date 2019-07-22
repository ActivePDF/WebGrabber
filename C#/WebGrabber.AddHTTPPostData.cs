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
            APWebGrabber.WebGrabber webgrabber = new APWebGrabber.WebGrabber();

            // Rendering engine used for the HTML
            // 0 = Native, 1 = IE
            webgrabber.EngineToUse = APWebGrabberInterface.ConversionEngine.Native;

            // Send HTTP post data to the URL
            webgrabber.AddHTTPPostData("input_name_first=John");
            webgrabber.AddHTTPPostData("input_name_last=Johnson");
            webgrabber.AddHTTPPostData("input_email=john.johnson@fakedomain.com");
            webgrabber.AddHTTPPostData("radio_gender=male");

            // Enable extra logging (logging should only be used while troubleshooting)
            // C:\ProgramData\activePDF\Logs\
            webgrabber.Debug = true;

            // PDF output location and filename
            webgrabber.NewDocumentName = "WebGrabber.AddHTTPPostData.pdf";
            webgrabber.OutputDirectory = strPath;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            webgrabber.URL = "http://localhost/AddHTTPPostData.asp";

            // Perform the HTML to PDF conversion - You need IIS installed to
            // test post data and the URL below expects the ASP page to be
            // located in the default website. "C:\inetpub\wwwroot"
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