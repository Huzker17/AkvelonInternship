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
            var type = typeof(T);
            if (type == null)
                return null;
            Attribute[] attrs = Attribute.GetCustomAttributes(type);    
            string description = null;
            foreach (Attribute attr in attrs)
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
            var type = typeof(T);
            if (type == null)
                return null;
            var refMethods = type.GetMethods();  // Reflection.  
            List<string> methods = new List<string>();
            foreach (var method in refMethods)
            {
                if(method.Name == "Authorize" || method.Name == "SelectAudio" || method.Name == "GetTotalAudioCount")
                    methods.Add(method.Name);
            }
            return methods.ToArray();
        }

        public string GetApiMethodDescription(string methodName)
        {
            var type = typeof(T);
            if (type == null)
                return null;
            var invoke = type.GetMethod(methodName);
            if (invoke == null)
                return null;
            var attrs = ApiDescriptionAttribute.GetCustomAttributes(invoke);
            if (attrs == null)
                return null;
            string description = null;
            foreach (var attr in attrs)
            {
                if (attr is ApiDescriptionAttribute)
                {
                    var a = (ApiDescriptionAttribute)attr;
                    description = a.Description;
                }
            }
            return description;
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            if(methodName == null)
                throw new ArgumentNullException(nameof(methodName));
            var type = typeof (T);
            MethodInfo invoke = type.GetMethod(methodName);
            var pars = invoke.GetParameters().Select(x => x.Name);
            return pars.ToArray<string>();
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            if (methodName == null || paramName == null)
                return null;
            var type = typeof(T);
            MethodInfo invoke = type.GetMethod(methodName);
            if (invoke == null)
                return null;
            var pars = invoke.GetParameters().FirstOrDefault(x => x.Name == paramName);
            if (pars != null)
            {
                var test = pars.GetCustomAttribute(typeof(ApiDescriptionAttribute));
                var a = (ApiDescriptionAttribute)test;
                if (a == null)
                    return null;
                var description = a.Description;
                return description;
            }
            else
                return null;
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            var type = typeof(T);
            var result = new ApiParamDescription
            {
                ParamDescription = new CommonDescription(paramName),
                MaxValue = null,
                MinValue = null,
                Required = false
            };
            var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);

            if (method == null)
            {
                return result;
            }

            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                var parameter = method.GetParameters()
                    .FirstOrDefault(x => x.Name == paramName);
                if (parameter == null)
                {
                    return result;
                }
                result = CheckAttributType(parameter, result);
            }

            return result;
        }

        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            var type = typeof(T);
            var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);

            if (method == null)
            {
                return null;
            }

            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                var pars = method.GetParameters();
                var res = new ApiMethodDescription
                {
                    MethodDescription = new CommonDescription(methodName, GetApiMethodDescription(methodName)),
                    ParamDescriptions = new ApiParamDescription[pars.Length]
                };

                for (int i = 0; i < pars.Length; i++)
                {
                    res.ParamDescriptions[i] = GetApiMethodParamFullDescription(method.Name, pars[i].Name);
                }

                var returnAttributes = method.ReturnTypeCustomAttributes.GetCustomAttributes(true);

                if (returnAttributes.Any())
                {
                    res.ReturnDescription = new ApiParamDescription
                    {
                        ParamDescription = new CommonDescription(),
                        Required = false,
                        MaxValue = null,
                        MinValue = null
                    };

                    if (returnAttributes.OfType<ApiRequiredAttribute>().Any())
                    {
                        res.ReturnDescription.Required = returnAttributes
                            .OfType<ApiRequiredAttribute>()
                            .First()
                            .Required;
                    }

                    if (returnAttributes.OfType<ApiIntValidationAttribute>().Any())
        
                    {
                        res.ReturnDescription.MinValue = returnAttributes
                            .OfType<ApiIntValidationAttribute>()
                            .First()
                            .MinValue;
                        res.ReturnDescription.MaxValue = returnAttributes
                            .OfType<ApiIntValidationAttribute>()
                            .First()
                            .MaxValue;
                    }
                }

                return res;
            }

            return null;
        }

        private ApiParamDescription CheckAttributType(ParameterInfo parameterInfo, ApiParamDescription description)
        {
            if (parameterInfo.GetCustomAttributes().OfType<ApiDescriptionAttribute>().Any())
            {
                description.ParamDescription.Description = parameterInfo
                    .GetCustomAttributes()
                    .OfType<ApiDescriptionAttribute>()
                    .First()
                    .Description;
            }

            if (parameterInfo.GetCustomAttributes().OfType<ApiRequiredAttribute>().Any())
            {
                description.Required = parameterInfo
                    .GetCustomAttributes()
                    .OfType<ApiRequiredAttribute>()
                    .First()
                    .Required;
            }

            if (parameterInfo.GetCustomAttributes().OfType<ApiIntValidationAttribute>().Any())
            {
                description.MinValue = parameterInfo
                    .GetCustomAttributes()
                    .OfType<ApiIntValidationAttribute>()
                    .First()
                    .MinValue;
                description.MaxValue = parameterInfo
                    .GetCustomAttributes()
                    .OfType<ApiIntValidationAttribute>()
                    .First()
                    .MaxValue;
            }
            return description;
        }
    }
}