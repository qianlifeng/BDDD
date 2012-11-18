using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.Repository;
using BDDD.Application;
using BDDD.Config;
using BDDD.Tests.Common.Configuration;
using BDDD.Tests.DomainModel;
using Microsoft.Practices.Unity;
using BDDD.Repository.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Automapping;
using BDDD.Specification;

namespace BDDD.Tests.Repository.NHibernateRepository
{
    [TestClass]
    public class NHibernateRepositoryTest
    {
        #region - Variable -


        static App application;
        Customer customerScott;
        Order customersOrder1;
        Order customersOrder2;
        OrderItem orderItem1;
        OrderItem orderItem2;
        Item item1;
        Item item2;
        ItemCategory itemCategory;
        PostalAddress address1;

        #endregion

        [ClassInitialize]
        public static void StartBDDD(TestContext context)
        {
            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            application = AppRuntime.Create(configSource);
            application.AppInitEvent += new App.AppInitHandle(application_AppInitEvent);
            application.Start();
        }

        static void application_AppInitEvent(IConfigSource source, ObjectContainer.IObjectContainer objectContainer)
        {
            Assert.AreEqual(AppRuntime.Instance.CurrentApplication.ObjectContainer.GetRealObjectContainer<UnityContainer>(), AppRuntime.Instance.CurrentApplication.ObjectContainer.GetRealObjectContainer<UnityContainer>());

            UnityContainer c = objectContainer.GetRealObjectContainer<UnityContainer>();
            c.RegisterType<INHibernateConfiguration, NHibernateConfiguration>(
                new InjectionConstructor(Helper.SetupNHibernateDatabase()));
            c.RegisterType<IRepositoryContext, NHibernateContext>(
                new InjectionConstructor(new ResolvedParameter<INHibernateConfiguration>()));
        }

        [TestInitialize]
        public void InitModel()
        {
            Helper.ResetDB();

            itemCategory = new ItemCategory { CategoryName = "日常用品" };
            item1 = new Item { Category = itemCategory, ItemName = "洗衣粉" };
            item2 = new Item { Category = itemCategory, ItemName = "肥皂" };

            customerScott = new Customer("scott", 11);
            orderItem1 = new OrderItem { Item = item1, Quantity = 1 };
            orderItem2 = new OrderItem { Item = item2, Quantity = 2 };
            address1 = new PostalAddress { City = "苏州", Phone = "15", Street = "莲花新训" };

            customersOrder1 = new Order
            {
                CreatedDate = DateTime.Now,
                Customer = customerScott,
                OrderName = "账单1",
                Items = new List<OrderItem> { orderItem1, orderItem2 },
                postalAddress = address1
            };
            customersOrder2 = new Order
            {
                CreatedDate = DateTime.Now,
                Customer = customerScott,
                OrderName = "账单2",
                Items = new List<OrderItem> { orderItem1 },
                postalAddress = address1
            };
        }

        [TestMethod]
        [Description("添加聚合根_内部不包含其他实体")]
        public void NHibernateRepositoryTest_AddAggregateRootToRepository()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                customerRepository.Add(customerScott);
                IRepository<ItemCategory> itemCategoryRepository = ctx.GetRepository<ItemCategory>();
                itemCategoryRepository.Add(itemCategory);
                ctx.Commit();

                Customer c = customerRepository.GetByKey(customerScott.ID);
                Assert.IsNotNull(c);
                Assert.AreEqual<Guid>(customerScott.ID, c.ID);

                ItemCategory category = itemCategoryRepository.GetByKey(itemCategory.ID);
                Assert.IsNotNull(category);
                Assert.AreEqual<Guid>(category.ID, itemCategory.ID);
            }
        }

        [TestMethod]
        [Description("添加聚合根_内部包含其他未持久化实体")]
        public void NHibernateRepositoryTest_AddAggregateRootToRepository_WithChildEntityInside()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Order> orderRepository = ctx.GetRepository<Order>();
                orderRepository.Add(customersOrder1);
                ctx.Commit();

                IEnumerable<Order> orders = orderRepository.GetAll();
                Assert.IsNotNull(customersOrder1.Customer.ID);
                Assert.IsTrue(orders.Count() == 1);
            }
        }

        [TestMethod]
        [Description("添加聚合根_内部包含其他已经持久化实体")]
        public void NHibernateRepositoryTest_AddAggregateRootToRepository_WithPersistedChildEntityInside()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                customerRepository.Add(customerScott);
                ctx.Commit();
                Customer c = customerRepository.GetByKey(customerScott.ID);
                Assert.IsNotNull(c);
                Assert.AreEqual<Guid>(customerScott.ID, c.ID);

                IRepository<Order> orderRepository = ctx.GetRepository<Order>();
                orderRepository.Add(customersOrder1);
                orderRepository.Add(customersOrder2);
                ctx.Commit();

                IEnumerable<Order> orders = orderRepository.GetAll();
                Assert.IsNotNull(customersOrder1.Customer.ID);
                Assert.IsTrue(orders.Count() == 2);
            }
        }

        [TestMethod]
        [Description("添加聚合根_不提交")]
        public void NHibernateRepositoryTest_AddAggregateRootToRepository_WithoutCommit()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                customerRepository.Add(customerScott);

                Customer c = customerRepository.GetByKey(customerScott.ID);
                Assert.IsNull(c);
            }
        }

        [TestMethod]
        [Description("更新聚合根")]
        public void NHibernateRepositoryTest_UpdateAggregateRootToRepository()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                customerRepository.Add(customerScott);
                ctx.Commit();

                Assert.IsNotNull(customerScott);

                Customer c = customerRepository.GetByKey(customerScott.ID);
                c.Name = "update";
                ctx.Commit();

                c = customerRepository.GetByKey(c.ID);
                Assert.IsNotNull(c);
                Assert.AreEqual<string>("update", c.Name);
            }
        }

        [TestMethod]
        [Description("删除聚合根_聚合根不被其他聚合根引用")]
        public void NHibernateRepositoryTest_DeleteAggregateRootToRepository()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                customerRepository.Add(customerScott);
                ctx.Commit();

                Assert.IsNotNull(customerScott);

                Customer c = customerRepository.GetByKey(customerScott.ID);
                customerRepository.Remove(c);
                ctx.Commit();

                c = customerRepository.GetByKey(c.ID);
                Assert.IsNull(c);
            }
        }

        [TestMethod]
        [Description("获得所有聚合根")]
        public void NHibernateRepositoryTest_GetAllAggregateRootToRepository()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                Customer u1 = new Customer("scott1", 12);
                Customer u2 = new Customer("scott2", 12);
                Customer u3 = new Customer("scott3", 12);
                customerRepository.Add(u1);
                customerRepository.Add(u2);
                customerRepository.Add(u3);
                ctx.Commit();

                IEnumerable<Customer> customers = customerRepository.GetAll();

                Assert.IsNotNull(customers);
                Assert.AreEqual<int>(3, customers.Count());
            }
        }

        [TestMethod]
        [Description("获得指定条件的所有聚合根")]
        public void NHibernateRepositoryTest_GetAllAggregateRootToRepository_Specifiaction()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                Customer u1 = new Customer("scott1", 12);
                Customer u2 = new Customer("scott2", 12);
                Customer u3 = new Customer("scott3", 12);
                customerRepository.Add(u1);
                customerRepository.Add(u2);
                customerRepository.Add(u3);
                ctx.Commit();

                IEnumerable<Customer> customers = customerRepository.GetAll(Specification<Customer>.Eval(o => o.Name.Contains("3")));

                Assert.IsNotNull(customers);
                Assert.AreEqual<int>(1, customers.Count());
                Assert.AreEqual<string>("scott3", customers.First().Name);
            }
        }


        [TestMethod]
        [Description("获得指定条件的所有聚合根_带分页")]
        public void NHibernateRepositoryTest_GetAllAggregateRootToRepository_SpecifiactionPage()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                Customer u1 = new Customer("scott1", 12);
                Customer u2 = new Customer("scott2", 13);
                Customer u3 = new Customer("scott3", 14);
                Customer u4 = new Customer("scott4", 15);
                Customer u5 = new Customer("scott5", 16);
                Customer u6 = new Customer("scott6", 17);
                Customer u7 = new Customer("scott7", 18);
                Customer u8 = new Customer("scott8", 19);
                customerRepository.Add(u1);
                customerRepository.Add(u2);
                customerRepository.Add(u3);
                customerRepository.Add(u4);
                customerRepository.Add(u5);
                customerRepository.Add(u6);
                customerRepository.Add(u7);
                customerRepository.Add(u8);
                ctx.Commit();

                IEnumerable<Customer> customers = customerRepository.GetAll(
                    Specification<Customer>.Eval(o => o.Age > 10)
                    , 1, 3, o => o.Name, SortOrder.Descending, o => o.PostalAddresses
                    );

                Assert.IsNotNull(customers);
                Assert.AreEqual<int>(3, customers.Count());
                Assert.AreEqual<string>("scott8", customers.First().Name);

                customers = customerRepository.GetAll(
                    Specification<Customer>.Eval(o => o.Age > 14)
                    , 1, 2, o => o.Name, SortOrder.Descending, o => o.PostalAddresses
                    );

                Assert.IsNotNull(customers);
                Assert.AreEqual<int>(2, customers.Count());
                Assert.AreEqual<string>("scott8", customers.First().Name);
            }
        }

        [TestMethod]
        [Description("获得指定条件的所有聚合根_带分页_带eager加载")]
        public void NHibernateRepositoryTest_GetAllAggregateRootToRepository_SpecifiactionPageEager()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Order> orderRepository = ctx.GetRepository<Order>();
                Order u1 = new Order { Customer = customerScott, CreatedDate = DateTime.Now, Items = new List<OrderItem> { orderItem1, orderItem2 }, OrderName = "1", postalAddress = address1 };
                Order u2 = new Order { Customer = customerScott, CreatedDate = DateTime.Now, Items = new List<OrderItem> { orderItem1, orderItem2 }, OrderName = "2", postalAddress = address1 };
                Order u3 = new Order { Customer = customerScott, CreatedDate = DateTime.Now, Items = new List<OrderItem> { orderItem1, orderItem2 }, OrderName = "3", postalAddress = address1 };
                Order u4 = new Order { Customer = customerScott, CreatedDate = DateTime.Now, Items = new List<OrderItem> { orderItem1, orderItem2 }, OrderName = "4", postalAddress = address1 };
                Order u5 = new Order { Customer = customerScott, CreatedDate = DateTime.Now, Items = new List<OrderItem> { orderItem1, orderItem2 }, OrderName = "5", postalAddress = address1 };
                Order u6 = new Order { Customer = customerScott, CreatedDate = DateTime.Now, Items = new List<OrderItem> { orderItem1, orderItem2 }, OrderName = "6", postalAddress = address1 };
                Order u7 = new Order { Customer = customerScott, CreatedDate = DateTime.Now, Items = new List<OrderItem> { orderItem1, orderItem2 }, OrderName = "7", postalAddress = address1 };

                orderRepository.Add(u1);
                orderRepository.Add(u2);
                orderRepository.Add(u3);
                orderRepository.Add(u4);
                orderRepository.Add(u5);
                orderRepository.Add(u6);
                orderRepository.Add(u7);
                ctx.Commit();

                //如果在同一个session下面获取所有的order，那么这个order的子对象会被加载
                //因为上面添加的时候已经存在于这个session里面了。所以为了测试立即加载应该
                //新开一个session进行查询
            }


            IEnumerable<Order> orders = null;
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Order> orderRepository = ctx.GetRepository<Order>();
                orders = orderRepository.GetAll(
                   Specification<Order>.Eval(o => o.OrderName != null)
                   , 1, 3, o => o.OrderName, SortOrder.Descending, o => o.Items, o => o.Customer
                   );
            }

            Assert.IsNotNull(orders);
            Assert.AreEqual<int>(3, orders.Count());
            Assert.AreEqual<string>("7", orders.First().OrderName);

            Assert.IsTrue(orders.First().Customer != null);
            Assert.IsTrue(orders.First().Customer.Name == "scott");
        }
    }
}
