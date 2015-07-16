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

    public class Category : System.Attribute
    {
        private string _category;

        public string Category1
        {
            get
            {
                return _category;
            }

        }
        public Category(string category)
        {
            this._category = Category1;
        }


        public static bool Exists(MethodInfo memberInfo, string category)
        {
            foreach (object attribute in memberInfo.GetCustomAttributes(true))
            {
                if (attribute is Category)
                {
                    var attr = attribute as Category;
                    return attr._category.Equals(category, StringComparison.OrdinalIgnoreCase);
                }
            }
            return false;
        }


    }
}
