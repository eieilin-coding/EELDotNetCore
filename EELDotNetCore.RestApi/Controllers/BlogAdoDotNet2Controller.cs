using EELDotNetCore.RestApi.Models;
using EELDotNetCore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using static EELDotNetCore.Shared.AdoDotNetService;

namespace EELDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);

        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from Tbl_Blog where BlogID = @BlogID";

            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogID",id);
            //var lst = _adoDotNetService.Query<BlogModel>(query, parameters);

            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogID",id));

            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogID", id);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);

            //connection.Close();

            if (item is null)
            {
                return NotFound("No data found");
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

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle!),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor!),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent!)
                );

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

            int result = _adoDotNetService.Execute(query,
                   new AdoDotNetParameter("@BlogID", id),
                   new AdoDotNetParameter("@BlogTitle", blog.BlogTitle!),
                   new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor!),
                   new AdoDotNetParameter("@BlogContent", blog.BlogContent!)
                   );

            string message = result > 0 ? "Update successful" : "Update Fail";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult UpdatePatch(int id, BlogModel blog)
        {
            List<string> list = new List<string>();
            List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>
            {
                new AdoDotNetParameter("@BlogId", id)
            };

            if (blog.BlogTitle != null)
            {
                list.Add("[BlogTitle] = @BlogTitle");
                parameters.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));
            }
            if (blog.BlogAuthor != null)
            {
                list.Add("[BlogAuthor] = @BlogAuthor");
                parameters.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));
            }
            if (blog.BlogContent != null)
            {
                list.Add("[BlogContent] = @BlogContent");
                parameters.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            }

            if (!list.Any())
            {
                return BadRequest("No data to update.");
            }

            string item = string.Join(", ", list);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                      SET {item}
                      WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query, parameters.ToArray());

            string message = result > 0 ? "Updated Successfully!" : "Update failed!";
            return Ok(message);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogID = @BlogID
		   ";
           int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogID", id));

            string message = result > 0 ? "Deleting successful" : "Deleting Fail";
            return Ok(message); 
        }

    }
}
