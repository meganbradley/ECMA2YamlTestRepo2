Private Sub ToolStripItem1_MouseMove(sender as Object, e as MouseEventArgs) _ 
     Handles ToolStripItem1.MouseMove

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseMove Event")

End Sub