﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedAuthentication.Helper
{
    public class CustomPrincipalSerializedModel
    {

            public string EmpId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Title { get; set; }

            public string EmailId { get; set; }
    }
}