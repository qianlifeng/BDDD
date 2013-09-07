using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.DTO.Admin
{
    public class AdminLoginDTO : BaseDTO
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
    }
}
