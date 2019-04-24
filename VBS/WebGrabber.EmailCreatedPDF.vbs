' Copyright (c) 2019 ActivePDF, Inc.
' ActivePDF WebGrabber 2016
' Example generated 04/16/19 

Dim FSO, strPath, results

' Get current path
Set FSO = CreateObject("Scripting.FileSystemObject")
strPath = FSO.GetFile(Wscript.ScriptFullName).ParentFolder & "\"
Set FSO = Nothing

' Instantiate Object
Set oWG = CreateObject("APWebGrabber.Object")

' Enable extra logging (logging should only be used while troubleshooting)
' C:\ProgramData\activePDF\Logs\
oWG.Debug = true

' PDF output location and filename
oWG.NewDocumentName = "WebGrabber.Email.pdf"
oWG.OutputDirectory = strPath

' Add an email
oWG.AddEMail

' Set server information
oWG.SetSMTPInfo "#.#.#.#", 25
oWG.SetSMTPCredentials "credentials.ame", "Domain", "password"

' Set email addresses
oWG.SetSenderInfo "Sender Name", "sender.email@asdidlwenra.com"
oWG.SetReplyToInfo "ReplyTo Name", "replyto.name@asdidlwenra.com"
oWG.SetRecipientInfo "Recipient Name", "recipient.name@asdidlwenra.com"
oWG.AddToCC "CC Name", "cc.name@asdidlwenra.com"
oWG.AddToBcc "BCC Name", "bcc.name@asdidlwenra.com"

' Subject and Body
oWG.EMailSubject = "PDF Delivery from activePDF"
oWG.SetEMailBody "<html><body style='background-color: #EEE; padding: 4px;'>Here is your PDF!</body></html>", true

' Attachments - Binary attachments can be added with AddEMailBinaryAttachment
oWG.AddEMailAttachment strPath + "x.pdf"

' Other email options
oWG.EMailReadReceipt = False
oWG.EMailAttachOutput = True

' HTML to convert
' Examples:
' http://domain.com/path/file.aspx
' file:///c:/folder/file.html
oWG.URL = "file:///" & strPath & "ActivePDFExamples.html"

' Perform the HTML to PDF conversion
Set results = oWG.ConvertToPDF("127.0.0.1", 62625)
If results.WebGrabberStatus <> 0 Then
  ErrorHandler "ConvertToPDF", results, results.WebGrabberStatus
End If

' Release Object
Set oWG = Nothing

' Process Complete
Wscript.Echo("Done!")

' Error Handling
Sub ErrorHandler(method, oResult, errorStatus)
  Wscript.Echo("Error with " & method & ": " & vbcrlf _
    & errorStatus & vbcrlf _
    & oResult.details)
  Wscript.Quit 1
End Sub