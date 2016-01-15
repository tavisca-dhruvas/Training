using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTesting.Attributes
{

    [AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true)]

    public class TestClass : System.Attribute
    {
        public static bool Exists(Type type)
        {
            foreach (Object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is TestClass)
                {
                    return true;
                }

            }
            return false;
        }

    }
}
