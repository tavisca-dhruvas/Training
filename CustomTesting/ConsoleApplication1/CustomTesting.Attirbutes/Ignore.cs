using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CustomTesting.Attributes
{

    [AttributeUsage(AttributeTargets.Class |
    AttributeTargets.Constructor |
    AttributeTargets.Method,
    AllowMultiple = true)]

    public class Ignore : System.Attribute
    {
        public static bool Exists(MethodInfo type)
        {
            foreach (Object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is Ignore)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
