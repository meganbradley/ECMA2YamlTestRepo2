      ' myModBuilder is an instance of ModuleBuilder.
      ' Note that for the use of PermissionSet and SecurityAction,
      ' the namespaces System.Security and System.Security.Permissions
      ' should be included.
      Dim myTypeBuilder As TypeBuilder = myModBuilder.DefineType("MyType", _
						      TypeAttributes.Public)
      
      Dim myMethod1 As MethodBuilder = myTypeBuilder.DefineMethod("MyMethod", _
						     MethodAttributes.Public, _
						     GetType(Integer), _
						     New Type() {GetType(Integer), GetType(Integer)})
      
      Dim myMethodPermissions As New PermissionSet(PermissionState.Unrestricted)
      
      myMethod1.AddDeclarativeSecurity(SecurityAction.Demand, myMethodPermissions)
