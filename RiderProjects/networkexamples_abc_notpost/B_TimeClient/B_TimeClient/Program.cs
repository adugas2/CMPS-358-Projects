using System.Net;
using System.Net.Sockets;
using System.Text;

/* 	Some Public Time Servers
	time.nist.gov 192.43.244.18 NCAR, Boulder, Colorado
	time-b.nist.gov 129.6.15.29 NIST, Gaithersburg, Maryland
	ntp-wwv.nist.gov
	ntp-d.nist.gov
*/


var port = 13;

Console.Write("Enter URL of Time Server: ");
var url = Console.ReadLine();

var hostEntry = Dns.GetHostEntry(url);

foreach (var address in hostEntry.AddressList)
{
    var ipe = new IPEndPoint(address, port);
    var sock = new Socket(ipe.AddressFamily,
        SocketType.Stream, ProtocolType.Tcp);
    sock.Connect(ipe);
    if (sock.Connected)
    {
        Console.WriteLine("connected");
        var bytesReceived = new byte[256];
        var bytes = sock.Receive(bytesReceived,
            bytesReceived.Length, 0);
        Console.WriteLine("Bytes Received: {0}",
            bytes);

        Console.WriteLine(Encoding.ASCII.GetString(
            bytesReceived, 0, bytes));
    }

    break;
}