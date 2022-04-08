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
            if(type != typeof(VkApi))
                return null;
            return type.GetCustomAttribute<ApiDescriptionAttribute>().Description; 
        }

        public string[] GetApiMethodNames()
        {
            var type = typeof(T);
            if (type == null)
                return null;
            return type.GetMethods().Where(x => x.Name != "Authorize2"
                                             && x.Name != "ToString"
                                             && x.Name != "GetHashCode"
                                             && x.Name != "Equals"
                                             && x.Name != "EnterBackdoor"
                                             && x.Name != "GetType")
                                        .Select(x => x.Name).ToArray();
        }

        public string GetApiMethodDescription(string methodName)
        {
            var type = typeof(T);
            if (type == null)
                return null;
            var methodInfo = type.GetMethod(methodName);
            if (methodInfo == null)
                return null;
            if(methodInfo.GetCustomAttributes(typeof(ApiDescriptionAttribute), false).Length == 0)
                return null;
            return methodInfo.GetCustomAttribute<ApiDescriptionAttribute>().Description;
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            if(methodName == null)
                throw new ArgumentNullException(nameof(methodName));
            var type = typeof (T);
            MethodInfo methodInfo = type.GetMethod(methodName);
            var pars = methodInfo.GetParameters().Select(x => x.Name);
            return pars.ToArray<string>();
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            if (methodName == null || paramName == null)
                return null;
            var type = typeof(T);
            MethodInfo methodInfo = type.GetMethod(methodName);
            if (methodInfo == null)
                return null;
            if (methodInfo.GetParameters().FirstOrDefault(x => x.Name == paramName) == null)
                return null;
            var parameter = methodInfo.GetParameters().FirstOrDefault(x => x.Name == paramName);
            if (parameter == null)
                return null;
            var paramAttribute = parameter.GetCustomAttribute<ApiDescriptionAttribute>();
            if (paramAttribute == null)
                return null;
            return paramAttribute.Description;
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
                var parameterInfos = method.GetParameters();
                var result = new ApiMethodDescription
                {
                    MethodDescription = new CommonDescription(methodName, GetApiMethodDescription(methodName)),
                    ParamDescriptions = new ApiParamDescription[parameterInfos.Length]
                };

                for (int i = 0; i < parameterInfos.Length; i++)
                {
                    result.ParamDescriptions[i] = GetApiMethodParamFullDescription(method.Name, parameterInfos[i].Name);
                }

                var returnAttributes = method.ReturnTypeCustomAttributes.GetCustomAttributes(true);

                if (returnAttributes.Any())
                {
                    result.ReturnDescription = new ApiParamDescription
                    {
                        ParamDescription = new CommonDescription(),
                        Required = false,
                        MaxValue = null,
                        MinValue = null
                    };

                    if (returnAttributes.OfType<ApiRequiredAttribute>().Any())
                    {
                        result.ReturnDescription.Required = returnAttributes
                            .OfType<ApiRequiredAttribute>()
                            .First()
                            .Required;
                    }

                    if (returnAttributes.OfType<ApiIntValidationAttribute>().Any())
        
                    {
                        result.ReturnDescription.MinValue = returnAttributes
                            .OfType<ApiIntValidationAttribute>()
                            .First()
                            .MinValue;
                        result.ReturnDescription.MaxValue = returnAttributes
                            .OfType<ApiIntValidationAttribute>()
                            .First()
                            .MaxValue;
                    }
                }

                return result;
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