using BDDD.Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BDDD.Tests.DomainModel;

namespace BDDD.Tests.Common
{

    /// <summary>
    ///This is a test class for SpecificationTest and is intended
    ///to contain all SpecificationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpecificationTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        [Description("测试Specification的And功能")]
        public void AndTest()
        {
            Customer u1 = new Customer("test1", 11);
            Customer u2 = new Customer("qianlifeng", 11);

            ISpecification<Customer> left = Specification<Customer>.Eval(o => o.Name == "qianlifeng");
            ISpecification<Customer> right = Specification<Customer>.Eval(o => o.Age == 11);
            ISpecification<Customer> spec = left.And(right);
            Assert.IsTrue(spec.IsSatisfiedBy(u2));
        }

        [TestMethod()]
        [Description("测试Specification的Or功能")]
        public void OrTest()
        {
            Customer u1 = new Customer("test1", 11);
            Customer u2 = new Customer("qianlifeng", 11);

            ISpecification<Customer> left = Specification<Customer>.Eval(o => o.Name == "qianlifeng");
            ISpecification<Customer> right = Specification<Customer>.Eval(o => o.Name == "test1");
            ISpecification<Customer> spec = left.Or(right);
            Assert.IsTrue(spec.IsSatisfiedBy(u2));
            Assert.IsTrue(spec.IsSatisfiedBy(u1));
        }

        [TestMethod()]
        [Description("测试Specification的Not功能")]
        public void NotTest()
        {
            Customer u1 = new Customer("test1", 11);

            ISpecification<Customer> spec = Specification<Customer>.Eval(o => o.Name == "test1").Not();
            Assert.IsFalse(spec.IsSatisfiedBy(u1));
        }
    }
}
