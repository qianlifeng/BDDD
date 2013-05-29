using System;
using BDDD.Commands;

namespace BDDD.Tests.Bus.Commands
{
    public class ChangeCategoryNameCommand : ICommand<Guid>
    {
        public ChangeCategoryNameCommand(Guid categoryID, string newName)
        {
            ID = categoryID;
            NewName = newName;
        }

        public string NewName { get; set; }
        public Guid ID { get; set; }
    }
}