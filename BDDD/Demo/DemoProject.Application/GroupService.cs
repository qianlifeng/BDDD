using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoProject.Domain.Repositories;

namespace DemoProject.Application
{
    public class GroupService : ApplicationServiceBase
    {
        private IGroupRepository groupRepository;

        public GroupService()
        {
            groupRepository = GetResolvedRepository<IGroupRepository>();
        }
    }
}
