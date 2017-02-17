<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom Xml - Render - VB.NET Example</title>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom Xml - Render - VB.NET Example</h3>
            
            <aspSample:CustomXmlRender id="xml1" runat="server" 
             DocumentSource="People.xml" TransformSource="PeopleTable.xslt" />
        </form>
    </body>
</html>