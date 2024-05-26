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
            //await ReadAsync();
            await EditAsync(1);
            await EditAsync(100);
        }
        private async Task ReadAsync()
        {
            var lst = await _service.GetBlogs();
            foreach (var item in lst)
            {
                Console.WriteLine($"Id => {item.BlogID}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("---------------------------------");
            }
        }
        private async Task EditAsync(int id)
        {
            // Refit.ApiException: 'Response status code does not indicate success : 404 (not found).
            try
            {
                var item = await _service.GetBlog(id);
                Console.WriteLine($"Id => {item.BlogID}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("---------------------------------");
            }
            catch(ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
