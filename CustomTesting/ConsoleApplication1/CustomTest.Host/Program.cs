using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CustomTesting.Attributes;

namespace CustomTesting.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(args[0]);
            var category = "Smoke Test";

            var ignoreMethods = new List<string>();
            var executableMethods = new List<string>();
             
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass && TestClass.Exists(type))
                {
                    foreach (MethodInfo method in (type.GetMethods()))
                    {
                        if (TestMethod.Exists(method))
                        {
                            if (Ignore.Exists(method))
                                ignoreMethods.Add(method.Name);
                            else if (string.IsNullOrWhiteSpace(category) || Category.Exists(method, category))
                                executableMethods.Add(method.Name);
                        }
                    }
                }
            }
            foreach (string s in ignoreMethods)
            {
                Console.WriteLine("ignore methods" + s);
            }
            foreach (string s in executableMethods)
            {
                Console.WriteLine("executalbe methods" + s);
            }
            Console.ReadKey();

        }
    }
}
