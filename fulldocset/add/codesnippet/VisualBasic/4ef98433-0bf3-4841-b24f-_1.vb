    Public Sub DrawVisualStyleElementExplorerBarNormalGroupExpand2(ByVal e As PaintEventArgs)
        If (VisualStyleRenderer.IsElementDefined( _
         VisualStyleElement.ExplorerBar.NormalGroupExpand.Hot)) Then
            Dim renderer As New VisualStyleRenderer _
              (VisualStyleElement.ExplorerBar.NormalGroupExpand.Hot)
            Dim rectangle1 As New Rectangle(10, 50, 50, 50)
            renderer.DrawBackground(e.Graphics, rectangle1)
            e.Graphics.DrawString("VisualStyleElement.ExplorerBar.NormalGroupExpand.Hot", _
              Me.Font, Brushes.Black, New Point(10, 10))
        Else
            e.Graphics.DrawString("This element is not defined in the current visual style.", _
              Me.Font, Brushes.Black, New Point(10, 10))
        End If
    End Sub