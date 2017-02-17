
      Sub Page_Load(Sender As Object, e As EventArgs ) 
      
         Response.Write("<h3>Page.Context Example:</h3>")
            
         ' Add three custom exceptions.
        Context.AddError(New Exception( _
            "<h3 style=""color: red"">New Exception #1.</h3>"))
        Context.AddError(New Exception( _
            "<h3 style=""color: red"">New Exception #2.</h3>"))
        Context.AddError(New Exception( _
            "<h3 style=""color: red"">New Exception #3.</h3>"))
 
         ' Capture all the new Exceptions in an array.
         Dim errs() As Exception = Context.AllErrors
         Dim ex As Exception
         
         For Each ex In errs
            Response.Write("<p style='text-align:center; font-weight:bold'>")
            Response.Write(Server.HtmlEncode(ex.ToString()) + "</p>")
         Next
 
         ' Clear the exceptions so ASP.NET won't handle them.
         Context.ClearError()
      End Sub