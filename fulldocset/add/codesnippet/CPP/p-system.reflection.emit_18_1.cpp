      MethodBuilder^ myMethodBuilder = nullptr;
      AppDomain^ myCurrentDomain = AppDomain::CurrentDomain;

      // Create assembly in current CurrentDomain.
      AssemblyName^ myAssemblyName = gcnew AssemblyName;
      myAssemblyName->Name = "TempAssembly";

      // Create a dynamic assembly.
      myAssemblyBuilder = myCurrentDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );

      // Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder->DefineDynamicModule( "TempModule" );
      FieldInfo^ myFieldInfo = myModuleBuilder->DefineUninitializedData( "myField", 2, FieldAttributes::Public );

      // Create a type in the module.
      TypeBuilder^ myTypeBuilder = myModuleBuilder->DefineType( "TempClass", TypeAttributes::Public );
      FieldBuilder^ myGreetingField = myTypeBuilder->DefineField( "Greeting", String::typeid, FieldAttributes::Public );
      array<Type^>^myConstructorArgs = {String::typeid};

      // Define a constructor of the dynamic class.
      ConstructorBuilder^ myConstructor = myTypeBuilder->DefineConstructor( MethodAttributes::Public, CallingConventions::Standard, myConstructorArgs );

      // Display the name of the constructor.
      Console::WriteLine( "The constructor name is  : {0}", myConstructor->Name );

      // Display the 'Type' object from which this object was obtained.
      Console::WriteLine( "The reflected type  is  : {0}", myConstructor->ReflectedType );

      // Display the signature of the field.
      Console::WriteLine( myConstructor->Signature );

      // Display the constructor builder instance as a string.
      Console::WriteLine( myConstructor );