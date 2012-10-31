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

namespace BDDD.Tests.Repository.NHibernateRepository
{
    [TestClass]
    public class NHibernateRepositoryTest
    {
        static App application;
        Customer newCustomer;
        Order customersOrder1;
        Order customersOrder2;
        OrderItem item1;
        OrderItem item2;


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
            NHibernate.Cfg.Configuration nhibernateCfg = Helper.SetupNHibernateDatabase();
            UnityContainer c = objectContainer.GetRealObjectContainer<UnityContainer>();
            c.RegisterInstance<NHibernate.Cfg.Configuration>(nhibernateCfg)
            .RegisterType<IRepositoryContext, NHibernateContext>(new InjectionConstructor(new ResolvedParameter<NHibernate.Cfg.Configuration>()))
            .RegisterType<IRepository<Customer>, NHibernateRepository<Customer>>();
        }

        [TestInitialize]
        public void InitModel()
        {
            newCustomer = new Customer("scott", 11);
            item1 = new OrderItem { ItemName = "item1" };
            item2 = new OrderItem { ItemName = "item2" };

            customersOrder1 = new Order
            {
                CreatedDate = DateTime.Now,
                Customer = newCustomer,
                OrderName = "orderName1",
                Items = new List<OrderItem> { item1, item2 }
            };
            customersOrder2 = new Order
            {
                CreatedDate = DateTime.Now,
                Customer = newCustomer,
                OrderName = "orderName2",
                Items = new List<OrderItem> { item1 }
            };
        }

        [TestMethod]
        [Description("添加聚合根_内部不包含其他实体")]
        public void NHibernateRepositoryTest_AddAggregateRootToRepository()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                customerRepository.Add(newCustomer);
                ctx.Commit();

                Customer c = customerRepository.GetByKey(newCustomer.ID);
                Assert.IsNotNull(c);
                Assert.AreEqual<Guid>(newCustomer.ID, c.ID);
            }
        }
        [TestMethod]
        [Description("添加聚合根_内部包含其他实体")]
        public void NHibernateRepositoryTest_AddAggregateRootToRepository_WithChildEntityInside()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                customerRepository.Add(newCustomer);

                IRepository<Order> orderRepository = ctx.GetRepository<Order>();
                orderRepository.Add(customersOrder1);
                ctx.Commit();

                IEnumerable<Order> orders = orderRepository.GetAll();

                Assert.IsNotNull(customersOrder1.Customer.ID);
                Assert.IsTrue(orders.Count() == 1);
            }
        }

        [TestMethod]
        [Description("添加聚合根_不提交")]
        public void NHibernateRepositoryTest_AddAggregateRootToRepository_WithoutCommit()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                customerRepository.Add(newCustomer);

                Customer c = customerRepository.GetByKey(newCustomer.ID);
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
                customerRepository.Add(newCustomer);
                ctx.Commit();

                Assert.IsNotNull(newCustomer);

                Customer c = customerRepository.GetByKey(newCustomer.ID);
                c.Name = "update";
                ctx.Commit();

                c = customerRepository.GetByKey(c.ID);
                Assert.IsNotNull(c);
                Assert.AreEqual<string>("update", c.Name);
            }
        }

        [TestMethod]
        [Description("删除聚合根")]
        public void NHibernateRepositoryTest_DeleteAggregateRootToRepository()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                customerRepository.Add(newCustomer);
                ctx.Commit();

                Assert.IsNotNull(newCustomer);

                Customer c = customerRepository.GetByKey(newCustomer.ID);
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
                Assert.AreEqual<string>("scott1", customers.First().Name);
            }
        }



    }
}
