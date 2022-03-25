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

byte[] dataout = File.ReadAllBytes
    (Combine(CurrentDirectory, "encryptedmessage"));
string publicPrivate = File.ReadAllText
    (Combine(CurrentDirectory, "PrivateKeyOnly.xml"));
string messageDecrypted;

byte[] decrypted;
using (var rsaPublicPrivate = new RSACryptoServiceProvider())
{
    rsaPublicPrivate.FromXmlString(publicPrivate);
    decrypted = rsaPublicPrivate.Decrypt(dataout, true);
    messageDecrypted = Encoding.UTF8.GetString(decrypted);
}
Console.WriteLine("decrypted: " + messageDecrypted);