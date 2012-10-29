using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.ObjectContainer;
using BDDD.Config;
using BDDD.Application;
using BDDD.Interception;
using BDDD.Repository;
using System.Reflection;

namespace BDDD.Tests.Common.Configuration
{
    [TestClass]
    public class ManualConfigurationTest
    {
        Type UnitOfWorkContract = typeof(IUnitOfWork);
        MethodInfo CommitMethod;
        MethodInfo RollbackMethod;

        public ManualConfigurationTest()
        {
            CommitMethod = UnitOfWorkContract.GetMethod("Commit", BindingFlags.Public | BindingFlags.Instance);
            RollbackMethod = UnitOfWorkContract.GetMethod("Rollback", BindingFlags.Public | BindingFlags.Instance);
        }

        [TestMethod()]
        [Description("测试用ManualConfigSource启动App")]
        public void ManualConfigSourceStart()
        {
            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            AppRuntime.Create(configSource);

            Assert.IsNotNull(configSource);
        }

        [TestMethod()]
        [Description("向ManualConfigSource中添加拦截器")]
        public void ManualConfigSource_AddInterceptor()
        {
            ManualConfigSource manualConfigSource = ConfigHelper.GetManualConfigSource();
            manualConfigSource.AddInterceptor(typeof(ExceptionHandlerInterceptor));

            Assert.IsTrue(manualConfigSource.Config.Interception.Interceptors.Count == 1);
        }

        [TestMethod()]
        [Description("向ManualConfigSource中添加拦截器代理")]
        public void ManualConfigSource_AddInterceptorRef()
        {
            ManualConfigSource manualConfigSource = ConfigHelper.GetManualConfigSource();
            manualConfigSource.AddInterceptorRef(UnitOfWorkContract, CommitMethod, typeof(ExceptionHandlerInterceptor).AssemblyQualifiedName);

            Assert.IsTrue(manualConfigSource.Config.Interception.Contracts.Count > 0);
            Assert.AreEqual<string>(manualConfigSource.Config.Interception.Contracts.GetItemAt(0).Type, UnitOfWorkContract.AssemblyQualifiedName);
            Assert.AreEqual<int>(manualConfigSource.Config.Interception.Contracts.GetItemAt(0).Methods.Count,1);
            Assert.AreEqual<string>(manualConfigSource.Config.Interception.Contracts.GetItemAt(0).Methods.GetItemAt(0).Signature, CommitMethod.GetSignature());
            Assert.AreEqual<int>(manualConfigSource.Config.Interception.Contracts.GetItemAt(0).Methods.GetItemAt(0).InterceptorRefs.Count, 1);
            Assert.AreEqual<string>(manualConfigSource.Config.Interception.Contracts.GetItemAt(0).Methods.GetItemAt(0).InterceptorRefs.GetItemAt(0).Name, typeof(ExceptionHandlerInterceptor).AssemblyQualifiedName);
        }
    }
}
