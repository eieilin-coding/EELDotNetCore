using Microsoft.EntityFrameworkCore;

namespace EELDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _daBlog;

        public BL_Blog()
        {
            _daBlog = new DA_Blog();
        }
        public List<BlogModel> GetBlogs()
        {
            var lst = _daBlog.GetBlogs();
            return lst;
        }
        public BlogModel GetBlog(int id)
        {
            var item = _daBlog.GetBlog(id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            var result = _daBlog.CreateBlog(requestModel);
            return result;
        }
        public int UpdateBlog(int id, BlogModel resquestModel)
        {
            var result = _daBlog.UpdateBlog(id, resquestModel);
            return result;
        }
        public int DeleteBlog(int id)
        {
            var result = _daBlog.DeleteBlog(id);
            return result;
        }
    }
}
