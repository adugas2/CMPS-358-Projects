// If you have trouble running this example, 
// create a new project in Rider and copy the
// code from Program.cs into the new project.


using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TaskContinuingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().AsyncServer();
            Console.ReadLine();             // necessary :(
        }

        async void AsyncServer()
        {
            var listen = new TcpListener(IPAddress.Any, 8081);
            try
            {
                listen.Start();
                Console.WriteLine($"Listening on 8081 ...");
            }
            catch (Exception e) {
                Console.WriteLine("Port 8081 in use");
                return;
            }

            try
            {
                while (true)
                {
                    ServeOneClient(await listen.AcceptTcpClientAsync());
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("stopping ...");
                listen.Stop();
            }

        }

        async Task ServeOneClient(TcpClient clientConnection)
        {

            await Task.Yield();

            try
            {
                using (clientConnection)
                using (NetworkStream theClient = clientConnection.GetStream())
                {
                    BinaryWriter bw = new BinaryWriter(theClient);
                    String time = DateTime.Now.ToString();
                    Console.WriteLine(bw.ToString() + ", " + time);
                    bw.Write(time);
                    bw.Flush();
                    bw.Close();
                    bw.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
