
    ' Deny access to a specific resource by setting the Accept property.

   <WebPermission(SecurityAction.Deny, Accept := "http://www.contoso.com/Private.htm")>  _
      Public Shared Sub CheckAcceptPermission(uriToCheck As String)
      Dim permissionToCheck As New WebPermission()
      permissionToCheck.AddPermission(NetworkAccess.Accept, uriToCheck)
      permissionToCheck.Demand()
   End Sub 'CheckAcceptPermission
   
   
   Public Shared Sub demoDenySite()
      ' Pass the security check when accessing allowed resources.
      CheckAcceptPermission("http://www.contoso.com/Public.htm")
      Console.WriteLine("Public page has passed Accept permission check")
      Try
         'Throw a SecurityException when trying to access not allowed resources.
         CheckAcceptPermission("http://www.contoso.com/Private.htm")
         Console.WriteLine("This line will not be printed")
      Catch e As SecurityException
         Console.WriteLine(("Exception trying to access private resource:" + e.Message))
      End Try
   End Sub 'demoDenySite