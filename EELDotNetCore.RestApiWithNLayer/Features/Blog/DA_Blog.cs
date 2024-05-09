using EELDotNetCore.RestApiWithNLayer.Db;

namespace EELDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;
        public DA_Blog()
        {
            _context = new AppDbContext();
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = _context.Blogs.ToList();
            return lst;
        }
        public BlogModel GetBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogID == id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            _context.Blogs.Add(requestModel);
            var result = _context.SaveChanges();
            return result;
        }
        public int UpdateBlog(int id, BlogModel resquestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null) return 0;

            item.BlogTitle = resquestModel.BlogTitle;
            item.BlogAuthor = resquestModel.BlogAuthor;
            item.BlogContent = resquestModel.BlogContent;

            var result = _context.SaveChanges();
            return result;
        }
        public int DeleteBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null) return 0;

            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();
            return result;
        }

    }
}
