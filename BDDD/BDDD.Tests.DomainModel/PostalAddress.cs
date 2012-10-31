using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class PostalAddress
    {
        public virtual string City { get; set; }
        public virtual string Stress { get; set; }
        public virtual string Phone { get; set; }
    }
}