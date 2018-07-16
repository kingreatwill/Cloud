using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Cloud.Blog.Domain.Repositories;
using Cloud.Blog.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Blog.Categories
{
    public class CategoryAppService : BlogAppServiceBase, ICategoryAppService
    {
        private readonly IBlogRepository<Category, long> _categoryRepository;

        public CategoryAppService(IBlogRepository<Category, long> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Get(long id)
        {
            var category = await _categoryRepository.GetAsync(id);
            //var output = ObjectMapper.Map<CategoryDto>(category);
            return category;
        }

        public PagedResultDto<Category> GetByPaged(PagedResultInput input)
        {
            return _categoryRepository.GetAll().PageListBy(input);
        }

        public long Create(CategoryDto input)
        {
            return _categoryRepository.InsertAndGetId(new Category
            {
                Name = input.Name
            });
        }

        public class CategoryDto
        {
            public string Name { get; set; }
        }
    }
}