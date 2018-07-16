using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Cloud.Blog.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Cloud.Blog.Categories.CategoryAppService;

namespace Cloud.Blog.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<Category> Get(long id);

        PagedResultDto<Category> GetByPaged(PagedResultInput input);

        long Create(CategoryDto input);
    }
}