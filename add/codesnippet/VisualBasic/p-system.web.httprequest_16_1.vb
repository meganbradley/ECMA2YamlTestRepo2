Dim userLang() As String
 Dim count As Integer
 
 userLang = Request.UserLanguages
 For count = 0 To userLang.GetUpperBound(0)
    Response.Write("User Language: " & Cstr(userLang(count)) & "<br>")
 Next count
   