using RoleBasedAuthentication.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace RoleBasedAuthentication.Helper
{
    public class CustomPrincipal:ICustomPrincipal
    {
        
    public IIdentity Identity { get; private set; }
 
    public CustomPrincipal(string username)
	{
		this.Identity = new GenericIdentity(username);
	}
 
	public bool IsInRole(string role)
	{
		return Identity != null && Identity.IsAuthenticated && 
		   !string.IsNullOrWhiteSpace(role) && string.Equals(Title,role);
	}

	public string EmpId { get; set; }

	public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Title { get; set; }

    }
}