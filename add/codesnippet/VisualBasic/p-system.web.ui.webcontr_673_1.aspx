<%@ page language="VB" %>
<%@ register tagprefix="aspSample" 
             Namespace="Samples.AspNet.VB.Controls" 
             Assembly="TextDisplayWebPartVB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    
    label1.Text = "Verb Count = " & _
      textwebpart.Verbs.Count.ToString()
    
  End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="Form1" runat="server">
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server"
      title="Zone 1"
      PartChromeType="TitleAndBorder">
        <parttitlestyle font-bold="true" ForeColor="#3300cc" />
        <partstyle
          borderwidth="1px"   
          borderstyle="Solid"  
          bordercolor="#81AAF2" />
        <zonetemplate>
          <aspSample:TextDisplayWebPart 
            runat="server"   
            id="textwebpart" 
            title = "Text Content WebPart" 
            ExportMode="all" />        
        </zonetemplate>
    </asp:webpartzone>
    <asp:Button ID="button1" Runat="server" 
      Text="Display Verb Count" OnClick="button1_Click" />
    <asp:Label ID="label1" Runat="server" />
  </form>
</body>
</html>