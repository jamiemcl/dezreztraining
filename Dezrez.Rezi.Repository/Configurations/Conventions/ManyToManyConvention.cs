using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;

namespace Dezrez.Rezi.Repository.Configurations.Conventions
{
    public static class ManyToManyConvention
    {
        public static void ManyToMany<TControllingEntity, TInverseEntity>(
            this ModelMapper mapper,
            Expression<Func<TControllingEntity, IEnumerable<TInverseEntity>>> controllingProperty,
            Expression<Func<TInverseEntity, IEnumerable<TControllingEntity>>> inverseProperty,
            string tableName = null, bool lazy = true
            )
            where TControllingEntity : class
            where TInverseEntity : class
        {
            //Get mapped entity names
            string controllingEntityName = typeof(TControllingEntity).Name;
            string inverseEntityName = typeof(TInverseEntity).Name;

            //suffix with 'Id'
            string controllingColumnName = string.Format("{0}Id", controllingEntityName);
            string inverseColumnName = string.Format("{0}{1}Id", inverseEntityName == controllingEntityName ? "Other" : String.Empty, inverseEntityName);

            //If table name is not supplied, generate one by convention
            //Get controlling property name
            string controllingPropertyName = ((MemberExpression)controllingProperty.Body).Member.Name;
            tableName = tableName ?? string.Format("Lnk_{0}_{1}", typeof(TControllingEntity).Name.Replace("Base", String.Empty), controllingPropertyName.Replace("Base", String.Empty));

            //Setup relationships
            mapper.Class<TControllingEntity>(map => map.IdBag(controllingProperty,
                cm =>
                {
                    cm.Id(id =>
                    {
                        id.Column("Id");
                        id.Generator(Generators.GuidComb);
                    });
                    cm.Cascade(Cascade.Persist);
                    cm.Table(tableName);
                    cm.Lazy(lazy ? CollectionLazy.Lazy : CollectionLazy.NoLazy);
                    cm.Key(km =>
                    {
                        km.Column(c =>
                        {
                            c.Name(controllingColumnName);
                            c.Index(String.Format("IX_{0}_{1}", tableName, controllingColumnName));
                        });
                        km.Unique(true);
                    });
                },
                em => em.ManyToMany(m => m.Column(c =>
                {
                    c.Name(inverseColumnName);
                    c.Index(String.Format("IX_{0}_{1}", tableName, inverseColumnName));
                }))));

            if (inverseProperty != null)
            {
                mapper.Class<TInverseEntity>(map => map.IdBag(inverseProperty,
                                                            cm =>
                                                            {
                                                                cm.Id(id =>
                                                                {
                                                                    id.Column("Id");
                                                                    id.Generator(Generators.GuidComb);
                                                                });
                                                                cm.Cascade(Cascade.Persist);
                                                                cm.Table(tableName);
                                                                cm.Inverse(true);
                                                                cm.Lazy(lazy ? CollectionLazy.Lazy : CollectionLazy.NoLazy);
                                                                cm.Key(km =>
                                                                {
                                                                    km.Column(inverseColumnName);
                                                                    km.Unique(true);
                                                                });
                                                            },
                                                            em => em.ManyToMany(m => m.Column(controllingColumnName))));
            }
        }
    }
}
