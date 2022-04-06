using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Documentation
{
    public class Specifier<T> : ISpecifier
    {
        public string GetApiDescription()
        {
            var type = typeof(VkApi);
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);  // Reflection.  
            string description = null;
            foreach (System.Attribute attr in attrs)
            {
                if (attr is ApiDescriptionAttribute)
                {
                    var a = (ApiDescriptionAttribute)attr;
                    description = a.Description;
                }
            }
            return description;
        }

        public string[] GetApiMethodNames()
        {
            var type = typeof(VkApi);
            var refMethods = type.GetMethods();  // Reflection.  
            List<string> methods = new List<string>();
            foreach (var method in refMethods)
            {
                methods.Add(method.Name);
            }
            return methods.ToArray();
        }

        public string GetApiMethodDescription(string methodName)
        {
            throw new NotImplementedException();
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            throw new NotImplementedException();
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            throw new NotImplementedException();
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            throw new NotImplementedException();
        }

        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            throw new NotImplementedException();
        }
    }
}