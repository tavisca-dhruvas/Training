using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;

namespace WebServer.Model
{
   public  class Dispatcher
    {
        private  Socket _clientSocket = null;

        public Dispatcher(Socket clientSocket)
        {
            this._clientSocket = clientSocket;
        }
        public void HandleClient()
        {
            var parserObject = new Parser();
            string requestString = DecodeRequest(this._clientSocket);
            parserObject.RequestParser(requestString);

            Console.WriteLine(parserObject.HttpUrl);
            if (parserObject.HttpMethod != null && parserObject.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {

                var createResponse = new Responses(this._clientSocket, ConfigurationManager.AppSettings["Path"]);
                createResponse.RequestUrl(parserObject.HttpUrl);
            }
            StopClientSocket(this._clientSocket);
        }

        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
        }

        private string DecodeRequest(Socket clientSocket)
        {
            Encoding _charEncoder = Encoding.UTF8;
            var bucket = new byte[1024];
            using (var buffer = new System.IO.MemoryStream())
            {
                while (true)
                {
                    var bytesRead = clientSocket.Receive(bucket);
                    if (bytesRead > 0)
                        buffer.Write(bucket, 0, bytesRead);

                    if (clientSocket.Available == 0)
                        break;
                }
                return  buffer.ToString();
            }



        }
    }
}
