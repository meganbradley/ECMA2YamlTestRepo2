Public Sub WindowsAuthentication_OnAuthenticate(sender As Object, args As WindowsAuthenticationEventArgs)
  If Not args.Identity.IsAnonymous Then
    args.User = New Samples.AspNet.Security.MyPrincipal(args.Identity)
  End If
End Sub