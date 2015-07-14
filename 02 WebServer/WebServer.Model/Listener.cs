using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Configuration;


namespace WebServer.Model
{
   public  class Listener
    {

        private TcpListener _listener;
        private bool _running = false;
        public Listener(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            Thread serverThread = new Thread(new ThreadStart(Run));
            serverThread.Start();
        }

        public void Run()
        {
            _running = true;
            _listener.Start();
            while (_running)
            {
                if (_listener.Pending())
                {

                    Socket clientSocket = _listener.AcceptSocket();
                    Dispatcher dispatcher = new Dispatcher(clientSocket);
                    Thread dispatcherThread = new Thread(new ThreadStart(dispatcher.HandleClient));
                    dispatcherThread.Start();
                    //clientSocket.Close();
                }
            }
            _running = false;
            _listener.Stop();
        }

    }
}
