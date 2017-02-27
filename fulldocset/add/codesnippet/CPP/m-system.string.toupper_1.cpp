using namespace System;

void main()
{
   int n = 0;
   for (int ctr = 0x20; ctr <= 0x017F; ctr++) {
      String^ string1 = Convert::ToChar(ctr).ToString();
      String^ upperString = string1->ToUpper();
      if (string1 != upperString) {
         Console::Write(L"{0} (\u+{1}) --> {2} (\u+{3})         ",
                       string1, 
                       Convert::ToUInt16(string1[0]).ToString("X4"),
                       upperString, 
                       Convert::ToUInt16(upperString[0]).ToString("X4"));
         n++;
         if (n % 2 == 0) Console::WriteLine();
      }
   } 
}
// The example displays the following output:
//    a (\u+0061) --> A (\u+0041)         b (\u+0062) --> B (\u+0042)
//    c (\u+0063) --> C (\u+0043)         d (\u+0064) --> D (\u+0044)
//    e (\u+0065) --> E (\u+0045)         f (\u+0066) --> F (\u+0046)
//    g (\u+0067) --> G (\u+0047)         h (\u+0068) --> H (\u+0048)
//    i (\u+0069) --> I (\u+0049)         j (\u+006A) --> J (\u+004A)
//    k (\u+006B) --> K (\u+004B)         l (\u+006C) --> L (\u+004C)
//    m (\u+006D) --> M (\u+004D)         n (\u+006E) --> N (\u+004E)
//    o (\u+006F) --> O (\u+004F)         p (\u+0070) --> P (\u+0050)
//    q (\u+0071) --> Q (\u+0051)         r (\u+0072) --> R (\u+0052)
//    s (\u+0073) --> S (\u+0053)         t (\u+0074) --> T (\u+0054)
//    u (\u+0075) --> U (\u+0055)         v (\u+0076) --> V (\u+0056)
//    w (\u+0077) --> W (\u+0057)         x (\u+0078) --> X (\u+0058)
//    y (\u+0079) --> Y (\u+0059)         z (\u+007A) --> Z (\u+005A)
//    à (\u+00E0) --> À (\u+00C0)         á (\u+00E1) --> Á (\u+00C1)
//    â (\u+00E2) --> Â (\u+00C2)         ã (\u+00E3) --> Ã (\u+00C3)
//    ä (\u+00E4) --> Ä (\u+00C4)         å (\u+00E5) --> Å (\u+00C5)
//    æ (\u+00E6) --> Æ (\u+00C6)         ç (\u+00E7) --> Ç (\u+00C7)
//    è (\u+00E8) --> È (\u+00C8)         é (\u+00E9) --> É (\u+00C9)
//    ê (\u+00EA) --> Ê (\u+00CA)         ë (\u+00EB) --> Ë (\u+00CB)
//    ì (\u+00EC) --> Ì (\u+00CC)         í (\u+00ED) --> Í (\u+00CD)
//    î (\u+00EE) --> Î (\u+00CE)         ï (\u+00EF) --> Ï (\u+00CF)
//    ð (\u+00F0) --> Ð (\u+00D0)         ñ (\u+00F1) --> Ñ (\u+00D1)
//    ò (\u+00F2) --> Ò (\u+00D2)         ó (\u+00F3) --> Ó (\u+00D3)
//    ô (\u+00F4) --> Ô (\u+00D4)         õ (\u+00F5) --> Õ (\u+00D5)
//    ö (\u+00F6) --> Ö (\u+00D6)         ø (\u+00F8) --> Ø (\u+00D8)
//    ù (\u+00F9) --> Ù (\u+00D9)         ú (\u+00FA) --> Ú (\u+00DA)
//    û (\u+00FB) --> Û (\u+00DB)         ü (\u+00FC) --> Ü (\u+00DC)
//    ý (\u+00FD) --> Ý (\u+00DD)         þ (\u+00FE) --> Þ (\u+00DE)
//    ÿ (\u+00FF) --> Ÿ (\u+0178)         ā (\u+0101) --> Ā (\u+0100)
//    ă (\u+0103) --> Ă (\u+0102)         ą (\u+0105) --> Ą (\u+0104)
//    ć (\u+0107) --> Ć (\u+0106)         ĉ (\u+0109) --> Ĉ (\u+0108)
//    ċ (\u+010B) --> Ċ (\u+010A)         č (\u+010D) --> Č (\u+010C)
//    ď (\u+010F) --> Ď (\u+010E)         đ (\u+0111) --> Đ (\u+0110)
//    ē (\u+0113) --> Ē (\u+0112)         ĕ (\u+0115) --> Ĕ (\u+0114)
//    ė (\u+0117) --> Ė (\u+0116)         ę (\u+0119) --> Ę (\u+0118)
//    ě (\u+011B) --> Ě (\u+011A)         ĝ (\u+011D) --> Ĝ (\u+011C)
//    ğ (\u+011F) --> Ğ (\u+011E)         ġ (\u+0121) --> Ġ (\u+0120)
//    ģ (\u+0123) --> Ģ (\u+0122)         ĥ (\u+0125) --> Ĥ (\u+0124)
//    ħ (\u+0127) --> Ħ (\u+0126)         ĩ (\u+0129) --> Ĩ (\u+0128)
//    ī (\u+012B) --> Ī (\u+012A)         ĭ (\u+012D) --> Ĭ (\u+012C)
//    į (\u+012F) --> Į (\u+012E)         ı (\u+0131) --> I (\u+0049)
//    ĳ (\u+0133) --> Ĳ (\u+0132)         ĵ (\u+0135) --> Ĵ (\u+0134)
//    ķ (\u+0137) --> Ķ (\u+0136)         ĺ (\u+013A) --> Ĺ (\u+0139)
//    ļ (\u+013C) --> Ļ (\u+013B)         ľ (\u+013E) --> Ľ (\u+013D)
//    ŀ (\u+0140) --> Ŀ (\u+013F)         ł (\u+0142) --> Ł (\u+0141)
//    ń (\u+0144) --> Ń (\u+0143)         ņ (\u+0146) --> Ņ (\u+0145)
//    ň (\u+0148) --> Ň (\u+0147)         ŋ (\u+014B) --> Ŋ (\u+014A)
//    ō (\u+014D) --> Ō (\u+014C)         ŏ (\u+014F) --> Ŏ (\u+014E)
//    ő (\u+0151) --> Ő (\u+0150)         œ (\u+0153) --> Œ (\u+0152)
//    ŕ (\u+0155) --> Ŕ (\u+0154)         ŗ (\u+0157) --> Ŗ (\u+0156)
//    ř (\u+0159) --> Ř (\u+0158)         ś (\u+015B) --> Ś (\u+015A)
//    ŝ (\u+015D) --> Ŝ (\u+015C)         ş (\u+015F) --> Ş (\u+015E)
//    š (\u+0161) --> Š (\u+0160)         ţ (\u+0163) --> Ţ (\u+0162)
//    ť (\u+0165) --> Ť (\u+0164)         ŧ (\u+0167) --> Ŧ (\u+0166)
//    ũ (\u+0169) --> Ũ (\u+0168)         ū (\u+016B) --> Ū (\u+016A)
//    ŭ (\u+016D) --> Ŭ (\u+016C)         ů (\u+016F) --> Ů (\u+016E)
//    ű (\u+0171) --> Ű (\u+0170)         ų (\u+0173) --> Ų (\u+0172)
//    ŵ (\u+0175) --> Ŵ (\u+0174)         ŷ (\u+0177) --> Ŷ (\u+0176)
//    ź (\u+017A) --> Ź (\u+0179)         ż (\u+017C) --> Ż (\u+017B)
//    ž (\u+017E) --> Ž (\u+017D)