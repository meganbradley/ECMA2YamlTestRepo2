    Public Sub InstantiateMyCheckBox()
        ' Create and initialize a CheckBox.   
        Dim checkBox1 As New CheckBox()
        
        ' Make the check box control appear as a toggle button.
        checkBox1.Appearance = Appearance.Button
        
        ' Turn off the update of the display on the click of the control.
        checkBox1.AutoCheck = False
        
        ' Add the check box control to the form.
        Controls.Add(checkBox1)
    End Sub 'InstantiateMyCheckBox