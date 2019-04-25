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
oWG.NewDocumentName = "WebGrabber.OverwriteMethod.pdf"
oWG.OutputDirectory = strPath

' HTML to convert
' Examples:
' http://domain.com/path/file.aspx
' file:///c:/folder/file.html
oWG.URL = "http://samples.activepdf.com/webgrabber/basic/ActivePDFExamples.html"

' The below code will perform three conversions to demonstrate OverwriteMethod

' Perform the HTML to PDF conversion
' With OverwriteMethod set to Always an existing PDF with the same
' name will be overridden.
oWG.OverwriteMethod = 0
Set results = oWG.ConvertToPDF("127.0.0.1", 62625)
If results.WebGrabberStatus <> 0 Then
  ErrorHandler "ConvertToPDF", results, results.WebGrabberStatus
End If

' With OverwriteMethod set to Never if a PDF with the same
' name exists the ConvertToPDF function will return an error.
' This should return an error since the previous call to 
' ConvertToPDF should have created an OverwriteMethod.pdf
oWG.OverwriteMethod = 2
Set results = oWG.ConvertToPDF("127.0.0.1", 62625)

' With OverwriteMethod set to AlterFilename if an existing PDF
' with the same exists the output file name will be incremented.
oWG.OverwriteMethod = 3
Set results = oWG.ConvertToPDF("127.0.0.1", 62625)
If results.WebGrabberStatus <> 0 Then
  ErrorHandler "ConvertToPDF", results, results.WebGrabberStatus
End If

' With OverwriteMethod set to Concatenate if an existing PDF
' with the same exists the output file will be appeneded to the
' original file.
oWG.OverwriteMethod = 1
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