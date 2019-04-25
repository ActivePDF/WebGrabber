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
oWG.EngineToUse = 1

' PDF output location and filename
oWG.NewDocumentName = "WebGrabber.ImageDownsample.pdf"
oWG.OutputDirectory = strPath

' Set the quality options for the created PDF (IE engine only)
' For custom settings to take effect set the configuration to custom
oWG.PredefinedSetting = 0

' Specifies if ASCII85 encoding should be applied to binary streams
oWG.ASCIIEncode = true

' Automatically control the page orientation based on text flow
oWG.AutoRotate = true

' Specifies if CMYK colors should be converted to RGB
oWG.ConvertCMYKToRGB = true

' Set the DPI for the created PDF
oWG.Resolution = 300.0

' Color Image Quality Settings
oWG.ColorImageDownsampleThreshold = 1
oWG.ColorImageDownsampleType = 0
oWG.ColorImageFilter = 2
oWG.ColorImageResolution = 72

' Gray Image Quality Settings
oWG.GrayImageDownsampleThreshold = 1
oWG.GrayImageDownsampleType = 0
oWG.GrayImageFilter = 2
oWG.GrayImageResolution = 72

' Monochrome Image Quality Settings
oWG.MonoImageDownsampleThreshold = 1
oWG.MonoImageDownsampleType = 0
oWG.MonoImageFilter = 2
oWG.MonoImageResolution = 72

' Convert the HTML background (IE engine only)
oWG.PrintBackground = true

' HTML to convert
' Examples:
' http://domain.com/path/file.aspx
' file:///c:/folder/file.html
oWG.URL = "http://samples.activepdf.com/webgrabber/images/ActivePDFImageExample.html"

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