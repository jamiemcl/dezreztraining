using System;
using System.Collections.Generic;
using Dezrez.Rezi.Domain;

namespace Dezrez.Rezi.Abstractions.Repository
{
    public interface IRepository
    {
        T Get<T>(object id, bool excludeDeleted = true) where T : BaseEntity;
        BaseEntity Get(object id, Type type, bool excludeDeleted = true);
        T GetByName<T>(string name, bool excludeDeleted = true) where T : BaseEntity;
        IList<T> FindAll<T>(bool excludeDeleted = true) where T : BaseEntity;
        IList<T> FindAllPaged<T>(int pageSize, int pageNumber, bool excludeDeleted = true) where T : BaseEntity;
        int CountAll<T>(bool excludeDeleted = true) where T : BaseEntity;
        IList<T> FindById<T>(IEnumerable<long> ids, bool excludeDeleted = true) where T : BaseEntity;
        void Delete<T>(T t) where T : BaseEntity;
        void SoftDelete<T>(T t) where T : BaseEntity;
        object Save<T>(T t) where T : BaseEntity;
        void SaveOrUpdate<T>(T t) where T : BaseEntity;
        void SaveOrUpdate<T>(BaseEntity t) where T : BaseEntity;
    }
}