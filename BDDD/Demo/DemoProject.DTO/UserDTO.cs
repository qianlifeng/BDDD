using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.DTO
{
    public class UserDTO
    {
        public  string UserName { get; set; }
        public  string NickName { get; set; }
        public  string Password { get; set; }
        public  string Email { get; set; }
        public  bool IsDisabled { get; set; }
        public  DateTime DateRegistered { get; set; }
        public  DateTime? DateLastLogin { get; set; }
        public  Guid ID { get; set; }
    }
}
