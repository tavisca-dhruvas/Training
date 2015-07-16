using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Model
{
    class Application
    {
        static Application()
        {
            RequestQueue = new InProcQueue();
        }
        public static IQueue RequestQueue { get; private set; }
    }
}
