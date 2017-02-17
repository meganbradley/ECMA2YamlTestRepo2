        // Signals when the resolve has finished.
        public static ManualResetEvent GetHostEntryFinished = 
            new ManualResetEvent(false);

        // Define the state object for the callback. 
        // Use hostName to correlate calls with the proper result.
        public class ResolveState
        {
            string hostName;
            IPHostEntry resolvedIPs;

            public ResolveState(string host)
            {
                hostName = host;
            }

            public IPHostEntry IPs
            {
                get { return resolvedIPs; } 
                set {resolvedIPs = value;}}
            public string host {get {return hostName;} 
                set {hostName = value;}}
        }

        // Record the IPs in the state object for later use.
        public static void GetHostEntryCallback(IAsyncResult ar)
        {
            ResolveState ioContext = (ResolveState)ar.AsyncState;

            ioContext.IPs = Dns.EndGetHostEntry(ar);
            GetHostEntryFinished.Set();
        }       
        
        // Determine the Internet Protocol (IP) addresses for 
        // this host asynchronously.
        public static void DoGetHostEntryAsync(string hostname)
        {
            GetHostEntryFinished.Reset();
            ResolveState ioContext= new ResolveState(hostname);

            Dns.BeginGetHostEntry(ioContext.host, 
                new AsyncCallback(GetHostEntryCallback), ioContext);

            // Wait here until the resolve completes (the callback 
            // calls .Set())
            GetHostEntryFinished.WaitOne();

            Console.WriteLine("EndGetHostEntry({0}) returns:", ioContext.host);

            foreach (IPAddress ip in ioContext.IPs.AddressList)
            {
                Console.WriteLine("    {0}", ip);
            }
 
        }
  