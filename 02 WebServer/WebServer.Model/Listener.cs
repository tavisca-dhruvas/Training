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
using Webserver.Model;


namespace WebServer.Model
{
   public  class Listener
    {
       private TcpListener _listener;
        private bool _running = false;
        public Listener(int port)
        {
            this._listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            Thread serverThread = new Thread(new ThreadStart(Run));
            serverThread.Start();
        }

        private void Run()
        {
            _running = true;
            this._listener.Start();
            Queue queueObject = new Queue();
            while (_running)
            {
                if (_listener.Pending())
                {

                    Socket clientSocket = this._listener.AcceptSocket();
                    if (clientSocket.Connected == false) continue;
                    queueObject.Enqueue(clientSocket);

                    if (queueObject.TryDequeue(out clientSocket) == false) continue;

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
