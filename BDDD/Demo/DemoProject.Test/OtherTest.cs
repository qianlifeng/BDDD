using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
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

        [TestMethod]
        public void AutoMapperTest()
        {
            List<User> users = new List<User>
                {
                    new User("1","1",null),
                    new User("2","2",null)
                };

            Mapper.CreateMap<User, UserDTO>();
            Mapper.AssertConfigurationIsValid();
            List<UserDTO> userDtos = Mapper.Map<List<User>, List<UserDTO>>(users.ToList());

            Assert.IsTrue(userDtos.Count == 2);
        }
    }
}
