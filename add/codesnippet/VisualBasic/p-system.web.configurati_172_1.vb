      ' Get the EnableVersionHeader property value.
      Response.Write("EnableVersionHeader: " & _
        configSection.EnableVersionHeader & "<br>")

      ' Set the EnableVersionHeader property value to false
      configSection.EnableVersionHeader = False