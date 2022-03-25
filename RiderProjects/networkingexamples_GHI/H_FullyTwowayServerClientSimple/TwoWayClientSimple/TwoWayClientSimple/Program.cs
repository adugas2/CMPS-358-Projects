using System.Net.Sockets;

namespace Fully2wayClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client();
        }

        static void Client()
        {
            using (TcpClient connectionToServer = new TcpClient("localhost", 8081))
            using (NetworkStream theServer = connectionToServer.GetStream())
            {
                BinaryReader br = new BinaryReader(theServer);
                BinaryWriter bw = new BinaryWriter(theServer);

                new StreamFromServerInput(br);

                try
                {
                    while (true)
                    {
                        bw.Write(Console.ReadLine());
                    }
                }
                catch { }
            }
        }
        
       class StreamFromServerInput
        {
            public StreamFromServerInput(BinaryReader br)
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