using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net.Sockets;
using System.Collections.Concurrent;

namespace WebServer.Model
{
    public class InProcQueue : IQueue
    {
        private ConcurrentQueue<Socket> _queue = new ConcurrentQueue<Socket>();

        public bool TryDequeue(out Socket socket)
        {
            return this._queue.TryDequeue(out socket);
        }

        public void Enqueue(Socket socket)
        {
            this._queue.Enqueue(socket);

        }
    }
}
