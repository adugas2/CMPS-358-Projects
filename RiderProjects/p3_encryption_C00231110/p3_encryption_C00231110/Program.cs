// Austin Dugas
// C00231110
// CMPS 358
// Project: p3

using System;
using System.IO;
using static System.Environment;
using static System.IO.Path;
using System.Text;
using System.Security.Cryptography;

byte[] datain = Encoding.UTF8.GetBytes("Madam, I am Adam.");
string publicKeyOnly = File.ReadAllText
    (Combine(CurrentDirectory, "PublicKeyOnly.xml"));

byte[] encrypted;
using (var rsaPublicOnly = new RSACryptoServiceProvider())
{
    rsaPublicOnly.FromXmlString(publicKeyOnly);
    encrypted = rsaPublicOnly.Encrypt(datain, true);
}
File.WriteAllBytes
    (Combine(CurrentDirectory, "encryptedmessage"), encrypted);
