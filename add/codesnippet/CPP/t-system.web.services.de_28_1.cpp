#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;

int main()
{
   try
   {
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_input_cs.wsdl" );
      String^ myTargetNamespace = myServiceDescription->TargetNamespace;
      
      // Create an OperationBinding for the Add operation.
      OperationBinding^ addOperationBinding = gcnew OperationBinding;
      String^ addOperation = "Add";
      addOperationBinding->Name = addOperation;

      // Create an InputBinding for the Add operation.
      InputBinding^ myInputBinding = gcnew InputBinding;
      SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
      mySoapBodyBinding->Use = SoapBindingUse::Literal;
      myInputBinding->Extensions->Add( mySoapBodyBinding );

      // Add the InputBinding to the OperationBinding.
      addOperationBinding->Input = myInputBinding;

      // Create an OutputBinding for the Add operation.
      OutputBinding^ myOutputBinding = gcnew OutputBinding;
      myOutputBinding->Extensions->Add( mySoapBodyBinding );
      
      // Add the OutputBinding to the OperationBinding. 
      addOperationBinding->Output = myOutputBinding;

      // Create an extensibility element for a SoapOperationBinding.
      SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
      mySoapOperationBinding->Style = SoapBindingStyle::Document;
      mySoapOperationBinding->SoapAction = String::Concat( myTargetNamespace, addOperation );

      // Add the extensibility element SoapOperationBinding to 
      // the OperationBinding.
      addOperationBinding->Extensions->Add( mySoapOperationBinding );

      ServiceDescriptionFormatExtensionCollection^ myExtensions;

      // Get the FaultBindingCollection from the OperationBinding.
      FaultBindingCollection^ myFaultBindingCollection = addOperationBinding->Faults;
      FaultBinding^ myFaultBinding = gcnew FaultBinding;
      myFaultBinding->Name = "ErrorFloat";

      // Associate SOAP fault binding to the fault binding of the operation.
      myExtensions = myFaultBinding->Extensions;
      SoapFaultBinding^ mySoapFaultBinding = gcnew SoapFaultBinding;
      mySoapFaultBinding->Use = SoapBindingUse::Literal;
      mySoapFaultBinding->Namespace = myTargetNamespace;
      myExtensions->Add( mySoapFaultBinding );
      myFaultBindingCollection->Add( myFaultBinding );

      // Get the BindingCollection from the ServiceDescription.
      BindingCollection^ myBindingCollection = myServiceDescription->Bindings;

      // Get the OperationBindingCollection of SOAP binding 
      // from the BindingCollection.
      OperationBindingCollection^ myOperationBindingCollection = myBindingCollection[ 0 ]->Operations;
      myOperationBindingCollection->Add( addOperationBinding );
      Console::WriteLine( "The operations supported by this service are:" );
      System::Collections::IEnumerator^ myEnum = myOperationBindingCollection->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         OperationBinding^ myOperationBinding = safe_cast<OperationBinding^>(myEnum->Current);

         Binding^ myBinding = myOperationBinding->Binding;
         Console::WriteLine( " Binding : {0} :: Name of operation : {1}", myBinding->Name, myOperationBinding->Name );

         FaultBindingCollection^ myFaultBindingCollection1 = myOperationBinding->Faults;
         System::Collections::IEnumerator^ myEnum1 = myFaultBindingCollection1->GetEnumerator();
         while ( myEnum1->MoveNext() )
         {
            FaultBinding^ myFaultBinding1 = safe_cast<FaultBinding^>(myEnum1->Current);
            Console::WriteLine( "    Fault : {0}", myFaultBinding1->Name );
         }
      }
      myServiceDescription->Write( "MathService_new_cs.wsdl" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}