using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RollBaseAcess.Model
{
    public class ChangePasssword
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string EmailId { get; set; }
    }
}