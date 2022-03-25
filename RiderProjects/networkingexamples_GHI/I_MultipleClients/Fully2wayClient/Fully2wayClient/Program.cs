using System.Net.Sockets;

namespace Fully2wayClient
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Client(name);
        }

        static void Client(string name)
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
                        string message = "[" + name + "] " + Console.ReadLine();
                        bw.Write(message);
                        bw.Flush();
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
                        Console.WriteLine(incoming);
                    }
                }
                catch { }
            }
        }
    }  
}