public:
   static void main()
   {
      // Starts the application.
      Application::Run( gcnew Form1 );
   }

private:
   void button1_Click( Object^ sender, System::EventArgs^ e )
   {
      // Populates a list box with three numbers.
      int i = 3;
      for ( int j = 1; j <= i; j++ )
      {
         listBox1->Items->Add( j );
      }
      
      /* Determines whether the user wants to exit the application.
       * If not, adds another number to the list box. */
      while ( MessageBox::Show( "Exit application?", "",
         MessageBoxButtons::YesNo ) == ::DialogResult::No )
      {
         // Increments the counter ands add the number to the list box.
         i++;
         listBox1->Items->Add( i );
      }
      
      // The user wants to exit the application. Close everything down.
      Application::Exit();
   }