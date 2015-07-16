using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WebServer.Model
{
    public class Parser
    {
        private Encoding _charEncoder = Encoding.UTF8;
        public string HttpMethod;
        public string HttpUrl;
        public string HttpProtocolVersion;


        public void RequestParser(string requestString)
        {
            try
            {
                if (requestString == null)
                    throw new Exception(Resources.UnImplementedMethod);
                string[] tokens = requestString.Split(' ');

                tokens[1] = tokens[1].Replace("/", "\\");
                HttpMethod = tokens[0].ToUpper();
                HttpUrl = tokens[1];
                HttpProtocolVersion = tokens[2];
            }
            catch (Exception )
            {
                throw new Exception (Resources.RequestInvalid);
            }
        }
    }
}
