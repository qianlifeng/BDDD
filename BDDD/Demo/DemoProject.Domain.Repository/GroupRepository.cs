using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Repository;
using BDDD.Repository.NHibernate;
using DemoProject.Domain.Model;
using DemoProject.Domain.Repositories;

namespace DemoProject.Domain.Repository
{
    public class GroupRepository: NHibernateRepository<Group>,IGroupRepository
    {
        public GroupRepository(IRepositoryContext context)
            : base(context)
        {
        }
    }
}
