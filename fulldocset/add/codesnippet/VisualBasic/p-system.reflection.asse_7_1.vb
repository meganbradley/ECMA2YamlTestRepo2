Imports System
Imports System.Reflection
Imports System.Threading
Imports System.IO
Imports System.Globalization
Imports System.Reflection.Emit
Imports System.Configuration.Assemblies
Imports System.Text
Imports Microsoft.VisualBasic


Public Class AssemblyName_CodeBase
   
   Public Shared Sub MakeAssembly(myAssemblyName As AssemblyName, fileName As String)
      ' Get the assembly builder from the application domain associated with the current thread.
      Dim myAssemblyBuilder As AssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave)
      ' Create a dynamic module in the assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule("MyModule", fileName)
      ' Create a type in the module.
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("MyType")
      ' Create a method called 'Main'.
      Dim myMethodBuilder As MethodBuilder = myTypeBuilder.DefineMethod("Main", MethodAttributes.Public Or MethodAttributes.HideBySig Or MethodAttributes.Static, GetType(object), Nothing)
      ' Get the Intermediate Language generator for the method.
      Dim myILGenerator As ILGenerator = myMethodBuilder.GetILGenerator()
      ' Use the utility method to generate the IL instructions that print a string to the console.
      myILGenerator.EmitWriteLine("Hello World!")
      ' Generate the 'ret' IL instruction.
      myILGenerator.Emit(OpCodes.Ret)
      ' End the creation of the type.
      myTypeBuilder.CreateType()
      ' Set the method with name 'Main' as the entry point in the assembly.
      myAssemblyBuilder.SetEntryPoint(myMethodBuilder)
      myAssemblyBuilder.Save(fileName)
   End Sub 'MakeAssembly
   
   
   Public Shared Sub Main()
      

      ' Create a dynamic assembly with name 'MyAssembly' and build version '1.0.0.2001'.
      Dim myAssemblyName As New AssemblyName()
      ' Set the codebase to the physical directory were the assembly resides.
      myAssemblyName.CodeBase = Directory.GetCurrentDirectory()
      ' Set the culture information of the assembly to 'English-American'.
      myAssemblyName.CultureInfo = New CultureInfo("en-US")
      ' Set the hash algoritm to 'SHA1'.
      myAssemblyName.HashAlgorithm = AssemblyHashAlgorithm.SHA1
      myAssemblyName.VersionCompatibility = AssemblyVersionCompatibility.SameProcess
      myAssemblyName.Flags = AssemblyNameFlags.PublicKey
      ' Provide this assembly with a strong name.
      myAssemblyName.KeyPair = New StrongNameKeyPair(File.Open("KeyPair.snk", FileMode.Open, FileAccess.Read))
      myAssemblyName.Name = "MyAssembly"
      myAssemblyName.Version = New Version("1.0.0.2001")
      MakeAssembly(myAssemblyName, "MyAssembly.exe")
      
      ' Get the assemblies loaded in the current application domain.
      Dim myAssemblies As [Assembly]() = Thread.GetDomain().GetAssemblies()
      
      ' Get the dynamic assembly named 'MyAssembly'. 
      Dim myAssembly As [Assembly] = Nothing
      Dim i As Integer
      For i = 0 To myAssemblies.Length - 1
         If [String].Compare(myAssemblies(i).GetName().Name, "MyAssembly") = 0 Then
            myAssembly = myAssemblies(i)
         End If 
      Next i ' Display the full assembly information to the console.
      If Not (myAssembly Is Nothing) Then
      Console.WriteLine(ControlChars.CrLf +"Displaying the full assembly name."+ ControlChars.CrLf)
      Console.WriteLine(myAssembly.GetName().FullName)
      Console.WriteLine(ControlChars.CrLf +"Displaying the public key." + ControlChars.CrLf)
      Dim pk() As Byte
      pk = myAssembly.GetName().GetPublicKey()
      For i = 0 To (pk.GetLength(0)) - 1
         Console.Write("{0:x2}", pk(i))
      Next i
      Console.WriteLine()
      Console.WriteLine(ControlChars.CrLf +"Displaying the public key token."+ ControlChars.CrLf)
      Dim pt() As Byte
      pt = myAssembly.GetName().GetPublicKeyToken()
      For i = 0 To (pt.GetLength(0)) - 1
         Console.Write("{0:x2}", pt(i))
      Next i
      End If
   End Sub 'Main 
End Class 'AssemblyName_CodeBase 