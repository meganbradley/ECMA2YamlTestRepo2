<%@ Page Language="VB" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Timer Example Page</title>
    <script runat="server">
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            OriginalTime.Text = DateTime.Now.ToLongTimeString()
        End Sub

        Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
            StockPrice.Text = GetStockPrice()
            TimeOfPrice.Text = DateTime.Now.ToLongTimeString()
        End Sub

        Private Function GetStockPrice() As String
            Dim randomStockPrice As Double = 50 + New Random().NextDouble()
            Return randomStockPrice.ToString("C")
        End Function
            
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="10000" />
      
        <asp:UpdatePanel ID="StockPricePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
        </Triggers>
        <ContentTemplate>
            Stock price is <asp:Label id="StockPrice" runat="server"></asp:Label><BR />
            as of <asp:Label id="TimeOfPrice" runat="server"></asp:Label>  
        </ContentTemplate>
        </asp:UpdatePanel>
        <div>
        Page originally created at <asp:Label ID="OriginalTime" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>