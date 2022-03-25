// Austin Dugas
// C00231110
// CMPS 358
// Project: p5

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;

namespace Post
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
                        Console.Write("Write your message: ");
                        string outgoing = Console.ReadLine();
                        Console.Write("Write your IP Address: ");
                        string ipAddress = Console.ReadLine();
                        bw.Write(outgoing);
                        bw.Write(ipAddress);
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