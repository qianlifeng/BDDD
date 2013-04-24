using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.ObjectContainer;
using BDDD.Bus;
using BDDD.Tests.Bus.Commands;

namespace BDDD.Tests.Bus
{
    [TestClass]
    public class BusTests
    {
        [TestMethod]
        public void TestDispatchCommand()
        {
            ChangeCategoryNameCommand command = new ChangeCategoryNameCommand(Guid.NewGuid(), "test new name");
            ICommandBus<Guid> commandBus = ServiceLocator.Instance.GetService<ICommandBus<Guid>>();
            commandBus.Publish(command);
        }
    }
}
