<%@ Page Language="VB" AutoEventWireup="True" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RadioButtonList.RepeatColumns Example</title>
</head>
<body>

<asp:RadioButtonList id="RadioButtonList1"
      RepeatLayout="Table"
      RepeatColumns = "2" 
      runat="server">
 
    <asp:ListItem>Item 1</asp:ListItem>
    <asp:ListItem>Item 2</asp:ListItem>
    <asp:ListItem>Item 3</asp:ListItem>
    <asp:ListItem>Item 4</asp:ListItem>
    <asp:ListItem>Item 5</asp:ListItem>
    <asp:ListItem>Item 6</asp:ListItem>
 
 </asp:RadioButtonList>
</body>
</html>   