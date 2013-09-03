using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DemoProject.DTO;
using DemoProject.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject.Test
{
    [TestClass]
    public class OtherTest
    {
        [TestMethod]
        public void ExpressionTest()
        {
            Func<UserDTO, bool> func = dto => dto.UserName == "s";

            ParameterExpression parameterExpression = Expression.Parameter(typeof (UserDTO), "userDTO");
            UnaryExpression unaryExpression = Expression.Convert(parameterExpression, typeof (User));
        }
    }
}
