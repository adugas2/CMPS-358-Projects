// "WebServer" from "C# 8.0 in a Nutshell"
// by Albahari and Johannsen
//
// Do not delete bin/ or obj/ from this example.
// If you have trouble running this example, 
// create a new project in Rider and copy the
// code from Program.cs into the new project.

using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;


namespace HttpServer
{
    class Program
    {
        static void Main()
        {
            // Listen on port 8081, serving files in TempDirectory/webroot: (\ for Windows)
            var server = new WebServer("http://localhost:8081/", Path.Combine(TempDirectory, "webroot"));

            try
            {
                server.Start();
                // If running in LINQPad, stop the query manually:
                Console.WriteLine("Server running... press Enter to stop");
                Console.ReadLine();
            }
            finally { server.Stop(); }
        }


        class WebServer
        {
            HttpListener _listener;
            string _baseFolder;      // Your web page folder.

            public WebServer(string uriPrefix, string baseFolder)
            {
                _listener = new HttpListener();
                _listener.Prefixes.Add(uriPrefix);
                _baseFolder = baseFolder;
            }

            public async void Start()
            {
                _listener.Start();
                while (true)
                    try
                    {
                        var context = await _listener.GetContextAsync();
                        Task.Run(() => ProcessRequestAsync(context));
                    }
                    catch (HttpListenerException) { break; }   // Listener stopped.
                    catch (InvalidOperationException) { break; }   // Listener stopped.
            }

            public void Stop() { _listener.Stop(); }

            async void ProcessRequestAsync(HttpListenerContext context)
            {
                try
                {
                    string filename = Path.GetFileName(context.Request.RawUrl);
                    string path = Path.Combine(_baseFolder, filename);
                    byte[] msg;
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Resource not found: " + path);
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        msg = Encoding.UTF8.GetBytes("Sorry, that page does not exist");
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        msg = File.ReadAllBytes(path);
                    }
                    context.Response.ContentLength64 = msg.Length;
                    using (Stream s = context.Response.OutputStream)
                        await s.WriteAsync(msg, 0, msg.Length);
                }
                catch (Exception ex) { Console.WriteLine("Request error: " + ex); }
            }
        }
        static string TempDirectory
        {
            // Linux Example
            get => RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "/home/fducrest/httpd" : "/tmp";

            // Mac Example 
            // get => RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "/Users/fducrest/httpd" : "/tmp";

            // Windows Example
            //get => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? @"C:\Users\fducrest\Documents\vscprojects\08\httpd" : @"c:\";
        }
    }
}