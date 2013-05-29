using System;
using System.Reflection;
using System.Text;

namespace BDDD
{
    public static class Utils
    {
        public static string GetSignature(this Type type)
        {
            var sb = new StringBuilder();

            if (type.IsGenericType)
            {
                sb.Append(type.GetGenericTypeDefinition().FullName);
                sb.Append("[");
                int i = 0;
                Type[] genericArgs = type.GetGenericArguments();
                foreach (Type genericArg in genericArgs)
                {
                    sb.Append(genericArg.GetSignature());
                    if (i != genericArgs.Length - 1)
                        sb.Append(", ");
                    i++;
                }
                sb.Append("]");
            }
            else
            {
                if (!string.IsNullOrEmpty(type.FullName))
                    sb.Append(type.FullName);
                else if (!string.IsNullOrEmpty(type.Name))
                    sb.Append(type.Name);
                else
                    sb.Append(type);
            }
            return sb.ToString();
        }

        public static string GetSignature(this MethodInfo method)
        {
            var sb = new StringBuilder();
            Type returnType = method.ReturnType;
            sb.Append(method.ReturnType.GetSignature());
            sb.Append(" ");
            sb.Append(method.Name);
            if (method.IsGenericMethod)
            {
                sb.Append("[");
                Type[] genericTypes = method.GetGenericArguments();
                int i = 0;
                foreach (Type genericType in genericTypes)
                {
                    sb.Append(genericType.GetSignature());
                    if (i != genericTypes.Length - 1)
                        sb.Append(", ");
                    i++;
                }
                sb.Append("]");
            }
            sb.Append("(");
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters != null && parameters.Length > 0)
            {
                int i = 0;
                foreach (ParameterInfo parameter in parameters)
                {
                    sb.Append(parameter.ParameterType.GetSignature());
                    if (i != parameters.Length - 1)
                        sb.Append(", ");
                    i++;
                }
            }
            sb.Append(")");
            return sb.ToString();
        }
    }
}