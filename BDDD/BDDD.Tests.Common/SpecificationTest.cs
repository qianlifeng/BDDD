using BDDD.Specification;
using BDDD.Tests.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDDD.Tests.Common
{
    /// <summary>
    ///     This is a test class for SpecificationTest and is intended
    ///     to contain all SpecificationTest Unit Tests
    /// </summary>
    [TestClass]
    public class SpecificationTest
    {
        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        [Description("测试Specification的And功能")]
        public void AndTest()
        {
            var u1 = new Customer("test1", 11);
            var u2 = new Customer("qianlifeng", 11);

            ISpecification<Customer> left = Specification<Customer>.Eval(o => o.Name == "qianlifeng");
            ISpecification<Customer> right = Specification<Customer>.Eval(o => o.Age == 11);
            ISpecification<Customer> spec = left.And(right);
            Assert.IsTrue(spec.IsSatisfiedBy(u2));
        }

        [TestMethod]
        [Description("测试Specification的Or功能")]
        public void OrTest()
        {
            var u1 = new Customer("test1", 11);
            var u2 = new Customer("qianlifeng", 11);

            ISpecification<Customer> left = Specification<Customer>.Eval(o => o.Name == "qianlifeng");
            ISpecification<Customer> right = Specification<Customer>.Eval(o => o.Name == "test1");
            ISpecification<Customer> spec = left.Or(right);
            Assert.IsTrue(spec.IsSatisfiedBy(u2));
            Assert.IsTrue(spec.IsSatisfiedBy(u1));
        }

        [TestMethod]
        [Description("测试Specification的Not功能")]
        public void NotTest()
        {
            var u1 = new Customer("test1", 11);

            ISpecification<Customer> spec = Specification<Customer>.Eval(o => o.Name == "test1").Not();
            Assert.IsFalse(spec.IsSatisfiedBy(u1));
        }
    }
}