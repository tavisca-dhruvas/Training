﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Tavisca.EmployeeManagement.DataContract
{
    [DataContract]
    public class RemarkResponse : Result
    {
        [DataMember]
        public Remark Remark
        {
            get;
            set;
        }
    }
}
