using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Cloud.Blog.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Cloud.Blog.EntityFrameworkCore.Repositories
{
    public class BlogRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<BlogDbContext, TEntity, TPrimaryKey>, IBlogRepository<TEntity, TPrimaryKey>
     where TEntity : class, IEntity<TPrimaryKey>
    {
        public BlogRepositoryBase(IDbContextProvider<BlogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //A new custom method

        //public PagedResult<TEntity> GetPageList(Expression<Func<TEntity, bool>> predicate, int pageIndex = 1, int pageSize = 10)
        //{
        //    return GetAll().Where(predicate).Skip(pageIndex).Take(pageSize);
        //}
    }

    public class BlogRepositoryBase<TEntity> : BlogRepositoryBase<TEntity, int>, IBlogRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public BlogRepositoryBase(IDbContextProvider<BlogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}