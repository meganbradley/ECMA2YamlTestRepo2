            Console.WriteLine("Passive: {0}  Keep alive: {1}  Binary: {2} Timeout: {3}.", 
                request.UsePassive, 
                request.KeepAlive, 
                request.UseBinary,
                request.Timeout == -1 ? "none" : request.Timeout.ToString()
            );