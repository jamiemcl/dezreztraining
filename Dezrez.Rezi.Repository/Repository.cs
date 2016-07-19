using System;
using System.Collections.Generic;
using System.Linq;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Dezrez.Rezi.Repository
{
    public class Repository : IRepository
    {
        protected IUnitOfWork UnitOfWork;

        private readonly Guid _repositoryInstanceID;

        public Repository(IUnitOfWork unitOfWork, FlushMode? flushMode = null)
        {
            UnitOfWork = unitOfWork;
            _repositoryInstanceID = Guid.NewGuid();
            if (flushMode.HasValue)
            {
                UnitOfWork.FlushMode = flushMode;
            }
        }

        public Guid RepositoryInstanceID
        {
            get { return _repositoryInstanceID; }
        }

        public virtual T Get<T>(object id, bool excludeDeleted = true) where T : BaseEntity
        {
            ICriteria crit = GetCriteria<T>();
            crit.Add(Restrictions.Eq("Id", id));
            if (excludeDeleted)
            {
                crit.Add(!Restrictions.Eq("Deleted", excludeDeleted));
            }

            return crit.UniqueResult<T>();
        }

        public virtual BaseEntity Get(object id, Type type, bool excludeDeleted = true)
        {
            ICriteria crit = GetCriteria(type);
            crit.Add(Restrictions.Eq("Id", id));
            if (excludeDeleted)
            {
                crit.Add(!Restrictions.Eq("Deleted", excludeDeleted));
            }
            return crit.UniqueResult<BaseEntity>();
        }

        public virtual T GetByName<T>(string name, bool excludeDeleted = true) where T : BaseEntity
        {
            ICriteria crit = GetCriteria<T>();
            crit.Add(Restrictions.Eq("Name", name));
            if (excludeDeleted)
            {
                crit.Add(!Restrictions.Eq("Deleted", excludeDeleted));
            }

            return crit.UniqueResult<T>();
        }

        public virtual IList<T> FindAll<T>(bool excludeDeleted = true) where T : BaseEntity
        {
            ICriteria crit = GetCriteria<T>();
            if (excludeDeleted)
            {
                crit.Add(!Restrictions.Eq("Deleted", excludeDeleted));
            }

            crit.AddOrder(new Order("Id", false));

            return crit.List<T>();
        }

        public int CountAll<T>(bool excludeDeleted = true) where T : BaseEntity
        {
            return CountAll(typeof(T), excludeDeleted);
        }

        public int CountAll(Type type, bool excludeDeleted = true)
        {
            ICriteria crit = GetCriteria(type);
            if (excludeDeleted)
            {
                crit.Add(!Restrictions.Eq("Deleted", excludeDeleted));
            }

            crit.SetProjection(Projections.RowCount());

            return crit.UniqueResult<int>();
        }

        public virtual IList<T> FindById<T>(IEnumerable<long> ids, bool excludeDeleted = true) where T : BaseEntity
        {
            ICriteria crit = GetCriteria<T>();
            crit.Add(Restrictions.In("Id", ids.ToArray()));
            if (excludeDeleted)
            {
                crit.Add(!Restrictions.Eq("Deleted", excludeDeleted));
            }

            crit.AddOrder(new Order("Id", false));

            return crit.List<T>();
        }

        public virtual IList<T> FindAllPaged<T>(int pageSize, int pageNumber, bool excludeDeleted = true) where T : BaseEntity
        {
            ICriteria crit = GetCriteria<T>();
            if (excludeDeleted)
            {
                crit.Add(!Restrictions.Eq("Deleted", excludeDeleted));
            }
            crit.SetFirstResult(GetFirstResult(pageSize, pageNumber));
            crit.SetMaxResults(pageSize);

            crit.AddOrder(new Order("Id", false));

            return crit.List<T>();
        }

        public virtual void SoftDelete<T>(T t) where T : BaseEntity
        {
            t.Deleted = true;
            SaveOrUpdate(t);
        }

        public virtual void Delete<T>(T t) where T : BaseEntity
        {
            UnitOfWork.Session.Delete(t);
        }

        public virtual object Save<T>(T t) where T : BaseEntity
        {
            object result = UnitOfWork.Session.Save(t);
            return result;
        }

        public virtual void SaveOrUpdate<T>(T t) where T : BaseEntity
        {
            UnitOfWork.Session.Save(t);
        }

        public virtual void SaveOrUpdate<T>(BaseEntity t) where T : BaseEntity
        {
            UnitOfWork.Session.Save(t);
        }

        public virtual void Dispose() { }

        protected int GetFirstResult(int pageSize, int pageNumber)
        {
            return (pageNumber - 1) * pageSize;
        }

        protected virtual ICriteria GetCriteria<T>() where T : BaseEntity
        {
            ICriteria criteria = UnitOfWork.Session.CreateCriteria<T>();
            criteria.SetCacheable(true);
            return criteria;
        }

        protected virtual ICriteria GetCriteria(Type type)
        {
            ICriteria criteria = UnitOfWork.Session.CreateCriteria(type);
            criteria.SetCacheable(true);
            return criteria;
        }
    }
}