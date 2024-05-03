using EELDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace EELDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        //Read
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_blog";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
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
        public IActionResult Post(BlogModel model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("No data found.");

            }
            string query = @"UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle
            ,[BlogAuthor] = @BlogAuthor
            ,[BlogContent] = @BlogContent
        WHERE BlogID = @BlogID
		   ";

            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Updating successful" : "Updating Fail";

            return Ok(message);

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            return Ok();
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
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogID = id }).FirstOrDefault();
            return item;
        }
    }
}
