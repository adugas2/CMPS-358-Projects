using System.Net.Sockets;

namespace Fully2wayClient
{
    class Program
    {
        static List<string> area1 = new List<string>();
        static List<string> area2 = new List<string>();
        static int areaHeights = 0;
        
        static void Main(string[] args)
        {
            Client();
        }

        static void Client()
        {
            // Number of rows for each area
            areaHeights = (Console.WindowHeight - 2) / 2;

            using (TcpClient connectionToServer = new TcpClient("localhost", 8081))
            using (NetworkStream theServer = connectionToServer.GetStream())
            {
                BinaryReader br = new BinaryReader(theServer);
                BinaryWriter bw = new BinaryWriter(theServer);

                new StreamFromServerInput(br);
                
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
                catch { }
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