using System.Net;
using System.Net.Sockets;

namespace Fully2wayServer
{
    class Program
    {
        static List<string> area1 = new List<string>();
        static List<string> area2 = new List<string>();
        static int areaHeights = 0;
        
        static void Main(string[] args)
        {
            // Number of rows for each area
            areaHeights = (Console.WindowHeight - 2) / 2;
            
            TcpListener listen = new TcpListener(IPAddress.Any, 8081);
            listen.Start();
            Console.WriteLine($"Listening for client on 8081 ...");

            using (TcpClient clientConnect = listen.AcceptTcpClient())
            using (NetworkStream theClient = clientConnect.GetStream())
            {
                BinaryWriter bw = new BinaryWriter(theClient);
                BinaryReader br = new BinaryReader(theClient);

                new StreamFromClientInput(br);
                    
                DrawScreen();
                
                try
                {
                    while (true)
                    {
                        bw.Write(AddLineToBuffer(ref area2, Console.ReadLine()));
                        DrawScreen();
                        bw.Flush();
                    }
                }
                catch
                {
                    Console.WriteLine("Connection Broken");
                }
            }
        }
        
        private static String AddLineToBuffer(ref List<string> areaBuffer, string line)
        {
            areaBuffer.Insert(0, line);

            if (areaBuffer.Count == areaHeights)
            {
                areaBuffer.RemoveAt(areaHeights - 1);
            }

            return line;
        }
        
        private static void DrawScreen()
        {
            Console.Clear();

            // Draw the area divider
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.SetCursorPosition(i, areaHeights);
                Console.Write('=');
            }

            int currentLine = areaHeights - 1;

            for (int i = 0; i < area1.Count; i++)
            {
                Console.SetCursorPosition(0, currentLine - (i + 1));
                Console.WriteLine(area1[i]);

            }

            currentLine = (areaHeights * 2);
            for(int i = 0; i < area2.Count; i++)
            {
                Console.SetCursorPosition(0, currentLine - (i + 1));
                Console.WriteLine("You said: " + area2[i]);
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("You Say: ");
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
                            string incomming = br.ReadString();
                            AddLineToBuffer(ref area1, "They said: " + incomming);
                            DrawScreen();
                        }
                    }
                    catch { }
            }
        }
    }
}