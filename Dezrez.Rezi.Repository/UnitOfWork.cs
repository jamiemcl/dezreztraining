using Dezrez.Rezi.Abstractions.Repository;
using NHibernate;

namespace Dezrez.Rezi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession _session;
        protected readonly IInterceptor Interceptor;
        protected bool Completed;
        protected bool DefaultReadonly;
        public FlushMode? FlushMode { get; set; }
        private readonly IDatabaseConfig _config;

        public ISession Session
        {
            get
            {
                if (_session == null)
                {
                    OpenSession();
                }
                return _session;
            }
        }

        public UnitOfWork(IInterceptor interceptor, IDatabaseConfig config)
        {
            Interceptor = interceptor;
            _config = config;
        }

        public UnitOfWork(IDatabaseConfig config) : this(null, config) { }

        protected virtual void OpenSession()
        {
            _session = Interceptor == null ? _config.SessionFactory().OpenSession() : _config.SessionFactory().OpenSession(Interceptor);
            if (FlushMode.HasValue)
            {
                _session.FlushMode = FlushMode.Value;
            }
            _session.DefaultReadOnly = DefaultReadonly;
            _session.Transaction.Begin();
        }

        public void Complete()
        {
            if (!Completed && _session != null)
            {
                try
                {
                    if (_session.Transaction.IsActive)
                    {
                        _session.Transaction.Commit();
                    }
                }
                catch
                {
                    _session.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    _session.Clear();
                    Completed = true;
                }
            }
        }

        public void Rollback()
        {
            if (_session != null && _session.Transaction.IsActive)
            {
                _session.Transaction.Rollback();
            }
        }

        public void Dispose()
        {
            try
            {
                Complete();
            }
            finally
            {
                if (_session != null)
                {
                    _session.Dispose();
                }
            }
        }
         
    }
}