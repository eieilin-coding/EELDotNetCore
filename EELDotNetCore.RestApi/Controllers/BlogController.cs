﻿using EELDotNetCore.RestApi.Db;
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

        public IActionResult Create()
        {
            return Ok("Create");
        }

        [HttpPut]

        public IActionResult Update()
        {
            return Ok("Update");
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
