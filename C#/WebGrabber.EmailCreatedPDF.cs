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
            webgrabber.NewDocumentName = "WebGrabber.EmailCreated.pdf";
            webgrabber.OutputDirectory = strPath;

            // Add an email
            webgrabber.AddEMail();

            // Set server information
            webgrabber.SetSMTPInfo("#.#.#.#", 25);
            webgrabber.SetSMTPCredentials("credentials.ame", "Domain", "password");

            // Set email addresses
            webgrabber.SetSenderInfo("Sender Name", "sender.email@asdidlwenra.com");
            webgrabber.SetReplyToInfo("ReplyTo Name", "replyto.name@asdidlwenra.com");
            webgrabber.SetRecipientInfo("Recipient Name", "recipient.name@asdidlwenra.com");
            webgrabber.AddToCC("CC Name", "cc.name@asdidlwenra.com");
            webgrabber.AddToBcc("BCC Name", "bcc.name@asdidlwenra.com");

            // Subject and Body
            webgrabber.EMailSubject = "PDF Delivery from activePDF";
            webgrabber.SetEMailBody("<html><body style='background-color: #EEE; padding: 4px;'>Here is your PDF!</body></html>", true);

            // Attachments - Binary attachments can be added with AddEMailBinaryAttachment
            webgrabber.AddEMailAttachment(strPath + "x.pdf");

            // Other email options
            webgrabber.EMailReadReceipt = false;
            webgrabber.EMailAttachOutput = true;

            // HTML to convert
            // Examples:
            // http://domain.com/path/file.aspx
            // file:///c:/folder/file.html
            webgrabber.URL = "http://samples.activepdf.com/webgrabber/basic/ActivePDFExamples.html";

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