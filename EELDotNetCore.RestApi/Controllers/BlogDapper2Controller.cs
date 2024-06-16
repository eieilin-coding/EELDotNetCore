using EELDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using EELDotNetCore.Shared;

namespace EELDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
       //private readonly DapperService _dapperService = 
           // new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        
        private readonly DapperService _dapperService;

        public BlogDapper2Controller(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        //Read
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_blog";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
            var lst = _dapperService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            //string query = "select * from Tbl_blog where blogid = @BlogID";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>(query, new BlogModel { BlogID = id }).FirstOrDefault();

            var item = FindById(id);

            if (item is null)
            {
                return NotFound("No data found.");
                
            }
            return Ok(item);

        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
		   ,@BlogAuthor
		   ,@BlogContent
		   )";

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Saving successful" : "Saving Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("No data found.");

            }
            blog.BlogID = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle
            ,[BlogAuthor] = @BlogAuthor
            ,[BlogContent] = @BlogContent
        WHERE BlogID = @BlogID
		   ";

           int result = _dapperService.Execute(query,blog);

            string message = result > 0 ? "Updating successful" : "Updating Fail";

            return Ok(message);

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("No data found.");

            }

            string conditions = string.Empty;
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }

            if(conditions.Length == 0)
            {
                return NotFound("No data to update");
            }
            conditions = conditions.Substring(0, conditions.Length - 2); 
            //(-2 for space and comma)
            blog.BlogID = id;

            string query = $@"UPDATE [dbo].[Tbl_Blog]
        SET {conditions}
        WHERE BlogID = @BlogID
		   ";
            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Updating successful" : "Updating Fail";

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("No data found.");

            }
            string query = @"DELETE from [dbo].[Tbl_Blog]
                             WHERE BlogID = @BlogID ";

            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Deleting successful" : "Deleting Fail";

            return Ok(message);
        }

        private BlogModel? FindById (int id)
        {
            string query = "select * from Tbl_blog where blogid = @BlogID";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>(query, new BlogModel { BlogID = id }).FirstOrDefault();

            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogID = id });
            return item;
        }
    }
}
