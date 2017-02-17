            ' Creates a delegate of type System.EventHandler pointing to a method named OnMouseEnter.
            Dim mouseEnterDelegate As New CodeDelegateCreateExpression(New CodeTypeReference("System.EventHandler"), New CodeThisReferenceExpression(), "OnMouseEnter")
            ' Creates a remove event statement that removes the delegate from the TestEvent event.
            Dim removeEvent1 As New CodeRemoveEventStatement(New CodeThisReferenceExpression(), "TestEvent", mouseEnterDelegate)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            '   RemoveHandler TestEvent, AddressOf Me.OnMouseEnter            