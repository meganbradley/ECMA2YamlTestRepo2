    Private Sub MeasureStringSizeFFormatInts(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Set maximum layout size.
        Dim layoutSize As New SizeF(100.0F, 200.0F)

        ' Set string format.
        Dim newStringFormat As New StringFormat
        newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical

        ' Measure string.
        Dim charactersFitted As Integer
        Dim linesFilled As Integer
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont, _
        layoutSize, newStringFormat, charactersFitted, linesFilled)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), 0.0F, 0.0F, _
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        New PointF(0, 0), newStringFormat)

        ' Draw output parameters to screen.
        Dim outString As String = "chars " & charactersFitted & _
        ", lines " & linesFilled
        e.Graphics.DrawString(outString, stringFont, Brushes.Black, _
        New PointF(100, 0))
    End Sub