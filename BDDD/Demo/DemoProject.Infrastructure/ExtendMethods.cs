using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.Infrastructure
{
    public static class ExtendMethods
    {
        public static bool IsEmptyGuid(this Guid guid)
        {
            return guid == Guid.Empty;
        }
    }
}
