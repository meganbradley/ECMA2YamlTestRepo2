using namespace System;
using namespace System::Security::Cryptography::X509Certificates;
int main()
{
   
   // The path to the certificate.
   String^ Certificate = "Certificate.cer";
   
   // Load the certificate into an X509Certificate object.
   X509Certificate^ cert = X509Certificate::CreateFromCertFile( Certificate );
   
   // Get the value.
   int results = cert->GetHashCode();
   
   // Display the value to the console.
   Console::WriteLine( results );
}
