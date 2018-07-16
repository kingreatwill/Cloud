using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Linq.Extensions;
using Cloud.Blog.Domain.Repositories;
using Cloud.Blog.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Blog.Categories
{
    public class CategoryManager : DomainService, ICategoryManager
    {
        public const int MaxActiveTaskCountForAPerson = 3;

        private readonly IBlogRepository<Category, long> _categoryRepository;

        public CategoryManager(IBlogRepository<Category, long> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public class sdsd : PagedResultInput
        {
        }

        public void test()
        {
            _categoryRepository.GetAll().PageListBy(new sdsd { });
        }
    }
}