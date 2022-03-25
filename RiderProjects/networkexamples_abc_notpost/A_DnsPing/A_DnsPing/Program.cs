using System.Net;
using System.Net.NetworkInformation;

Console.Write("Enter URL: ");
var address = Console.ReadLine();

if (string.IsNullOrWhiteSpace(address)) address = "https://louisiana.edu/search?q=cmix";

// create a URI
Uri uri = new(address);

// get basic information
Console.WriteLine($"Protocol: {uri.Scheme}, Port: {uri.Port}, Host: {uri.Host}, " +
                  "Path: {uri.AbsolutePath}, Query: {uri.Query}");
Console.WriteLine();

// get DNS information
var entry = Dns.GetHostEntry(uri.Host);
Console.WriteLine("Host has the following addresses: ");
foreach (var addr in entry.AddressList) Console.WriteLine($"    {addr} ({addr.AddressFamily})");

Console.WriteLine();

// ping and response
try
{
    Ping ping = new();
    Console.WriteLine("Pinging ...");
    var reply = ping.Send(uri.Host);
    Console.WriteLine($"Response to ping: {reply.Status}");
    if (reply.Status == IPStatus.Success) Console.WriteLine($"round trip: {reply.RoundtripTime} ms");
}
catch
{
    Console.WriteLine("Fail!");
}