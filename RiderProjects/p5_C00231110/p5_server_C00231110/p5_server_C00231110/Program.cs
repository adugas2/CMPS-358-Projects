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

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sets up address for post client
            TcpListener listenPort = new TcpListener(IPAddress.Any, 8081);
            listenPort.Start();
            Console.WriteLine($"Listening on 8081 ...");

            // Sets up address for retrieve client
            TcpListener listenRetrieve = new TcpListener(IPAddress.Any, 8082);
            listenRetrieve.Start();
            Console.WriteLine("Listening on 8082 ...");

            // Runs thread for post client
            using (TcpClient clientConnect = listenPort.AcceptTcpClient())
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

                        Console.Write("Key = 7");
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
            
            // Runs thread for retrieving client
            using (TcpClient clientConnect = listenRetrieve.AcceptTcpClient())
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

                        Console.Write("Key: ");
                        string outgoing = Console.ReadLine();
                        if (outgoing == "7")
                            bw.Write("hi");
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