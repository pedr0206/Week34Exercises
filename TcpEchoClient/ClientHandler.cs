using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Week34Exercises
{
    public class ClientHandler
    {
        Socket client;
        public ClientHandler(Socket client)
        {
            this.client = client;
        }

        public void Run()
        {
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);
            string inputLine = "";
            while (inputLine != null)
            {
                inputLine = reader.ReadLine();
                writer.WriteLine("Echoing string: " + inputLine);
                Console.WriteLine("Echoing string: " + inputLine);
            }
            Console.WriteLine("Server saw disconnect from client.");
        }
    }
}
