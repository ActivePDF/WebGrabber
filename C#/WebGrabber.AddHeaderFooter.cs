// Copyright (c) 2019 ActivePDF, Inc.
// ActivePDF WebGrabber 2016
// Example generated 04/16/19 

using System;

// Make sure to add the ActivePDF product .NET DLL(s) to your application.
// .NET DLL(s) are typically found in the products 'bin' folder.

class Examples
{
    public static void Example()
    {
        string strPath = System.AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/");

        // Instantiate Object
        APWebGrabber.WebGrabber oWG = new APWebGrabber.WebGrabber();

        // Enable extra logging (logging should only be used while troubleshooting)
        // C:\ProgramData\activePDF\Logs\
        oWG.Debug = true;

        // Add a header and footer to the PDF output
        // Must use full paths to additional files
        // Using %cp% of %tp% in the HTML equals current and total page numbers
        oWG.FooterHeight = 0.5f;
        oWG.FooterHTML = "<html><body>";
        oWG.FooterHTML = "<div style='text-align: center;'>%cp% of %tp%</div>";
        oWG.FooterHTML = "</body></html>";

        DateTime now = DateTime.Now;
        oWG.HeaderHeight = 0.5f;
        oWG.HeaderHTML = "<html><body>";
        oWG.HeaderHTML = "<div style='float: left;'>ActivePDF.com</div>";
        oWG.HeaderHTML = $"<div style='float: right;'>{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}</div>";
        oWG.HeaderHTML = "</body></html>";

        // PDF output location and filename
        oWG.NewDocumentName = "WebGrabber.AddHeaderFooter.pdf";
        oWG.OutputDirectory = strPath;

        // HTML to convert
        // Examples:
        // http://domain.com/path/file.aspx
        // file:///c:/folder/file.html
        oWG.URL = $"file:///{strPath}ActivePDFExamples.html";

        // Perform the HTML to PDF conversion
        WebGrabberDK.Results.WebGrabberResult results = oWG.ConvertToPDF();
        if (results.WebGrabberStatus != WebGrabberDK.Results.WebGrabberStatus.Success)
        {
            ErrorHandler("ConvertToPDF", results, results.WebGrabberStatus.ToString());
        }

        // Release Object
        oWG = null;

        // Process Complete
        WriteResults("Done!");
    }

    // Error Handling
    public static void ErrorHandler(string strMethod, ADK.Results.Result results, string errorStatus)
    {
        WriteResults($"Error with {strMethod}");
        WriteResults(errorStatus);
        WriteResults(results.Details);
        if (results.Origin.Function != strMethod)
        {
            WriteResults($"{results.Origin.Class}.{results.Origin.Function}");
        }

        if (results.ResultException != null)
        {
            WriteResults(results.ResultException.StackTrace);
        }
    }

    public static void WriteResults(string content)
    {
        Console.WriteLine(content);
    }
}