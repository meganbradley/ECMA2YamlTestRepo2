                        // Get the identity section.
                        IdentitySection identity =
                            systemWeb.Identity;
                        // Read section information.
                        info =
                            identity.SectionInformation;
                        name = info.SectionName;
                        type = info.Type;
                        declared = info.IsDeclared.ToString();
                        msg = String.Format(
                            "Name:     {0}\nDeclared: {1}\nType:     {2}\n",
                            name, declared, type);