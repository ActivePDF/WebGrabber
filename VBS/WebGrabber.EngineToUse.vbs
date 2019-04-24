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

' Rendering engine used for the HTML
' 0 = Native, 1 = IE
oWG.EngineToUse = 0

' PDF output location and filename
oWG.NewDocumentName = "WebGrabber.EngineToUse.pdf"
oWG.OutputDirectory = strPath

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