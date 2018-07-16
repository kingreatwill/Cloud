using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Cloud.Blog.Domain.Repositories
{
    public interface IBlogRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        //PagedResult<TEntity> GetPageList(Expression<Func<TEntity, bool>> predicate, int pageIndex = 1, int pageSize = 10);

        //PagedResult<TEntity> GetPageList(int pageIndex = 1, int pageSize = 10);

        //PagedResult<List<TEntity>> GetPageListAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex = 1, int pageSize = 10);

        //PagedResult<List<TEntity>> GetPageListAsync(int pageIndex = 1, int pageSize = 10);
    }

    public interface IBlogRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
    }
}