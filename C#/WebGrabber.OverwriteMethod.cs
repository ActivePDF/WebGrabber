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
            oWG.NewDocumentName = "WebGrabber.OverwriteMethod.pdf";
            oWG.OutputDirectory = strPath;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            oWG.URL = $"file:///{strPath}ActivePDFExamples.html";

            // With OverwriteMethod set to Always an existing PDF with the same
            // name will be overridden.
            oWG.OverwriteMethod = ADK.Conversion.OverwriteMethod.Always;
            WebGrabberDK.Results.WebGrabberResult result = oWG.ConvertToPDF();
            if (result.WebGrabberStatus != WebGrabberDK.Results.WebGrabberStatus.Success)
            {
                ErrorHandler(result);
            }

            // With OverwriteMethod set to Never if a PDF with the same
            // name exists the ConvertToPDF function will return an error.
            // This should return an error since the previous call to 
            // ConvertToPDF should have created an OverwriteMethod.pdf
            oWG.OverwriteMethod = ADK.Conversion.OverwriteMethod.Never;
            result = oWG.ConvertToPDF();

            // With OverwriteMethod set to AlterFilename if an existing PDF
            // with the same exists the output file name will be incremented.
            oWG.OverwriteMethod = ADK.Conversion.OverwriteMethod.AlterFilename;
            result = oWG.ConvertToPDF();
            if (result.WebGrabberStatus != WebGrabberDK.Results.WebGrabberStatus.Success)
            {
                ErrorHandler(result);
            }

            // With OverwriteMethod set to Concatenate if an existing PDF
            // with the same exists the output file will be appeneded to the
            // original file.
            oWG.OverwriteMethod = ADK.Conversion.OverwriteMethod.Concatenate;
            result = oWG.ConvertToPDF();
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