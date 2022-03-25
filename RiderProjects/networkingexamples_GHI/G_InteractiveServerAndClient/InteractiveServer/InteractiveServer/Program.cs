using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;


namespace InteractiveServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listen = new TcpListener(IPAddress.Any, 8081);
            listen.Start();
            Console.WriteLine($"Listening on 8081 ...");

            using (TcpClient clientConnect = listen.AcceptTcpClient())
            using (NetworkStream theClient = clientConnect.GetStream())
            {
                BinaryWriter bw = new BinaryWriter(theClient);
                BinaryReader br = new BinaryReader(theClient);

                try
                {
                    while (true)
                    {
                        Console.WriteLine("Waiting ...");
                        string incomming = br.ReadString();
                        Console.WriteLine(incomming);

                        Console.Write("Send: ");
                        string outgoing = Console.ReadLine();
                        bw.Write(outgoing);
                        bw.Flush();
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