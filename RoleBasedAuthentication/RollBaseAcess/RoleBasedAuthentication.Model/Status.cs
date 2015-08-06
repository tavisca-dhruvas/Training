using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RollBasedAuthentication.Model
{

    public class Status
    {

        public String StatusCode
        {
            get;
            set;
        }


        public string Message
        {
            get;
            set;
        }
        public Status()
        {
        }
        public Status(string statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }
    }
}
