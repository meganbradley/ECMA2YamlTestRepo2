      MimePart[] myArray = new MimePart[myMimePartCollection.Count];
      // Copy the mimepartcollection to an array.
      myMimePartCollection.CopyTo(myArray,0);
      Console.WriteLine("Displaying the array copied from mimepartcollection");
      for(int j=0;j<myMimePartCollection.Count;j++)
      {
         Console.WriteLine("Mimepart object at position : " + j);
         for(int i=0;i<myArray[j].Extensions.Count;i++)
         {
            MimeXmlBinding myMimeXmlBinding3 = (MimeXmlBinding)myArray[j].Extensions[i];
            Console.WriteLine("Part: "+(myMimeXmlBinding3.Part));
         }
      }