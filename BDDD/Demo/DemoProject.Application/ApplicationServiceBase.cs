using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BDDD.Application;
using BDDD.Repository;
using BDDD.ObjectContainer;
using BDDD.Specification;
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
            CreateMapper<User, UserDTO>();
            CreateMapper<Role, RoleDTO>();
            CreateMapper<Group, GroupDTO>();
        }

        private static void CreateMapper<T1, T2>()
        {
            Mapper.CreateMap<T1, T2>();
            Mapper.CreateMap<T2, T1>();
            Mapper.CreateMap<List<T1>, List<T2>>();
            Mapper.CreateMap<List<T2>, List<T1>>();
            Mapper.CreateMap<ISpecification<T1>, ISpecification<T2>>();
            Mapper.CreateMap<ISpecification<T2>, ISpecification<T1>>();
        }

        protected IRepositoryContext RepositoryContext
        {
            get { return context; }
        }
    }
}
