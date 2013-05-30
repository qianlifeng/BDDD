using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BDDD.Application;
using BDDD.Repository;
using BDDD.ObjectContainer;
using DemoProject.DTO;
using DemoProject.Domain.Model;
using DemoProject.Domain.Repositories;
using Microsoft.Practices.Unity;

namespace DemoProject.Application
{
    public abstract class ApplicationServiceBase
    {
        private readonly IRepositoryContext context = ServiceLocator.Instance.GetService<IRepositoryContext>();
        UnityContainer unityContainer = AppRuntime.Instance.CurrentApplication.ObjectContainer.GetRealObjectContainer<UnityContainer>();

        protected T GetResolvedRepository<T>()
        {
            //因为UserRepository的构造函数里面需要RepositoryContext参数
            return unityContainer.Resolve<T>(new ParameterOverrides
                {
                    {"context", RepositoryContext}
                });
        }

        static ApplicationServiceBase()
        {
            Mapper.CreateMap<User, UserDTO>();
            Mapper.CreateMap<UserDTO, User>();
        }

        protected IRepositoryContext RepositoryContext
        {
            get { return context; }
        }
    }
}
