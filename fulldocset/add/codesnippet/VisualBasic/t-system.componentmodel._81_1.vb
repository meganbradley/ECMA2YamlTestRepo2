Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization

<MetadataType(GetType(CustomerMetaData))> _
Partial Public Class Customer

   
End Class

Public Class CustomerMetaData
    ' Require that the Title is not null.
    ' Use custom validation error.
    <Required(ErrorMessage:="Title is required.")> _
    Public Title As Object

    ' Require that the MiddleName is not null.
    ' Use standard validation error.
    <Required()> _
    Public MiddleName As Object

End Class
