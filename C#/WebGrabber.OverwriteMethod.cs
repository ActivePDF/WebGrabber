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

            // PDF output location and filename
            webgrabber.NewDocumentName = "WebGrabber.OverwriteMethod.pdf";
            webgrabber.OutputDirectory = strPath;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            webgrabber.URL = "http://samples.activepdf.com/webgrabber/basic/ActivePDFExamples.html";

            // With OverwriteMethod set to Always an existing PDF with the same
            // name will be overridden.
            webgrabber.OverwriteMethod = ADK.Conversion.OverwriteMethod.Always;
            WebGrabberDK.Results.WebGrabberResult result = webgrabber.ConvertToPDF();
            if (result.WebGrabberStatus != WebGrabberDK.Results.WebGrabberStatus.Success)
            {
                WriteResult(result);
            }

            // With OverwriteMethod set to Never if a PDF with the same
            // name exists the ConvertToPDF function will return an error.
            // This should return an error since the previous call to 
            // ConvertToPDF should have created an OverwriteMethod.pdf
            webgrabber.OverwriteMethod = ADK.Conversion.OverwriteMethod.Never;
            result = webgrabber.ConvertToPDF();
            Console.WriteLine($"Overwrite Never Result: {result.WebGrabberStatus}");

            // With OverwriteMethod set to AlterFilename if an existing PDF
            // with the same exists the output file name will be incremented.
            webgrabber.OverwriteMethod = ADK.Conversion.OverwriteMethod.AlterFilename;
            result = webgrabber.ConvertToPDF();
            if (result.WebGrabberStatus != WebGrabberDK.Results.WebGrabberStatus.Success)
            {
                WriteResult(result);
            }

            // With OverwriteMethod set to Concatenate if an existing PDF
            // with the same exists the output file will be appeneded to the
            // original file.
            webgrabber.OverwriteMethod = ADK.Conversion.OverwriteMethod.Concatenate;
            result = webgrabber.ConvertToPDF();

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