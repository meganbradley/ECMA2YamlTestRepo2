private:
   void PopulateListView()
   {
      ListView1->Width = 270;
      ListView1->Location = System::Drawing::Point( 10, 10 );
      
      // Declare and construct the ColumnHeader objects.
      ColumnHeader^ header1;
      ColumnHeader^ header2;
      header1 = gcnew ColumnHeader;
      header2 = gcnew ColumnHeader;
      
      // Set the text, alignment and width for each column header.
      header1->Text = "File name";
      header1->TextAlign = HorizontalAlignment::Left;
      header1->Width = 70;
      header2->TextAlign = HorizontalAlignment::Left;
      header2->Text = "Location";
      header2->Width = 200;
      
      // Add the headers to the ListView control.
      ListView1->Columns->Add( header1 );
      ListView1->Columns->Add( header2 );
            
	  // Specify that each item appears on a separate line.
      ListView1->View = View::Details;

	  // Populate the ListView.Items property.
      // Set the directory to the sample picture directory.
      System::IO::DirectoryInfo^ dirInfo = gcnew System::IO::DirectoryInfo( "C:\\Documents and Settings\\All Users"
      "\\Documents\\My Pictures\\Sample Pictures" );
      
      // Get the .jpg files from the directory
      array<System::IO::FileInfo^>^files = dirInfo->GetFiles( "*.jpg" );
      
      // Add each file name and full name including path
      // to the ListView.
      if ( files != nullptr )
      {
         System::Collections::IEnumerator^ myEnum = files->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            System::IO::FileInfo^ file = safe_cast<System::IO::FileInfo^>(myEnum->Current);
            ListViewItem^ item = gcnew ListViewItem( file->Name );
            item->SubItems->Add( file->FullName );
            ListView1->Items->Add( item );
         }
      }
   }

   void InitializePictureBox()
   {
      PictureBox1 = gcnew PictureBox;
      
      // Set the location and size of the PictureBox control.
      this->PictureBox1->Location = System::Drawing::Point( 70, 120 );
      this->PictureBox1->Size = System::Drawing::Size( 140, 140 );
      this->PictureBox1->TabStop = false;
      
      // Set the SizeMode property to the StretchImage value.  This
      // will shrink or enlarge the image as needed to fit into
      // the PictureBox.
      this->PictureBox1->SizeMode = PictureBoxSizeMode::StretchImage;
      
      // Set the border style to a three-dimensional border.
      this->PictureBox1->BorderStyle = BorderStyle::Fixed3D;
      
      // Add the PictureBox to the form.
      this->Controls->Add( this->PictureBox1 );
   }

   void ListView1_MouseDown( Object^ /*sender*/, MouseEventArgs^ e )
   {
      ListViewItem^ selection = ListView1->GetItemAt( e->X, e->Y );
      
      // If the user selects an item in the ListView, display
      // the image in the PictureBox.
      if ( selection != nullptr )
      {
         PictureBox1->Image = System::Drawing::Image::FromFile( selection->SubItems[ 1 ]->Text );
      }
   }