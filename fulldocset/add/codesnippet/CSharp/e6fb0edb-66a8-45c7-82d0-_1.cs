
   public static Object GetFile (String fileURL, XmlResolver resolver) {
    
     // Generate the default PermissionSet using the file URL.
     Evidence evidence = XmlSecureResolver.CreateEvidenceForUrl(fileURL);
     PermissionSet myPermissions = SecurityManager.ResolvePolicy(evidence);

     // Modify the PermissionSet to only allow access to http://www.contoso.com.
     // Create a WebPermission which only allows access to http://www.contoso.com.
     WebPermission myWebPermission = new WebPermission(NetworkAccess.Connect, "http://www.contoso.com");
     // Replace the existing WebPermission in myPermissions with the updated WebPermission.
     myPermissions.SetPermission(myWebPermission);

     // Use the modified PermissionSet to construct the XmlSecureResolver.
     XmlSecureResolver sResolver = new XmlSecureResolver(resolver, myPermissions);

     // Get the object.
     Uri fullUri = sResolver.ResolveUri(null, fileURL);
     return sResolver.GetEntity(fullUri, null, null);
   } 