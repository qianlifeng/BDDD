using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace BDDD.Config
{
    partial class BDDDConfigSection
    {
        #region Private Methods

        private InterceptContractElement FindInterceptContractElement(Type contractType)
        {
            if (Interception.Contracts == null)
                return null;

            foreach (InterceptContractElement interceptContractElement in Interception.Contracts)
            {
                if (interceptContractElement.Type.Equals(contractType.AssemblyQualifiedName))
                    return interceptContractElement;
            }
            return null;
        }

        private InterceptMethodElement FindInterceptMethodElement(InterceptContractElement interceptContractElement,
                                                                  MethodInfo method)
        {
            if (interceptContractElement == null)
                return null;
            if (interceptContractElement.Methods == null)
                return null;

            foreach (InterceptMethodElement interceptMethodElement in interceptContractElement.Methods)
            {
                string methodSignature = null;
                if (method.IsGenericMethod)
                    methodSignature = method.GetGenericMethodDefinition().GetSignature();
                else
                    methodSignature = method.GetSignature();
                if (interceptMethodElement.Signature.Equals(methodSignature))
                    return interceptMethodElement;
            }
            return null;
        }

        private IEnumerable<string> FindInterceptorRefNames(InterceptMethodElement interceptMethodElement)
        {
            if (interceptMethodElement == null)
                return null;
            if (interceptMethodElement.InterceptorRefs == null)
                return null;
            var ret = new List<string>();
            foreach (InterceptorRefElement interceptorRefElement in interceptMethodElement.InterceptorRefs)
            {
                ret.Add(interceptorRefElement.Name);
            }
            return ret;
        }

        private string FindInterceptorTypeNameByRefName(string refName)
        {
            if (Interception == null || Interception.Interceptors == null)
                return null;
            foreach (InterceptorElement interceptorElement in Interception.Interceptors)
            {
                if (interceptorElement.Name.Equals(refName))
                    return interceptorElement.Type;
            }
            return null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     得到web.config/app.config中BDDD框架配置节点的序列化信息
        /// </summary>
        /// <returns>XML序列化后的配置信息</returns>
        public string GetSerializedXmlString()
        {
            return SerializeSection(null, Constants.DEFALT_CONFIG_SECTION_NAME, ConfigurationSaveMode.Full);
        }

        /// <summary>
        ///     从配置中查找所有需要对该类型的该方法进行拦截的所有拦截器
        /// </summary>
        /// <param name="contractType">需要被拦截的类型</param>
        /// <param name="method">需要被拦截的方法</param>
        /// <returns>
        ///     A list of <see cref="System.String" /> values which contains the interceptor types.
        /// </returns>
        public IEnumerable<string> GetInterceptorTypes(Type contractType, MethodInfo method)
        {
            if (Interception == null ||
                Interception.Interceptors == null ||
                Interception.Contracts == null)
                return null;

            InterceptContractElement interceptContractElement = FindInterceptContractElement(contractType);
            if (interceptContractElement == null)
                return null;

            InterceptMethodElement interceptMethodElement = FindInterceptMethodElement(interceptContractElement, method);
            if (interceptMethodElement == null)
                return null;

            IEnumerable<string> interceptorRefNames = FindInterceptorRefNames(interceptMethodElement);
            if (interceptorRefNames == null || interceptorRefNames.Count() == 0)
                return null;

            var ret = new List<string>();
            foreach (string interceptorRefName in interceptorRefNames)
            {
                string interceptorTypeName = FindInterceptorTypeNameByRefName(interceptorRefName);
                if (!string.IsNullOrEmpty(interceptorTypeName))
                    ret.Add(interceptorTypeName);
            }
            return ret;
        }

        #endregion
    }
}