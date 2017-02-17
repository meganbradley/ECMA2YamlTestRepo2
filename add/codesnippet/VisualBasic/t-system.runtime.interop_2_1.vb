Imports System
Imports System.Runtime.InteropServices

Public Class CallBack
    
    Public Function Activate(Aggregator As IntPtr) As IntPtr
        Dim oCOM As New ECFSRV32Lib.ObjectActivator()
        Dim itf As ECFSRV32Lib.IObjectActivator = _
           CType(oCOM, ECFSRV32Lib.IObjectActivator)
        Return New IntPtr(itf.CreateBaseComponent(Aggregator.ToInt32()))
    End Function
End Class

'
' The EcfInner class. First .NET class derived directly from COM class.
'
Public Class EcfInner
    Inherits ECFSRV32Lib.BaseComponent
    Private Shared callbackInner As CallBack    
    
    Shared Sub RegisterInner()
        callbackInner = New CallBack()
        ExtensibleClassFactory.RegisterObjectCreationCallback( _
           New System.Runtime.InteropServices.ObjectCreationDelegate( _
           AddressOf callbackInner.Activate))
    End Sub    
    
    'This is the static initializer.    
    Shared Sub New()
        RegisterInner()
    End Sub
End Class