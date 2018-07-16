using Cloud.Blog.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.Blog.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : BlogControllerBase
    {
        private readonly ICategoryManager _categoryRepository;

        public TestController(ICategoryManager categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public JsonResult Test()
        {
            _categoryRepository.test();
            return Json(0);
        }

        [HttpGet]
        public JsonResult List()
        {
            var list = new List<int>() { 1, 2, 3 };
            return Json(list);
        }
    }
}