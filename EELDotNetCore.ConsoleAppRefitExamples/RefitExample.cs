using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EELDotNetCore.ConsoleAppRefitExamples
{
    internal class RefitExample
    {
        private readonly IBlogApi _service = RestService.For<IBlogApi>("http://localhost:5179");
        public async Task RunAsync()
        {
            await ReadAsync();
        }
        private async Task ReadAsync()
        {
            var lst = await _service.GetBlogs();
            foreach (var blog in lst)
            {
                Console.WriteLine($"Id => {blog.BlogID}");
                Console.WriteLine($"Title => {blog.BlogTitle}");
                Console.WriteLine($"Author => {blog.BlogAuthor}");
                Console.WriteLine($"Content => {blog.BlogContent}");
                Console.WriteLine("---------------------------------");

            }
        }
    }
}
