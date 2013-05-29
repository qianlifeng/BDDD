using DemoProject.DTO;
using DemoProject.Domain.Model;
using DemoProject.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject.Test.InfrastructureTest
{
    [TestClass]
    public class ReflectUtilTest
    {
        [TestMethod]
        public void UpdateAllNotNullOrEmptyTest()
        {
            User user = new User("qianlifeng", "qlf", "qianlf2008@163.com", "test", null);
            UserDTO userDTO = new UserDTO
                {
                    UserName = "qianlifeng2",
                    NickName = "qlf2"
                };

            User userNew = ReflectUtil.UpdateAllNotNullOrEmpty(userDTO, user);

            Assert.IsTrue(userNew.UserName == userDTO.UserName);
            Assert.IsTrue(userNew.NickName == userDTO.NickName);
            Assert.IsTrue(userNew.Email != userDTO.Email);
        }
    }
}
