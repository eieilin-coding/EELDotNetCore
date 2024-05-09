using EELDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace EELDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
          
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            //List<BlogModel> lst = new List<BlogModel>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    BlogModel blog = new BlogModel();
            //    blog.BlogID = Convert.ToInt32(dr["BlogID"]);
            //    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            //    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //    blog.BlogContent = Convert.ToString(dr["BlogContent"]);

            //    BlogModel blogModel = new BlogModel
            //    {
            //        BlogID = Convert.ToInt32(dr["BlogID"]),
            //        BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //        BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //        BlogContent = Convert.ToString(dr["BlogContent"])
            //    };
            //    lst.Add(blog);
            //}

            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogID = Convert.ToInt32(dr["BlogID"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            }).ToList();

            return Ok(lst);

        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from Tbl_Blog where BlogID = @BlogID";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                return NotFound("No data found");
            }
            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogID = Convert.ToInt32(dr["BlogID"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };
            return Ok(dt);
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

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
          
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Saving successful" : "Saving Fail";
            //return StatusCode(500, message);
            return Ok(message);



        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle
            ,[BlogAuthor] = @BlogAuthor
            ,[BlogContent] = @BlogContent
        WHERE BlogID = @BlogID
		   ";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Update successful" : "Update Fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePatch(int id, BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            List<string> list = new List<string>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                list.Add("[BlogTitle] = @BlogTitle");
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                list.Add("[BlogAuthor] = @BlogAuthor");
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                list.Add("[BlogContent] = @BlogContent");
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            }

            if (!list.Any())
            {
                return NotFound("No valid fields provided to update.");
            }

            string item = string.Join(", ", list);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                          SET {item}
                          WHERE BlogId = @BlogId";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Update Successfully!" : "No changes were made.";
            return Ok(message);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogID = @BlogID
		   ";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
           
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Deleting successful" : "Deleting Fail";
            return Ok(message); 
        }

    }
}
