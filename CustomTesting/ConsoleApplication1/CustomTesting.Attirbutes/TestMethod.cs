using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CustomTesting.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor |
    AttributeTargets.Method,
    AllowMultiple = true)]

    public class TestMethod : System.Attribute
    {
        public static bool Exists(MethodInfo type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is TestMethod)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
