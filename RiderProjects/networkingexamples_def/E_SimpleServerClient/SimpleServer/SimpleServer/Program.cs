// Do not delete bin/ or obj/ from this example.
// If you have trouble running this example, 
// create a new project in Rider and copy the
// code from Program.cs into the new project.

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SimpleServer
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
                String time = DateTime.Now.ToString();
                Console.WriteLine(bw.ToString() + ", " + time);
                bw.Write(time);
                bw.Flush();
            }
        }
    }
}