        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        Dim writer As XmlWriter = XmlWriter.Create("outfile.xml")
        item.SaveAsAtom10(writer)
        writer.Close()