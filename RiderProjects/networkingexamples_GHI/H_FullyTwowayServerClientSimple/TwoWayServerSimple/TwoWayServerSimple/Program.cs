using System.Net;
using System.Net.Sockets;

namespace TwoWayServerSimple

{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listen = new TcpListener(IPAddress.Any, 8081);
            listen.Start();
            Console.WriteLine($"Listening for client on 8081 ...");

            using (TcpClient clientConnect = listen.AcceptTcpClient())
            using (NetworkStream theClient = clientConnect.GetStream())
            {
                BinaryWriter bw = new BinaryWriter(theClient);
                BinaryReader br = new BinaryReader(theClient);

                new StreamFromClientInput(br);

                try
                {
                    while (true)
                    {
                        bw.Write(Console.ReadLine());
                        bw.Flush();
                    }
                }
                catch
                {
                    Console.WriteLine("Connection Broken");
                }
            }
        }
        

        class StreamFromClientInput
        {
            public StreamFromClientInput(BinaryReader br)
            {
                new Thread(() => InputLoop(br)).Start();
            }

            static void InputLoop(BinaryReader br)
                {
                    try
                    {
                        while (true)
                        {
                            string incoming = br.ReadString();
                            Console.WriteLine($"Incoming: {incoming}");
                        }
                    }
                    catch { }
            }
        }
    }
}