using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Repository;
using BDDD.ObjectContainer;

namespace DemoProject.Application
{
    public abstract class ApplicationServiceBase
    {
        private readonly IRepositoryContext context = ServiceLocator.Instance.GetService<IRepositoryContext>();

        static ApplicationServiceBase()
        {
            //todo:do dto mapping stuff
        }
      
        protected IRepositoryContext RepositoryContext
        {
            get { return context; }
        }
    }
}
