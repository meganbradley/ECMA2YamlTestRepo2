    public void DisplayAttributes(XmlReader reader)
    {
        if (reader.HasAttributes)
        {
            Console.WriteLine("Attributes of <" + reader.Name + ">");
            while (reader.MoveToNextAttribute())
            {
                Console.WriteLine(" {0}={1}", reader.Name, reader.Value);
            }
        }
    }