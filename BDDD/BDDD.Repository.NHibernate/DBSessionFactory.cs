using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace BDDD.Repository.NHibernate
{
    public class DBSessionFactory
    {
        private ISessionFactory sessionFactory = null;
        private ISession session = null;

        internal DBSessionFactory(Configuration nhibernateConfig)
        {
            //根据当前的NHibernate配置文件获得一个SessionFactory工厂
            //从此工厂创建的session只使用当前传入的配置信息
            sessionFactory = nhibernateConfig.BuildSessionFactory();
        }

        /// <summary>
        /// 获得一个session单例，如果存在已经打开的session则返回此session。如果不存在则
        /// 新打开一个session
        /// </summary>
        public ISession Session
        {
            get
            {
                try
                {
                    ISession result = session;
                    if (result != null && result.IsOpen)
                        return result;
                    return OpenSession();
                }
                catch
                { throw; }
            }
        }

        /// <summary>
        /// 总是从NHibernate的SessionFactory中获得一个新的session
        /// </summary>
        public ISession OpenSession()
        {
            session = sessionFactory.OpenSession();
            return session;
        }
    }
}
