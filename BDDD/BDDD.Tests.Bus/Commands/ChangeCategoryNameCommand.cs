using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Commands;

namespace BDDD.Tests.Bus.Commands
{
    public class ChangeCategoryNameCommand : ICommand<Guid>
    {
        public Guid ID { get; set; }
        public string NewName { get; set; }

        public ChangeCategoryNameCommand(Guid categoryID, string newName)
        {
            this.ID = categoryID;
            this.NewName = newName;
        }
    }
}
