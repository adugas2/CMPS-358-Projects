using System.Net;
using System.Net.Sockets;

namespace Fully2wayServer;

internal class Program
{
    private static void Main(string[] args)
    {
        List<StreamFromClientInput> clientList = new List<StreamFromClientInput>();
        
        var listen = new TcpListener(IPAddress.Any, 8081);
        listen.Start();
        Console.WriteLine("Listening for client on 8081 ...");

        while (true)
        {
            var clientConnect = listen.AcceptTcpClient();
            var theClient = clientConnect.GetStream();
            
            var bw = new BinaryWriter(theClient);
            var br = new BinaryReader(theClient);

            var sfcInput = new StreamFromClientInput(br, bw, clientList);
            lock (clientList) 
            {
                clientList.Add(sfcInput);
            }
        }
        
    }

    private class StreamFromClientInput
    {
        private BinaryWriter bw;
        
        public StreamFromClientInput(BinaryReader br, BinaryWriter bw, List<StreamFromClientInput> list)
        {
            this.bw = bw;
            new Thread(() => InputLoop(br, list)).Start();
        }

        private static void InputLoop(BinaryReader br, List<StreamFromClientInput> list)
        {
            try
            {
                while (true)
                {
                    var incomming = br.ReadString();
                    foreach(var c in list)
                        try
                        {
                            c.bw.Write(incomming);
                        }
                        catch 
                        {
                        }
                }
            }
            catch
            {
            }
        }
    }
}