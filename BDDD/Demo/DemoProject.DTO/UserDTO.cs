using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.DTO
{
    public class UserDTO
    {
        public virtual string UserName { get; set; }
        public virtual string NickName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsDisabled { get; set; }
        public virtual DateTime DateRegistered { get; set; }
        public virtual DateTime? DateLastLogin { get; set; }
        public virtual Guid ID { get; set; }
    }
}
