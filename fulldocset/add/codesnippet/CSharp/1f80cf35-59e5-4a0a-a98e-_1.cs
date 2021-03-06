      // Define property Greeting.
      PropertyBuilder greetingPropertyBuilder = helloWorldTypeBuilder.DefineProperty(
                               "Greeting",PropertyAttributes.None,typeof(string),null);

      // Define the 'get_Greeting' method.
      MethodBuilder getGreetingMethod = helloWorldTypeBuilder.DefineMethod("get_Greeting",
         MethodAttributes.Public|MethodAttributes.HideBySig|MethodAttributes.SpecialName,
         typeof(String),null);
      // Generate IL code for 'get_Greeting' method.
      ILGenerator methodIL = getGreetingMethod.GetILGenerator();
      methodIL.Emit(OpCodes.Ldarg_0);
      methodIL.Emit(OpCodes.Ldfld, greetingFieldBuilder);
      methodIL.Emit(OpCodes.Ret);
      greetingPropertyBuilder.SetGetMethod(getGreetingMethod);