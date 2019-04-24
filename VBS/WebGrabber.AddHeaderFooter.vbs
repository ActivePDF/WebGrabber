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
oWG.OutputDirectory = strPath
oWG.NewDocumentName = "WebGrabber.AddHeaderFooter.pdf"

' Add a header and footer to the PDF output
' Must use full paths to additional files
' Using %cp% of %tp% in the HTML equals current and total page numbers
oWG.HeaderHTML = "<html><body>"
oWG.HeaderHTML = "<div style='float: left;'>activePDF.com</div>"
oWG.HeaderHTML = "<div style='float: right;'>04/16/2019 04:44PM</div>"
oWG.HeaderHTML = "</body></html>"
oWG.HeaderHeight = 0.5

oWG.FooterHTML = "<html><body>"
oWG.FooterHTML = "<div style='text-align: center;'>%cp% of %tp%</div>"
oWG.FooterHTML = "</body></html>"
oWG.FooterHeight = 0.5

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