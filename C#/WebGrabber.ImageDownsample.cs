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
            // Image sampling is Internet Explorer only
            oWG.EngineToUse = APWebGrabberInterface.ConversionEngine.IE;

            // PDF output location and filename
            oWG.NewDocumentName = "WebGrabber.ImageDownsample.pdf";
            oWG.OutputDirectory = strPath;

            // Set the quality options for the created PDF (IE engine only)
            // For custom settings to take effect set the configuration to custom
            oWG.PredefinedSetting = ADK.PostScript.PredefinedConfiguration.Custom;

            // Automatically control the page orientation based on text flow
            oWG.AutoRotate = true;

            // Specifies if CMYK colors should be converted to RGB
            oWG.ConvertCMYKToRGB = true;

            // Set the DPI for the created PDF
            oWG.Resolution = 300.0f;

            // Color Image Quality Settings
            oWG.ColorImageDownsampleThreshold = 1;
            oWG.ColorImageDownsampleType = ADK.PostScript.Images.DownsampleOption.None;
            oWG.ColorImageFilter = ADK.PostScript.Images.CompressionOption.FlateEncode;
            oWG.ColorImageResolution = 72;

            // Gray Image Quality Settings
            oWG.GrayImageDownsampleThreshold = 1;
            oWG.GrayImageDownsampleType = ADK.PostScript.Images.DownsampleOption.None;
            oWG.GrayImageFilter = ADK.PostScript.Images.CompressionOption.FlateEncode;
            oWG.GrayImageResolution = 72;

            // Monochrome Image Quality Settings
            oWG.MonoImageDownsampleThreshold = 1;
            oWG.MonoImageDownsampleType = ADK.PostScript.Images.DownsampleOption.None;
            oWG.MonoImageFilter = ADK.PostScript.Images.MonochromeCompression.FlateEncode;
            oWG.MonoImageResolution = 72;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            oWG.URL = $"file:///{strPath}ActivePDFImageExample.html";

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
