// Do not delete bin/ or obj/ from this example.
// If you have trouble running this example, 
// create a new project in Rider and copy the
// code from Program.cs into the new project.

using System;
using System.IO;
using System.Net.Sockets;

namespace SimpleClient
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
                String line = br.ReadString();
                Console.WriteLine("Time and Date: " + line);
            }
        }
    }
}