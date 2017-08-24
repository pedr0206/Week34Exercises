using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace Week34Exercises
{
    class TcpEchoServer
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting echo server...");

            int port = 21234;
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();
            
           
            while (true)
            {
                Socket client = listener.AcceptSocket();
                ClientHandler ch = new ClientHandler(client);
                Thread Th = new Thread(new ThreadStart(ch.Run));
                Th.Start();
            }
        }
    }
}
//https://thiscouldbebetter.wordpress.com/2015/01/13/an-echo-server-and-client-in-c-using-tcplistener-and-tcpclient/
