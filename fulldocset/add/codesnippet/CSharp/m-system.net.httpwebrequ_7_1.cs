    try
    {      

      
      // Create a HttpWebrequest object to the desired URL.
      HttpWebRequest myHttpWebRequest1= (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
      
      // Create an instance of the RequestState and assign the previous myHttpWebRequest1
      // object to it's request field.  
      RequestState myRequestState = new RequestState();  
      myRequestState.request = myHttpWebRequest1;


      // Start the asynchronous request.
      IAsyncResult result=
        (IAsyncResult) myHttpWebRequest1.BeginGetResponse(new AsyncCallback(RespCallback),myRequestState);

      allDone.WaitOne();
      
      // Release the HttpWebResponse resource.
      myRequestState.response.Close();
    }
    catch(WebException e)
    {
      Console.WriteLine("\nException raised!");
      Console.WriteLine("\nMessage:{0}",e.Message);
      Console.WriteLine("\nStatus:{0}",e.Status);
      Console.WriteLine("Press any key to continue..........");
    }
    catch(Exception e)
    {
      Console.WriteLine("\nException raised!");
      Console.WriteLine("Source :{0} " , e.Source);
      Console.WriteLine("Message :{0} " , e.Message);
      Console.WriteLine("Press any key to continue..........");
      Console.Read();
    }
  }
  private static void RespCallback(IAsyncResult asynchronousResult)
  {  
    try
    {
      // State of request is asynchronous.
      RequestState myRequestState=(RequestState) asynchronousResult.AsyncState;
      HttpWebRequest  myHttpWebRequest2=myRequestState.request;
      myRequestState.response = (HttpWebResponse) myHttpWebRequest2.EndGetResponse(asynchronousResult);
      
      // Read the response into a Stream object.
      Stream responseStream = myRequestState.response.GetResponseStream();
      myRequestState.streamResponse=responseStream;
      
      // Begin the Reading of the contents of the HTML page and print it to the console.
      IAsyncResult asynchronousInputRead = responseStream.BeginRead(myRequestState.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
    }
    catch(WebException e)
    {
      Console.WriteLine("\nException raised!");
      Console.WriteLine("\nMessage:{0}",e.Message);
      Console.WriteLine("\nStatus:{0}",e.Status);
      
    }
  }
  private static  void ReadCallBack(IAsyncResult asyncResult)
  {
    try
    {

    RequestState myRequestState = (RequestState)asyncResult.AsyncState;
    Stream responseStream = myRequestState.streamResponse;
    int read = responseStream.EndRead( asyncResult );
    // Read the HTML page and then print it to the console.
    if (read > 0)
    {
      myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.BufferRead, 0, read));
      IAsyncResult asynchronousResult = responseStream.BeginRead( myRequestState.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
    }
    else
    {
      Console.WriteLine("\nThe contents of the Html page are : ");
      if(myRequestState.requestData.Length>1)
      {
        string stringContent;
        stringContent = myRequestState.requestData.ToString();
        Console.WriteLine(stringContent);
      }
      Console.WriteLine("Press any key to continue..........");
      Console.ReadLine();
      
      responseStream.Close();
      allDone.Set();
     
    }

    }
    catch(WebException e)
    {
      Console.WriteLine("\nException raised!");
      Console.WriteLine("\nMessage:{0}",e.Message);
      Console.WriteLine("\nStatus:{0}",e.Status);
      
    }

  }