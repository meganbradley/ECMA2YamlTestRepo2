   void InitializeMyMenu()
   {
      // Create the MainMenu Object*.
      MainMenu^ myMainMenu = gcnew MainMenu;
      
      // Create the MenuItem objects.
      MenuItem^ fileMenu = gcnew MenuItem( "&File" );
      MenuItem^ editMenu = gcnew MenuItem( "&Edit" );
      MenuItem^ newFile = gcnew MenuItem( "&New" );
      MenuItem^ openFile = gcnew MenuItem( "&Open" );
      MenuItem^ exitProgram = gcnew MenuItem( "E&xit" );
      
      // Add the MenuItem objects to myMainMenu.
      myMainMenu->MenuItems->Add( fileMenu );
      myMainMenu->MenuItems->Add( editMenu );
      
      // Add three submenus to the File menu.
      fileMenu->MenuItems->Add( newFile );
      fileMenu->MenuItems->Add( openFile );
      fileMenu->MenuItems->Add( exitProgram );
      
      // Assign myMainMenu to the form.
      this->Menu = myMainMenu;
      
      // Clear the File menu items. 
      fileMenu->MenuItems->Clear();
   }