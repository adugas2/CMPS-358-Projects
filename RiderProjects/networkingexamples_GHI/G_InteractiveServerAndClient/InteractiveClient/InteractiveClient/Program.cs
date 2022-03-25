using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;

namespace InteractiveClient
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

                try
                {
                    while (true)
                    {   
                        Console.Write("Send: ");
                        string outgoing = Console.ReadLine();
                        bw.Write(outgoing);
                        bw.Flush();

                        Console.WriteLine("Waiting ...");
                        string incomming = br.ReadString();
                        Console.WriteLine(incomming);
                    }

                }
                catch
                {
                    Console.WriteLine("Connection Broken");
                }
            }
        }
    }  
}
