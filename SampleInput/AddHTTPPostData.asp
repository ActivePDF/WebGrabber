<body>
WebGrabber PostData
<br />
<%
response.write("First Name: " & request.querystring("input_name_first") & "<br />")
response.write("Last Name: " & request.querystring("input_name_last") & "<br />")
response.write("Email: " & request.querystring("input_email") & "<br />")
response.write("Gender: " & request.querystring("radio_gender") & "<br />")
%>
</body>