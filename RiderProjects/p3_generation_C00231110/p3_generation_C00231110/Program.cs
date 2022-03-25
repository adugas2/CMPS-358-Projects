// Austin Dugas
// C00231110
// CMPS 358
// Project: p3

using System.IO;
using static System.Environment;
using static System.IO.Path;
using System.Security.Cryptography;

using (var rsa = new RSACryptoServiceProvider())
{
    File.WriteAllText
        (Combine(CurrentDirectory, "PublicKeyOnly.xml"),
        rsa.ToXmlString(false));
    File.WriteAllText
        (Combine(CurrentDirectory, "PrivateKeyOnly.xml"),
        rsa.ToXmlString(true));
}