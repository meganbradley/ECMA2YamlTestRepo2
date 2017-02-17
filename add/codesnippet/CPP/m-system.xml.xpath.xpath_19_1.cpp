        XmlDocument^ document = gcnew XmlDocument();
        document->Load("contosoBooks.xml");
        XPathNavigator^ navigator = document->CreateNavigator();

        navigator->MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator->MoveToChild("book", "http://www.contoso.com/books");

        XmlReader^ pages = XmlReader::Create(gcnew StringReader("<pages xmlns=\"http://www.contoso.com/books\">100</pages>"));

        navigator->PrependChild(pages);

        Console::WriteLine(navigator->OuterXml);