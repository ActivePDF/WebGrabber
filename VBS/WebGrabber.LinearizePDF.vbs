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

' Fast web view
oWG.LinearizePDF = true
		
' PDF output location and filename
oWG.NewDocumentName = "WebGrabber.Linearize.pdf"
oWG.OutputDirectory = strPath

' HTML to convert
' Examples:
' http://domain.com/path/file.aspx
' file:///c:/folder/file.html
oWG.URL = "http://samples.activepdf.com/webgrabber/basic/ActivePDFExamples.html"

' Perform the HTML to PDF conversion
Set result = oWG.ConvertToPDF("127.0.0.1", 62625)

' Output conversion result
WriteResult result

' Process Complete
Wscript.Quit

Sub WriteResult(oResult)
  message = "Result Status: " & result.WebGrabberStatus
  If result.WebGrabberStatus = 0 Then
      message = message & ", Success!"
  Else
      message = message &", " & result.Details
  End If
  Wscript.Echo message
End Sub