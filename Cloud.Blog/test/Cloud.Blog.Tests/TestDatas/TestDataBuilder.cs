using Cloud.Blog.EntityFrameworkCore;

namespace Cloud.Blog.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly BlogDbContext _context;

        public TestDataBuilder(BlogDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}