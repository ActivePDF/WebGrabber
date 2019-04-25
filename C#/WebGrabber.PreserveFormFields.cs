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

            // Rendering engine used for the HTML
            // 0 = Native, 1 = IE
            oWG.EngineToUse = APWebGrabberInterface.ConversionEngine.Native;

            // PDF output location and filename
            oWG.NewDocumentName = "WebGrabber.PreserveFormFields.pdf";
            oWG.OutputDirectory = strPath;

            // The WebGrabber native conveter will convert HTML fields to PDF
            // intelligent forms by default, you can enable/disable this with
            // the below settings. (Native engine only)
            oWG.PreserveButtons = true;
            oWG.PreserveCheckBoxes = true;
            oWG.PreserveDropDowns = true;
            oWG.PreserveRadioButtons = true;
            oWG.PreserveTextBoxes = true;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            oWG.URL = "http://samples.activepdf.com/webgrabber/FormFields/ActivePDFFormFields.html"

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