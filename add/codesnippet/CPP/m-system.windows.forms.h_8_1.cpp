   // Open the Help file for the Character Map topic.  
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Help::ShowHelp( TextBox1, "file://c:\\charmap.chm" );
   }