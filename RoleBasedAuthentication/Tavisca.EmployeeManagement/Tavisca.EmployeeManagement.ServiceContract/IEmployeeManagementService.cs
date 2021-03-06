﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Tavisca.EmployeeManagement.ServiceContract
{
    [ServiceContract]
    public interface IEmployeeManagementService
    {
        [WebInvoke(Method="POST", UriTemplate="/employee", RequestFormat= WebMessageFormat.Json, ResponseFormat= WebMessageFormat.Json)]
        EmployeeResponse Create(Employee employee);

        [WebInvoke(Method = "POST", UriTemplate = "/employee/{employeeId}/remark", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        RemarkResponse AddRemark(string employeeId, Remark remark);

        [WebInvoke(Method = "POST", UriTemplate = "/update", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result UpdatePassword(ChangePassword changePassword);

        [WebInvoke(Method = "POST", UriTemplate = "/login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        EmployeeResponse Authenticate(Credentials credentials );
    }

}
