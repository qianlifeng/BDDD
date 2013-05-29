using System;
using BDDD.Bus;
using BDDD.ObjectContainer;
using BDDD.Tests.Bus.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDDD.Tests.Bus
{
    [TestClass]
    public class BusTests
    {
        [TestMethod]
        public void TestDispatchCommand()
        {
            var command = new ChangeCategoryNameCommand(Guid.NewGuid(), "test new name");
            var commandBus = ServiceLocator.Instance.GetService<ICommandBus<Guid>>();
            commandBus.Publish(command);
        }
    }
}