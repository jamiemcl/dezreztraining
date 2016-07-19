using System;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Type;

namespace Dezrez.Rezi.Repository
{
    public class BasicInterceptor : EmptyInterceptor
    {
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            bool result = base.OnSave(entity, id, state, propertyNames, types);

            return result;
        }

        #region Utilities
        protected void Set<T>(string[] propertyNames, object[] state, Expression<Func<T, object>> expression, object value)
        {
            string propertyName = GetPropertyName(expression);
            var index = Array.IndexOf(propertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
        protected static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression;

            if (body != null)
            {
                return body.Member.Name;
            }
            return null;
        }
        #endregion
    }
}