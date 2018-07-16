using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Blog.Categories
{
    public interface ICategoryManager : IDomainService
    {
        void test();
    }
}