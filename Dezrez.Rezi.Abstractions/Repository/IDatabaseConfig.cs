using NHibernate;

namespace Dezrez.Rezi.Abstractions.Repository
{
    public interface IDatabaseConfig
    {
        ISessionFactory SessionFactory();
        void CreateDbSchema();
        void UpdateDbSchema();
    }
}