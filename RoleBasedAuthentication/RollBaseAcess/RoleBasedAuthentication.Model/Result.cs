using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RollBasedAuthentication.Model
{

    public class Result
    {

        public Status Status;
        public Result()
        {
            Status = new Status();
            Status.StatusCode = "200";
            Status.Message = "OK";
        }

    }
}
