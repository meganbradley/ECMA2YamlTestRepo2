        // Connect to a queue on the local computer.
        MessageQueue queue = new MessageQueue(".\\exampleQueue");

        // Create a new instance of MessageQueuePermissionEntry.
        MessageQueuePermissionEntry entry = new MessageQueuePermissionEntry(
            MessageQueuePermissionAccess.Receive,
            queue.MachineName,
            queue.Label,
            queue.Category.ToString());

        // Display the value of the entry's MachineName property.
        Console.WriteLine("MachineName: {0}", entry.MachineName);