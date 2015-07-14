using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Listener serverListener = new Listener(8080);
                serverListener.Start();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
