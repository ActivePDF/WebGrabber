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
            oWG.NewDocumentName = "WebGrabber.EmailCreated.pdf";
            oWG.OutputDirectory = strPath;

            // Add an email
            oWG.AddEMail();

            // Set server information
            oWG.SetSMTPInfo("#.#.#.#", 25);
            oWG.SetSMTPCredentials("credentials.ame", "Domain", "password");

            // Set email addresses
            oWG.SetSenderInfo("Sender Name", "sender.email@asdidlwenra.com");
            oWG.SetReplyToInfo("ReplyTo Name", "replyto.name@asdidlwenra.com");
            oWG.SetRecipientInfo("Recipient Name", "recipient.name@asdidlwenra.com");
            oWG.AddToCC("CC Name", "cc.name@asdidlwenra.com");
            oWG.AddToBcc("BCC Name", "bcc.name@asdidlwenra.com");

            // Subject and Body
            oWG.EMailSubject = "PDF Delivery from activePDF";
            oWG.SetEMailBody("<html><body style='background-color: #EEE; padding: 4px;'>Here is your PDF!</body></html>", true);

            // Attachments - Binary attachments can be added with AddEMailBinaryAttachment
            oWG.AddEMailAttachment(strPath + "x.pdf");

            // Other email options
            oWG.EMailReadReceipt = false;
            oWG.EMailAttachOutput = true;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            oWG.URL = "http://samples.activepdf.com/webgrabber/basic/ActivePDFExamples.html";

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