using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoProject.Domain.Repositories;

namespace DemoProject.Application
{
    public class RoleService:ApplicationServiceBase
    {
        private IRoleRepository roleRepository;

        public RoleService()
        {
            roleRepository = GetResolvedRepository<IRoleRepository>();
        }
    }
}
