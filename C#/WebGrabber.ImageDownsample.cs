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

            // Rendering engine used for the HTML
            // 0 = Native, 1 = IE
            // Image sampling is Internet Explorer only
            webgrabber.EngineToUse = APWebGrabberInterface.ConversionEngine.IE;

            // PDF output location and filename
            webgrabber.NewDocumentName = "WebGrabber.ImageDownsample.pdf";
            webgrabber.OutputDirectory = strPath;

            // Set the quality options for the created PDF (IE engine only)
            // For custom settings to take effect set the configuration to custom
            webgrabber.PredefinedSetting = ADK.PostScript.PredefinedConfiguration.Custom;

            // Automatically control the page orientation based on text flow
            webgrabber.AutoRotate = true;

            // Specifies if CMYK colors should be converted to RGB
            webgrabber.ConvertCMYKToRGB = true;

            // Set the DPI for the created PDF
            webgrabber.Resolution = 300.0f;

            // Color Image Quality Settings
            webgrabber.ColorImageDownsampleThreshold = 1;
            webgrabber.ColorImageDownsampleType = ADK.PostScript.Images.DownsampleOption.None;
            webgrabber.ColorImageFilter = ADK.PostScript.Images.CompressionOption.FlateEncode;
            webgrabber.ColorImageResolution = 72;

            // Gray Image Quality Settings
            webgrabber.GrayImageDownsampleThreshold = 1;
            webgrabber.GrayImageDownsampleType = ADK.PostScript.Images.DownsampleOption.None;
            webgrabber.GrayImageFilter = ADK.PostScript.Images.CompressionOption.FlateEncode;
            webgrabber.GrayImageResolution = 72;

            // Monochrome Image Quality Settings
            webgrabber.MonoImageDownsampleThreshold = 1;
            webgrabber.MonoImageDownsampleType = ADK.PostScript.Images.DownsampleOption.None;
            webgrabber.MonoImageFilter = ADK.PostScript.Images.MonochromeCompression.FlateEncode;
            webgrabber.MonoImageResolution = 72;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            webgrabber.URL = "http://samples.activepdf.com/webgrabber/images/ActivePDFImageExample.html";

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
