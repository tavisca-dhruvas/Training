using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CustomTesting.Attributes;
using CustomTesting.Model;

namespace CustomTesting.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(args[0]);
            Console.WriteLine("Enter the category");
            var category = Console.ReadLine();

            var ignoreMethods = new List<string>();
            var executableMethods = new List<string>();
            var categoryMethods = new List<string>();
             
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
                            else
                            {
                                executableMethods.Add(method.Name);
                                if (!string.IsNullOrWhiteSpace(category) && Category.Exists(method, category))
                                    categoryMethods.Add(method.Name);
                            }
                                
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
            foreach (string s in categoryMethods)
            {
                Console.WriteLine("category methods" + s);
            }
            Console.ReadKey();

        }
    }
}
