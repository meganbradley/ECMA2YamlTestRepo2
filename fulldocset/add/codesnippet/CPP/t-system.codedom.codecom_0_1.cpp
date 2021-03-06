         // Creates an empty CodeCommentStatementCollection.
         CodeCommentStatementCollection^ collection = gcnew CodeCommentStatementCollection;

         // Adds a CodeCommentStatement to the collection.
         collection->Add( gcnew CodeCommentStatement( "Test comment" ) );

         // Adds an array of CodeCommentStatement objects to the collection.
         array<CodeCommentStatement^>^comments = {gcnew CodeCommentStatement( "Test comment" ),gcnew CodeCommentStatement( "Another test comment" )};
         collection->AddRange( comments );
         
         // Adds a collection of CodeCommentStatement objects to the collection.
         CodeCommentStatementCollection^ commentsCollection = gcnew CodeCommentStatementCollection;
         commentsCollection->Add( gcnew CodeCommentStatement( "Test comment" ) );
         commentsCollection->Add( gcnew CodeCommentStatement( "Another test comment" ) );
         collection->AddRange( commentsCollection );

         // Tests for the presence of a CodeCommentStatement in the 
         // collection, and retrieves its index if it is found.
         CodeCommentStatement^ testComment = gcnew CodeCommentStatement( "Test comment" );
         int itemIndex = -1;
         if ( collection->Contains( testComment ) )
            itemIndex = collection->IndexOf( testComment );

         // Copies the contents of the collection, beginning at index 0, 
         // to the specified CodeCommentStatement array.
         // 'comments' is a CodeCommentStatement array.
         collection->CopyTo( comments, 0 );

         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;

         // Inserts a CodeCommentStatement at index 0 of the collection.
         collection->Insert( 0, gcnew CodeCommentStatement( "Test comment" ) );

         // Removes the specified CodeCommentStatement from the collection.
         CodeCommentStatement^ comment = gcnew CodeCommentStatement( "Test comment" );
         collection->Remove( comment );

         // Removes the CodeCommentStatement at index 0.
         collection->RemoveAt( 0 );