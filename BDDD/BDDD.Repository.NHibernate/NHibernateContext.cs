using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using BDDD.Application;
using BDDD.ObjectContainer;

namespace BDDD.Repository.NHibernate
{
    public class NHibernateContext : INHibernateContext
    {
        #region 变量

        [ThreadStatic]
        private readonly Guid id;
        [ThreadStatic]
        private bool committed = true;
        [ThreadStatic]
        private readonly DBSessionFactory databaseSessionFactory;
        [ThreadStatic]
        private readonly ISession session = null;
        [ThreadStatic]
        private readonly List<object> newObjects = new List<object>();
        [ThreadStatic]
        private readonly List<object> modifiedObjects = new List<object>();
        [ThreadStatic]
        private readonly List<object> deletedObjects = new List<object>();

        private readonly object sync = new object();
        private readonly Dictionary<string, object> repositories = new Dictionary<string, object>();

        #endregion

        public NHibernateContext()
        {
            id = Guid.NewGuid();
        }

        public NHibernateContext(INHibernateConfiguration nhibernateConfig)
            : this()
        {
            databaseSessionFactory = new DBSessionFactory(nhibernateConfig.GetNHibernateConfiguration());
            session = databaseSessionFactory.Session;
        }

        public ISession Session
        {
            get { return session; }
        }

        public Guid ID
        {
            get { return id; }
        }

        public void RegisterNew(object obj)
        {
            newObjects.Add(obj);
            committed = false;
        }

        public void RegisterModified(object obj)
        {
            modifiedObjects.Add(obj);
            committed = false;
        }

        public void RegisterDeleted(object obj)
        {
            deletedObjects.Add(obj);
            committed = false;
        }

        public IRepository<TAggregateRoot> GetRepository<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot
        {
            string key = typeof(TAggregateRoot).AssemblyQualifiedName;
            if (repositories.ContainsKey(key))
            {
                return repositories[key] as IRepository<TAggregateRoot>;
            }
            else
            {
                var repository = new NHibernateRepository<TAggregateRoot>(this);
                lock (sync)
                {
                    repositories.Add(key, repository);
                }
                return repository;
            }
        }

        public bool Committed
        {
            get { return committed; }
        }

        public void Commit()
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    foreach (object obj in newObjects)
                    {
                        session.Save(obj);
                    }
                    foreach (object obj in modifiedObjects)
                    {
                        session.Update(obj);
                    }
                    foreach (object obj in deletedObjects)
                    {
                        session.Delete(obj);
                    }
                    transaction.Commit();
                    newObjects.Clear();
                    deletedObjects.Clear();
                    modifiedObjects.Clear();
                    committed = true;
                }
                catch
                {
                    if (transaction.IsActive)
                        transaction.Rollback();
                    this.session.Clear();
                    throw;
                }
            }
        }

        public void Rollback()
        {
            committed = false;
        }

        public void Dispose()
        {
            ISession dbSession = session;
            if (dbSession != null && dbSession.IsOpen)
            {
                dbSession.Close();
            }
            dbSession.Dispose();
        }
    }
}
