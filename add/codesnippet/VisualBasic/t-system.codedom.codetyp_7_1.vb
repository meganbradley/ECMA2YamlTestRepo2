         ' Creates a new type declaration.
         Dim newType As New CodeTypeDeclaration("TestType")
            ' name parameter indicates the name of the type.
            ' Sets the member attributes for the type to private.
            newType.Attributes = MemberAttributes.Private
            ' Sets a base class which the type inherits from.
            newType.BaseTypes.Add("BaseType")

         ' A Visual Basic code generator produces the following source code for the preceeding example code:

         ' Class TestType
         '    Inherits BaseType
         ' End Class