using System;
using NHibernate;

namespace Dezrez.Rezi.Abstractions.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        FlushMode? FlushMode { get; set; }
        ISession Session { get; }
        void Complete();
        void Rollback();
    }
}