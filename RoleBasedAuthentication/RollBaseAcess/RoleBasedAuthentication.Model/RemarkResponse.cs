using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace RollBasedAuthentication.Model
{

    public class RemarkResponse : Result
    {

        public Remark Remark
        {
            get;
            set;
        }
    }
}
