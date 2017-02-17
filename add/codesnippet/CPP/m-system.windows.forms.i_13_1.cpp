private:
   void GetFormats2()
   {
      // Creates a new data object using a string and the UnicodeText format.
      DataObject^ myDataObject = gcnew DataObject( DataFormats::UnicodeText,"My text string" );
      
      // Gets the original data formats in the data object by setting the automatic
      // conversion parameter to false.
      array<String^>^myFormatsArray = myDataObject->GetFormats( false );
      
      // Stores the results in a string.
      String^ theResult = "The original format associated with the data is:\n";
      for ( int i = 0; i < myFormatsArray->Length; i++ )
         theResult = theResult + myFormatsArray[ i ] + "\n";
      
      // Gets all data formats and data conversion formats for the data object.
      myFormatsArray = myDataObject->GetFormats( true );
      
      // Stores the results in the string.
      theResult = theResult + "\nThe data format(s) and conversion format(s) associated with the data are:\n";
      for ( int i = 0; i < myFormatsArray->Length; i++ )
         theResult = theResult + myFormatsArray[ i ] + "\n";
      
      // Displays the results.
      MessageBox::Show( theResult );
   }