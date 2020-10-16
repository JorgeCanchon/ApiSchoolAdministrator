using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ApiSchoolAdministrator.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T> : IDisposable
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        EntityState Update(T entity, string propertyName);
        EntityState Delete(T entity);
        IQueryable<T> ExecuteQuery(string sql);
    }
}
