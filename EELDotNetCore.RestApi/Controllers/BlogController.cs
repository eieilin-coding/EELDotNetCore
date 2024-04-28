using EELDotNetCore.RestApi.Db;
using EELDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EELDotNetCore.RestApi.Controllers
{
    //https://localhost:3000 => domain url
    //api/blog => endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]

        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blogs.SingleOrDefault(x=> x.BlogID == id);
            if (item is null)
            {
                return NotFound("No data Found.");
            }
            return Ok(item);
        }

        [HttpPost]

        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _context.Blogs.SingleOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                return NotFound("No data Found.");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _context.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Fail.";
            return Ok(message);
        }

        [HttpPatch]

        public IActionResult Patch()
        {
            return Ok("Patch");
        }

        [HttpDelete]

        public IActionResult Delete()
        {
            return Ok("Delete");
        }

    }
}
