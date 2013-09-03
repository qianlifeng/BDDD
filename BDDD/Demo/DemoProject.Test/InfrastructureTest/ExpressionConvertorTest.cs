using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DemoProject.DTO;
using DemoProject.Domain.Model;
using DemoProject.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject.Test.InfrastructureTest
{
    [TestClass]
    public class ExpressionConvertorTest
    {
        [TestMethod]
        public void ConvertExpressionTypeTest()
        {
            Expression<Func<UserDTO, bool>> expression = dto => dto.UserName.Contains("11");
            Func<User, bool> newFunc = ExpressionConvertor<UserDTO, User>.Convert(expression).Compile();

            User u = new User("111", "password", null);
            bool b = newFunc(u);
            Assert.IsTrue(b);

            u = new User("ert", "password", null);
            b = newFunc(u);
            Assert.IsTrue(!b);
        }
    }
}
