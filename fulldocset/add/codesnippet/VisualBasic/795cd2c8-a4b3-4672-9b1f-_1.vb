        'Output chain information of the selected certificate.
        Dim ch As New X509Chain()
        ch.Build(certificate)
        Console.WriteLine("Chain Information")
        ch.ChainPolicy.RevocationMode = X509RevocationMode.Online
        Console.WriteLine("Chain revocation flag: {0}", ch.ChainPolicy.RevocationFlag)
        Console.WriteLine("Chain revocation mode: {0}", ch.ChainPolicy.RevocationMode)
        Console.WriteLine("Chain verification flag: {0}", ch.ChainPolicy.VerificationFlags)
        Console.WriteLine("Chain verification time: {0}", ch.ChainPolicy.VerificationTime)
        Console.WriteLine("Chain status length: {0}", ch.ChainStatus.Length)
        Console.WriteLine("Chain application policy count: {0}", ch.ChainPolicy.ApplicationPolicy.Count)
        Console.WriteLine("Chain certificate policy count: {0} {1}", ch.ChainPolicy.CertificatePolicy.Count, Environment.NewLine)